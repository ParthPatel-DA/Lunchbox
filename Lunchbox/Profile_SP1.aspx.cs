﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.NetworkInformation;

public partial class Profile_SP : System.Web.UI.Page
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

    static int TotalAmount, temp = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try { 
        //divMealMenu.Visible = true;
        //divMeal.Visible = true;
        if (!IsPostBack)
        {

            if (Session["ViewServiceProviderID"] != null)
            {
                Session["ServiceProviderID"] = Session["ViewServiceProviderID"];
                lnkHome.Visible = false;
                FileUpload3.Enabled = false;
                lnkOrder.Visible = false;
                divClientSidePanel.Visible = true;
                divSPSidePanel.Visible = false;
                divTodayStatus.Visible = false;
                var DC = new DataClassesDataContext();

                lnkbtnChangePwd.Visible = false;
                lnkEditProfile.Visible = false;
                var MealData = from obj in DC.tblMealPlans
                               where obj.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"]) && obj.IsActive == true && obj.TodaySpacial == true
                               select obj;
                rptClientSidePanel.DataSource = MealData;
                rptClientSidePanel.DataBind();
                foreach (RepeaterItem item in rptClientSidePanel.Items)
                {
                    HiddenField hdn = (HiddenField)item.FindControl("hdnImageID");
                    Image imgItem = (Image)item.FindControl("Image1");
                    tblImage imgName = DC.tblImages.Single(ob => ob.ImagesID == Convert.ToInt32(hdn.Value));
                    imgItem.ImageUrl = "ServiceProvider/Meal/" + imgName.Name;
                }
                var SPData = GetSPData();
                ltrSPName.Text = SPData.CompanyName;
                string ImageName = (from obj in DC.tblImages
                                    where obj.ImagesID == SPData.ImageID
                                    select obj.Name).Single();
                imgSPImage.ImageUrl = "ServiceProvider/Upload/" + ImageName;
                divLogout.Visible = false;
                divCart.Visible = true;
                btnAddMeal.Visible = false;
                btnAddMenu.Visible = false;
                BindMeal();
                binddata();
                binddata1();
            }
            else if (Session["ServiceProviderID"] != null)
            {
                divClientSidePanel.Visible = false;
                divSPSidePanel.Visible = true;
                divTodayStatus.Visible = true;
                divCart.Visible = false;
                BindData();
                LinkButton10.Visible = false;

            }
        }
        if (Session["ServiceProviderID"] == null)
        {
            Response.Redirect("ServiceLogin.aspx");
        }

        FileUpload3.Attributes["onchange"] = "UploadFile(this)";
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    private void DataClear()
    {
        try { 
        txtaddmnm.Text = "";
        txtItemDesc.Text = "";
        txtItemDescription1.Text = "";
        txtItemName.Text = "";
        txtItemName1.Text = "";
        txtItemPrice.Text = "";
        txtItemPrice1.Text = "";
        txtmdes.Text = "";
        txtmnm.Text = "";
        txtmprice.Text = "";
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void Upload(object sender, EventArgs e)
    {
        try { 
        var DC = new DataClassesDataContext();
        FileUpload3.SaveAs(Server.MapPath("ServiceProvider/Upload/" + FileUpload3.FileName));

        tblImage Data = new tblImage();
        Data.Name = FileUpload3.FileName;
        Data.IsActive = true;
        Data.CreatedOn = DateTime.Now;
        Data.AlbumID = 3;
        DC.tblImages.InsertOnSubmit(Data);
        DC.SubmitChanges();
        tblImage imgData = (from obj in DC.tblImages
                            orderby obj.ImagesID descending
                            select obj).First();
        tblServiceProvider SPData = DC.tblServiceProviders.Single(ob => ob.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"]));
        SPData.ImageID = imgData.ImagesID;
        DC.SubmitChanges();
        Response.Redirect("Profile_SP.aspx");
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    public string GetMACAddress()
    {
        try { 
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
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    private void BindData()
    {
        try { 
        OpenHomePanel();
        var DC = new DataClassesDataContext();
        var SPData = GetSPData();
        ltrSPName.Text = SPData.CompanyName;
        ltrServiceProviderName.Text = SPData.FirstName + " " + SPData.LastName;
        string ImageName = (from obj in DC.tblImages
                            where obj.ImagesID == SPData.ImageID
                            select obj.Name).Single();
        imgSPImage.ImageUrl = "ServiceProvider/Upload/" + ImageName;

        int cnt = (from obj in DC.tblPackages
                   join obj2 in DC.tblSPPackages
                   on obj.PackagesID equals obj2.PackagesId
                   where obj2.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"]) && obj2.IsActive == true
                   select new
                   {
                       PackName = obj.Name,
                       StartDate = obj2.Start_Date,
                       EndDate = obj2.End_Date
                   }).Count();

        if (cnt > 0)
        {
            var PackData = (from obj in DC.tblPackages
                            join obj2 in DC.tblSPPackages
                            on obj.PackagesID equals obj2.PackagesId
                            where obj2.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"]) && obj2.IsActive == true
                            select new
                            {
                                PackName = obj.Name,
                                StartDate = obj2.Start_Date,
                                EndDate = obj2.End_Date
                            }).Single();
            lblPackName.Text = PackData.PackName;
            lblStartDate.Text = Convert.ToDateTime(PackData.StartDate).ToShortDateString();
            lblEndDate.Text = Convert.ToDateTime(PackData.EndDate).ToShortDateString();
            divPackage.Visible = true;
        }


        // Count Of Lunch, Dinner & Total Amount

        //int LunchOrder = (from obj in DC.tblMenuDetails
        //                  join obj2 in DC.tblitems
        //                  on obj.MenuID equals obj2.MenuID
        //                  join obj3 in DC.tblcarts
        //                  on obj2.ItemID equals obj3.ItemID
        //                  join obj4 in DC.tblOrders
        //                  on obj3.CartID equals obj4.CartID
        //                  where obj.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"]) && obj2.Time == 1 && obj4.Date == DateTime.Now.Date
        //                  select obj4.OrderID).Count();
        //lblLunchOrder.Text = LunchOrder.ToString();

        // Today Meal Order

        var MealDate = from obj in DC.tblMealPlans
                       join obj3 in DC.tblOrders
                       on obj.MealID equals obj3.MealID
                       where obj.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"]) && obj3.Date == DateTime.Now.Date
                       select new
                       {
                           MealName = obj.MealName,
                           MealPrice = obj.MealPrice,
                           Time = obj.Time,
                           Qty = obj3.Qty,
                           OrderID = obj3.OrderID,
                           OrderStatus = obj3.IsOrder
                       };
        rptTodayMealOrder.DataSource = MealDate;
        rptTodayMealOrder.DataBind();

        var MenuDate = from obj in DC.tblMenuDetails
                       join obj2 in DC.tblitems
                       on obj.MenuID equals obj2.MenuID
                       join obj4 in DC.tblOrders
                       on obj2.ItemID equals obj4.ItemID
                       where obj.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"]) && obj4.Date == DateTime.Now.Date
                       select new
                       {
                           ItemName = obj2.ItemName,
                           ItemPrice = obj2.ItemPrice,
                           Time = obj2.Time,
                           Qty = obj4.Qty,
                           OrderID = obj4.OrderID,
                           OrderStatus = obj4.IsOrder
                       };
        rptTodayMenuOrder.DataSource = MenuDate;
        rptTodayMenuOrder.DataBind();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    private tblServiceProvider GetSPData()
    {
        try { 
        var DC = new DataClassesDataContext();
        tblServiceProvider Data = (from obj in DC.tblServiceProviders
                                   where obj.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"])
                                   select obj).Single();
        return Data;
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    private void OpenHomePanel()
    {
        try { 
        AddMeal.Visible = false;
        AddMenu.Visible = false;
        divHome.Visible = true;
        //divTodayStatus.Visible = true;
        divTodayOrder.Visible = true;
        divMenu.Visible = false;
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void lnkaddmenu_Click(object sender, EventArgs e)
    {
        try { 
        lnkaddmenu.Visible = false;
        Panel1.Visible = true;
        ddlMenu.SelectedValue = null;
        ddlMenu.Visible = false;
        lblMenu.Visible = false;
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }



    protected void ddlMenu_SelectedIndexChanged(object sender, EventArgs e)
    {

        try { 
        if (ddlMenu.SelectedIndex == 0)
        {
            divItem.Visible = false;
            lnkaddmenu.Visible = true;
        }
        else
        {
            divItem.Visible = true;
            lnkaddmenu.Visible = false;
        }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }



    protected void lnkmeal_Click(object sender, EventArgs e)
    {
        try { 
        BindMeal();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    private void BindMeal()
    {
        try { 
        divHome.Visible = true;
        divItem.Visible = false;
        divOrder.Visible = false;
        divProfile.Visible = false;
        divTodayOrder.Visible = false;
        //divTodayStatus.Visible = true;
        divMeal.Visible = true;
        AddMenu.Visible = false;
        divMenu.Visible = false;

        var DC = new DataClassesDataContext();
        if (Session["ViewServiceProviderID"] != null)
        {
            var MealData = from obj in DC.tblMealPlans
                           where obj.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"]) && obj.IsActive == true && (obj.MealStatus == false || obj.MealStatus == null)
                           select obj;
            rptSPMeal.DataSource = MealData;
            rptSPMeal.DataBind();
        }
        else
        {
            var MealData = from obj in DC.tblMealPlans
                           where obj.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"]) && obj.IsActive == true
                           select obj;
            rptSPMeal.DataSource = MealData;
            rptSPMeal.DataBind();
        }


        foreach (RepeaterItem item in rptSPMeal.Items)
        {
            HiddenField hdn = (HiddenField)item.FindControl("hdnImageID");
            Image img = (Image)item.FindControl("imgMealImage");
            LinkButton lnkHideMeal = (LinkButton)item.FindControl("lnkHideMeal");
            LinkButton lnkShowMeal = (LinkButton)item.FindControl("lnkShowMeal");
            LinkButton lnkMakeSpacial = (LinkButton)item.FindControl("lnkMakeSpacial");
            LinkButton lnkRemoveSpacial = (LinkButton)item.FindControl("lnkRemoveSpacial");
            LinkButton lnkDeleteItem = (LinkButton)item.FindControl("lnkDeleteItem");
            LinkButton lnkShowEditerItem = (LinkButton)item.FindControl("lnkShowEditerItem");
            HiddenField hdnSpacial = (HiddenField)item.FindControl("hdnSpacial");
            HiddenField hdnMealStatus = (HiddenField)item.FindControl("hdnMealStatus");
            LinkButton lnkCart = (LinkButton)item.FindControl("LinkButton10");
            tblImage imgName = DC.tblImages.Single(ob => ob.ImagesID == Convert.ToInt32(hdn.Value));
            img.ImageUrl = "ServiceProvider/Meal/" + imgName.Name;
            if (hdnSpacial.Value == "True")
            {
                lnkRemoveSpacial.Visible = false;
                lnkMakeSpacial.Visible = true;
            }
            else
            {
                lnkRemoveSpacial.Visible = true;
                lnkMakeSpacial.Visible = false;
            }
            if (hdnMealStatus.Value == "True")
            {
                lnkHideMeal.Visible = true;
                lnkShowMeal.Visible = false;
            }
            else
            {
                lnkHideMeal.Visible = false;
                lnkShowMeal.Visible = true;
            }

            if (Session["ViewServiceProviderID"] != null)
            {
                lnkRemoveSpacial.Visible = false;
                lnkMakeSpacial.Visible = false;
                lnkHideMeal.Visible = false;
                lnkShowMeal.Visible = false;
                lnkDeleteItem.Visible = false;
                lnkShowEditerItem.Visible = false;
            }
            else
            {
                lnkCart.Visible = false;
            }
        }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void lnkmenu_Click(object sender, EventArgs e)
    {
        try {
            BindMenu();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    private void BindMenu()
    {
        try { 
        divHome.Visible = true;
        divItem.Visible = false;
        divOrder.Visible = false;
        divProfile.Visible = false;
        divTodayOrder.Visible = false;
        //divTodayStatus.Visible = true;
        divMeal.Visible = false;
        AddMenu.Visible = false;
        divMenu.Visible = true;
        AddMeal.Visible = false;

        var DC = new DataClassesDataContext();
        if (Session["EmpID"] != null)
        {
            var MenuData = from obj in DC.tblMenuDetails
                           where obj.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"])
                           select obj;
            rptSPMenu.DataSource = MenuData;
            rptSPMenu.DataBind();

            foreach (RepeaterItem item in rptSPMenu.Items)
            {
                HiddenField hdn = (HiddenField)item.FindControl("hdnImageID");
                HiddenField hdnMenuID = (HiddenField)item.FindControl("hdnMenuID");
                Repeater rptItemList = (Repeater)item.FindControl("rptItemList");
                Repeater rptItem = (Repeater)item.FindControl("rptItem");


                Image img = (Image)item.FindControl("imgMenuImage");
                tblImage imgName = DC.tblImages.Single(ob => ob.ImagesID == Convert.ToInt32(hdn.Value));
                img.ImageUrl = "ServiceProvider/Menu/" + imgName.Name;
                LinkButton lnkDeleteItem = (LinkButton)item.FindControl("lnkDeleteItem");
                LinkButton lnkShowEditerItem = (LinkButton)item.FindControl("lnkShowEditerItem");
                if (Session["ClientID"] != null)
                {
                    lnkDeleteItem.Visible = false;
                    lnkShowEditerItem.Visible = false;
                }
                else
                {

                }
                var ItemList = from obj in DC.tblitems
                               join obj2 in DC.tblImages
                               on obj.ImageID equals obj2.ImagesID
                               where obj.MenuID == Convert.ToInt32(hdnMenuID.Value) && obj.ImageID == obj2.ImagesID && obj.Isactive == true && (obj.ItemStatus == true || obj.ItemStatus == null)
                               select new
                               {
                                   Name = obj2.Name,
                                   ItemID = obj.ItemID
                               };

                rptItemList.DataSource = ItemList;
                rptItemList.DataBind();

                Panel panelMenu = (Panel)item.FindControl("PanelMenuData");
                if (rptItemList.Items.Count <= 0)
                {
                    panelMenu.Visible = false;
                }

                //foreach (RepeaterItem item1 in rptItemList.Items)
                //{
                //    Image img1 = (Image)item1.FindControl("imgItemImage");
                //    HiddenField hdnImgName = (HiddenField)item1.FindControl("hdnImageName");
                //    img1.ImageUrl = "ServiceProvider/Iteam/" + hdnImgName.Value;
                //}

                //tblitem Items = (from obj in DC.tblitems
                //            join obj2 in DC.tblImages
                //            on obj.ImageID equals obj2.ImagesID
                //            where obj.MenuID == Convert.ToInt32(hdnMenuID.Value) && obj.ImageID == obj2.ImagesID
                //            select obj).FirstOrDefault();

                //Image imgItem = (Image)item.FindControl("imgItem");
                //tblImage imgItemName = (from obj in DC.tblitems
                //                  join obj2 in DC.tblImages
                //                  on obj.ImageID equals obj2.ImagesID
                //                  where obj.MenuID == Convert.ToInt32(hdnMenuID.Value) && obj.ImageID == obj2.ImagesID
                //                  select obj2).FirstOrDefault();
                //imgItem.ImageUrl = "ServiceProvider/Iteam/" + imgItemName.Name;
                //Literal ltrItemName = (Literal)item.FindControl("ltrItemName");
                //Literal ltrItemPrice = (Literal)item.FindControl("ltrItemPrice");
                //Literal ltrItemDesc = (Literal)item.FindControl("ltrItemDescription");
                //LinkButton lnkBuy = (LinkButton)item.FindControl("lnkBuy");

                //ltrItemName.Text = Items.ItemName;
                //ltrItemPrice.Text = Items.ItemPrice.ToString();
                //ltrItemDesc.Text = Items.ItemDescription;

                ////rptItem.DataSource = Items;
                ////rptItem.DataBind();
                ////foreach (RepeaterItem itm in rptItem.Items)
                ////{
                ////    Image imgItem = (Image)itm.FindControl("imgItem");
                ////    HiddenField hdnItem = (HiddenField)itm.FindControl("hdnItemImage");
                ////    var imgData = DC.tblImages.Single(ob => ob.ImagesID == Convert.ToInt32(hdnItem.Value));
                ////    imgItem.ImageUrl = "ServiceProvider/Iteam/" + imgData.Name;
                ////    HiddenField hdnRecordNo = (HiddenField)itm.FindControl("hdnRecordNo");
                ////    if (Convert.ToInt32(hdnRecordNo.Value) == 0)
                ////    {
                ////        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "AddClass();", true);
                ////    }

                ////}
                ////RepeaterItem FirstItem = rptItem.Items[0];
                ////Panel div = (Panel)FirstItem.FindControl("divItemPanel");
                ////div.CssClass = "active item";

            }
        }
        else
        {
            var MenuData = from obj in DC.tblMenuDetails
                           where obj.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"])
                           select obj;
            rptSPMenu.DataSource = MenuData;
            rptSPMenu.DataBind();

            if (Session["ClientID"] != null)
            {

            }
            lnkHideItem.Visible = false;

            foreach (RepeaterItem item in rptSPMenu.Items)
            {
                HiddenField hdn = (HiddenField)item.FindControl("hdnImageID");
                HiddenField hdnMenuID = (HiddenField)item.FindControl("hdnMenuID");
                Repeater rptItemList = (Repeater)item.FindControl("rptItemList");
                Repeater rptItem = (Repeater)item.FindControl("rptItem");
                Image img = (Image)item.FindControl("imgMenuImage");
                tblImage imgName = DC.tblImages.Single(ob => ob.ImagesID == Convert.ToInt32(hdn.Value));
                LinkButton lnkDeleteItem = (LinkButton)item.FindControl("lnkDeleteItem");
                LinkButton lnkShowEditerItem = (LinkButton)item.FindControl("lnkShowEditerItem");
                if (Session["ClientID"] != null)
                {
                    lnkDeleteItem.Visible = false;
                    lnkShowEditerItem.Visible = false;
                }
                img.ImageUrl = "ServiceProvider/Menu/" + imgName.Name;

                var ItemList = from obj in DC.tblitems
                               join obj2 in DC.tblImages
                               on obj.ImageID equals obj2.ImagesID
                               where obj.MenuID == Convert.ToInt32(hdnMenuID.Value) && obj.ImageID == obj2.ImagesID && obj.Isactive == true
                               select new
                               {
                                   Name = obj2.Name,
                                   ItemID = obj.ItemID
                               };

                rptItemList.DataSource = ItemList;
                rptItemList.DataBind();

                Panel panelMenu = (Panel)item.FindControl("PanelMenuData");
                if (rptItemList.Items.Count <= 0)
                {
                    panelMenu.Visible = false;
                }

                //foreach (RepeaterItem item1 in rptItemList.Items)
                //{
                //    Image img1 = (Image)item1.FindControl("imgItemImage");
                //    HiddenField hdnImgName = (HiddenField)item1.FindControl("hdnImageName");
                //    img1.ImageUrl = "ServiceProvider/Iteam/" + hdnImgName.Value;
                //}

                //tblitem Items = (from obj in DC.tblitems
                //            join obj2 in DC.tblImages
                //            on obj.ImageID equals obj2.ImagesID
                //            where obj.MenuID == Convert.ToInt32(hdnMenuID.Value) && obj.ImageID == obj2.ImagesID
                //            select obj).FirstOrDefault();

                //Image imgItem = (Image)item.FindControl("imgItem");
                //tblImage imgItemName = (from obj in DC.tblitems
                //                  join obj2 in DC.tblImages
                //                  on obj.ImageID equals obj2.ImagesID
                //                  where obj.MenuID == Convert.ToInt32(hdnMenuID.Value) && obj.ImageID == obj2.ImagesID
                //                  select obj2).FirstOrDefault();
                //imgItem.ImageUrl = "ServiceProvider/Iteam/" + imgItemName.Name;
                //Literal ltrItemName = (Literal)item.FindControl("ltrItemName");
                //Literal ltrItemPrice = (Literal)item.FindControl("ltrItemPrice");
                //Literal ltrItemDesc = (Literal)item.FindControl("ltrItemDescription");
                //LinkButton lnkBuy = (LinkButton)item.FindControl("lnkBuy");

                //ltrItemName.Text = Items.ItemName;
                //ltrItemPrice.Text = Items.ItemPrice.ToString();
                //ltrItemDesc.Text = Items.ItemDescription;

                ////rptItem.DataSource = Items;
                ////rptItem.DataBind();
                ////foreach (RepeaterItem itm in rptItem.Items)
                ////{
                ////    Image imgItem = (Image)itm.FindControl("imgItem");
                ////    HiddenField hdnItem = (HiddenField)itm.FindControl("hdnItemImage");
                ////    var imgData = DC.tblImages.Single(ob => ob.ImagesID == Convert.ToInt32(hdnItem.Value));
                ////    imgItem.ImageUrl = "ServiceProvider/Iteam/" + imgData.Name;
                ////    HiddenField hdnRecordNo = (HiddenField)itm.FindControl("hdnRecordNo");
                ////    if (Convert.ToInt32(hdnRecordNo.Value) == 0)
                ////    {
                ////        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "AddClass();", true);
                ////    }

                ////}
                ////RepeaterItem FirstItem = rptItem.Items[0];
                ////Panel div = (Panel)FirstItem.FindControl("divItemPanel");
                ////div.CssClass = "active item";

            }
        }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void lnkOrder_Click(object sender, EventArgs e)
    {
        try { 
        BindOrder();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    private void BindOrder()
    {
        try { 
        divHome.Visible = true;
        divItem.Visible = false;
        divOrder.Visible = true;
        divProfile.Visible = false;
        divTodayOrder.Visible = false;
        //divTodayStatus.Visible = true;
        divMeal.Visible = false;
        AddMenu.Visible = false;
        divMenu.Visible = false;
        AddMeal.Visible = false;

        var DC = new DataClassesDataContext();
        var OrderDate = (from obj in DC.tblOrders
                         orderby obj.Date
                         select obj.Date).Distinct();
        rptOrder.DataSource = OrderDate;
        rptOrder.DataBind();

        foreach (RepeaterItem item in rptOrder.Items)
        {
            Literal ltrDate = (Literal)item.FindControl("ltrOrderDate");
            Repeater rptMeal = (Repeater)item.FindControl("rptMealOrder");
            Repeater rptMenu = (Repeater)item.FindControl("rptMenuOrder");
            var MealData = from obj in DC.tblMealPlans
                           join obj3 in DC.tblOrders
                           on obj.MealID equals obj3.MealID
                           where obj.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"]) && obj3.Date == Convert.ToDateTime(ltrDate.Text).Date
                           select new
                           {
                               MealName = obj.MealName,
                               MealPrice = obj.MealPrice,
                               Time = obj.Time,
                               Qty = obj3.Qty,
                               OrderID = obj3.OrderID,
                               OrderStatus = obj3.IsOrder
                           };
            rptMeal.DataSource = MealData;
            rptMeal.DataBind();

            if (rptMeal.Items.Count <= 0)
            {
                rptMeal.Visible = false;
            }

            var MenuData = from obj in DC.tblMenuDetails
                           join obj2 in DC.tblitems
                           on obj.MenuID equals obj2.MenuID
                           join obj4 in DC.tblOrders
                           on obj2.ItemID equals obj4.ItemID
                           where obj.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"]) && obj4.Date == Convert.ToDateTime(ltrDate.Text).Date
                           select new
                           {
                               ItemName = obj2.ItemName,
                               ItemPrice = obj2.ItemPrice,
                               Time = obj2.Time,
                               Qty = obj4.Qty,
                               OrderID = obj4.OrderID,
                               OrderStatus = obj4.IsOrder
                           };
            rptMenu.DataSource = MenuData;
            rptMenu.DataBind();

            if (rptMenu.Items.Count <= 0)
            {
                rptMenu.Visible = false;
            }

        }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void lnkprofile_Click(object sender, EventArgs e)
    {
        try { 
        divHome.Visible = false;
        divItem.Visible = false;
        divOrder.Visible = false;
        divProfile.Visible = true;
        divTodayOrder.Visible = false;
        //divTodayStatus.Visible = false;
        divMeal.Visible = false;
        AddMenu.Visible = false;
        divMenu.Visible = false;
        AddMeal.Visible = false;

        var DC = new DataClassesDataContext();
        tblServiceProvider SPData = DC.tblServiceProviders.Single(ob => ob.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"]));
        textCompanyName.Text = SPData.CompanyName;
        lblComName.Text = SPData.CompanyName;
        txtFName.Text = SPData.FirstName;
        txtLName.Text = SPData.LastName;
        lnkSPNAME.Text = SPData.FirstName + " " + SPData.LastName;
        txtEmailID.Text = SPData.Email;
        lblEmail.Text = SPData.Email;
        txtContactNo.Text = SPData.ContactNo;
        lblContectNo.Text = SPData.ContactNo;
        tblAddress AddressData = DC.tblAddresses.Single(ob => ob.AddressID == SPData.AddressID);
        textStreet.Text = AddressData.Address;
        textLandmark.Text = AddressData.Landmark;
        textZipCode.Text = AddressData.PincodeNo;
        int CountryID = (from obj in DC.CountryMasters
                         join obj2 in DC.StateMasters
                         on obj.ID equals obj2.CountryID
                         join obj3 in DC.CityMasters
                         on obj2.ID equals obj3.StateID
                         where obj3.ID == AddressData.CityID && obj3.StateID == obj2.ID && obj2.CountryID == obj.ID
                         select obj.ID).Single();
        var CountryData = DC.CountryMasters;
        ddCountry.DataSource = CountryData;
        ddCountry.DataValueField = "ID";
        ddCountry.DataTextField = "Name";
        ddCountry.DataBind();

        ddCountry.SelectedIndex = CountryID - 1;

        int StateID = Convert.ToInt32((from obj in DC.CityMasters
                                       where obj.ID == AddressData.CityID
                                       select obj.StateID).Single());
        var StateData = DC.StateMasters;
        ddState.DataSource = StateData;
        ddState.DataValueField = "ID";
        ddState.DataTextField = "Name";
        ddState.DataBind();
        ddState.SelectedIndex = StateID - 1;

        var CityData = DC.CityMasters;
        ddCity.DataSource = CityData;
        ddCity.DataTextField = "Name";
        ddCity.DataValueField = "ID";
        ddCity.DataBind();
        ddCity.SelectedIndex = AddressData.CityID - 1;
        ltrAddress.Text = AddressData.Address;
        ltrLandmark.Text = AddressData.Landmark;
        ltrZipCode.Text = AddressData.PincodeNo;
        ltrCity.Text = ddCity.SelectedItem.Text;
        ltrState.Text = ddState.SelectedItem.Text;
        ltrCountry.Text = ddCountry.SelectedItem.Text;
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void lnkHome_Click(object sender, EventArgs e)
    {
        try { 
        divHome.Visible = true;
        divItem.Visible = false;
        divOrder.Visible = false;
        divProfile.Visible = false;
        divTodayOrder.Visible = true;
        //divTodayStatus.Visible = true;
        divMeal.Visible = false;
        divMenu.Visible = false;
        AddMenu.Visible = false;
        AddMeal.Visible = false;
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void rptTodayMealOrder_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try { 
        var DC = new DataClassesDataContext();
        if (e.CommandName == "EditOrderStatus")
        {
            tblOrder OrderData = DC.tblOrders.Single(ob => ob.OrderID == Convert.ToInt32(e.CommandArgument.ToString()));
            if (OrderData.IsOrder == true)
            {
                OrderData.IsOrder = false;
            }
            else
            {
                OrderData.IsOrder = true;
            }
            DC.SubmitChanges();
        }
        else if (e.CommandName == "ShowOrderDetail")
        {
            var MealData = (from obj in DC.tblMealPlans
                            join obj2 in DC.tblcarts
                            on obj.MealID equals obj2.MealID
                            join obj3 in DC.tblOrders
                            on obj2.MealID equals obj3.MealID
                            where obj.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"]) && obj3.Date == DateTime.Now.Date && obj3.OrderID == Convert.ToInt32(e.CommandArgument)
                            select new
                            {
                                MealName = obj.MealName,
                                MealPrice = obj.MealPrice,
                                Time = obj.Time,
                                Qty = obj2.Quantity,
                                OrderID = obj3.OrderID,
                                OrderStatus = obj3.IsOrder,
                                Description = obj.MealDescription,
                                Type = obj.MealType,
                                ImageID = obj.ImageID,
                                ClientID = obj3.ClientID,
                                SAddress = obj3.ShippingAddress,
                                BAddress = obj3.BillingAddress
                            }).First();
            lblItemName.Text = MealData.MealName;
            lblItemPrice.Text = MealData.MealPrice.ToString();
            ltrItemDescription.Text = MealData.Description;
            if (MealData.Type == "Veg")
            {
                imgItemType.ImageUrl = "Icon/Veg.png";
            }
            else if (MealData.Type == "Non-Veg")
            {
                imgItemType.ImageUrl = "Icon/Non-Veg.png";
            }
            tblImage imgName = DC.tblImages.Single(ob => ob.ImagesID == MealData.ImageID);
            imgItemImage.ImageUrl = "ServiceProvider/Meal/" + imgName.Name;
            tblClient ClientData = DC.tblClients.Single(ob => ob.ClientID == MealData.ClientID);
            lblClientName.Text = ClientData.FirstName + " " + ClientData.LastName;
            ltrClientContactNo.Text = ClientData.ContactNo;
            ltrClientMailID.Text = ClientData.Email;
            ltrShippingAddress.Text = MealData.SAddress;
            ltrBillingAddress.Text = MealData.BAddress;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal({backdrop:'static', keyboard: false});", true);
        }
        BindData();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void rptTodayMenuOrder_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try { 
        var DC = new DataClassesDataContext();
        if (e.CommandName == "EditOrderStatus")
        {
            tblOrder OrderData = DC.tblOrders.Single(ob => ob.OrderID == Convert.ToInt32(e.CommandArgument.ToString()));
            if (OrderData.IsOrder == true)
            {
                OrderData.IsOrder = false;
            }
            else
            {
                OrderData.IsOrder = true;
            }
            DC.SubmitChanges();
        }
        else if (e.CommandName == "ShowOrderDetail")
        {
            var MenuData = (from obj in DC.tblMenuDetails
                            join obj2 in DC.tblitems
                            on obj.MenuID equals obj2.MenuID
                            join obj3 in DC.tblcarts
                            on obj2.ItemID equals obj3.ItemID
                            join obj4 in DC.tblOrders
                            on obj3.ItemID equals obj4.ItemID
                            where obj.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"]) && obj4.Date == DateTime.Now.Date && obj4.OrderID == Convert.ToInt32(e.CommandArgument)
                            select new
                            {
                                ItemName = obj2.ItemName,
                                ItemPrice = obj2.ItemPrice,
                                Time = obj2.Time,
                                Qty = obj3.Quantity,
                                OrderID = obj4.OrderID,
                                OrderStatus = obj4.IsOrder,
                                Description = obj2.ItemDescription,
                                Type = obj2.ItemType,
                                ImageID = obj2.ImageID,
                                ClientID = obj4.ClientID,
                                SAddress = obj4.ShippingAddress,
                                BAddress = obj4.BillingAddress
                            }).Single();
            lblItemName.Text = MenuData.ItemName;
            lblItemPrice.Text = MenuData.ItemPrice.ToString();
            ltrItemDescription.Text = MenuData.Description;
            if (MenuData.Type == "Veg")
            {
                imgItemType.ImageUrl = "Icon/Veg.png";
            }
            else if (MenuData.Type == "Non-Veg")
            {
                imgItemType.ImageUrl = "Icon/Non-Veg.png";
            }
            tblImage imgName = DC.tblImages.Single(ob => ob.ImagesID == MenuData.ImageID);
            imgItemImage.ImageUrl = "ServiceProvider/Iteam/" + imgName.Name;
            tblClient ClientData = DC.tblClients.Single(ob => ob.ClientID == MenuData.ClientID);
            lblClientName.Text = ClientData.FirstName + " " + ClientData.LastName;
            ltrClientContactNo.Text = ClientData.ContactNo;
            ltrClientMailID.Text = ClientData.Email;
            ltrShippingAddress.Text = MenuData.SAddress;
            ltrBillingAddress.Text = MenuData.BAddress;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal({backdrop:'static', keyboard: false});", true);
        }
        BindData();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void textCompanyName_TextChanged(object sender, EventArgs e)
    {
        try { 
        var DC = new DataClassesDataContext();
        tblServiceProvider SPData = DC.tblServiceProviders.Single(ob => ob.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"].ToString()));
        SPData.CompanyName = textCompanyName.Text;
        DC.SubmitChanges();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void txtEmailID_TextChanged(object sender, EventArgs e)
    {
        try { 
        var DC = new DataClassesDataContext();
        tblServiceProvider SPData = DC.tblServiceProviders.Single(ob => ob.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"].ToString()));
        SPData.Email = txtEmailID.Text;
        DC.SubmitChanges();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void txtContactNo_TextChanged(object sender, EventArgs e)
    {
        try { 
        var DC = new DataClassesDataContext();
        tblServiceProvider SPData = DC.tblServiceProviders.Single(ob => ob.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"].ToString()));
        SPData.ContactNo = txtContactNo.Text;
        DC.SubmitChanges();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void lnkbtnChangePwd_Click(object sender, EventArgs e)
    {
        try { 
        lnkbtnChangePwd.Visible = false;
        txtPwd.Visible = true;
        txtRPwd.Visible = true;
        txtOldPassword.Visible = true;
        txtOldPassword.Focus();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void lnkAddress_Click(object sender, EventArgs e)
    {
        try { 
        //lnkAddress.Visible = false;
        //  divAddressForm.Visible = true;
        textStreet.Focus();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void textStreet_TextChanged(object sender, EventArgs e)
    {
        try { 
        var DC = new DataClassesDataContext();
        tblServiceProvider SPData = DC.tblServiceProviders.Single(ob => ob.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"].ToString()));
        tblAddress Address = DC.tblAddresses.Single(ob => ob.AddressID == SPData.AddressID);
        Address.Address = textStreet.Text;
        DC.SubmitChanges();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void textLandmark_TextChanged(object sender, EventArgs e)
    {
        try { 
        var DC = new DataClassesDataContext();
        tblServiceProvider SPData = DC.tblServiceProviders.Single(ob => ob.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"].ToString()));
        tblAddress Address = DC.tblAddresses.Single(ob => ob.AddressID == SPData.AddressID);
        Address.Landmark = textLandmark.Text;
        DC.SubmitChanges();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void ddCountry_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ddState_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void textZipCode_TextChanged(object sender, EventArgs e)
    {
        try { 
        var DC = new DataClassesDataContext();
        tblServiceProvider SPData = DC.tblServiceProviders.Single(ob => ob.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"].ToString()));
        tblAddress Address = DC.tblAddresses.Single(ob => ob.AddressID == SPData.AddressID);
        Address.PincodeNo = textZipCode.Text;
        DC.SubmitChanges();
            //divAddressForm.Visible = false;
            //lnkAddress.Visible = true;
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void ddCity_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void lnkSPNAME_Click(object sender, EventArgs e)
    {
        try { 
        lnkSPNAME.Visible = false;
        txtFName.Visible = true;
        txtLName.Visible = true;

        txtFName.Focus();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void textFName_TextChanged(object sender, EventArgs e)
    {
        try { 
        if (txtFName.Text != null)
        {

            txtFName.Focus();

        }
        else
        {
            txtLName.Focus();
        }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void txtLName_TextChanged(object sender, EventArgs e)
    {
        try { 
        if (txtFName.Text != null && txtLName.Text != null)
        {
            var DC = new DataClassesDataContext();
            tblServiceProvider SPData = DC.tblServiceProviders.Single(ob => ob.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"].ToString()));
            SPData.FirstName = txtFName.Text;
            SPData.LastName = txtLName.Text;
            DC.SubmitChanges();
            txtFName.Visible = false;
            txtLName.Visible = false;
            lnkSPNAME.Visible = true;
        }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void btnAddMenu_Click(object sender, EventArgs e)
    {
        try { 
        divHome.Visible = true;
        divItem.Visible = false;
        divOrder.Visible = false;
        divProfile.Visible = false;
        divTodayOrder.Visible = false;
        //divTodayStatus.Visible = true;
        divMeal.Visible = false;
        //AddMenu.Visible = false;
        divMenu.Visible = false;
        AddMenu.Visible = true;

        AddMeal.Visible = false;
        var DC = new DataClassesDataContext();
        var Data = from obj in DC.tblMenuDetails
                   where obj.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"]) && obj.IsActive == true
                   select obj;
        ddlMenu.DataSource = Data;
        ddlMenu.DataTextField = "MenuName";
        ddlMenu.DataValueField = "MenuID";
        ddlMenu.DataBind();
        ddlMenu.Items.Insert(0, new ListItem("Select Menu", "0"));
            //BindMenu();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }

    }

    protected void btnAddMeal_Click(object sender, EventArgs e)
    {
        try { 
        divHome.Visible = true;
        divItem.Visible = false;
        divOrder.Visible = false;
        divProfile.Visible = false;
        divTodayOrder.Visible = false;
        //divTodayStatus.Visible = true;
        divMeal.Visible = false;
        AddMenu.Visible = false;
        divMenu.Visible = false;
        AddMenu.Visible = false;
        AddMeal.Visible = true;
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void btnMealAdd_Click(object sender, EventArgs e)
    {
        try { 
        var dc = new DataClassesDataContext();
        var str1 = (from p2 in dc.tblMealPlans
                    where p2.MealName == txtmnm.Text && p2.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"])
                    select p2).Count();
        if (str1 > 0)
        {
            errorSameMeal.Visible = true;
        }
        else
        {
            var DC = new DataClassesDataContext();
            tblMealPlan Meal = new tblMealPlan();
            Meal.MealName = txtmnm.Text;
            Meal.MealDescription = txtmdes.Text;
            if (rdVeg.Checked)
            {
                Meal.MealType = "Veg";
            }
            else if (rdNonVeg.Checked)
            {
                Meal.MealType = "Non-Veg";
            }
            else
            {
                Meal.MealType = "Both";
            }
            if (FileUpload1.HasFile)
            {
                var path = Server.MapPath("~/ServiceProvider/Meal");
                FileUpload1.SaveAs(path + "/" + FileUpload1.FileName);
                tblImage objimg = new tblImage();
                objimg.Name = FileUpload1.FileName;
                objimg.AlbumID = 2;
                objimg.IsActive = true;
                objimg.IsDefault = false;
                objimg.CreatedOn = DateTime.Now;
                DC.tblImages.InsertOnSubmit(objimg);
                DC.SubmitChanges();


            }
            var img = (from im in DC.tblImages
                       orderby im.ImagesID descending
                       select im).FirstOrDefault();
            Meal.Time = ddlMeal.SelectedItem.Value;
            int Price = Convert.ToInt32(Convert.ToDecimal(txtmprice.Text));
            Meal.MealPrice = Price;
            Meal.ImageID = Convert.ToInt32(img.ImagesID);
            Meal.IsActive = true;
            Meal.ServiceProviderID = Convert.ToInt32(Session["ServiceProviderID"]);

            DC.tblMealPlans.InsertOnSubmit(Meal);
            DC.SubmitChanges();
            AddMeal.Visible = false;
            DataClear();
            BindMeal();
            errorSameMeal.Visible = false;
        }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void txtOldPassword_TextChanged(object sender, EventArgs e)
    {
        try { 
        var DC = new DataClassesDataContext();
        tblServiceProvider SPData = DC.tblServiceProviders.Single(ob => ob.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"]));
        if (txtOldPassword.Text == SPData.Password)
        {
            txtPwd.Focus();
            errorChangePassword.Visible = false;
        }
        else
        {
            errorChangePassword.Text = "Please Enter Currect Password.";
            txtOldPassword.Focus();
            errorChangePassword.Visible = true;
        }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void txtRPwd_TextChanged(object sender, EventArgs e)
    {
        try { 
        var DC = new DataClassesDataContext();
        tblServiceProvider SPData = DC.tblServiceProviders.Single(ob => ob.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"]));
        if (txtOldPassword.Text == SPData.Password)
        {
            if (txtPwd.Text == txtRPwd.Text)
            {

                //tblServiceProvider SPData = DC.tblServiceProviders.Single(ob => ob.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"].ToString()));
                SPData.Password = txtPwd.Text;
                DC.SubmitChanges();
                lnkbtnChangePwd.Visible = true;
                txtPwd.Visible = false;
                txtRPwd.Visible = false;
                txtOldPassword.Visible = false;
                errorChangePassword.Visible = false;
            }
            else
            {
                errorChangePassword.Text = "Please Enter Same Password.";
                errorChangePassword.Visible = true;
            }

        }
        else
        {
            errorChangePassword.Text = "Please Enter Currect Password.";
            txtOldPassword.Focus();
            errorChangePassword.Visible = true;
        }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void rptSPMeal_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try { 
        var DC = new DataClassesDataContext();
        if (e.CommandName == "ShowEditerItem")
        {
            Literal lblName = (Literal)e.Item.FindControl("ltrMealName");
            Literal lblPrice = (Literal)e.Item.FindControl("ltrPrice");
            Literal lblDesc = (Literal)e.Item.FindControl("ltrDesc");
            TextBox txtName = (TextBox)e.Item.FindControl("txtMealName");
            TextBox txtPrice = (TextBox)e.Item.FindControl("txtPrice");
            TextBox txtDesc = (TextBox)e.Item.FindControl("txtDesc");
            LinkButton lnkShowEditerItem = (LinkButton)e.Item.FindControl("lnkShowEditerItem");
            Button lnkEditItem = (Button)e.Item.FindControl("lnkEditItem");
            Image img = (Image)e.Item.FindControl("imgMealType");
            ImageButton imgbtnMealType = (ImageButton)e.Item.FindControl("imgbtnMealType");
            lblName.Visible = false;
            lblPrice.Visible = false;
            lblDesc.Visible = false;
            txtName.Visible = true;
            txtPrice.Visible = true;
            txtDesc.Visible = true;
            lnkEditItem.Visible = true;
            lnkShowEditerItem.Visible = false;
            img.Visible = false;
            imgbtnMealType.Visible = true;
        }
        else if (e.CommandName == "EditItem")
        {

            Literal lblName = (Literal)e.Item.FindControl("ltrMealName");
            Literal lblPrice = (Literal)e.Item.FindControl("ltrPrice");
            Literal lblDesc = (Literal)e.Item.FindControl("ltrDesc");
            TextBox txtName = (TextBox)e.Item.FindControl("txtMealName");
            TextBox txtPrice = (TextBox)e.Item.FindControl("txtPrice");
            TextBox txtDesc = (TextBox)e.Item.FindControl("txtDesc");
            LinkButton lnkShowEditerItem = (LinkButton)e.Item.FindControl("lnkShowEditerItem");
            Button lnkEditItem = (Button)e.Item.FindControl("lnkEditItem");
            Image img = (Image)e.Item.FindControl("imgMealType");
            ImageButton imgbtnMealType = (ImageButton)e.Item.FindControl("imgbtnMealType");
            tblMealPlan MealData = (from obj in DC.tblMealPlans
                                    where obj.MealID == Convert.ToInt32(e.CommandArgument)
                                    select obj).Single();
            MealData.MealName = txtName.Text;
            MealData.MealPrice = Convert.ToInt32(txtPrice.Text);
            MealData.MealDescription = txtDesc.Text;
            DC.SubmitChanges();
            lblName.Visible = true;
            lblPrice.Visible = true;
            lblDesc.Visible = true;
            txtName.Visible = false;
            txtPrice.Visible = false;
            txtDesc.Visible = false;
            lnkEditItem.Visible = false;
            lnkShowEditerItem.Visible = true;
            img.Visible = true;
            imgbtnMealType.Visible = false;
            //------------------------------------------------------------------
        }
        else if (e.CommandName == "EditMealType")
        {
            tblMealPlan MealData = (from obj in DC.tblMealPlans
                                    where obj.MealID == Convert.ToInt32(e.CommandArgument)
                                    select obj).Single();
            if (MealData.MealType == "Veg")
            {
                MealData.MealType = "Non-Veg";
            }
            else
            {
                MealData.MealType = "Non-Veg";
            }
            DC.SubmitChanges();
        }
        else if (e.CommandName == "DeleteMeal")
        {
            tblMealPlan MealData = (from obj in DC.tblMealPlans
                                    where obj.MealID == Convert.ToInt32(e.CommandArgument)
                                    select obj).Single();
            MealData.IsActive = false;
            DC.SubmitChanges();
        }
        else if (e.CommandName == "HideMeal")
        {
            tblMealPlan MealData = (from obj in DC.tblMealPlans
                                    where obj.MealID == Convert.ToInt32(e.CommandArgument)
                                    select obj).Single();
            MealData.MealStatus = true;
            DC.SubmitChanges();
        }
        else if (e.CommandName == "ShowMeal")
        {
            tblMealPlan MealData = (from obj in DC.tblMealPlans
                                    where obj.MealID == Convert.ToInt32(e.CommandArgument)
                                    select obj).Single();
            MealData.MealStatus = false;
            DC.SubmitChanges();
        }
        else if (e.CommandName == "HideSpacialMeal")
        {
            tblMealPlan MealData = (from obj in DC.tblMealPlans
                                    where obj.MealID == Convert.ToInt32(e.CommandArgument)
                                    select obj).Single();
            MealData.TodaySpacial = false;
            DC.SubmitChanges();

        }
        else if (e.CommandName == "ShowSpacialMeal")
        {
            tblMealPlan MealData = (from obj in DC.tblMealPlans
                                    where obj.MealID == Convert.ToInt32(e.CommandArgument)
                                    select obj).Single();
            MealData.TodaySpacial = true;
            DC.SubmitChanges();

        }
        if (e.CommandName != "ShowEditerItem")
        {
            BindMeal();
        }
        if (e.CommandName == "CartMeal")
        {
            tblcart cart = new tblcart();
            cart.MealID = Convert.ToInt32(e.CommandArgument);
            cart.ItemID = null;
            cart.IsActive = true;
            cart.MACAddress = GetMACAddress();
            cart.Quantity = 1;
            cart.Date = DateTime.Now;
            DC.tblcarts.InsertOnSubmit(cart);
            DC.SubmitChanges();
        }
        binddata();
        binddata1();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void btnMenuAdd_Click(object sender, EventArgs e)
    {
        try { 
        var dc = new DataClassesDataContext();
        var str1 = (from p2 in dc.tblMenuDetails
                    where p2.MenuName == txtaddmnm.Text && p2.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"])
                    select p2).Count();
        if (str1 > 0)
        {
            errorSameManu.Visible = true;
        }
        else
        {
            var DC = new DataClassesDataContext();
            tblMenuDetail Menu = new tblMenuDetail();
            Menu.MenuName = txtaddmnm.Text;
            if (rptmenuveg.Checked)
            {
                Menu.MenuType = "Veg";
            }
            else if (rptmenunonveg.Checked)
            {
                Menu.MenuType = "Non-Veg";
            }
            else
            {
                Menu.MenuType = "Both";
            }
            if (FileUpload2.HasFile)
            {
                var path = Server.MapPath("~/ServiceProvider/Menu");
                FileUpload2.SaveAs(path + "/" + FileUpload2.FileName);
                tblImage objimg = new tblImage();
                objimg.Name = FileUpload2.FileName;
                objimg.AlbumID = 2;
                objimg.IsActive = true;
                objimg.IsDefault = false;
                objimg.CreatedOn = DateTime.Now;
                DC.tblImages.InsertOnSubmit(objimg);
                DC.SubmitChanges();


            }
            var img = (from im in DC.tblImages
                       orderby im.ImagesID descending
                       select im).FirstOrDefault();


            Menu.ImageID = Convert.ToInt32(img.ImagesID);
            Menu.IsActive = true;
            Menu.ServiceProviderID = Convert.ToInt32(Session["ServiceProviderID"]);

            DC.tblMenuDetails.InsertOnSubmit(Menu);
            DC.SubmitChanges();

            Panel1.Visible = false;
            AddMenu.Visible = true;
            lblMenu.Visible = true;
            ddlMenu.Visible = true;
            errorSameManu.Visible = false;
            DataClear();
            BindMenu();
            errorSameManu.Visible = false;
        }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void rptMealOrder_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try { 
        var DC = new DataClassesDataContext();
        if (e.CommandName == "EditOrderStatus")
        {
            tblOrder OrderData = DC.tblOrders.Single(ob => ob.OrderID == Convert.ToInt32(e.CommandArgument.ToString()));
            if (OrderData.IsOrder == true)
            {
                OrderData.IsOrder = false;
            }
            else
            {
                OrderData.IsOrder = true;
            }
            DC.SubmitChanges();
        }
        else if (e.CommandName == "ShowOrderDetail")
        {
            var MealData = (from obj in DC.tblMealPlans
                            join obj2 in DC.tblcarts
                            on obj.MealID equals obj2.MealID
                            join obj3 in DC.tblOrders
                            on obj2.MealID equals obj3.MealID
                            where obj.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"]) && obj3.OrderID == Convert.ToInt32(e.CommandArgument)
                            select new
                            {
                                MealName = obj.MealName,
                                MealPrice = obj.MealPrice,
                                Time = obj.Time,
                                Qty = obj2.Quantity,
                                OrderID = obj3.OrderID,
                                OrderStatus = obj3.IsOrder,
                                Description = obj.MealDescription,
                                Type = obj.MealType,
                                ImageID = obj.ImageID,
                                ClientID = obj3.ClientID,
                                SAddress = obj3.ShippingAddress,
                                BAddress = obj3.BillingAddress
                            }).First();
            lblItemName.Text = MealData.MealName;
            lblItemPrice.Text = MealData.MealPrice.ToString();
            ltrItemDescription.Text = MealData.Description;
            if (MealData.Type == "Veg")
            {
                imgItemType.ImageUrl = "Icon/Veg.png";
            }
            else if (MealData.Type == "Non-Veg")
            {
                imgItemType.ImageUrl = "Icon/Non-Veg.png";
            }
            tblImage imgName = DC.tblImages.Single(ob => ob.ImagesID == MealData.ImageID);
            imgItemImage.ImageUrl = "ServiceProvider/Meal/" + imgName.Name;
            tblClient ClientData = DC.tblClients.Single(ob => ob.ClientID == MealData.ClientID);
            lblClientName.Text = ClientData.FirstName + " " + ClientData.LastName;
            ltrClientContactNo.Text = ClientData.ContactNo;
            ltrClientMailID.Text = ClientData.Email;
            ltrShippingAddress.Text = MealData.SAddress;
            ltrBillingAddress.Text = MealData.BAddress;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal({backdrop:'static', keyboard: false});", true);
        }
        BindOrder();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void rptMenuOrder_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try { 
        var DC = new DataClassesDataContext();
        if (e.CommandName == "EditOrderStatus")
        {
            tblOrder OrderData = DC.tblOrders.Single(ob => ob.OrderID == Convert.ToInt32(e.CommandArgument.ToString()));
            if (OrderData.IsOrder == true)
            {
                OrderData.IsOrder = false;
            }
            else
            {
                OrderData.IsOrder = true;
            }
            DC.SubmitChanges();
        }
        else if (e.CommandName == "ShowOrderDetail")
        {
            string ID = e.CommandArgument.ToString();
            var MenuData = (from obj in DC.tblMenuDetails
                            join obj2 in DC.tblitems
                            on obj.MenuID equals obj2.MenuID
                            join obj3 in DC.tblcarts
                            on obj2.ItemID equals obj3.ItemID
                            join obj4 in DC.tblOrders
                            on obj3.ItemID equals obj4.ItemID
                            where obj.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"]) && obj4.Date == DateTime.Now.Date && obj4.OrderID == Convert.ToInt32(e.CommandArgument)
                            select new
                            {
                                ItemName = obj2.ItemName,
                                ItemPrice = obj2.ItemPrice,
                                Time = obj2.Time,
                                Qty = obj3.Quantity,
                                OrderID = obj4.OrderID,
                                OrderStatus = obj4.IsOrder,
                                Description = obj2.ItemDescription,
                                Type = obj2.ItemType,
                                ImageID = obj2.ImageID,
                                ClientID = obj4.ClientID,
                                SAddress = obj4.ShippingAddress,
                                BAddress = obj4.BillingAddress
                            }).Single();
            lblItemName.Text = MenuData.ItemName;
            lblItemPrice.Text = MenuData.ItemPrice.ToString();
            ltrItemDescription.Text = MenuData.Description;
            if (MenuData.Type == "Veg")
            {
                imgItemType.ImageUrl = "Icon/Veg.png";
            }
            else if (MenuData.Type == "Non-Veg")
            {
                imgItemType.ImageUrl = "Icon/Non-Veg.png";
            }
            tblImage imgName = DC.tblImages.Single(ob => ob.ImagesID == MenuData.ImageID);
            imgItemImage.ImageUrl = "ServiceProvider/Iteam/" + imgName.Name;
            tblClient ClientData = DC.tblClients.Single(ob => ob.ClientID == MenuData.ClientID);
            lblClientName.Text = ClientData.FirstName + " " + ClientData.LastName;
            ltrClientContactNo.Text = ClientData.ContactNo;
            ltrClientMailID.Text = ClientData.Email;
            ltrShippingAddress.Text = MenuData.SAddress;
            ltrBillingAddress.Text = MenuData.BAddress;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal({backdrop:'static', keyboard: false});", true);
        }


        BindOrder();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void rptItemList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try { 
        var DC = new DataClassesDataContext();
        if (e.CommandName == "ViewItem")
        {
            string ID = e.CommandArgument.ToString();
            var MenuData = (from obj in DC.tblitems
                            where obj.ItemID == Convert.ToInt32(e.CommandArgument)
                            select obj).Single();
            lblItemName1.Text = MenuData.ItemName;
            txtItemName1.Text = MenuData.ItemName;
            lblItemPrice1.Text = MenuData.ItemPrice.ToString();
            txtItemPrice1.Text = MenuData.ItemPrice.ToString();
            ltrItemDescription1.Text = MenuData.ItemDescription;
            txtItemDescription1.Text = MenuData.ItemDescription;

            if (MenuData.ItemType == "Veg")
            {
                imgItemType1.ImageUrl = "Icon/Veg.png";
                imgbtnItemType1.ImageUrl = "Icon/Veg.png";
            }
            else if (MenuData.ItemType == "Non-Veg")
            {
                imgItemType1.ImageUrl = "Icon/Non-Veg.png";
                imgbtnItemType1.ImageUrl = "Icon/Non-Veg.png";
            }
            tblImage imgName = DC.tblImages.Single(ob => ob.ImagesID == MenuData.ImageID);
            imgItemImage1.ImageUrl = "ServiceProvider/Iteam/" + imgName.Name;
            hdnItemID.Value = MenuData.ItemID.ToString();
            tblitem itemData = DC.tblitems.Single(ob => ob.ItemID == Convert.ToInt32(e.CommandArgument));
            if (temp == 0)
            {
                lblItemName1.Visible = true;
                txtItemName1.Visible = false;
                lblItemPrice1.Visible = true;
                txtItemPrice1.Visible = false;
                divItemDescltr.Visible = true;
                divItemDesctxt.Visible = false;
                imgItemType1.Visible = true;
                imgbtnItemType1.Visible = false;
                if (itemData.ItemStatus == false)
                {
                    lnkShowItem.Visible = true;
                }
                else
                {
                    lnkHideItem.Visible = true;
                }
            }

            if (Session["ViewServiceProviderID"] != null)
            {
                lnkDeleteItem.Visible = false;
                lnkHideItem.Visible = false;
                lnkShowItem.Visible = false;
                lnkEditItemOK.Visible = false;
            }


            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal1').modal({backdrop:'static', keyboard: false});", true);
        }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void btnSumbitItem_Click(object sender, EventArgs e)
    {
        try { 
        var dc = new DataClassesDataContext();
        tblMenuDetail data = (from p2 in dc.tblMenuDetails
                              where p2.MenuID == Convert.ToInt32(ddlMenu.SelectedValue) && p2.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"])
                              select p2).Single();
        var str1 = (from obj in dc.tblitems
                    where obj.MenuID == Convert.ToInt32(data.MenuID) && obj.ItemName == txtItemName.Text
                    select obj.ItemName).Count();

        if (str1 > 0)
        {
            errorSameItem.Visible = true;
        }
        else
        {
            var DC = new DataClassesDataContext();
            if (imgImageItem.HasFile)
            {
                var path = Server.MapPath("~/ServiceProvider/Iteam");
                imgImageItem.SaveAs(path + "/" + imgImageItem.FileName);
                tblImage objimg = new tblImage();
                objimg.Name = imgImageItem.FileName;
                objimg.AlbumID = 2;
                objimg.IsActive = true;
                objimg.IsDefault = false;
                objimg.CreatedOn = DateTime.Now;
                DC.tblImages.InsertOnSubmit(objimg);
                DC.SubmitChanges();


            }
            var img = (from im in DC.tblImages
                       orderby im.ImagesID descending
                       select im).FirstOrDefault();


            tblitem item = new tblitem();
            item.ItemName = txtItemName.Text;
            item.ItemPrice = Convert.ToDecimal(txtItemPrice.Text);
            item.ItemDescription = txtItemDesc.Text;
            item.Time = ddItemType.SelectedValue;
            item.MenuID = Convert.ToInt32(ddlMenu.SelectedValue);
            if (rdVegItem.Checked)
            {
                item.ItemType = "Veg";
            }
            else if (rdNonVeg.Checked)
            {
                item.ItemType = "Non-Veg";
            }
            else
            {
                item.ItemType = "Both";
            }
            item.Isactive = true;
            item.ImageID = img.ImagesID;
            DC.tblitems.InsertOnSubmit(item);
            DC.SubmitChanges();
            DataClear();
            BindMenu();
            errorSameItem.Visible = false;

        }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void rptClientSidePanel_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try { 
        var dc = new DataClassesDataContext();
        if (e.CommandName == "CartSpecialMeal")
        {
            tblcart cart = new tblcart();
            cart.MealID = Convert.ToInt32(e.CommandArgument);
            cart.ItemID = null;
            cart.IsActive = true;
            cart.Quantity = 1;
            cart.MACAddress = GetMACAddress();
            cart.Date = DateTime.Now;
            dc.tblcarts.InsertOnSubmit(cart);
            dc.SubmitChanges();
        }
        binddata();
        binddata1();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void LinkButton10_Click(object sender, EventArgs e)
    {
        try { 
        var DC = new DataClassesDataContext();
        tblcart cart = new tblcart();
        cart.MealID = null;
        int ItemID = Convert.ToInt32(hdnItemID.Value);
        cart.ItemID = ItemID;
        cart.MACAddress = GetMACAddress();
        cart.IsActive = true;
        cart.Quantity = 1;
        cart.Date = DateTime.Now;
        DC.tblcarts.InsertOnSubmit(cart);
        DC.SubmitChanges();
        binddata();
        binddata1();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        try { 
        Session["ServiceProviderID"] = null;
        Session.Clear();
        Response.Redirect("ServiceLogin.aspx");
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void rptSPMenu_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try { 
        var DC = new DataClassesDataContext();
        if (e.CommandName == "ShowEditerItem")
        {
            Literal lblName = (Literal)e.Item.FindControl("ltrMenuName");
            TextBox txtName = (TextBox)e.Item.FindControl("txtMenuName");
            LinkButton lnkShowEditerItem = (LinkButton)e.Item.FindControl("lnkShowEditerItem");
            Button lnkEditItem = (Button)e.Item.FindControl("lnkEditItem");
            lblName.Visible = false;
            txtName.Visible = true;
            lnkEditItem.Visible = true;
            lnkShowEditerItem.Visible = false;
            txtItemName1.Visible = true;
            lblItemName1.Visible = false;
            lblItemPrice1.Visible = false;
            txtItemPrice1.Visible = true;
            divItemDescltr.Visible = false;
            divItemDesctxt.Visible = true;
            imgItemType1.Visible = false;
            imgbtnItemType1.Visible = true;
            lnkEditItemOK.Visible = true;

            temp = 1;
        }
        else if (e.CommandName == "EditMenu")
        {
            Literal lblName = (Literal)e.Item.FindControl("ltrMenuName");
            TextBox txtName = (TextBox)e.Item.FindControl("txtMenuName");
            LinkButton lnkShowEditerItem = (LinkButton)e.Item.FindControl("lnkShowEditerItem");
            Button lnkEditItem = (Button)e.Item.FindControl("lnkEditItem");
            tblMenuDetail MenuData = (from obj in DC.tblMenuDetails
                                      where obj.MenuID == Convert.ToInt32(e.CommandArgument)
                                      select obj).Single();
            MenuData.MenuName = txtName.Text;
            DC.SubmitChanges();
            lblName.Visible = true;
            txtName.Visible = false;
            lnkEditItem.Visible = false;
            lnkShowEditerItem.Visible = true;
            BindMenu();
        }
        binddata();
        binddata1();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
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
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
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
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }


    protected void repitem_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try { 
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
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void repmeal_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try { 
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
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void btnClearCart_Click(object sender, EventArgs e)
    {
        try { 
        var DC = new DataClassesDataContext();
        IQueryable<tblcart> Data = from obj in DC.tblcarts
                                   where obj.MACAddress == GetMACAddress()
                                   select obj;
        DC.tblcarts.DeleteAllOnSubmit(Data);
        DC.SubmitChanges();
        binddata();
        binddata1();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void btnCheckOut_Click(object sender, EventArgs e)
    {
        try { 
        var DC = new DataClassesDataContext();
        //foreach (RepeaterItem item in repitem.Items)
        //{
        //    CheckBox chk = (CheckBox)item.FindControl("chkItemSelect");
        //    if (chk.Checked == true)
        //    {
        //        tblcart cartData = DC.tblcarts.Single(ob => ob.CartID == Convert.ToInt32(chk.Text));
        //        tblitem itemData = DC.tblitems.Single(ob => ob.ItemID == cartData.ItemID);
        //        tblOrder OrderData = new tblOrder();
        //        OrderData.ClientID = Convert.ToInt32(cartData.ClientID);
        //        OrderData.Date = DateTime.Now;
        //        OrderData.ItemID = cartData.ItemID;
        //        OrderData.MACAddress = GetMACAddress();
        //        OrderData.Qty = cartData.Quantity;
        //        OrderData.TotalAmount = itemData.ItemPrice * cartData.Quantity;
        //        OrderData.IsActive = true;
        //        DC.tblOrders.InsertOnSubmit(OrderData);
        //        DC.tblcarts.DeleteOnSubmit(cartData);
        //    }
        //}
        //foreach (RepeaterItem item in repmeal.Items)
        //{
        //    CheckBox chk = (CheckBox)item.FindControl("chkItemSelect");
        //    if (chk.Checked)
        //    {
        //        tblcart cartData = DC.tblcarts.Single(ob => ob.CartID == Convert.ToInt32(chk.Text));
        //        tblMealPlan MealData = DC.tblMealPlans.Single(ob => ob.MealID == cartData.MealID);
        //        tblOrder OrderData = new tblOrder();
        //        OrderData.ClientID = Convert.ToInt32(cartData.ClientID);
        //        OrderData.Date = DateTime.Now;
        //        OrderData.MealID = cartData.MealID;
        //        OrderData.MACAddress = GetMACAddress();
        //        OrderData.Qty = cartData.Quantity;
        //        OrderData.TotalAmount = Convert.ToDecimal(MealData.MealPrice) * cartData.Quantity;
        //        OrderData.IsActive = true;
        //        DC.tblOrders.InsertOnSubmit(OrderData);
        //        DC.SubmitChanges();
        //        DC.tblcarts.DeleteOnSubmit(cartData);
        //        DC.SubmitChanges();
        //    }
        //}
        //DC.SubmitChanges();
        //binddata();
        //binddata1();

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
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }



    protected void btnOrder_Click(object sender, EventArgs e)
    {
        try { 
        Response.Redirect("OrderDetail.aspx");
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }


    protected void lnkEditItemOK_Click(object sender, EventArgs e)
    {
        try { 
        var DC = new DataClassesDataContext();
        tblitem ItemData = DC.tblitems.Single(ob => ob.ItemID == Convert.ToInt32(hdnItemID.Value));
        ItemData.ItemName = txtItemName1.Text;
        ItemData.ItemPrice = Convert.ToInt32(txtItemPrice1.Text);
        ItemData.ItemDescription = txtItemDescription1.Text;
        DC.SubmitChanges();
        lblItemName1.Visible = true;
        txtItemName1.Visible = false;
        lblItemPrice1.Visible = true;
        txtItemPrice1.Visible = false;
        divItemDescltr.Visible = true;
        divItemDesctxt.Visible = false;
        imgItemType1.Visible = true;
        imgbtnItemType1.Visible = false;
        if (ItemData.ItemStatus == false)
        {
            lnkShowItem.Visible = true;
            lnkHideItem.Visible = false;
        }
        else
        {
            lnkHideItem.Visible = true;
            lnkShowItem.Visible = false;
        }
        temp = 0;
        BindMenu();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void lnkDeleteItem_Click(object sender, EventArgs e)
    {
        try { 
        var DC = new DataClassesDataContext();
        tblitem ItemData = DC.tblitems.Single(ob => ob.ItemID == Convert.ToInt32(hdnItemID.Value));
        ItemData.Isactive = false;

        DC.SubmitChanges();
        BindMenu();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void lnkHideMeal_Click(object sender, EventArgs e)
    {
        try { 
        var DC = new DataClassesDataContext();
        tblitem ItemData = DC.tblitems.Single(ob => ob.ItemID == Convert.ToInt32(hdnItemID.Value));
        ItemData.ItemStatus = false;
        DC.SubmitChanges();
        BindMenu();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void lnkShowMeal_Click(object sender, EventArgs e)
    {
        try { 
        var DC = new DataClassesDataContext();
        tblitem ItemData = DC.tblitems.Single(ob => ob.ItemID == Convert.ToInt32(hdnItemID.Value));
        ItemData.ItemStatus = true;
        DC.SubmitChanges();
        BindMenu();
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void txtaddmnm_TextChanged(object sender, EventArgs e)
    {
        try { 
        var dc = new DataClassesDataContext();
        var str1 = (from p2 in dc.tblMenuDetails
                    where p2.MenuName == txtaddmnm.Text && p2.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"])
                    select p2).Count();
        if (str1 > 0)
        {
            errorSameManu.Visible = true;
        }
        else
        {
            errorSameManu.Visible = false;
        }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void txtItemName_TextChanged(object sender, EventArgs e)
    {
        try { 
        var dc = new DataClassesDataContext();
        tblMenuDetail data = (from p2 in dc.tblMenuDetails
                              where p2.MenuID == Convert.ToInt32(ddlMenu.SelectedValue) && p2.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"])
                              select p2).Single();
        var str1 = (from obj in dc.tblitems
                    where obj.MenuID == Convert.ToInt32(data.MenuID) && obj.ItemName == txtItemName.Text
                    select obj.ItemName).Count();

        if (str1 > 0)
        {
            errorSameItem.Visible = true;
        }
        else
        {
            errorSameItem.Visible = false;
        }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void txtmnm_TextChanged(object sender, EventArgs e)
    {
        try { 
        var dc = new DataClassesDataContext();
        var str1 = (from p2 in dc.tblMealPlans
                    where p2.MealName == txtmnm.Text && p2.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"])
                    select p2).Count();
        if (str1 > 0)
        {
            errorSameMeal.Visible = true;
        }
        else
        {
            errorSameMeal.Visible = false;
        }
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void lnkEditProfile_Click(object sender, EventArgs e)
    {
        try { 
        lblComName.Visible = false;
        lnkSPNAME.Visible = false;
        lblEmail.Visible = false;
        lblContectNo.Visible = false;
        divAddressDetail.Visible = false;
        textCompanyName.Visible = true;
        txtFName.Visible = true;
        txtLName.Visible = true;
        txtContactNo.Visible = true;
        txtEmailID.Visible = true;
        divAddress.Visible = true;
        lnkEditProfile.Visible = false;
        lnkUpdateProfile.Visible = true;
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void lnkUpdateProfile_Click(object sender, EventArgs e)
    {
        try { 
        var DC = new DataClassesDataContext();
        tblServiceProvider SPData = (from obj in DC.tblServiceProviders
                                     where obj.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"])
                                     select obj).Single();
        tblAddress AddressData = (from obj in DC.tblAddresses
                                  where obj.AddressID == SPData.AddressID
                                  select obj).Single();
        SPData.CompanyName = textCompanyName.Text;
        SPData.ContactNo = txtContactNo.Text;
        SPData.Email = txtEmailID.Text;
        SPData.FirstName = txtFName.Text;
        SPData.LastName = txtLName.Text;

        AddressData.Address = textStreet.Text;
        AddressData.Area = textLandmark.Text;
        AddressData.PincodeNo = textZipCode.Text;
        AddressData.CityID = Convert.ToInt32(ddCity.SelectedValue);
        DC.SubmitChanges();

        lblComName.Visible = true;
        lnkSPNAME.Visible = true;
        lblEmail.Visible = true;
        lblContectNo.Visible = true;
        divAddressDetail.Visible = true;
        textCompanyName.Visible = false;
        txtFName.Visible = false;
        txtLName.Visible = false;
        txtContactNo.Visible = false;
        txtEmailID.Visible = false;
        divAddress.Visible = false;
        lnkEditProfile.Visible = true;
        lnkUpdateProfile.Visible = false;

        lblComName.Text = SPData.CompanyName;
        lnkSPNAME.Text = SPData.FirstName + " " + SPData.LastName;
        lblEmail.Text = SPData.Email;
        lblContectNo.Text = SPData.ContactNo;
        ltrAddress.Text = AddressData.Address;
        ltrLandmark.Text = AddressData.Landmark;
        ltrCity.Text = ddCity.SelectedItem.Text;
        ltrState.Text = ddState.SelectedItem.Text;
        ltrCountry.Text = ddCountry.SelectedItem.Text;
        }
        catch (Exception ex)
        {
            int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", session, 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }
}