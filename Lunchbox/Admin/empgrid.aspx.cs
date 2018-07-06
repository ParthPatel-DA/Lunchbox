using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net.NetworkInformation;

public partial class Admin_empgrid : System.Web.UI.Page
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

    private object hidid;

    protected void Page_Load(object sender, EventArgs e)
    {
        try { 
        if (Session["AdminID"] == null)
        {
            Response.Redirect("Adlogin.aspx");
        }
        if (!IsPostBack)
        {
            BindData();
        }
        var DC = new DataClassesDataContext();
        tblAdmin result = (from u in DC.tblAdmins
                           where u.AdminID == Convert.ToInt32(Session["AdminID"])
                           select u).Single();
        if (result.IsSuper == false)
        {
            rptAdmin.Visible = false;
            Panel1.Visible = false;
            Literal1.Visible = true;
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

    private void BindData()
    {
        try {
            var DC = new DataClassesDataContext();
            var str = from obj in DC.tblAdmins
                      where /*obj.IsActive==true &&*/ obj.AdminID != Convert.ToInt32(Session["AdminID"])
                      select new
                      {
                          obj.FirstName,

                          CBy = (from ob in DC.tblAdmins
                                 where ob.AdminID == obj.CreatedBy
                                 select new
                                 {
                                     Data = ob.FirstName + " " + ob.LastName
                                 }).Take(1).SingleOrDefault().Data,

                          img = (from o1 in DC.tblImages
                                 where o1.ImagesID == obj.ImageID
                                 select new
                                 {
                                     str = o1.Name

                                 }).Take(1).SingleOrDefault().str,

                          obj.IsActive,
                          obj.IsDelete,
                          obj.IsSuper,
                          obj.IsInsert,
                          obj.IsUpdate,
                          obj.LastName,
                          obj.ContactNO,
                          obj.Email,
                          obj.AdminID,
                          obj.CreatedOn,
                      };
            DC.SubmitChanges();
            rptAdmin.DataSource = str;
            rptAdmin.DataBind();
            tblAdmin AdminData = DC.tblAdmins.Single(ob => ob.AdminID == Convert.ToInt32(Session["AdminID"]));
            if (AdminData.IsUpdate == false)
            {
                foreach (RepeaterItem item in rptAdmin.Items)
                {
                    PlaceHolder PlaceHolderActive = (PlaceHolder)item.FindControl("PlaceHolderActive");
                    PlaceHolderActive.Visible = false;
                }
                PlaceHolderActiveHeader.Visible = false;
            }

            if (AdminData.IsDelete == false)
            {
                foreach (RepeaterItem item in rptAdmin.Items)
                {
                    PlaceHolder PlaceHolderDelete = (PlaceHolder)item.FindControl("PlaceHolderDelete");
                    PlaceHolderDelete.Visible = false;
                }
                PlaceHolderDeleteHeader.Visible = false;
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

    protected void rptAdmin_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try {
            var DC = new DataClassesDataContext();

            int ID = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Super")
            {
                tblAdmin result1 = (from u in DC.tblAdmins
                                    where u.AdminID == ID
                                    select u).Single();
                if (result1.IsSuper == true)
                {
                    result1.IsSuper = false;
                }
                else
                {
                    result1.IsSuper = true;
                }
                DC.SubmitChanges();
            }

            if (e.CommandName == "Insert")
            {
                tblAdmin result = (from u in DC.tblAdmins
                                   where u.AdminID == ID
                                   select u).Single();
                if (result.IsInsert == true)
                {
                    result.IsInsert = false;
                }
                else
                {
                    result.IsInsert = true;
                }
                DC.SubmitChanges();
            }

            else if (e.CommandName == "Update")
            {
                tblAdmin result = (from u in DC.tblAdmins
                                   where u.AdminID == ID
                                   select u).Single();
                if (result.IsUpdate == true)
                {
                    result.IsUpdate = false;
                }
                else
                {
                    result.IsUpdate = true;
                }
                DC.SubmitChanges();
            }
            else if (e.CommandName == "Delete")
            {
                tblAdmin result = (from u in DC.tblAdmins
                                   where u.AdminID == ID
                                   select u).Single();
                if (result.IsDelete == true)
                {
                    result.IsDelete = false;
                }
                else
                {
                    result.IsDelete = true;
                }
                DC.SubmitChanges();
            }
            else if (e.CommandName == "Active")
            {
                tblAdmin result = (from u in DC.tblAdmins
                                   where u.AdminID == ID
                                   select u).Single();
                if (result.IsActive == true)
                {
                    result.IsActive = false;
                }
                else
                {
                    result.IsActive = true;
                }
                DC.SubmitChanges();

            }
            else if (e.CommandName == "View")
            {

                var str = from obj in DC.tblAdmins
                          where obj.AdminID == Convert.ToInt32(e.CommandArgument)
                          select new
                          {
                              obj.FirstName,

                              CBy = (from ob in DC.tblAdmins
                                     where ob.AdminID == obj.CreatedBy
                                     select new
                                     {
                                         Data = ob.FirstName + " " + ob.LastName
                                     }).Take(1).SingleOrDefault().Data,

                              img = (from o1 in DC.tblImages
                                     where o1.ImagesID == obj.ImageID
                                     select new
                                     {
                                         str = o1.Name

                                     }).Take(1).SingleOrDefault().str,


                              obj.IsActive,
                              obj.IsDelete,
                              obj.IsSuper,
                              obj.IsInsert,
                              obj.IsUpdate,
                              obj.LastName,
                              obj.ContactNO,
                              obj.Email,
                              obj.AdminID,
                              obj.CreatedOn,
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
}

