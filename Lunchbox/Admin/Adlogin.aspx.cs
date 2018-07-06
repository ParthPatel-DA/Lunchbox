using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Net.NetworkInformation;

public partial class Admin_Adlogin : System.Web.UI.Page
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
    private string Encryptdata(string password)
    {
        string strmsg = string.Empty;
        byte[] encode = new byte[password.Length];
        encode = Encoding.UTF8.GetBytes(password);

        strmsg = Convert.ToBase64String(encode);

        return strmsg;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Panel2.Visible = false;
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        try {
            string mail = txtmail.Text;
            string pass = txtpass.Text;

            var dc = new DataClassesDataContext();
            var st = (from ob in dc.tblAdmins
                      where (ob.Email == mail && ob.Password == Encryptdata(pass))
                      select ob).Count();

            var st1 = (from ob in dc.tblAdmins
                       where (ob.Email == mail && ob.Password == Encryptdata(pass))
                       select ob).FirstOrDefault();

            if (st > 0)
            {
                //ScriptManager.RegisterStartupScript(Page, GetType(), "Store_Data", "<script>Store_Data()</script>", false);
                Session["AdminID"] = st1.AdminID;
                var dc1 = new DataClassesDataContext();
                tblAction objAction = new tblAction();
                string currentPageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
                objAction.PageName = currentPageName;
                objAction.WebAction = "Insert";
                objAction.CreatedOn = DateTime.Now;
                objAction.MacAddress = GetMACAddress();
                objAction.UserType = "Admin";
                objAction.UserID = Convert.ToInt32(Session["AdminID"].ToString());
                dc1.tblActions.InsertOnSubmit(objAction);
                dc1.SubmitChanges();
                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                mailer.Visible = true;
                palLogin.Visible = true;

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

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try {
            palLogin.Visible = false;
            Panel2.Visible = true;
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

    protected void Button2_Click(object sender, EventArgs e)
    {
        try {

            string mail = TextBox1.Text;
            var dc = new DataClassesDataContext();
            var check = (from user in dc.tblAdmins
                         where user.Email == TextBox1.Text
                         select user.AdminID).Count();
            var st1 = (from user in dc.tblAdmins
                       where user.Email == TextBox1.Text
                       select user).FirstOrDefault();

            if (check > 0)
            {
                Panel6.Visible = true;
                string vc;

                DateTime now = DateTime.Now;
                vc = now.ToString();
                vc = vc.GetHashCode().ToString().Trim('-');
                MailMessage Msg = new MailMessage("lunchboxindia2017@gmail.com", TextBox1.Text);
                Msg.Subject = "Email Verification";
                Msg.Body = "<html><head></head><body><table><tr><td>Your E-Mail :</td><td>" + TextBox1.Text + "</td></tr><tr><td>Your Code :</td><td>" + vc + "</td></tr></table></body></html>";
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
                Panel2.Visible = true;
                Panel6.Visible = true;
                Session["VCode"] = vc;
                //Label1.Text = Session["VCode"].ToString();
                Button2.Visible = false;
            }
            else
            {
                TextBox1.Text = "";
                mailer.Visible = true;
                Panel2.Visible = true;

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



    protected void cheking_Click(object sender, EventArgs e)
    {
        try {
            Panel2.Visible = true;
            Panel6.Visible = true;
            if (Session["VCode"].ToString() == TextBox2.Text)
            {
                Panel2.Visible = false;
                Panel8.Visible = true;
                //Response.Write("ok");

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

    protected void btnsub_Click(object sender, EventArgs e)
    {
        try {
            if (txtrpass.Text == txtrepass.Text)
            {
                var dc = new DataClassesDataContext();
                var check = (from user in dc.tblAdmins
                             where user.Email == TextBox1.Text
                             select user.AdminID).Count();
                var st1 = (from user in dc.tblAdmins
                           where user.Email == TextBox1.Text
                           select user).FirstOrDefault();

                if (check > 0)
                {
                    Session["AdminID"] = st1.AdminID;
                    tblAdmin result = (from u in dc.tblAdmins
                                       where u.AdminID == Convert.ToInt32(Session["AdminID"].ToString())
                                       select u).Single();
                    result.Password = Encryptdata(txtrpass.Text);
                    dc.SubmitChanges();



                    Response.Redirect("Adlogin.aspx");

                }
            }
            else
            {
                lblerrorPwd.Visible = true;
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
    public string GetMACAddress()
    {
        NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
        String sMacAddress = string.Empty;
        foreach (NetworkInterface adapter in nics)
        {
            if (sMacAddress == String.Empty)// only return MAC Address from first card  
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();
                sMacAddress = adapter.GetPhysicalAddress().ToString();
            }
        }
        return sMacAddress;

    }

}
