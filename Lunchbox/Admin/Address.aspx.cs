using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.NetworkInformation;

public partial class Admin_Address : System.Web.UI.Page
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
        try
        {
            if (Session["AdminID"] == null)
        {
            Response.Redirect("Adlogin.aspx");
        }
        if (!IsPostBack)
        {
            bindata();
            bindata1();
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

    private void bindata1()
    {
        try
        { 
        var DC = new DataClassesDataContext();
        var str = from obj in DC.tblAddresses
                  select new
                  {
                      data = (from ob in DC.tblServiceProviders
                              where ob.AddressID == obj.AddressID
                              select new
                              {
                                  Da = ob.FirstName + " " + ob.LastName
                              }).Take(1).SingleOrDefault().Da,
                      city = (from obj1 in DC.CityMasters
                              where obj1.ID == obj.CityID
                              select new
                              {
                                  Da1 = obj1.Name,


                              }).Take(1).SingleOrDefault().Da1,


                      obj.AddressID,
                      obj.Address,
                      obj.Area,
                      obj.CityID,
                      obj.IsActive,
                      obj.Landmark,
                      obj.PincodeNo,



                  };
        DC.SubmitChanges();
        rptservice.DataSource = str;
        rptservice.DataBind();
        tblAdmin AdminData = DC.tblAdmins.Single(ob => ob.AdminID == Convert.ToInt32(Session["AdminID"]));
        if (AdminData.IsUpdate == false)
        {
            foreach (RepeaterItem item in rptservice.Items)
            {
                PlaceHolder PlaceHolderActive = (PlaceHolder)item.FindControl("PlaceHolderActive");
                PlaceHolderActive.Visible = false;
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

    private void bindata()
    {
        try
        {
            var DC = new DataClassesDataContext();
            var str = from obj in DC.tblAddresses
                      select new
                      {
                          data = (from ob in DC.tblClients
                                  where ob.AddressID == obj.AddressID
                                  select new
                                  {
                                      Da = ob.FirstName + " " + ob.LastName
                                  }).Take(1).SingleOrDefault().Da,
                          city = (from obj1 in DC.CityMasters
                                  where obj1.ID == obj.CityID
                                  select new
                                  {
                                      Da1 = obj1.Name,


                                  }).Take(1).SingleOrDefault().Da1,


                          obj.AddressID,
                          obj.Address,
                          obj.Area,
                          obj.CityID,
                          obj.IsActive,
                          obj.Landmark,
                          obj.PincodeNo,



                      };
            DC.SubmitChanges();
            rptCliadd.DataSource = str;
            rptCliadd.DataBind();

            tblAdmin AdminData = DC.tblAdmins.Single(ob => ob.AdminID == Convert.ToInt32(Session["AdminID"]));
            if (AdminData.IsUpdate == false)
            {
                foreach (RepeaterItem item in rptCliadd.Items)
                {
                    PlaceHolder PlaceHolderActive = (PlaceHolder)item.FindControl("PlaceHolderActive");
                    PlaceHolderActive.Visible = false;
                }
                PlaceHolderActiveHeader1.Visible = false;
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




    protected void rptCliadd_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            var DC = new DataClassesDataContext();

            int ID = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Active")
            {
                tblAddress result = (from u in DC.tblAddresses
                                     where u.AddressID == ID
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

                var str = (from obj in DC.tblAddresses
                           where obj.AddressID == Convert.ToInt32(e.CommandArgument)
                           select new
                           {
                               data = (from ob in DC.tblClients
                                       where ob.AddressID == obj.AddressID
                                       select new
                                       {
                                           Da = ob.FirstName + " " + ob.LastName
                                       }).Take(1).SingleOrDefault().Da,
                               city = (from obj1 in DC.CityMasters
                                       where obj1.ID == obj.CityID
                                       select new
                                       {
                                           Da1 = obj1.Name,

                                       }).Take(1).SingleOrDefault().Da1,
                               obj.AddressID,
                               obj.Address,
                               obj.Area,
                               obj.CityID,
                               obj.IsActive,
                               obj.Landmark,
                               obj.PincodeNo,
                           });
                rptViewDetail.DataSource = str;
                rptViewDetail.DataBind();
                foreach (RepeaterItem item in rptViewDetail.Items)
                {
                    HiddenField hdn = (HiddenField)item.FindControl("HiddenField1");
                    Label lblState = (Label)item.FindControl("Label6");
                    HiddenField hdnState = (HiddenField)item.FindControl("HiddenField3");
                    if (hdn.Value != "")
                    {
                        var State = (from obj in DC.StateMasters
                                     where obj.ID == Convert.ToInt32(hdn.Value)
                                     select obj).Single();
                        lblState.Text = State.Name;
                        hdnState.Value = State.ID.ToString();
                    }

                }

                foreach (RepeaterItem item in rptViewDetail.Items)
                {
                    HiddenField hdn = (HiddenField)item.FindControl("HiddenField3");
                    Label lblState = (Label)item.FindControl("Label7");
                    if (hdn.Value != "")
                    {
                        var Country = (from obj in DC.CountryMasters
                                       where obj.ID == Convert.ToInt32(hdn.Value)
                                       select obj).Single();
                        lblState.Text = Country.Name;
                    }

                }
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal({backdrop:'static', keyboard: false});", true);
                //    upModal.Update();

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

    protected void rptservice_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            var DC = new DataClassesDataContext();

            int ID = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Active")
            {
                tblAddress result = (from u in DC.tblAddresses
                                     where u.AddressID == ID
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

                var str = (from obj in DC.tblAddresses
                           where obj.AddressID == Convert.ToInt32(e.CommandArgument)
                           select new
                           {
                               data = (from ob in DC.tblServiceProviders
                                       where ob.AddressID == obj.AddressID
                                       select new
                                       {
                                           Da = ob.FirstName + " " + ob.LastName
                                       }).Take(1).SingleOrDefault().Da,
                               city = (from obj1 in DC.CityMasters
                                       where obj1.ID == obj.CityID
                                       select new
                                       {
                                           Da1 = obj1.Name,

                                       }).Take(1).SingleOrDefault().Da1,
                               obj.AddressID,
                               obj.Address,
                               obj.Area,
                               obj.CityID,
                               obj.IsActive,
                               obj.Landmark,
                               obj.PincodeNo,
                           });
                rptViewDetail.DataSource = str;
                rptViewDetail.DataBind();
                foreach (RepeaterItem item in rptViewDetail.Items)
                {
                    HiddenField hdn = (HiddenField)item.FindControl("HiddenField1");
                    Label lblState = (Label)item.FindControl("Label6");
                    HiddenField hdnState = (HiddenField)item.FindControl("HiddenField3");
                    if (hdn.Value != "")
                    {
                        var State = (from obj in DC.StateMasters
                                     where obj.ID == Convert.ToInt32(hdn.Value)
                                     select obj).Single();
                        lblState.Text = State.Name;
                        hdnState.Value = State.ID.ToString();
                    }

                }

                foreach (RepeaterItem item in rptViewDetail.Items)
                {
                    HiddenField hdn = (HiddenField)item.FindControl("HiddenField3");
                    Label lblState = (Label)item.FindControl("Label7");
                    if (hdn.Value != "")
                    {
                        var Country = (from obj in DC.CountryMasters
                                       where obj.ID == Convert.ToInt32(hdn.Value)
                                       select obj).Single();
                        lblState.Text = Country.Name;
                    }

                }
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal({backdrop:'static', keyboard: false});", true);
                //    upModal.Update();

            }
            bindata1();
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
