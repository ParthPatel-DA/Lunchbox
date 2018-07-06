using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Net.NetworkInformation;

public partial class Admin_ReplyInquiry : System.Web.UI.Page
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
            var DC = new DataClassesDataContext();
            tblAdmin AdminData = DC.tblAdmins.Single(ob => ob.AdminID == Convert.ToInt32(Session["AdminID"]));
            if (AdminData.IsUpdate == false || AdminData.IsInsert == false)
            {
                divPage.Visible = false;
                divError.Visible = true;
            }
            if (!IsPostBack)
            {
                BindData();
            }
            tblAdmin result = (from u in DC.tblAdmins
                               where u.AdminID == Convert.ToInt32(Session["AdminID"])
                               select u).Single();
            if (result.IsSuper == false)
            {
                //rptAdmin.Visible = false;
                //Panel1.Visible = false;
                //Literal1.Visible = true;
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
            var result = (from u in DC.tblInquiries
                          select u);
            var id = Request.QueryString["id"];
            var mail = Request.QueryString["mail"];
            var cno = Request.QueryString["cno"];
            var sub = Request.QueryString["sub"];
            txtmail.Text = mail;
            lblcon.Text = cno;
            txtsub.Text = sub;
            //ddlsub.DataSource = result;
            //ddlsub.DataTextField = "Discription";
            //ddlsub.DataValueField = "InquiryID";
            //ddlsub.DataBind();
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
    protected void SendMail()
    {
        try {
            MailMessage Msg = new MailMessage("lunchboxindia2017@gmail.com", txtmail.Text);
            Msg.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            Msg.Subject = txtsub.Text;
            Msg.Body = txtmsg.Text;
            Msg.IsBodyHtml = true;

            NetworkCredential MyCredentials = new NetworkCredential("lunchboxindia2017@gmail.com", "lunchbox2017");
            smtp.Credentials = MyCredentials;
            smtp.Send(Msg);

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



    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try {
            SendMail();
            lblcon.Text = "";
            txtmail.Text = "";
            txtsub.Text = "";
            txtmsg.Text = "";

            var DC = new DataClassesDataContext();
            var data = (from ob in DC.tblInquiries
                        where ob.Email == Request.QueryString["mail"]
                        select ob).Single();
            data.IsNotify = true;
            DC.SubmitChanges();
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

    protected void btnreset_Click(object sender, EventArgs e)
    {

    }

    protected void ddlsub_SelectedIndexChanged(object sender, EventArgs e)
    {
    //    var DC = new DataClassesDataContext();
    //    var result1 = (from u in DC.tblInquiries
    //                  where u.InquiryID ==  Convert.ToInt32(ddlsub.Text)
    //                  select u).SingleOrDefault();
    //    lblcon.Text = result1.ContactNO;
    //    txtmail.Text = result1.Email;
    //    txtsub.Text = result1.Discription;
       
        
        

    }
}