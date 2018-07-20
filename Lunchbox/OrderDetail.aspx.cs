using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.NetworkInformation;

public partial class OrderDetail : System.Web.UI.Page
{
    int TotalQuentity, TotalAmount = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ClientID"] == null)
        {
            Session["FromOrder"] = true;
            Response.Redirect("ServiceLogin.aspx");
        }
        if (!IsPostBack)
        {
            InitPage();
            binddata();
            var DC = new DataClassesDataContext();
            tblClient ClientData = DC.tblClients.Single(ob => ob.ClientID == Convert.ToInt32(Session["ClientID"]));
            txtfnm.Text = ClientData.FirstName;
            txtlnm.Text = ClientData.LastName;
            txtcontact.Text = ClientData.ContactNo;
            txtemail.Text = ClientData.Email;
            tblAddress AddressData = DC.tblAddresses.Single(ob => ob.AddressID == ClientData.AddressID);
            txtShippingAddress.Text = AddressData.Address;
            txtShippingAddressLandmark.Text = AddressData.Landmark;
            txtBillingAddress.Text = AddressData.Address;
            txtBillingAddressLandmark.Text = AddressData.Landmark;
            //hdnAddress.Value = AddressData.Address + ", " + AddressData.Landmark;
            bindCheckOutData();
            ltrTotalAmount.Text = TotalAmount.ToString();
            ltrTotalQty.Text = TotalQuentity.ToString();
            ltrTotalAmountO.Text = TotalAmount.ToString();
            ltrTotalQtyO.Text = TotalQuentity.ToString();
            Session["TotalAmount"] = TotalAmount;
        }

    }

    private void bindCheckOutData()
    {
        var DC = new DataClassesDataContext();
        var OrderMealData = from obj in DC.tblOrders
                            join obj1 in DC.tblMealPlans
                            on obj.MealID equals obj1.MealID
                            where obj.MACAddress == GetMACAddress() && obj.ClientID == Convert.ToInt32(Session["ClientID"]) && (obj.IsActive == false || obj.IsActive == null) && obj.MealID == obj1.MealID
                            select new
                            {
                                obj1.MealName,
                                obj.OrderID,
                                obj1.MealType,
                                obj1.MealPrice,
                                Image = (from obj2 in DC.tblImages
                                         where obj2.ImagesID == obj1.ImageID
                                         select obj2.Name).Single(),
                                obj.Qty
                            };
        rptchekoutinfo.DataSource = OrderMealData;
        rptchekoutinfo.DataBind();
        foreach (RepeaterItem data in rptchekoutinfo.Items)
        {
            Literal TP = (Literal)data.FindControl("ltrPrice");
            TextBox txtQty = (TextBox)data.FindControl("txtquan");
            TotalAmount += (Convert.ToInt32(TP.Text) * Convert.ToInt32(txtQty.Text));
            TotalQuentity += Convert.ToInt32(txtQty.Text);
        }
        var OrderItemData = from obj in DC.tblOrders
                            join obj1 in DC.tblitems
                            on obj.ItemID equals obj1.ItemID
                            where obj.MACAddress == GetMACAddress() && obj.ClientID == Convert.ToInt32(Session["ClientID"]) && (obj.IsActive == false || obj.IsActive == null) && obj.ItemID == obj1.ItemID
                            select new
                            {
                                obj1.ItemName,
                                obj.OrderID,
                                obj1.ItemType,
                                obj1.ItemPrice,
                                Image = (from obj2 in DC.tblImages
                                         where obj2.ImagesID == obj1.ImageID
                                         select obj2.Name).Single(),
                                obj.Qty
                            };
        rptItem.DataSource = OrderItemData;
        rptItem.DataBind();
        foreach (RepeaterItem data in rptItem.Items)
        {
            Literal TP = (Literal)data.FindControl("ltrPrice");
            TextBox txtQty = (TextBox)data.FindControl("txtquan");
            TotalAmount += (Convert.ToInt32(TP.Text) * Convert.ToInt32(txtQty.Text));
            TotalQuentity += Convert.ToInt32(txtQty.Text);
        }

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

        //int ID = Convert.ToInt32(Session["CartID"]);
        //tblcart st = (from u in DC.tblcarts
        //             where u.CartID == ID && u.ItemID == ID 
        //             select u).Single() ;




        var str = from obj in DC.tblOrders
                  where obj.MACAddress == GetMACAddress() && obj.ClientID == Convert.ToInt32(Session["ClientID"]) && (obj.IsActive == false || obj.IsActive == null) && obj.ItemID != null
                  select new
                  {

                      CN = (from ob in DC.tblitems
                            where ob.ItemID == obj.ItemID
                            select new
                            {
                                Data = ob.ItemName,

                            }).Take(1).SingleOrDefault().Data,

                      CNN = (from ob in DC.tblitems
                             where ob.ItemID == obj.ItemID
                             select new
                             {
                                 Data = Convert.ToInt32(ob.ItemPrice).ToString(),
                             }).Take(1).SingleOrDefault().Data,

                      Image = (from objImg in DC.tblImages
                               join objItem in DC.tblitems
                               on objImg.ImagesID equals objItem.ImageID
                               where objImg.ImagesID == objItem.ImageID && objItem.ItemID == obj.ItemID
                               select objImg.Name).Single(),

                      obj.OrderID,
                      obj.Qty
                  };

        DC.SubmitChanges();

        repcart.DataSource = str;
        repcart.DataBind();





        var strr = from obj in DC.tblOrders
                   where obj.MACAddress == GetMACAddress() && obj.ClientID == Convert.ToInt32(Session["ClientID"]) && (obj.IsActive == false || obj.IsActive == null) && obj.MealID != null
                   select new
                   {

                       mealnm = (from ob in DC.tblMealPlans
                                 where ob.MealID == obj.MealID
                                 select new
                                 {
                                     Data3 = ob.MealName
                                 }).Take(1).SingleOrDefault().Data3,

                       mealpri = (from ob in DC.tblMealPlans
                                  where ob.MealID == obj.MealID
                                  select new
                                  {
                                      Data3 = Convert.ToString(ob.MealPrice),
                                  }).Take(1).SingleOrDefault().Data3,
                       Image = (from objImg in DC.tblImages
                                join objItem in DC.tblMealPlans
                                on objImg.ImagesID equals objItem.ImageID
                                where objImg.ImagesID == objItem.ImageID && objItem.MealID == obj.MealID
                                select objImg.Name).Single(),
                       obj.OrderID,
                       obj.Qty
                   };

        DC.SubmitChanges();

        repca.DataSource = strr;
        repca.DataBind();
    }


    private void InitPage()
    {
        var db = new DataClassesDataContext();
        var Country = from obj in db.CountryMasters
                      select obj;
        ddlcountry.DataSource = Country;
        ddlcountry.DataTextField = "Name";
        ddlcountry.DataValueField = "ID";
        ddlcountry.DataBind();
        ddlcountry.Items.Insert(0, new ListItem("Select Country", ""));
    }

    protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        var db = new DataClassesDataContext();
        int Country = Convert.ToInt32(ddlcountry.SelectedItem.Value);
        var states = from obj in db.StateMasters
                     where obj.CountryID == Country
                     select obj;
        ddlstate.DataSource = states;
        ddlstate.DataTextField = "Name";
        ddlstate.DataValueField = "ID";
        ddlstate.DataBind();
        ddlstate.Items.Insert(0, new ListItem("Select State", ""));
    }

    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        var db = new DataClassesDataContext();
        int State = Convert.ToInt32(ddlstate.SelectedItem.Value);
        var Cities = from obj in db.CityMasters
                     where obj.StateID == State
                     select obj;
        ddlcity.DataSource = Cities;
        ddlcity.DataTextField = "Name";
        ddlcity.DataValueField = "ID";
        ddlcity.DataBind();
        ddlcity.Items.Insert(0, new ListItem("Select City", ""));
    }

    //protected void btncontinue_Click(object sender, EventArgs e)
    //{
    //    using (DataClassesDataContext data = new DataClassesDataContext())
    //    {
    //        var DC = new DataClassesDataContext();
    //        int ID = Convert.ToInt32(Session["ClientID"]);
    //        int count = (from u in DC.tblClients
    //                     where u.ClientID == ID && u.Email == txtemail.Text
    //                     select u).Count();
    //        if (count > 0)
    //        {
    //            tblClient result1 = (from u in DC.tblClients
    //                                 where u.ClientID == ID && u.Email == txtemail.Text
    //                                 select u).Single();
    //            result1.Email = txtemail.Text;
    //            DC.SubmitChanges();

    //        }





    //        //tblAddress add = new tblAddress()
    //        //{
    //        //    CityID = ddlcity.SelectedIndex
    //        //};
    //        //data.tblAddresses.InsertOnSubmit(add);
    //        //data.SubmitChanges();


    //        tblOrder ad = new tblOrder()
    //        {

    //            ShippingAddress = txtshiadd.Text,
    //            BillingAddress = txtbiladd.Text,
    //            Date = DateTime.Now
    //        };
    //        data.tblOrders.InsertOnSubmit(ad);
    //        data.SubmitChanges();







    //        //using (DataClassesDataContext data = new DataClassesDataContext())
    //        //{
    //        // tblAddress add = new tblAddress()
    //        //{

    //        //    Landmark = txtlnm.Text,
    //        //    PincodeNo = txtpin.Text ,
    //        //    IsActive = true ,
    //        //    CityID = ddlcity.SelectedIndex
    //        //};
    //        //data.tblAddresses.InsertOnSubmit(add);
    //        //data.SubmitChanges();

    //        //tblClient user = new tblClient
    //        //{
    //        //    AddressID = add.AddressID,
    //        //    FirstName = txtfnm.Text,
    //        //    LastName = txtlnm.Text,
    //        //    Email = txtemail .Text ,
    //        //    ContactNo = txtcontact.Text,
    //        //    VerifyBy = 1,
    //        //    IsActive = true,
    //        //    CreatedOn = DateTime.Now,

    //        //};

    //        //data.tblClients.InsertOnSubmit(user);
    //        //data.SubmitChanges();

    //        //tblOrder ad = new tblOrder()
    //        //{

    //        //    ShippingAddress = txtshiadd.Text,
    //        //    BillingAddress = txtbiladd.Text
    //        //};
    //        //data.tblOrders.InsertOnSubmit(ad);
    //        //data.SubmitChanges();


    //        //Response.Redirect("Home.aspx");
    //    }

    //}

    protected void chkisrecurring_CheckedChanged(object sender, EventArgs e)
    {
        if (chkisrecurring.Checked == true)
        {

            panelPlanSelection.Visible = true;

            //lblselected.Text = ddlrecurringtype.SelectedValue;
        }
        else
        {
            panelPlanSelection.Visible = false;
        }
    }

    protected void rdPlan_CheckedChanged(object sender, EventArgs e)
    {
        if (rdPlan.Checked)
        {
            panelPlan.Visible = true;
            panelCustom.Visible = false;
        }

    }

    protected void rdCustom_CheckedChanged(object sender, EventArgs e)
    {
        if (rdCustom.Checked)
        {
            panelPlan.Visible = false;
            panelCustom.Visible = true;
        }
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        TimeSpan time = Convert.ToDateTime(TextBox1.Text) - DateTime.Now;
        if (time.TotalDays < -1)
        {
            errorPlan.Text = "Please Enter Propre Date.";
            Label6.Text = "";
            errorPlan.Visible = true;
        }
        else
        {
            if (DropDownList1.SelectedValue == "")
            {
                errorPlan.Text = "Please First Select Days.";
                errorPlan.Visible = true;
            }
            else
            {
                errorPlan.Visible = false;
                if (DropDownList1.SelectedValue == "1")
                {
                    Label6.Text = Convert.ToDateTime(TextBox1.Text).AddDays(7).ToShortDateString();
                }
                else if (DropDownList1.SelectedValue == "2")
                {
                    Label6.Text = Convert.ToDateTime(TextBox1.Text).AddDays(15).ToShortDateString();
                }
                else if (DropDownList1.SelectedValue == "3")
                {
                    Label6.Text = Convert.ToDateTime(TextBox1.Text).AddDays(30).ToShortDateString();
                }
            }
        }

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (TextBox1.Text != null)
        {
            if (DropDownList1.SelectedValue == "1")
            {
                Label6.Text = Convert.ToDateTime(TextBox1.Text).AddDays(7).ToShortDateString();
            }
            else if (DropDownList1.SelectedValue == "2")
            {
                Label6.Text = Convert.ToDateTime(TextBox1.Text).AddDays(15).ToShortDateString();
            }
            else if (DropDownList1.SelectedValue == "3")
            {
                Label6.Text = Convert.ToDateTime(TextBox1.Text).AddDays(30).ToShortDateString();
            }
        }
    }

    protected void btnplace_Click(object sender, EventArgs e)
    {

        var DC = new DataClassesDataContext();
        if (chkisrecurring.Checked)
        {
            if (rdPlan.Checked)
            {
                foreach (RepeaterItem item in repcart.Items)
                {
                    int cnt = 0;
                    HiddenField hdn = (HiddenField)item.FindControl("hdnOrder");
                    var Data = DC.tblOrders.Single(ob => ob.OrderID == Convert.ToInt32(hdn.Value));
                    DateTime StartDate = Convert.ToDateTime(TextBox1.Text);
                    DateTime EndDate = Convert.ToDateTime(Label6.Text);
                    while (StartDate.AddDays(1) <= EndDate)
                    {
                        if (cnt == 0)
                        {
                            tblOrder OrderItemData = DC.tblOrders.Single(ob => ob.OrderID == Convert.ToInt32(hdn.Value));
                            OrderItemData.Date = StartDate.AddDays(1);
                            OrderItemData.IsRecurring = true;
                            OrderItemData.IsActive = false;
                            DC.SubmitChanges();
                            StartDate = StartDate.AddDays(1);
                            cnt++;
                        }
                        else
                        {
                            tblOrder OrderData = new tblOrder();
                            OrderData.ClientID = Data.ClientID;
                            OrderData.BillingAddress = Data.BillingAddress;
                            OrderData.Date = StartDate.AddDays(1);
                            OrderData.IsRecurring = true;
                            OrderData.IsActive = false;
                            OrderData.IsOrder = true;
                            OrderData.ItemID = Data.ItemID;
                            OrderData.MACAddress = Data.MACAddress;
                            OrderData.Qty = Data.Qty;
                            OrderData.ShippingAddress = Data.ShippingAddress;
                            OrderData.TotalAmount = Data.TotalAmount;
                            DC.tblOrders.InsertOnSubmit(OrderData);
                            DC.SubmitChanges();
                            StartDate = StartDate.AddDays(1);
                        }
                    }


                }
                foreach (RepeaterItem item in repca.Items)
                {
                    int cnt = 0;
                    HiddenField hdn = (HiddenField)item.FindControl("hdnOrder");
                    var Data = DC.tblOrders.Single(ob => ob.OrderID == Convert.ToInt32(hdn.Value));
                    DateTime StartDate = Convert.ToDateTime(TextBox1.Text);
                    DateTime EndDate = Convert.ToDateTime(Label6.Text);
                    while (StartDate.AddDays(1) <= EndDate)
                    {
                        if (cnt == 0)
                        {
                            tblOrder OrderItemData = DC.tblOrders.Single(ob => ob.OrderID == Convert.ToInt32(hdn.Value));
                            OrderItemData.Date = StartDate.AddDays(1);
                            OrderItemData.IsRecurring = true;
                            OrderItemData.IsActive = false;
                            DC.SubmitChanges();
                            StartDate = StartDate.AddDays(1);
                            cnt++;
                        }
                        else
                        {
                            tblOrder OrderData = new tblOrder();
                            OrderData.ClientID = Data.ClientID;
                            OrderData.BillingAddress = Data.BillingAddress;
                            OrderData.Date = StartDate.AddDays(1);
                            OrderData.IsRecurring = true;
                            OrderData.IsActive = false;
                            OrderData.MealID = Data.MealID;
                            OrderData.MACAddress = Data.MACAddress;
                            OrderData.Qty = Data.Qty;
                            OrderData.ShippingAddress = Data.ShippingAddress;
                            OrderData.TotalAmount = Data.TotalAmount;
                            DC.tblOrders.InsertOnSubmit(OrderData);
                            DC.SubmitChanges();
                            StartDate = StartDate.AddDays(1);
                        }
                    }

                }
            }
            else if (rdCustom.Checked)
            {
                foreach (RepeaterItem item in repcart.Items)
                {
                    int cnt = 0;
                    HiddenField hdn = (HiddenField)item.FindControl("hdnOrder");
                    var Data = DC.tblOrders.Single(ob => ob.OrderID == Convert.ToInt32(hdn.Value));
                    DateTime StartDate = Convert.ToDateTime(txtstartdate.Text);
                    DateTime EndDate = Convert.ToDateTime(txtenddate.Text);
                    while (StartDate.AddDays(1) <= EndDate)
                    {
                        if (cnt == 0)
                        {
                            tblOrder OrderItemData = DC.tblOrders.Single(ob => ob.OrderID == Convert.ToInt32(hdn.Value));
                            OrderItemData.Date = StartDate.AddDays(1);
                            OrderItemData.IsRecurring = true;
                            OrderItemData.IsActive = false;
                            DC.SubmitChanges();
                            StartDate = StartDate.AddDays(1);
                            cnt++;
                        }
                        else
                        {
                            tblOrder OrderData = new tblOrder();
                            OrderData.ClientID = Data.ClientID;
                            OrderData.BillingAddress = Data.BillingAddress;
                            OrderData.Date = StartDate.AddDays(1);
                            OrderData.IsRecurring = true;
                            OrderData.IsActive = false;
                            OrderData.ItemID = Data.ItemID;
                            OrderData.MACAddress = Data.MACAddress;
                            OrderData.Qty = Data.Qty;
                            OrderData.ShippingAddress = Data.ShippingAddress;
                            OrderData.TotalAmount = Data.TotalAmount;
                            DC.tblOrders.InsertOnSubmit(OrderData);
                            DC.SubmitChanges();
                            StartDate = StartDate.AddDays(1);
                        }
                    }

                }
                foreach (RepeaterItem item in repca.Items)
                {
                    int cnt = 0;
                    HiddenField hdn = (HiddenField)item.FindControl("hdnOrder");
                    var Data = DC.tblOrders.Single(ob => ob.OrderID == Convert.ToInt32(hdn.Value));
                    DateTime StartDate = Convert.ToDateTime(txtstartdate.Text);
                    DateTime EndDate = Convert.ToDateTime(txtenddate.Text);
                    while (StartDate.AddDays(1) <= EndDate)
                    {
                        if (cnt == 0)
                        {
                            tblOrder OrderItemData = DC.tblOrders.Single(ob => ob.OrderID == Convert.ToInt32(hdn.Value));
                            OrderItemData.Date = StartDate.AddDays(1);
                            OrderItemData.IsRecurring = true;
                            OrderItemData.IsActive = false;
                            DC.SubmitChanges();
                            StartDate = StartDate.AddDays(1);
                            cnt++;
                        }
                        else
                        {
                            tblOrder OrderData = new tblOrder();
                            OrderData.ClientID = Data.ClientID;
                            OrderData.BillingAddress = Data.BillingAddress;
                            OrderData.Date = StartDate.AddDays(1);
                            OrderData.IsRecurring = true;
                            OrderData.IsActive = false;
                            OrderData.MealID = Data.MealID;
                            OrderData.MACAddress = Data.MACAddress;
                            OrderData.Qty = Data.Qty;
                            OrderData.ShippingAddress = Data.ShippingAddress;
                            OrderData.TotalAmount = Data.TotalAmount;
                            DC.tblOrders.InsertOnSubmit(OrderData);
                            DC.SubmitChanges();
                            StartDate = StartDate.AddDays(1);
                        }
                    }
                }
            }
        }
        else
        {
            foreach (RepeaterItem item in repcart.Items)
            {
                HiddenField hdn = (HiddenField)item.FindControl("hdnOrder");
                tblOrder OrderItemData = DC.tblOrders.Single(ob => ob.OrderID == Convert.ToInt32(hdn.Value));
                OrderItemData.Date = DateTime.Now;
                OrderItemData.IsRecurring = true;
                DC.SubmitChanges();
            }
            foreach (RepeaterItem item in repca.Items)
            {
                HiddenField hdn = (HiddenField)item.FindControl("hdnOrder");
                tblOrder OrderItemData = DC.tblOrders.Single(ob => ob.OrderID == Convert.ToInt32(hdn.Value));
                OrderItemData.Date = DateTime.Now;
                OrderItemData.IsRecurring = true;
                DC.SubmitChanges();
            }
        }
    }


    protected void chekoutinfo_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        var DC = new DataClassesDataContext();
        if (e.CommandName == "itemInc")
        {
            tblOrder OrderData = DC.tblOrders.Single(ob => ob.OrderID == Convert.ToInt32(e.CommandArgument));
            OrderData.Qty += 1;
        }
        else if (e.CommandName == "itemDec")
        {
            tblOrder OrderData = DC.tblOrders.Single(ob => ob.OrderID == Convert.ToInt32(e.CommandArgument));
            if (OrderData.Qty == 1)
            {
                OrderData.Qty = 1;
            }
            else
            {
                OrderData.Qty -= 1;
            }

        }
        else if (e.CommandName == "DeleteItem")
        {
            tblOrder OrderData = DC.tblOrders.Single(ob => ob.OrderID == Convert.ToInt32(e.CommandArgument));
            DC.tblOrders.DeleteOnSubmit(OrderData);
        }
        DC.SubmitChanges();
        bindCheckOutData();
    }

    protected void rptItem_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        var DC = new DataClassesDataContext();
        if (e.CommandName == "itemInc")
        {
            tblOrder OrderData = DC.tblOrders.Single(ob => ob.OrderID == Convert.ToInt32(e.CommandArgument));
            OrderData.Qty += 1;
        }
        else if (e.CommandName == "itemDec")
        {
            tblOrder OrderData = DC.tblOrders.Single(ob => ob.OrderID == Convert.ToInt32(e.CommandArgument));
            if (OrderData.Qty == 1)
            {
                OrderData.Qty = 1;
            }
            else
            {
                OrderData.Qty -= 1;
            }
        }
        else if (e.CommandName == "DeleteItem")
        {
            tblOrder OrderData = DC.tblOrders.Single(ob => ob.OrderID == Convert.ToInt32(e.CommandArgument));
            DC.tblOrders.DeleteOnSubmit(OrderData);
        }
        DC.SubmitChanges();
        bindCheckOutData();
    }

    protected void btnCheckOut_Click(object sender, EventArgs e)
    {

    }

    protected void btnSubmitAddress_Click(object sender, EventArgs e)
    {
        var DC = new DataClassesDataContext();
        var OrderData = from obj in DC.tblOrders
                        where obj.MACAddress == GetMACAddress() && obj.ClientID == Convert.ToInt32(Session["ClientID"]) && (obj.IsActive == false || obj.IsActive == null)
                        select obj;
        foreach (tblOrder OrderRecord in OrderData)
        {
            OrderRecord.ShippingAddress = txtShippingAddress.Text + ", " + txtShippingAddressLandmark.Text + ", " + ddlcity.SelectedItem.Text + ", " + ddlstate.SelectedItem.Text + ", " + ddlcountry.SelectedItem.Text + "-" + txtZipCode.Text;
            OrderRecord.BillingAddress = txtBillingAddress.Text + ", " + txtBillingAddressLandmark.Text + ", " + ddlcity.SelectedItem.Text + ", " + ddlstate.SelectedItem.Text + ", " + ddlcountry.SelectedItem.Text + "-" + txtZipCode.Text;
        }
        DC.SubmitChanges();

        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "collapse", "$('#collapseThree').modal({backdrop:'static', keyboard: false});", true);

        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "collapse", "$('#collapseThree').load('OrderDetail.aspx #collapseThree');", true);

        //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "callThree()", true);

        //if (txtBillingAddress.Text.Count() > 5 && txtBillingAddressLandmark.Text.Count() > 5)
        //{
        //    tblAddress AddressData = new tblAddress();
        //    AddressData.Address = txtBillingAddress.Text;
        //    AddressData.Landmark = txtBillingAddressLandmark.Text;
        //    AddressData.CityID = Convert.ToInt32(ddlcity.SelectedValue);
        //    AddressData.PincodeNo = txtZipCode.Text;
        //    DC.tblAddresses.InsertOnSubmit(AddressData);
        //    tblAddress AddData = (from obj in DC.tblAddresses
        //                          orderby obj.AddressID descending
        //                          select obj).Single();
        //    var OrderData = from obj in DC.tblOrders
        //                    where obj.MACAddress == GetMACAddress() && obj.ClientID == Convert.ToInt32(Session["ClientID"]) && (obj.IsActive == false || obj.IsActive == null)
        //                    select obj;
        //    foreach (tblOrder OrderRecord in OrderData)
        //    {
        //        OrderRecord.BillingAddress = AddData.AddressID;
        //    }
        //}
        //else if (txtShippingAddress.Text.Count() > 5 && txtShippingAddress.Text.Count() > 5)
        //{
        //    tblAddress AddressData = new tblAddress();
        //    AddressData.Address = txtShippingAddress.Text;
        //    AddressData.Landmark = txtShippingAddressLandmark.Text;
        //    AddressData.CityID = Convert.ToInt32(ddlcity.SelectedValue);
        //    AddressData.PincodeNo = txtZipCode.Text;
        //    DC.tblAddresses.InsertOnSubmit(AddressData);
        //}


    }

    //protected void lnkChangeShippingAddress_Click(object sender, EventArgs e)
    //{
    //    txtShippingAddress.Visible = true;
    //    txtShippingAddressLandmark.Visible = true;
    //    ltrshiadd.Visible = false;
    //    lnkChangeShippingAddress.Visible = false;
    //}

    //protected void lnkChangeBillingAddress_Click(object sender, EventArgs e)
    //{
    //    txtBillingAddress.Visible = true;
    //    txtBillingAddressLandmark.Visible = true;
    //    ltrbiladd.Visible = false;
    //    lnkChangeBillingAddress.Visible = false;
    //}







    protected void txtstartdate_TextChanged(object sender, EventArgs e)
    {
        TimeSpan time = Convert.ToDateTime(txtstartdate.Text) - DateTime.Now;
        if (time.TotalDays < -1)
        {
            errorPlan1.Text = "Please Enter Propre Date.";
            errorPlan1.Visible = true;
        }
        else
        {
            errorPlan1.Visible = false;
        }
    }

    protected void check2_Click(object sender, EventArgs e)
    {
        Session["Amount"] = Session["TotalAmount"];
        Session["FirstName"] = txtfnm.Text + txtlnm.Text;
        Session["Email"] = txtemail.Text;
        Session["PhoneNo"] = txtcontact.Text;
        Session["ProductInfo"] = "Lunch Box Order";
        Session["SuccessURL"] = "http://localhost:58118/Success.aspx";
        Session["FailureURL"] = "http://localhost:58118/Success.aspx";
        Response.Redirect("PayU/Default.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        var DC = new DataClassesDataContext();
        IQueryable<tblOrder> str = from obj in DC.tblOrders
                                   where obj.MACAddress == GetMACAddress() && obj.ClientID == Convert.ToInt32(Session["ClientID"]) && (obj.IsActive == false || obj.IsActive == null) && obj.ItemID != null
                                   select obj;
        foreach (tblOrder item in str)
        {
            tblRate RateData = new tblRate();
            RateData.FoodID = Convert.ToInt32(item.ItemID);
            RateData.IsItem = true;
            RateData.Point = Convert.ToInt32(txtRate.Value);
            RateData.CreatedOn = DateTime.Now;
            DC.tblRates.InsertOnSubmit(RateData);
            DC.SubmitChanges();
        }

        IQueryable<tblOrder> str1 = from obj in DC.tblOrders
                                    where obj.MACAddress == GetMACAddress() && obj.ClientID == Convert.ToInt32(Session["ClientID"]) && (obj.IsActive == false || obj.IsActive == null) && obj.MealID != null
                                    select obj;
        foreach (tblOrder item in str1)
        {
            tblRate RateData = new tblRate();
            RateData.FoodID = Convert.ToInt32(item.MealID);
            RateData.IsItem = false;
            RateData.Point = Convert.ToInt32(txtRate.Value);
            RateData.CreatedOn = DateTime.Now;
            DC.tblRates.InsertOnSubmit(RateData);
            DC.SubmitChanges();
        }
    }
}