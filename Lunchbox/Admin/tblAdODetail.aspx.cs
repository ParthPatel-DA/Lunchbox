using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_tblAdODetail : System.Web.UI.Page
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
                binddata1();
            }
            var DC = new DataClassesDataContext();
            tblAdmin result = (from u in DC.tblAdmins
                               where u.AdminID == Convert.ToInt32(Session["AdminID"])
                               select u).Single();
            if (result.IsSuper == false)
            {
                rptorder.Visible = false;
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

    private void binddata1()
    {
        try {
            var DC = new DataClassesDataContext();

            var Data = from obj in DC.tblOrders
                       join obj2 in DC.tblitems on obj.ItemID equals obj2.ItemID
                       select new
                       {

                           obj.Date,
                           obj.IsActive,
                           obj.OrderID,
                           obj2.ItemName,
                           obj2.ItemID,
                           obj.ClientID,
                           img = (from o1 in DC.tblImages
                                  where o1.ImagesID == obj2.ImageID
                                  select new
                                  {
                                      str = o1.Name

                                  }).Take(1).SingleOrDefault().str,
                           PhoneNo = (from objClient in DC.tblClients
                                      where objClient.ClientID == obj.ClientID
                                      select objClient.ContactNo).Single(),

                       };
            DC.SubmitChanges();
            reptMenu.DataSource = Data;
            reptMenu.DataBind();
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

            var Data = from obj in DC.tblOrders
                       join obj2 in DC.tblMealPlans on obj.MealID equals obj2.MealID
                       select new
                       {

                           obj.Date,
                           obj.IsActive,
                           obj.OrderID,
                           obj2.MealName,
                           obj2.MealID,
                           obj.ClientID,
                           img = (from o1 in DC.tblImages
                                  where o1.ImagesID == obj2.ImageID
                                  select new
                                  {
                                      str = o1.Name

                                  }).Take(1).SingleOrDefault().str,
                           PhoneNo = (from objClient in DC.tblClients
                                      where objClient.ClientID == obj.ClientID
                                      select objClient.ContactNo).Single(),

                       };

            DC.SubmitChanges();
            rptorder.DataSource = Data;
            rptorder.DataBind();
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

    protected void rptorder_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try { 
        var DC = new DataClassesDataContext();

        int ID = Convert.ToInt32(e.CommandArgument);


            if (e.CommandName == "Active")
            {
                tblOrder result = (from u in DC.tblOrders
                                   where u.OrderID == ID
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

                var str = from obj3 in DC.tblOrders
                          join obj1 in DC.tblMealPlans
                          on obj3.MealID equals obj1.MealID
                          join obj in DC.tblServiceProviders
                          on obj1.ServiceProviderID equals obj.ServiceProviderID
                          where obj.ServiceProviderID == obj1.ServiceProviderID && obj1.MealID == obj3.MealID && obj3.OrderID == Convert.ToInt32(e.CommandArgument)
                          select new
                          {
                              obj.FirstName,
                              obj.LastName,
                              obj.ServiceProviderID

                          };

                rptViewDetail.DataSource = str;
                rptViewDetail.DataBind();

                foreach (RepeaterItem item in rptViewDetail.Items)
                {
                    Label lbl = (Label)item.FindControl("Label3");
                    HiddenField hdn = (HiddenField)item.FindControl("HiddenField1");
                    Repeater rpt = (Repeater)item.FindControl("rptMenuOrderDetail");
                    var ClientOrder = from obj in DC.tblClients
                                      join obj1 in DC.tblOrders
                                      on obj.ClientID equals obj1.ClientID
                                      join obj3 in DC.tblMealPlans
                                     on obj1.MealID equals obj3.MealID
                                      join obj4 in DC.tblServiceProviders
                                      on obj3.ServiceProviderID equals obj4.ServiceProviderID
                                      where obj.ClientID == obj1.ClientID && obj1.OrderID == Convert.ToInt32(e.CommandArgument) && obj1.MealID == obj3.MealID && obj3.ServiceProviderID == Convert.ToInt32(hdn.Value)
                                      select new
                                      {
                                          Name = obj.FirstName + " " + obj.LastName,
                                          Price = obj3.MealPrice,
                                          qty = obj1.Qty,
                                          TotalPrice = obj3.MealPrice * obj1.Qty
                                      };

                    int cnt = (from obj in DC.tblClients
                               join obj1 in DC.tblOrders
                               on obj.ClientID equals obj1.ClientID
                               join obj3 in DC.tblMealPlans
                               on obj1.MealID equals obj3.MealID
                               join obj4 in DC.tblServiceProviders
                               on obj3.ServiceProviderID equals obj4.ServiceProviderID
                               where obj.ClientID == obj1.ClientID && obj1.OrderID == Convert.ToInt32(e.CommandArgument) && obj1.MealID == obj3.MealID && obj3.ServiceProviderID == Convert.ToInt32(hdn.Value)
                               select new
                               {
                                   Name = obj.FirstName + " " + obj.LastName,
                                   Price = obj3.MealPrice,
                                   qty = obj1.Qty,
                                   TotalPrice = obj3.MealPrice * obj1.Qty
                               }).Count();
                    if (cnt > 0)
                    {
                        rpt.DataSource = ClientOrder;
                        rpt.DataBind();
                    }
                    else
                    {
                        rpt.Visible = false;
                        lbl.Visible = false;
                    }
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal({backdrop:'static', keyboard: false});", true);
                }

                binddata();
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



    protected void reptMenu_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try {
            var DC = new DataClassesDataContext();

            int ID = Convert.ToInt32(e.CommandArgument);


            if (e.CommandName == "Active")
            {
                tblOrder result = (from u in DC.tblOrders
                                   where u.OrderID == ID
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
                var st = from obj in DC.tblServiceProviders
                         join obj1 in DC.tblMenuDetails
                         on obj.ServiceProviderID equals obj1.ServiceProviderID
                         join ob1 in DC.tblitems
                         on obj1.MenuID equals ob1.MenuID
                         join obj3 in DC.tblOrders
                         on ob1.ItemID equals obj3.ItemID
                         join obj4 in DC.tblClients
                         on obj3.ClientID equals obj4.ClientID
                         where obj.ServiceProviderID == obj1.ServiceProviderID && obj1.MenuID == ob1.MenuID && ob1.ItemID == obj3.ItemID && obj3.ClientID == obj4.ClientID && obj3.OrderID == Convert.ToInt32(e.CommandArgument)
                         select obj;



                rptViewDetail.DataSource = st;
                rptViewDetail.DataBind();

                foreach (RepeaterItem item in rptViewDetail.Items)
                {
                    Label lbl = (Label)item.FindControl("Label3");
                    HiddenField hdn = (HiddenField)item.FindControl("HiddenField1");
                    Repeater rpt = (Repeater)item.FindControl("rptMenuOrderDetail");
                    var ClientOrder = from obj in DC.tblClients
                                      join obj1 in DC.tblOrders
                                      on obj.ClientID equals obj1.ClientID
                                      join obj3 in DC.tblitems
                                      on obj1.ItemID equals obj3.ItemID
                                      join obj5 in DC.tblMenuDetails
                                      on obj3.MenuID equals obj5.MenuID
                                      join obj4 in DC.tblServiceProviders
                                      on obj5.ServiceProviderID equals obj4.ServiceProviderID
                                      where obj.ClientID == obj1.ClientID && obj1.OrderID == Convert.ToInt32(e.CommandArgument) && obj1.ItemID == obj3.ItemID && obj4.ServiceProviderID == Convert.ToInt32(hdn.Value) && obj5.MenuID == obj3.MenuID
                                      select new
                                      {
                                          Name = obj.FirstName + " " + obj.LastName,
                                          Price = obj3.ItemPrice,
                                          qty = obj1.Qty,
                                          TotalPrice = obj3.ItemPrice * obj1.Qty
                                      };
                    int cnt = (from obj in DC.tblClients
                               join obj1 in DC.tblOrders
                               on obj.ClientID equals obj1.ClientID

                               join ob6 in DC.tblitems
                               on obj1.ItemID equals ob6.ItemID
                               join obj3 in DC.tblMenuDetails
                               on ob6.MenuID equals obj3.MenuID
                               join obj4 in DC.tblServiceProviders
                               on obj3.ServiceProviderID equals obj4.ServiceProviderID
                               where obj.ClientID == obj1.ClientID && obj1.OrderID == Convert.ToInt32(e.CommandArgument) && obj1.ItemID == ob6.ItemID && ob6.MenuID == obj3.MenuID && obj3.ServiceProviderID == Convert.ToInt32(hdn.Value)
                               select new
                               {
                                   Name = obj.FirstName + " " + obj.LastName,
                                   Price = ob6.ItemPrice,
                                   qty = obj1.Qty,
                                   TotalPrice = ob6.ItemPrice * obj1.Qty
                               }).Count();
                    if (cnt > 0)
                    {
                        rpt.DataSource = ClientOrder;
                        rpt.DataBind();
                    }
                    else
                    {
                        rpt.Visible = false;
                        lbl.Visible = false;
                    }
                    //rpt.DataSource = ClientOrder;
                    //rpt.DataBind();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal({backdrop:'static', keyboard: false});", true);
                }




                //    upModal.Update();

            }

            binddata1();
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
