using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Log : System.Web.UI.Page
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
                binddata();
            }
            var DC = new DataClassesDataContext();
            tblAdmin result = (from u in DC.tblAdmins
                               where u.AdminID == Convert.ToInt32(Session["AdminID"])
                               select u).Single();
            if (result.IsSuper == false)
            {
                rptlog.Visible = false;
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

    private void binddata()
    {
        try {
            var DC = new DataClassesDataContext();
            var str = from obj in DC.tbllogs

                      select new
                      {

                          //CBy = (from ob in DC.tblAdmins
                          //       where ob.AdminID == obj.CreatedBy
                          //       select new
                          //       {
                          //           Data = ob.FirstName + " " + ob.LastName
                          //       }).Take(1).SingleOrDefault().Data,
                          obj.LogID,
                          obj.UserLogID,
                          obj.LoginTime,
                          obj.LogoutTime,
                          obj.MacAddress


                      };
            DC.SubmitChanges();
            rptlog.DataSource = str;
            rptlog.DataBind();
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

   
