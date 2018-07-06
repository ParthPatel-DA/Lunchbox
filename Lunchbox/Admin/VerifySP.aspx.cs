using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Net.NetworkInformation;

public partial class Admin_VerifyEmployee : System.Web.UI.Page
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
                BindVerifyEmployee();
            }
            var DC = new DataClassesDataContext();
            tblAdmin AdminData = DC.tblAdmins.Single(ob => ob.AdminID == Convert.ToInt32(Session["AdminID"]));
            if (AdminData.IsUpdate == false)
            {
                divPage.Visible = false;
                divError.Visible = true;
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

    private void BindVerifyEmployee()
    {
        try {
            var DC = new DataClassesDataContext();
            IQueryable<tblServiceProvider> Employee = (from ob in DC.tblServiceProviders
                                                       where (ob.IsVerify == false || ob.IsVerify == null) && (ob.IsVerifyByAdmin == false || ob.IsVerifyByAdmin == null)
                                                       select ob);
            rptVerifyEmployee.DataSource = Employee;
            rptVerifyEmployee.DataBind();
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

    protected void rptVerifyEmployee_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try {
            var DC = new DataClassesDataContext();
            if (e.CommandName == "Email")
            {
                tblServiceProvider EmpVerify = (from obj in DC.tblServiceProviders
                                                where obj.ServiceProviderID == Convert.ToInt32(e.CommandArgument)
                                                select obj).Single();
                string vc;
                DateTime now = DateTime.Now;
                vc = now.ToString();
                vc = vc.GetHashCode().ToString().Trim('-');
                MailMessage Msg = new MailMessage("lunchboxindia2017@gmail.com", EmpVerify.Email);
                Msg.Subject = "Email Verification";
                Msg.Body = "<html><head></head><body><table><tr><td>Your E-Mail :</td><td>" + EmpVerify.Email + "</td></tr><tr><td>Your Code :</td><td>" + vc + "</td></tr></table></body></html>";
                Msg.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                NetworkCredential MyCredentials = new NetworkCredential("lunchboxindia2017@gmail.com", "lunchbox2017");
                smtp.Credentials = MyCredentials;
                smtp.Send(Msg);

                EmpVerify.VerifyCode = vc;
                EmpVerify.IsVerifyByAdmin = true;
                DC.SubmitChanges();
            }
            BindVerifyEmployee();
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