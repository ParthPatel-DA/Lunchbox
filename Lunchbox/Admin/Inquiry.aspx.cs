using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Net.NetworkInformation;

public partial class Admin_Inquiry : System.Web.UI.Page
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
                rptin.Visible = false;
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
            var str = from obj in DC.tblInquiries
                          //where obj.IsNotify == true
                      select new
                      {


                          obj.ContactNO,
                          obj.Email,
                          obj.InquiryID,
                          obj.IsNotify,
                          obj.Discription,
                          obj.Createdon,

                      };
            DC.SubmitChanges();
            rptin.DataSource = str;
            rptin.DataBind();
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

    protected void rptin_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try {
            var DC = new DataClassesDataContext();


            if (e.CommandName == "Notify")
            {
                tblInquiry result = (from u in DC.tblInquiries
                                     where u.InquiryID == Convert.ToInt32(e.CommandArgument)
                                     select u).Single();

                if (result.IsNotify == false)
                {
                    //Session["InquiryID"] = result.InquiryID;
                    //Response.Redirect("ReplyInquiry.aspx");
                }
                else
                {
                    result.IsNotify = false;
                }
                DC.SubmitChanges();
            }

            binddata();
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




    protected void lnkbtnName_Click(object sender, EventArgs e)
    {
        try {
            LinkButton lnkRowSelection = (LinkButton)sender;
            string[] arguments = lnkRowSelection.CommandArgument.Split(';');
            string InquiryID = arguments[0];
            string Email = arguments[1];
            string ContactNO = arguments[2];
            string Subject = arguments[3];

            // pass emp_id, days_worked, total_absents, and days_marked to another page via query string

            Response.Redirect(string.Format("ReplyInquiry.aspx?id={0}&mail={1}&cno={2}&sub={3}", InquiryID, Email, ContactNO, Subject), false);
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