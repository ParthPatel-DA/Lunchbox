using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net.NetworkInformation;

public partial class Package : System.Web.UI.Page
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
        //if (Session["ServiceProviderID"] == null)
        //{
        //    if (Session["ClientID"] != null)
        //    {
        //        Response.Redirect("Default.aspx");
        //    }
        //    else
        //    {
        //        Response.Redirect("ServiceLogin.aspx");
        //    }
        //}
        
        if (!IsPostBack)
        {

            BindData();
        }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["ServiceProviderID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    private void BindData()
    {
        try { 
        var DC = new DataClassesDataContext();
        var str = from obj in DC.tblPackages
                  where obj.IsActive == true
                  select new
                  {

                      obj.Name,
                      obj.Description,
                      obj.Duration,
                      obj.Price,
                      obj.IsActive,
                      obj.PackagesID,
                      img = (from o1 in DC.tblImages
                             where o1.ImagesID == obj.ImageID
                             select new
                             {
                                 str = o1.Name
                             }).Take(1).SingleOrDefault().str,

                  };
        DC.SubmitChanges();
        rptpack.DataSource = str;
        rptpack.DataBind();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["ServiceProviderID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }




    protected void rptpack_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try { 
        var DC = new DataClassesDataContext();
        if (e.CommandName == "Buy")
        {
            tblPackage Pack = DC.tblPackages.Single(ob => ob.PackagesID == Convert.ToInt32(e.CommandArgument));
            tblSPPackage SPPackData = new tblSPPackage();
            SPPackData.ServiceProviderID = Convert.ToInt32(Session["ServiceProviderID"]);
            SPPackData.PackagesId = Convert.ToInt32(e.CommandArgument);
            SPPackData.IsActive = false;
            SPPackData.Start_Date = DateTime.Now;
            SPPackData.End_Date = DateTime.Now.AddDays(Convert.ToInt32(Pack.Duration));
            DC.tblSPPackages.InsertOnSubmit(SPPackData);
            DC.SubmitChanges();
            Double Price = (from obj in DC.tblPackages
                            where obj.PackagesID == Convert.ToInt32(e.CommandArgument)
                            select obj.Price).Single();
            var SPData = DC.tblServiceProviders.Single(ob => ob.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"]));
            Session["Amount"] = Convert.ToInt32(Price);
            Session["FirstName"] = SPData.FirstName + " " + SPData.LastName;
            Session["Email"] = SPData.Email;
            Session["PhoneNo"] = SPData.ContactNo;
            Session["ProductInfo"] = "Lunch Box Package Payment";
            Session["SuccessURL"] = "http://localhost:58118/Success.aspx";
            Session["FailureURL"] = "http://localhost:58118/Success.aspx";
            Response.Redirect("PayU/Default.aspx");
        }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["ServiceProviderID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }
}