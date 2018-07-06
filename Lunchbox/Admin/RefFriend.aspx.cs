using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_RefFriend : System.Web.UI.Page
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

            if (!IsPostBack)
            {
                BindData();
                BindData1();
            }
            tblAdmin result = (from u in DC.tblAdmins
                               where u.AdminID == Convert.ToInt32(Session["AdminID"])
                               select u).Single();
            if (result.IsSuper == false)
            {
                rptrefrd.Visible = false;
                rptservice.Visible = false;
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

    private void BindData1()
    {
        try {
            var DC = new DataClassesDataContext();
            var str = from obj in DC.tblreferfriends
                      where obj.ClientID == 0
                      select new
                      {


                          CN = (from ob in DC.tblServiceProviders
                                where ob.ServiceProviderID == obj.ServiceProviderID
                                select new
                                {
                                    Data = ob.FirstName + " " + ob.LastName
                                }).Take(1).SingleOrDefault().Data,
                          obj.ReferFriendID,
                          obj.ReferEmailID,

                          obj.ClientID,
                          obj.ServiceProviderID,
                          obj.ReferDate,
                          obj.Discription,
                          //obj.IsActive
                      };
            DC.SubmitChanges();
            rptservice.DataSource = str;
            rptservice.DataBind();
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
            var str = from obj in DC.tblreferfriends
                      where obj.ServiceProviderID == 0
                      select new
                      {

                          CN = (from ob in DC.tblClients
                                where ob.ClientID == obj.ClientID
                                select new
                                {
                                    Data = ob.FirstName + " " + ob.LastName
                                }).Take(1).SingleOrDefault().Data,

                          obj.ReferFriendID,
                          obj.ReferEmailID,

                          obj.ClientID,
                          obj.ServiceProviderID,
                          obj.ReferDate,
                          obj.Discription,
                          //obj.IsActive
                      };
            DC.SubmitChanges();
            rptrefrd.DataSource = str;
            rptrefrd.DataBind();
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




    protected void rptrefrd_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try {
            var DC = new DataClassesDataContext();

            int ID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "View")
            {


                var str = from obj in DC.tblreferfriends
                          where obj.ServiceProviderID == 0 && obj.ReferFriendID == Convert.ToInt32(e.CommandArgument)
                          select new
                          {


                              CN = (from ob in DC.tblClients
                                    where ob.ClientID == obj.ClientID
                                    select new
                                    {
                                        Data = ob.FirstName + " " + ob.LastName
                                    }).Take(1).SingleOrDefault().Data,
                              obj.ReferFriendID,
                              obj.ReferEmailID,

                              obj.ClientID,
                              obj.ServiceProviderID,
                              obj.ReferDate,
                              obj.Discription,
                              //obj.IsActive
                          };


                rptViewDetail.DataSource = str;
                rptViewDetail.DataBind();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal({backdrop:'static', keyboard: false});", true);
                //    upModal.Update();

            }
            BindData();
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

    protected void rptservice_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try {
            var DC = new DataClassesDataContext();

            int ID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "View")
            {


                var str = from obj in DC.tblreferfriends
                          where obj.ClientID == 0 && obj.ReferFriendID == Convert.ToInt32(e.CommandArgument)
                          select new
                          {

                              CN = (from ob in DC.tblServiceProviders
                                    where ob.ServiceProviderID == obj.ServiceProviderID
                                    select new
                                    {
                                        Data = ob.FirstName + " " + ob.LastName
                                    }).Take(1).SingleOrDefault().Data,

                              obj.ReferFriendID,
                              obj.ReferEmailID,

                              obj.ClientID,
                              obj.ServiceProviderID,
                              obj.ReferDate,
                              obj.Discription,
                              //obj.IsActive
                          };

                rptViewDetail.DataSource = str;
                rptViewDetail.DataBind();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal({backdrop:'static', keyboard: false});", true);
                //    upModal.Update();

            }
            BindData1();
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