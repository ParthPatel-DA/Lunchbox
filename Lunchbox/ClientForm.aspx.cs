using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ClientForm : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            InitPage();

        }
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", 0 , 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    private void InitPage()
    {
        try {
            var db = new DataClassesDataContext();
            var Country = from obj in db.CountryMasters
                          select obj;
            ddlcountry.DataSource = Country;
            ddlcountry.DataTextField = "Name";
            ddlcountry.DataValueField = "ID";
            ddlcountry.DataBind();
            ddlcountry.Items.Insert(0, new ListItem("Select Country", "0"));
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", 0 , 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void btnnext_Click(object sender, EventArgs e)
    {
        try { 
        var dc = new DataClassesDataContext();
        if (FileUpload1.HasFile)
        {
            var path = Server.MapPath("~/Client/Upload/");
            FileUpload1.SaveAs(path + "/" + FileUpload1.FileName);
            tblImage objimg = new tblImage();
            objimg.Name = FileUpload1.FileName;
            objimg.AlbumID = 3;
            objimg.IsActive = true;
            objimg.IsDefault = false;
            objimg.CreatedOn = DateTime.Now;
            dc.tblImages.InsertOnSubmit(objimg);
            dc.SubmitChanges();
         }
        Session["pass"] = txtpass.Text;
       
        if (txtpass.Text == txtconpass.Text)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            var check = (from us in dc.tblClients 
                         where us.Email == txtmail.Text
                         select us.ClientID ).Count();
            var st1 = (from us in dc.tblClients 
                       where us.Email == txtmail.Text
                       select us).FirstOrDefault();

            if (check > 0)
            {
                Session["ClientID"] = st1.ClientID ;
                tblClient  result = (from u in dc.tblClients 
                                             where u.ClientID == Convert.ToInt32(Session["ClientID"].ToString())
                                             select u).Single();
                result.Password = txtpass.Text;
                dc.SubmitChanges();
            }

        }
        else
        {
            lblerrorPwd.Visible = true;
        }
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", 0 , 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void btnsub_Click(object sender, EventArgs e)
    {
        try { 
        panel1.Visible = true;
        var dc = new DataClassesDataContext();
        using (DataClassesDataContext data = new DataClassesDataContext())
        {


            tblAddress add = new tblAddress()
            {
                Address = txtadd.Text,
                Area = txtarea.Text,
                Landmark = txtlandmark .Text,
                PincodeNo = txtpinno.Text,
                CityID = ddlcity.SelectedIndex
            };

            data.tblAddresses.InsertOnSubmit(add);
            data.SubmitChanges();


            

            var img = (from im in dc.tblImages
                       orderby im.ImagesID descending
                       select im).FirstOrDefault();
            tblClient  user = new tblClient ()
            {
                AddressID = add.AddressID,
                Password = Session["pass"].ToString(),
                FirstName = txtfnm.Text,
                LastName = txtlnm .Text,
                Email = txtmail.Text,
                ImageID = Convert.ToInt32(img.ImagesID),

          
                CreatedOn = DateTime.Now,
                ContactNo = txtphno.Text
          };
            data.tblClients .InsertOnSubmit(user);
            data.SubmitChanges();
            using (DataClassesDataContext des = new DataClassesDataContext())
            {
                tblNotification str = new tblNotification();
                str.Title = "New Client Registered";
                str.Description = txtfnm.Text + " " + txtlnm.Text + " is register on " + DateTime.Now + " with " + txtmail.Text + ".";
                str.CreatedOn = DateTime.Now;
                str.CreatedBy = Convert.ToInt32(Session["ClientID"]);
                des.tblNotifications.InsertOnSubmit(str);
                des.SubmitChanges();

                tblNotificationDetail strr = new tblNotificationDetail();
                strr.NotificationID = str.NotificationID;
                strr.IsRead = false;
                strr.IsNotify = false;
                des.tblNotificationDetails.InsertOnSubmit(strr);
                des.SubmitChanges();
            }
        }
        Response.Redirect("Default.aspx");
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", 0 , 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        try { 
        var db = new DataClassesDataContext();
        int Country = Convert.ToInt32(ddlcountry.SelectedItem.Value);
        var states = from obj in db.StateMasters
                     where obj.CountryID == Country
                     select obj;
        ddlstate.DataSource = states;
        ddlstate.DataTextField = "Name";
        ddlstate.DataValueField = "ID";
        ddlstate.DataBind();
        ddlstate.Items.Insert(0, new ListItem("Select state", "0"));
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", 0 , 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        try { 
        var db = new DataClassesDataContext();
        int State = Convert.ToInt32(ddlstate.SelectedItem.Value);
        var Cities = from obj in db.CityMasters
                     where obj.StateID == State
                     select obj;
        ddlcity.DataSource = Cities;
        ddlcity.DataTextField = "Name";
        ddlcity.DataValueField = "ID";
        ddlcity.DataBind();
        ddlcity.Items.Insert(0, new ListItem("Select city", "0"));
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", 0 , 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }
}