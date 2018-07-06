using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Net.NetworkInformation;

public partial class Admin_ChangePwd : System.Web.UI.Page
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
        if(Session["AdminID"] == null)
        {
            Response.Redirect("Adlogin.aspx");
        }

    }

    protected void btnChPwd_Click(object sender, EventArgs e)
    {
        try {
            if ((txtPwd.Text) == (txtRPwd.Text))
            {

                var DC = new DataClassesDataContext();
                int ID = Convert.ToInt32(Session["AdminID"]);
                int count = (from u in DC.tblAdmins
                             where u.AdminID == ID && u.Password == Encryptdata(txtCPwd.Text)
                             select u).Count();
                if (count > 0)
                {
                    tblAdmin result1 = (from u in DC.tblAdmins
                                        where u.AdminID == ID && u.Password == Encryptdata(txtCPwd.Text)
                                        select u).Single();
                    result1.Password = (Encryptdata(txtPwd.Text));
                    DC.SubmitChanges();
                    Response.Redirect("empgrid.aspx");


                }
                else
                {
                    pnlError.Visible = true;
                }
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
}