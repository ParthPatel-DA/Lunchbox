using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net.NetworkInformation;

public partial class Admin_ServicePackage : System.Web.UI.Page
{
    public static string GetMacAddress()
    {
        foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
        {
            // Only consider Ethernet network interfaces
            if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
            {
                return nic.GetPhysicalAddress().ToString();
            }
        }
        return null;
    }
    public void AddErrorLog(ref Exception strException, string PageName, string UserType, int UserID, int AdminID, string MACAddress = null)
    {
        var DC = new DataClassesDataContext();
        //Insert record in ErrorLog
        tblError objError = new tblError();
        objError.PageName = PageName;
        objError.Description = strException.Message.ToString();
        objError.CreatedOn = Convert.ToDateTime(System.DateTime.Now);
        objError.UserType = UserType;
        if (UserID != 0)
        {
            objError.UserID = UserID;
        }
        else
        {
            objError.UserID = null;
        }
        if (AdminID != 0)
        {
            objError.AdminID = AdminID;
        }
        else
        {
            objError.AdminID = null;
        }
        if (MACAddress != null)
        {
            objError.MacAddress = MACAddress;
        }
        else
        {
            objError.MacAddress = null;
        }
        DC.tblErrors.InsertOnSubmit(objError);
        DC.SubmitChanges();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try {
            if (Session["AdminID"] == null)
            {
                Response.Redirect("Adlogin.aspx");
            }
            if (!IsPostBack)
            {
                bindata();
            }




            var DC = new DataClassesDataContext();
            tblAdmin result = (from u in DC.tblAdmins
                               where u.AdminID == Convert.ToInt32(Session["AdminID"])
                               select u).Single();
            if (result.IsSuper == false)
            {
                rptSP.Visible = false;
            }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["AdminID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Admin", 0, session, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    private void bindata()
    {
        try {
            var DC = new DataClassesDataContext();
            var str = from obj in DC.tblSPPackages
                          //where obj.IsActive == true
                      select new
                      {
                          img = (from ob in DC.tblPackages
                                 where ob.PackagesID == obj.PackagesId
                                 select new
                                 {
                                     Data = (from o1 in DC.tblImages
                                             where o1.ImagesID == ob.ImageID
                                             select new
                                             {
                                                 str = o1.Name

                                             }).Take(1).SingleOrDefault().str,
                                 }).Take(1).SingleOrDefault().Data,

                          CBy = (from ob in DC.tblAdmins
                                 where ob.AdminID == obj.CreatedBy
                                 select new
                                 {
                                     Data = ob.FirstName + " " + ob.LastName
                                 }).Take(1).SingleOrDefault().Data,

                          SPN = (from ob in DC.tblServiceProviders
                                 where ob.ServiceProviderID == obj.ServiceProviderID
                                 select new
                                 {
                                     Data = ob.FirstName + " " + ob.LastName
                                 }).Take(1).SingleOrDefault().Data,
                          PN = (from ob in DC.tblPackages
                                where ob.PackagesID == obj.PackagesId
                                select new
                                {
                                    Data = ob.Name
                                }).Take(1).SingleOrDefault().Data,
                          //obj.Image,
                          obj.SPPackagesID,
                          obj.Start_Date,
                          obj.End_Date,
                          obj.CreatedBy,
                          obj.IsActive,

                      };
            DC.SubmitChanges();
            rptSP.DataSource = str;
            rptSP.DataBind();
            tblAdmin AdminData = DC.tblAdmins.Single(ob => ob.AdminID == Convert.ToInt32(Session["AdminID"]));
            if (AdminData.IsUpdate == false)
            {
                foreach (RepeaterItem item in rptSP.Items)
                {
                    PlaceHolder PlaceHolderActive = (PlaceHolder)item.FindControl("PlaceHolderActive");
                    PlaceHolderActive.Visible = false;
                }
                PlaceHolderActiveHeader.Visible = false;
            }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["AdminID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Admin", 0, session, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void rptSP_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try {
            var DC = new DataClassesDataContext();

            int ID = Convert.ToInt32(e.CommandArgument);


            if (e.CommandName == "Active")
            {
                tblSPPackage result = (from u in DC.tblSPPackages
                                       where u.SPPackagesID == ID
                                       select u).Single();

                if (result.IsActive == true)
                {
                    result.IsActive = false;
                }
                else
                {
                    result.IsActive = true;
                }
                DC.SubmitChanges();

            }
            else if (e.CommandName == "View")
            {

                int ED = 0;
                int SD = 0;
                var str = from obj in DC.tblSPPackages
                              //where obj.IsActive == true
                          where obj.SPPackagesID == Convert.ToInt32(e.CommandArgument)
                          select new
                          {
                              img = (from ob in DC.tblPackages
                                     where ob.PackagesID == obj.PackagesId
                                     select new
                                     {
                                         Data = (from o1 in DC.tblImages
                                                 where o1.ImagesID == ob.ImageID
                                                 select new
                                                 {
                                                     str = o1.Name

                                                 }).Take(1).SingleOrDefault().str,
                                     }).Take(1).SingleOrDefault().Data,

                              CBy = (from ob in DC.tblAdmins
                                     where ob.AdminID == obj.CreatedBy
                                     select new
                                     {
                                         Data = ob.FirstName + " " + ob.LastName
                                     }).Take(1).SingleOrDefault().Data,
                              PN = (from ob in DC.tblPackages
                                    where ob.PackagesID == obj.PackagesId
                                    select new
                                    {
                                        Data = ob.Name
                                    }).Take(1).SingleOrDefault().Data,
                              price = (from ob in DC.tblPackages
                                       where ob.PackagesID == obj.PackagesId
                                       select new
                                       {
                                           Data = ob.Price
                                       }).Take(1).SingleOrDefault().Data,
                              Du = (from ob in DC.tblPackages
                                    where ob.PackagesID == obj.PackagesId
                                    select new
                                    {
                                        Data = ob.Duration
                                    }).Take(1).SingleOrDefault().Data,

                              Des = (from ob in DC.tblPackages
                                     where ob.PackagesID == obj.PackagesId
                                     select new
                                     {
                                         Data = ob.Description
                                     }).Take(1).SingleOrDefault().Data,
                              //Da = (from ob in DC.tblSPPackages
                              //      where ob.SPPackagesID == obj.SPPackagesID
                              //      select new
                              //      {

                              //          //SD = Convert.ToDateTime(ob.Start_Date).Day,
                              //          //ED = Convert.ToDateTime(ob.End_Date).Day,
                              //          //da = (Convert.ToDateTime(ob.End_Date) - Convert.ToDateTime(ob.Start_Date)),


                              //          //SD = DateTime.MinValue,
                              //          //ED = DateTime.MaxValue,
                              //          // da = SD - ED ;


                              //       }).Take(1).SingleOrDefault().da,
                              //obj.Image,
                              obj.SPPackagesID,
                              obj.Start_Date,
                              obj.End_Date,
                              obj.CreatedBy,
                              obj.IsActive
                          };
                rptViewDetail.DataSource = str;
                rptViewDetail.DataBind();
                foreach (RepeaterItem item in rptViewDetail.Items)
                {
                    HiddenField Start_Date = (HiddenField)item.FindControl("h1");
                    HiddenField End_Date = (HiddenField)item.FindControl("h2");
                    Label da = (Label)item.FindControl("lblday");
                    TimeSpan day = Convert.ToDateTime(End_Date.Value) - Convert.ToDateTime(Start_Date.Value);
                    da.Text = day.TotalDays.ToString() + "Days";
                }
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal({backdrop:'static', keyboard: false});", true);
                //    upModal.Update();

            }
            bindata();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["AdminID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "Admin", 0, session, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }
}
