using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Net.NetworkInformation;

public partial class Admin_Default2 : System.Web.UI.Page
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
            tblAdmin AdminData = DC.tblAdmins.Single(ob => ob.AdminID == Convert.ToInt32(Session["AdminID"]));
            if (AdminData.IsInsert == false)
            {
                divPage.Visible = false;
                divError.Visible = true;
            }

            tblAdmin result = (from u in DC.tblAdmins
                               where u.AdminID == Convert.ToInt32(Session["AdminID"])
                               select u).Single();
            if (result.IsSuper == false)
            {
                pnlsup.Visible = false;
            }

            //if (Request.QueryString["AdminID"] != "" || Request.QueryString["AdminID"].ToString() != null)
            //{
            //    int AdminID = Convert.ToInt32(Request.QueryString["AdminID"]);

            //}
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
    private void clear1()
    {
        try {
            txtfnm.Text = string.Empty;
            txtlnm.Text = string.Empty;
            txtmail.Text = string.Empty;
            txtcno.Text = string.Empty;

            CheckBox1.Checked = false;
            CheckBox2.Checked = false;
            CheckBox3.Checked = false;
            CheckBox4.Checked = false;
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
            var dc = new DataClassesDataContext();
            var stud = from ob in dc.tblAdmins select ob;
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
            var dc = new DataClassesDataContext();
            if (FileUpload1.HasFile)
            {
                var path = Server.MapPath("~/Admin/Upload");
                FileUpload1.SaveAs(path + "/" + FileUpload1.FileName);
                tblImage objimg = new tblImage();
                objimg.Name = FileUpload1.FileName;
                objimg.AlbumID = 1;
                objimg.IsActive = true;
                objimg.IsDefault = false;
                objimg.CreatedOn = DateTime.Now;
                dc.tblImages.InsertOnSubmit(objimg);
                dc.SubmitChanges();


            }
            var img = (from im in dc.tblImages
                       orderby im.ImagesID descending
                       select im).FirstOrDefault();
            tblAdmin objAd = new tblAdmin();
            objAd.FirstName = txtfnm.Text;
            objAd.LastName = txtlnm.Text;
            objAd.Email = txtmail.Text;
            objAd.Password = Encryptdata(txtpass.Text);
            objAd.ContactNO = txtcno.Text;
            objAd.ImageID = Convert.ToInt32(img.ImagesID);
            //objAd.Image = FileUpload1.FileName;
            objAd.IsInsert = CheckBox1.Checked;
            objAd.IsUpdate = CheckBox2.Checked;
            objAd.IsDelete = CheckBox3.Checked;
            objAd.IsSuper = CheckBox4.Checked;
            objAd.IsActive = true;
            objAd.CreatedBy = Convert.ToInt32(Session["AdminID"]);
            objAd.CreatedOn = DateTime.Now;
            dc.tblAdmins.InsertOnSubmit(objAd);
            dc.SubmitChanges();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
            clear1();
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
}   