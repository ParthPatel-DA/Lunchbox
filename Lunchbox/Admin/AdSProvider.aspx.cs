using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AdSProvider : System.Web.UI.Page
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
                rptSPprovider.Visible = true;
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
            var str = from obj in DC.tblServiceProviders
                      where obj.IsVerify == true
                      select new
                      {

                          CBy = (from ob in DC.tblAdmins
                                 where ob.AdminID == obj.VerifyBy
                                 select new
                                 {
                                     Data = ob.FirstName + " " + ob.LastName
                                 }).Take(1).SingleOrDefault().Data,
                          img = (from o1 in DC.tblImages
                                 where o1.ImagesID == obj.ImageID
                                 select new
                                 {
                                     str = o1.Name

                                 }).Take(1).SingleOrDefault().str,

                          str1 = obj.FirstName + " " + obj.LastName,
                          obj.FirstName,
                          obj.ServiceProviderID,
                          obj.LastName,
                          obj.Email,
                          obj.ContactNo,
                          obj.Veg_NonVeg,
                          obj.CompanyName,
                          obj.CreatedOn,
                          obj.IsActive
                      };
            DC.SubmitChanges();
            rptSPprovider.DataSource = str;
            rptSPprovider.DataBind();
            tblAdmin AdminData = DC.tblAdmins.Single(ob => ob.AdminID == Convert.ToInt32(Session["AdminID"]));
            if (AdminData.IsUpdate == false)
            {
                foreach (RepeaterItem item in rptSPprovider.Items)
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



    protected void rptSPprovider_ItemCommand1(object source, RepeaterCommandEventArgs e)
    {
        try {
            var DC = new DataClassesDataContext();

            int ID = Convert.ToInt32(e.CommandArgument);


            if (e.CommandName == "Active")
            {
                tblServiceProvider result = (from u in DC.tblServiceProviders
                                             where u.ServiceProviderID == ID
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
                //var Data = from obj in DC.tblServiceProviders
                //           where obj.ServiceProviderID == Convert.ToInt32(e.CommandArgument)
                //           select obj;
                //rptViewDetail.DataSource = Data;
                //rptViewDetail.DataBind();
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal({backdrop:'static', keyboard: false});", true);
                //    upModal.Update();
                //Response.Write(e.CommandArgument);
                var Data = from obj in DC.tblServiceProviders
                           where obj.ServiceProviderID == Convert.ToInt32(e.CommandArgument)
                           select new
                           {

                               CBy = (from ob in DC.tblAdmins
                                      where ob.AdminID == obj.VerifyBy
                                      select new
                                      {
                                          Data = ob.FirstName + " " + ob.LastName
                                      }).Take(1).SingleOrDefault().Data,

                               Add = (from obj1 in DC.tblAddresses
                                      where obj1.AddressID == obj.AddressID
                                      select new
                                      {
                                          Data = obj1.Address
                                      }).Take(1).SingleOrDefault().Data,
                               img = (from o1 in DC.tblImages
                                      where o1.ImagesID == obj.ImageID
                                      select new
                                      {
                                          str = o1.Name

                                      }).Take(1).SingleOrDefault().str,


                               str1 = obj.FirstName + " " + obj.LastName,
                               obj.FirstName,
                               obj.ServiceProviderID,
                               obj.LastName,
                               obj.Email,
                               obj.ContactNo,

                               obj.Veg_NonVeg,
                               obj.CompanyName,
                               obj.CreatedOn,
                               obj.IsActive
                           };
                rptViewDetail.DataSource = Data;
                rptViewDetail.DataBind();
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