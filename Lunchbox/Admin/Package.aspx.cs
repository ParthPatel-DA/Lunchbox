using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Package : System.Web.UI.Page
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
                BindData();
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

    private void BindData()
    {
        try {
            var DC = new DataClassesDataContext();
            var str = from obj in DC.tblPackages
                          //where obj.IsActive == true
                      select new
                      {

                          CBy = (from ob in DC.tblAdmins
                                 where ob.AdminID == obj.CreatedBy
                                 select new
                                 {
                                     Data = ob.FirstName + " " + ob.LastName
                                 }).Take(1).SingleOrDefault().Data,

                          img = (from obj1 in DC.tblImages
                                 where obj1.ImagesID == obj.ImageID
                                 select new
                                 {
                                     str1 = obj1.Name
                                 }).Take(1).SingleOrDefault().str1,
                          obj.PackagesID,
                          obj.Name,
                          obj.Duration,
                          obj.Description,
                          cv = Convert.ToDouble(obj.Price),
                          obj.CreatedOn,
                          obj.IsActive
                      };
            DC.SubmitChanges();
            rptadmin.DataSource = str;
            rptadmin.DataBind();

            tblAdmin AdminData = DC.tblAdmins.Single(ob => ob.AdminID == Convert.ToInt32(Session["AdminID"]));


            if (AdminData.IsUpdate == false)
            {
                foreach (RepeaterItem item in rptadmin.Items)
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





    protected void rptadmin_ItemCommand1(object source, RepeaterCommandEventArgs e)
    {
        try {
            var DC = new DataClassesDataContext();

            int ID = Convert.ToInt32(e.CommandArgument);


            if (e.CommandName == "Active")

            {
                tblPackage result = (from u in DC.tblPackages
                                     where u.PackagesID == ID
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
                BindData();
            }
            else if (e.CommandName == "View")
            {


                var str = from obj in DC.tblPackages
                          where obj.PackagesID == Convert.ToInt32(e.CommandArgument)
                          select new
                          {

                              CBy = (from ob in DC.tblAdmins
                                     where ob.AdminID == obj.CreatedBy
                                     select new
                                     {
                                         Data = ob.FirstName + " " + ob.LastName
                                     }).Take(1).SingleOrDefault().Data,

                              img = (from obj1 in DC.tblImages
                                     where obj1.ImagesID == obj.ImageID
                                     select new
                                     {
                                         str1 = obj1.Name
                                     }).Take(1).SingleOrDefault().str1,
                              obj.PackagesID,
                              obj.Name,
                              obj.Duration,
                              obj.Description,
                              cv = Convert.ToDouble(obj.Price),
                              obj.CreatedOn,
                              obj.IsActive
                          };
                rptViewDetail.DataSource = str;
                rptViewDetail.DataBind();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal({backdrop:'static', keyboard: false});", true);
                //    upModal.Update();
                BindData();

            }
            else if (e.CommandName == "Package")
            {

                LinkButton lnkRowSelection = (LinkButton)e.Item.FindControl("lnkRowSelection");
                string[] arguments = lnkRowSelection.CommandArgument.Split(';');
                string PackageID = arguments[0];
                Response.Redirect(string.Format("Addpackages.aspx?id={0}", PackageID), false);
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

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        try {
            ImageButton lnkRowSelection = (ImageButton)sender;
            string[] arguments = lnkRowSelection.CommandArgument.Split(';');
            string PackageID = arguments[0];
            string Name = arguments[1];
            string Duration = arguments[2];
            string Prices = arguments[3];
            string Description = arguments[4];
            string Image = arguments[5];

            Response.Redirect(string.Format("Addpackages.aspx?id={0}&Name={1}&Dura={2}&Prices={3}&desc={4}&Img={5}", PackageID, Name, Duration, Prices, Description, Image), false);
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
