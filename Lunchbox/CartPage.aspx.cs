using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default4 : System.Web.UI.Page
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
            binddata();
            binddata1();
        }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }

    }
   


    private void binddata()
    {
        try { 
            var DC = new DataClassesDataContext();
      
        var item = from obj in DC.tblcarts
                   join obj1 in DC.tblitems
                   on obj.ItemID equals obj1.ItemID
                   where obj.IsActive == true
                   select new
                   {
                       obj.IsActive,
                       obj.CartID,
                       obj1.ItemName,
                       obj1.ItemID,
                       obj1.ItemPrice,
                       img = (from o1 in DC.tblImages
                              where o1.ImagesID == obj1.ImageID
                              select new
                              {
                                  str = o1.Name
                              }).Take(1).SingleOrDefault().str,
                   };
        DC.SubmitChanges();
        repitem.DataSource = item;
        repitem.DataBind();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }
    private void binddata1()
    {
        try { 
        var DC = new DataClassesDataContext();
        var item1 = from obj in DC.tblcarts
                    join obj2 in DC.tblMealPlans on obj.MealID equals obj2.MealID
                    where obj.IsActive == true
                    select new
                    {
                        obj.IsActive,
                        obj.CartID,
                        obj2.MealName,
                        obj2.MealPrice,
                        imge = (from o1 in DC.tblImages
                                where o1.ImagesID == obj2.ImageID
                                select new
                                {
                                    str = o1.Name
                                }).Take(1).SingleOrDefault().str,
                    };
        DC.SubmitChanges();
        repmeal.DataSource = item1;
        repmeal.DataBind();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
          
    }

    protected void repitem_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try { 
        if(e.CommandName== "diactiveitem")
        {
            var DC = new DataClassesDataContext();
            var data = (from ob in DC.tblcarts
                       where ob.CartID == Convert.ToInt32(e.CommandArgument)
                       select ob).Single();

            data.IsActive = false;
            DC.SubmitChanges();

           
        }
        binddata();
        binddata1();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void repmeal_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try { 
        if (e.CommandName == "diactiveMeal")
        {
            var DC = new DataClassesDataContext();
            var data = (from ob in DC.tblcarts
                        where ob.CartID == Convert.ToInt32(e.CommandArgument)
                        select ob).Single();

            data.IsActive = false;
            DC.SubmitChanges();


        }
        binddata();
        binddata1();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["ClientID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void btnOrder_Click(object sender, EventArgs e)
    {

    }

    protected void btnCheckOut_Click(object sender, EventArgs e)
    {

    }

    protected void btnClearCart_Click(object sender, EventArgs e)
    {

    }
}

public class txtQuantity
{
}