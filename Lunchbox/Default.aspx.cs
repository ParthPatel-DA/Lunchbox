using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
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
    {http://localhost:11033/Default.aspx.cs
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
       if(!IsPostBack )
        {
            bindata();
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

    private void bindata()
    {
        try { 
        var dc = new DataClassesDataContext();
        var str2 = (from obj2 in dc.tblSPPackages
                    where obj2.PackagesId == 1
                    orderby obj2.Start_Date descending
                    select new
                    {
                        SN = (from ob in dc.tblServiceProviders
                              where ob.ServiceProviderID == obj2.ServiceProviderID
                              select new
                              {
                                  Data = ob.CompanyName
                              }).Take(1).SingleOrDefault().Data,
                        img = (from ob in dc.tblImages
                               join obj in dc.tblServiceProviders
                               on ob.ImagesID equals obj.ImageID
                               where obj.ServiceProviderID == obj2.ServiceProviderID
                               select ob.Name).Single()
                            
                   }).Take(3);
                 
        var str = (from obj in dc.tblFeedbacks
                  where obj.IsNotify== true
                  orderby obj.FeedBackID descending
                  select new
                  {
                      FN = (from ob in dc.tblClients
                            where ob.ClientID == obj.ClientID
                            select new
                            {
                                Data = ob.FirstName + " " + ob.LastName
                            }).Take(1).SingleOrDefault().Data,
                      FD = (from obj1 in dc.tblFeedbacks
                            where obj1.FeedBackID==obj.FeedBackID
                            select new
                            {
                                Data = obj1.Description
                            }).Take(1).SingleOrDefault().Data
                  }).Take(3);
        //var str1 = from obj1 in dc.tblServiceProviders
        //           where obj1.IsActive == true
        //           select new
        //           {
        //               SN = (from ob in dc.tblServiceProviders
        //                     where ob.ServiceProviderID == obj1.ServiceProviderID
        //                     select new
        //                     {
        //                         data = ob.FirstName + " " + ob.LastName
        //                     }).Take(1).SingleOrDefault().data,
        //           };
        dc.SubmitChanges();
        rptfb.DataSource = str;
        rptfb.DataBind();
        rptsp.DataSource = str2;
        rptsp.DataBind();
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

    protected void btnserch_Click(object sender, EventArgs e)
    {
        try { 
        var dc = new DataClassesDataContext();
        string Ve;



        Session["ddlmemeal"] = DropDownList2.SelectedIndex;
        Session["ddltime"] = DropDownList1.SelectedIndex;
        if (chkvege.Checked == true)
        {
            Ve = "Veg";
            Session["Check"] = Ve;
            Response.Redirect("Menu1.aspx");
        }
        else if (chknonvege.Checked == true)
        {
            Ve = "Non-Veg";
            Session["Check"] = Ve;
            Response.Redirect("Menu1.aspx");
        }
        else if(chkcombo .Checked == true )
        {
            Ve = "Both";
            Session["Check"] = Ve;
            Response.Redirect("Menu1.aspx");
        }
        else
        {

            //Response.Write("<script>alert('Hello');</script>");
            // ScriptManager.RegisterStartupScript(
            //this,
            //this.GetType(),
            //"MessageBox",
            //"alert('plese any one choose ');",
            //true);
            panel1.Visible = true;

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
}