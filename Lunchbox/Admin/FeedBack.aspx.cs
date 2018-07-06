using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_FeedBack : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                binddata();
            }
            var DC = new DataClassesDataContext();
            tblAdmin result = (from u in DC.tblAdmins
                               where u.AdminID == Convert.ToInt32(Session["AdminID"])
                               select u).Single();
            if (result.IsSuper == false)
            {
                rptfb.Visible = false;
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
  
    private void binddata()
    {
        try {
            var DC = new DataClassesDataContext();

            var str = from obj in DC.tblFeedbacks
                      join obj1 in DC.tblClients
                      on obj.ClientID equals obj1.ClientID
                      where obj.ClientID == obj1.ClientID && obj.Email == obj1.Email
                      select new
                      {
                          Data = obj1.FirstName + " " + obj1.LastName,
                          obj1.ContactNo,
                          obj1.ClientID,
                          obj.FeedBackID,
                          obj.Email,
                          obj.IsNotify
                      };

            //var str = from obj in DC.tblFeedbacks
            //            where obj.IsNotify == true
            //          select new
            //          {

            //              CBy = (from ob in DC.tblClients
            //                     where ob.Email == obj.Email
            //                     select new
            //                     {
            //                         Data = ob.FirstName + " " + ob.LastName
            //                     }).Take(1).SingleOrDefault().Data,
            //              //obj.ClientID,
            //              obj.CreatedOn,
            //              obj.FeedBackID,
            //              obj.Email,
            //              obj.IsNotify,
            //              obj.Description


            //          };
            DC.SubmitChanges();
            rptfb.DataSource = str;
            rptfb.DataBind();
            tblAdmin AdminData = DC.tblAdmins.Single(ob => ob.AdminID == Convert.ToInt32(Session["AdminID"]));
            if (AdminData.IsUpdate == false)
            {
                foreach (RepeaterItem item in rptfb.Items)
                {
                    PlaceHolder PlaceHolderActive = (PlaceHolder)item.FindControl("PlaceHolderActive");
                    PlaceHolderActive.Visible = false;
                }
                PlaceHolderActiveHeader.Visible = false;
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

    protected void rptfb_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try {
            var DC = new DataClassesDataContext();

            int ID = Convert.ToInt32(e.CommandArgument);


            if (e.CommandName == "Notify")
            {
                tblFeedback result = (from u in DC.tblFeedbacks
                                      where u.FeedBackID == ID
                                      select u).Single();

                if (result.IsNotify == true)
                {
                    result.IsNotify = false;
                }
                else
                {
                    result.IsNotify = true;
                }
                DC.SubmitChanges();

            }
            else if (e.CommandName == "View")
            {
                var str = from obj in DC.tblFeedbacks
                          join obj1 in DC.tblClients
                          on obj.ClientID equals obj1.ClientID
                          where obj.ClientID == obj1.ClientID && obj.Email == obj1.Email && obj.FeedBackID == Convert.ToInt32(e.CommandArgument)
                          select new
                          {
                              Data = obj1.FirstName + " " + obj1.LastName,
                              obj1.ContactNo,
                              obj1.ClientID,
                              obj.FeedBackID,
                              obj.Email,
                              obj.Description,
                              obj.CreatedOn,
                              obj.IsNotify
                          };


                rptViewDetail.DataSource = str;
                rptViewDetail.DataBind();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal({backdrop:'static', keyboard: false});", true);
                //    upModal.Update();

            }
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