using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_CMSPage : System.Web.UI.Page
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
            var strCMSFillDD = from obj in DC.tblCMs where obj.IsActive == true select obj;
            ddCMSList.DataSource = strCMSFillDD;
            ddCMSList.DataValueField = "CMSID";
            ddCMSList.DataTextField = "Title";
            ddCMSList.DataBind();
            ddCMSList.Items.Insert(0, new ListItem("Select CMS Page", ""));
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

    protected void ddCMSList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try {
            Panel1.Visible = false;
            btnSaveCMS.Visible = false;
            btnEditCMS.Visible = true;
            txtTitle.Text = ddCMSList.SelectedItem.Text;
            var DC = new DataClassesDataContext();
            var strCMSFillDD = (from obj in DC.tblCMs where obj.CMSID == Convert.ToInt32(ddCMSList.SelectedValue) select obj).SingleOrDefault();
            DC.SubmitChanges();
            txtCkEditor.Text = strCMSFillDD.Content;
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

    protected void txtTitle_TextChanged(object sender, EventArgs e)
    {
        try {
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

    protected void btnSaveCMS_Click(object sender, EventArgs e)
    {
        try {
            var DC = new DataClassesDataContext();
            tblCM tblCMS = new tblCM();
            tblCMS.Title = txtTitle.Text;
            tblCMS.Content = txtCkEditor.Text;
            //tblCMS.CreatedBY = 101;
            //tblCMS.CreatedOn = DateTime.Now;
            tblCMS.IsActive = true;
            DC.tblCMs.InsertOnSubmit(tblCMS);
            DC.SubmitChanges();
            Response.Redirect("CMSPage.aspx");
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

    protected void btnEditCMS_Click(object sender, EventArgs e)
    {
        try {
            var DC = new DataClassesDataContext();
            tblCM strEditCMS = (from obj in DC.tblCMs
                                where obj.CMSID == Convert.ToInt32(ddCMSList.SelectedValue)
                                select obj).Single();
            strEditCMS.Title = txtTitle.Text;
            strEditCMS.Content = txtCkEditor.Text;
            //strEditCMS.ModifyOn = DateTime.Now;
            DC.SubmitChanges();
            Response.Redirect("CMSPage.aspx");
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