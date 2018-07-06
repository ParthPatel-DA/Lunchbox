using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.NetworkInformation;

public partial class takeurpick : System.Web.UI.MasterPage
{
    int TotalAmount = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            binddata();
            binddata1();
        }

        ltrTotalAmount.Text = "₹ " + TotalAmount.ToString();
    }

    public string GetMACAddress()
    {
        NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
        String sMacAddress = string.Empty;
        foreach (NetworkInterface adapter in nics)
        {
            if (sMacAddress == String.Empty)// only return MAC Address from first card  
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();
                sMacAddress = adapter.GetPhysicalAddress().ToString();
            }
        }
        return sMacAddress;

    }

    private void binddata()
    {
        var DC = new DataClassesDataContext();
        var item = from obj in DC.tblcarts
                   join obj1 in DC.tblitems
                   on obj.ItemID equals obj1.ItemID
                   where obj.IsActive == true && obj.MACAddress == GetMACAddress()
                   select new
                   {
                       obj.IsActive,
                       obj.CartID,
                       obj1.ItemName,
                       obj1.ItemID,
                       obj1.ItemPrice,
                       obj.Quantity,
                       Total = obj.Quantity * Convert.ToInt32(obj1.ItemPrice),
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
        foreach (RepeaterItem data in repitem.Items)
        {
            Label TP = (Label)data.FindControl("lblTotal");
            TotalAmount += Convert.ToInt32(TP.Text);
        }
    }

    private void binddata1()
    {
        var DC = new DataClassesDataContext();
        var item1 = from obj in DC.tblcarts
                    join obj2 in DC.tblMealPlans on obj.MealID equals obj2.MealID
                    where obj.IsActive == true && obj.MACAddress == GetMACAddress()
                    select new
                    {
                        obj.IsActive,
                        obj.CartID,
                        obj2.MealName,
                        obj2.MealPrice,
                        obj.Quantity,
                        Total = obj.Quantity * obj2.MealPrice,
                        imge = (from o1 in DC.tblImages
                                where o1.ImagesID == obj2.ImageID
                                select new
                                {
                                    str = o1.Name
                                }).Take(1).SingleOrDefault().str
                    };
        DC.SubmitChanges();
        repmeal.DataSource = item1;
        repmeal.DataBind();
        foreach (RepeaterItem data in repmeal.Items)
        {
            Label TP = (Label)data.FindControl("lblTotal");
            TotalAmount += Convert.ToInt32(TP.Text);
        }
    }


    protected void repitem_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        var DC = new DataClassesDataContext();
        if (e.CommandName == "diactiveitem")
        {
            var data = (from ob in DC.tblcarts
                        where ob.CartID == Convert.ToInt32(e.CommandArgument)
                        select ob).Single();

            data.IsActive = false;
        }
        else if (e.CommandName == "itemInc")
        {
            
            var data = (from ob in DC.tblcarts
                        where ob.CartID == Convert.ToInt32(e.CommandArgument)
                        select ob).Single();
            data.Quantity += 1;
        }
        else if (e.CommandName == "itemDec")
        {
            var data = (from ob in DC.tblcarts
                        where ob.CartID == Convert.ToInt32(e.CommandArgument)
                        select ob).Single();
            if (data.Quantity == 1)
            {
                data.Quantity = 1;
            }
            else
            {
                data.Quantity -= 1;
            }
        }
        DC.SubmitChanges();
        binddata();
        binddata1();
        Response.Redirect(Request.RawUrl);

    }

    protected void repmeal_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        var DC = new DataClassesDataContext();
        if (e.CommandName == "diactiveMeal")
        {
            var data = (from ob in DC.tblcarts
                        where ob.CartID == Convert.ToInt32(e.CommandArgument)
                        select ob).Single();
            data.IsActive = false;
        }
        else if (e.CommandName == "itemInc")
        {
            var data = (from ob in DC.tblcarts
                        where ob.CartID == Convert.ToInt32(e.CommandArgument)
                        select ob).Single();
            data.Quantity += 1;
        }
        else if (e.CommandName == "itemDec")
        {
            var data = (from ob in DC.tblcarts
                        where ob.CartID == Convert.ToInt32(e.CommandArgument)
                        select ob).Single();
            if (data.Quantity == 1)
            {
                data.Quantity = 1;
            }
            else
            {
                data.Quantity -= 1;
            }
        }
        DC.SubmitChanges();
        binddata();
        binddata1();
        Response.Redirect(Request.RawUrl);
    }

    protected void btnClearCart_Click(object sender, EventArgs e)
    {
        var DC = new DataClassesDataContext();
        IQueryable<tblcart> Data = from obj in DC.tblcarts
                                   where obj.MACAddress == GetMACAddress()
                                   select obj;
        DC.tblcarts.DeleteAllOnSubmit(Data);
        DC.SubmitChanges();
        binddata();
        binddata1();
    }

    protected void btnCheckOut_Click(object sender, EventArgs e)
    {
        var DC = new DataClassesDataContext();
        if (Session["ClientID"] != null)
        {
            foreach (RepeaterItem item in repitem.Items)
            {
                CheckBox chk = (CheckBox)item.FindControl("chkItemSelect");
                if (chk.Checked == true)
                {
                    tblcart cartData = DC.tblcarts.Single(ob => ob.CartID == Convert.ToInt32(chk.Text));
                    tblitem itemData = DC.tblitems.Single(ob => ob.ItemID == cartData.ItemID);
                    tblOrder OrderData = new tblOrder();
                    OrderData.ClientID = Convert.ToInt32(Session["ClientID"]);
                    OrderData.Date = DateTime.Now;
                    OrderData.ItemID = cartData.ItemID;
                    OrderData.MACAddress = GetMACAddress();
                    OrderData.Qty = cartData.Quantity;
                    OrderData.TotalAmount = itemData.ItemPrice * cartData.Quantity;
                    OrderData.IsActive = false;
                    DC.tblOrders.InsertOnSubmit(OrderData);
                    DC.tblcarts.DeleteOnSubmit(cartData);
                }
            }
            foreach (RepeaterItem item in repmeal.Items)
            {
                CheckBox chk = (CheckBox)item.FindControl("chkItemSelect");
                if (chk.Checked)
                {
                    tblcart cartData = DC.tblcarts.Single(ob => ob.CartID == Convert.ToInt32(chk.Text));
                    tblMealPlan MealData = DC.tblMealPlans.Single(ob => ob.MealID == cartData.MealID);
                    tblOrder OrderData = new tblOrder();
                    OrderData.ClientID = Convert.ToInt32(Session["ClientID"]);
                    OrderData.Date = DateTime.Now;
                    OrderData.MealID = cartData.MealID;
                    OrderData.MACAddress = GetMACAddress();
                    OrderData.Qty = cartData.Quantity;
                    OrderData.TotalAmount = Convert.ToDecimal(MealData.MealPrice) * cartData.Quantity;
                    OrderData.IsActive = false;
                    DC.tblOrders.InsertOnSubmit(OrderData);
                    DC.SubmitChanges();
                    DC.tblcarts.DeleteOnSubmit(cartData);
                    DC.SubmitChanges();
                }
            }
            DC.SubmitChanges();
            binddata();
            binddata1();
        }
        else
        {
            Response.Redirect("ServiceLogin.aspx");
        }
    }



    protected void btnOrder_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrderDetail.aspx");
    }


}
