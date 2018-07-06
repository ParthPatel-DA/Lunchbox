using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.NetworkInformation;

public partial class Admin_Addpackages : System.Web.UI.Page
{
    string chk;
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
        try
        {
            if (!IsPostBack)
            {
                bindata();
            }

            if (Session["AdminID"] == null)
            {
                Response.Redirect("Adlogin.aspx");
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
                pnlact.Visible = false;
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

    private void bindata()
    {
        try
        {
            var dc = new DataClassesDataContext();
            var ob = from obj in dc.tblPackages select obj;
            if (Request.QueryString["id"] != null)
            {
                var result = (from u in dc.tblPackages
                              where u.PackagesID == Convert.ToInt32(Request.QueryString["id"])
                              select u).SingleOrDefault();
                txtfnm.Text = result.Name;
                txtduration.Text = Convert.ToString(result.Duration);
                txtpri.Text = Convert.ToString(result.Price);
                if (result.IsActive == true)
                {
                    CheckBox4.Checked = true;
                }
                else
                {
                    CheckBox4.Checked = false;
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
    private void clear1()
    {
        try
        { 
        txtdesc.Text = string.Empty;
        txtduration.Text = string.Empty;
        txtfnm.Text = string.Empty;
        txtpri.Text = string.Empty;
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

    protected void btninsert_Click(object sender, EventArgs e)
    {
        try
        {
            var dc = new DataClassesDataContext();

            if (Request.QueryString["id"] != null)
            {
                if (FileUpload1.HasFile)
                {
                    var path = Server.MapPath("~/Admin/Packimg");
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

                tblPackage p1 = dc.tblPackages.Single(ob => ob.PackagesID == Convert.ToInt32(Request.QueryString["id"]));
                var str1 = (from p2 in dc.tblPackages
                            where p2.Name == txtfnm.Text
                            select p2).Count();

                if (str1 <= 0)
                {
                    p1.Name = txtfnm.Text;
                    if (FileUpload1.HasFile)
                    {
                        var img = (from im in dc.tblImages
                                   orderby im.ImagesID descending
                                   select im).FirstOrDefault();
                        p1.ImageID = Convert.ToInt32(img.ImagesID);
                    }
                    if (CheckBox4.Checked == true)
                    {
                        p1.IsActive = true;
                    }
                    else
                    {
                        p1.IsActive = false;
                    }


                    p1.Duration = Convert.ToInt32(txtduration.Text);
                    p1.Description = txtdesc.Text;
                    p1.Price = Convert.ToInt32(txtpri.Text);
                    p1.CreatedOn = DateTime.Now;
                    p1.CreatedBy = Convert.ToInt32(Session["AdminID"]);

                    dc.SubmitChanges();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Updated Successfully')", true);
                    clear1();
                    bindata();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record already Exit')", true);
                }
                
            }
            else
            {
                if (FileUpload1.HasFile)
                {
                    var path = Server.MapPath("~/Admin/Packimg");
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
                tblPackage p1 = new tblPackage();
                var str1 = (from p2 in dc.tblPackages
                            where p2.Name == txtfnm.Text
                            select p2).Count();
                if (str1 <= 0)
                {
                    p1.Name = txtfnm.Text;
                    p1.ImageID = Convert.ToInt32(img.ImagesID);
                    p1.Duration = Convert.ToInt32(txtduration.Text);
                    p1.Description = txtdesc.Text;
                    p1.Price = Convert.ToInt32(txtpri.Text);
                    p1.IsActive = false;

                    p1.CreatedOn = DateTime.Now;
                    p1.CreatedBy = Convert.ToInt32(Session["AdminID"]);

                    dc.tblPackages.InsertOnSubmit(p1);
                    dc.SubmitChanges();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
                    clear1();
                    bindata();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record already Exit')", true);
                }
            }
            bindata();
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