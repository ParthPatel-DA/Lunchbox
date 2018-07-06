using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Feedback : System.Web.UI.Page
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

    private void clear()
    {
        try {
            txtemail.Text = string.Empty;
            txtdis.Text = string.Empty;
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }
    protected void btnfeedback_Click(object sender, EventArgs e)
    {
        try { 
        var dc = new DataClassesDataContext();
        var data = (from obj in dc.tblClients
                    where obj.Email == txtemail.Text
                    select obj).SingleOrDefault();
        var data1 = (from obj in dc.tblClients
                    where obj.Email == txtemail.Text
                    select obj).Count();
        if (data1 > 0)
        {
            tblFeedback ob = new tblFeedback();
            ob.Email = txtemail.Text;
            ob.ClientID = Convert.ToInt32(data.ClientID);
            ob.Description = txtdis.Text;
            ob.IsNotify = true;
            ob.CreatedOn = DateTime.Now;
            dc.tblFeedbacks.InsertOnSubmit(ob);
            dc.SubmitChanges();
        }
        else
        {
            errorCode.Visible = true;
        }
        clear();

        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }
}