using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ServiceLogin : System.Web.UI.Page
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


    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {

        try
        {
            Session.Clear();
            string mail = txtSpmail.Text;
            string pass = txtsppwd.Text;

            var dc = new DataClassesDataContext();
            var ser = (from ob in dc.tblServiceProviders
                       where ob.Email == mail && (ob.IsVerify == null || ob.IsVerify == false)
                       select ob).Count();
            var cli = (from ob in dc.tblClients
                       where ob.Email == mail && ob.IsActive == false
                       select ob).Count();
            string check;
            if (ser > 0)
            {
                int verifycode = Convert.ToInt32((from obj in dc.tblServiceProviders
                                                  where obj.Email == mail && (obj.IsVerify == null || obj.IsVerify == false)
                                                  select obj.VerifyCode).Single());
                Session["VCode"] = verifycode;
                Session["check"] = "notvarify";


            }
            else if (cli > 0)
            {
                string vc;

                DateTime now = DateTime.Now;
                vc = now.ToString();
                vc = vc.GetHashCode().ToString().Trim('-');
                MailMessage Msg = new MailMessage("lunchboxindia2017@gmail.com", txtSpmail.Text);
                Msg.Subject = "Email Verification";
                Msg.Body = "<html><head></head><body><table><tr><td>Your E-Mail :</td><td>" + txtSpmail.Text + "</td></tr><tr><td>Your Code :</td><td>" + vc + "</td></tr></table></body></html>";
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
                // Panel6.Visible = true;
                Session["VCode"] = vc;


            }
            else
            {
                Session["VCode"] = "";
                Session["check"] = "";

            }
            if (Session["VCode"].ToString() != "" || Session["check"].ToString() == "notvarify")
            {
                panel5.Visible = true;
                // panel5.Visible = true;
                Panel1.Visible = false;
                Panel2.Visible = true;
            }
            else
            {
                var st = (from ob in dc.tblServiceProviders
                          where (ob.Email == mail && ob.Password == pass)
                          select ob).Count();
                var st1 = (from ob in dc.tblServiceProviders
                           where (ob.Email == mail && ob.Password == pass)
                           select ob).FirstOrDefault();
                var cl = (from ob in dc.tblClients
                          where (ob.Email == mail && ob.Password == pass)
                          select ob).Count();
                var cl1 = (from ob in dc.tblClients
                           where (ob.Email == mail && ob.Password == pass)
                           select ob).FirstOrDefault();

                if (st > 0)
                {

                    Session["ServiceProviderID"] = st1.ServiceProviderID;
                    Session["ViewServiceProviderID"] = null;
                    Response.Redirect("Profile_SP.aspx");
                }
                else if (cl > 0)
                {
                    Session["ClientID"] = cl1.ClientID;
                    if (Session["FromOrder"] != null)
                    {
                        Session["FromOrder"] = null;
                        Response.Redirect("OrderDetail.aspx");
                    }
                    else
                    {
                        Response.Redirect("Default.aspx");
                    }


                }
                else
                {
                    errorLogin.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", 0, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }



    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
            panel4.Visible = true;
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", 0, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            Panel2.Visible = true;
            Panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = true;
            string vc;
            DateTime now = DateTime.Now;
            vc = now.ToString();
            vc = vc.GetHashCode().ToString().Trim('-');
            MailMessage Msg = new MailMessage("lunchboxindia2017@gmail.com", txteid.Text);
            Msg.Subject = "Email Verification";
            Msg.Body = "<html><head></head><body><table><tr><td>Your E-Mail :</td><td>" + txteid.Text + "</td></tr><tr><td>Your Code :</td><td>" + vc + "</td></tr></table></body></html>";
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
            // Panel6.Visible = true;
            Session["VCode"] = vc;
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", 0, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void cheking_Click(object sender, EventArgs e)
    {
        try
        {
            // Panel2.Visible = false;

            /// Panel6.Visible = true;
            if (Session["VCode"].ToString() == txtcodd.Text)
            {

                panel5.Visible = true;
                //panel5.Visible = false;
                Panel2.Visible = false;
                Panel3.Visible = true;

                var DC = new DataClassesDataContext();
                int cntClient = (from obj in DC.tblClients
                                 where obj.Email == txtSpmail.Text && obj.IsActive == false
                                 select obj).Count();
                int cntSP = (from obj in DC.tblServiceProviders
                             where obj.Email == txtSpmail.Text && (obj.IsVerify == null || obj.IsVerify == false)
                             select obj).Count();
                if (cntClient > 0)
                {
                    tblClient ClientData = (from obj in DC.tblClients
                                            where obj.Email == txtSpmail.Text && obj.IsActive == false
                                            select obj).Single();
                    ClientData.IsActive = true;
                    DC.SubmitChanges();
                    Session["ClientID"] = ClientData.ClientID;
                    if (Session["FromOrder"] != null)
                    {
                        Session["FromOrder"] = null;
                        Response.Redirect("OrderDetail.aspx");
                    }
                    else
                    {
                        Response.Redirect("Default.aspx");
                    }
                }
                else if (cntSP > 0)
                {
                    tblServiceProvider SPData = (from obj in DC.tblServiceProviders
                                                 where obj.Email == txtSpmail.Text && (obj.IsVerify == null || obj.IsVerify == false)
                                                 select obj).Single();
                    SPData.IsVerify = true;
                    DC.SubmitChanges();
                    Session["ServiceProviderID"] = SPData.ServiceProviderID;
                    Response.Redirect("Profile_SP.aspx");
                }

            }
            else
            {
                errorCode.Visible = true;

            }
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", 0, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }




    protected void btnsub_Click(object sender, EventArgs e)
    {
        try
        {
            var dc = new DataClassesDataContext();
            var check = (from user in dc.tblServiceProviders
                         where user.Email == txteid.Text
                         select user.ServiceProviderID).Count();
            var st1 = (from user in dc.tblServiceProviders
                       where user.Email == txteid.Text
                       select user).FirstOrDefault();
            var check1 = (from ob in dc.tblClients
                          where ob.Email == txteid.Text
                          select ob.ClientID).Count();
            var cl1 = (from ob in dc.tblClients
                       where ob.Email == txteid.Text
                       select ob).FirstOrDefault();


            if (check > 0)
            {
                Session["ServiceProviderID"] = st1.ServiceProviderID;
                tblServiceProvider result = (from u in dc.tblServiceProviders
                                             where u.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"].ToString())
                                             select u).Single();
                result.Password = txtnepass.Text;
                dc.SubmitChanges();
                Response.Redirect("ServiceLogin.aspx");

            }
            else if (check1 > 0)
            {
                Session["CheID"] = cl1.ClientID;
                tblClient result = (from u in dc.tblClients
                                    where u.ClientID == Convert.ToInt32(Session["CheID"].ToString())
                                    select u).Single();
                result.Password = txtnepass.Text;
                dc.SubmitChanges();
                Response.Redirect("ServiceLogin.aspx");
            }
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", 0, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void btnclient_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("ClientForm.aspx");
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", 0, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void btnserviceprovider_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("SPform.aspx");
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", 0, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }
}
