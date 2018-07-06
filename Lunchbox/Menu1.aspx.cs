using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.NetworkInformation;

public partial class Menu : System.Web.UI.Page
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
        if (Session["ddlmemeal"] == null)
        {
            ddlmtype.SelectedIndex = 0;
            ddltime.SelectedIndex = 0;
            Session["ddlmemeal"] = ddlmtype.SelectedIndex;
            Session["ddltime"] = ddltime.SelectedIndex;
            string Type = "Veg";
            Session["Check"] = Type;
        }
        if (!IsPostBack)
        {
            Binddata();
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

    private void GetRateData()
    {
        try { 
        List<int> RateData = new List<int>(); if (chkRate1.Checked)
        {
            RateData.Add(Convert.ToInt32(1));
        }
        if (chkRate2.Checked)
        {
            RateData.Add(Convert.ToInt32(2));
        }
        if (chkRate3.Checked)
        {
            RateData.Add(Convert.ToInt32(3));
        }
        if (chkRate4.Checked)
        {
            RateData.Add(Convert.ToInt32(4));
        }
        if (chkRate5.Checked)
        {
            RateData.Add(Convert.ToInt32(5));
        }

        //foreach (int cntData in RateData)
        //{
        //    Response.Write(cntData + "<br>");
        //}
        if (RateData.Count != 0)
        {
            foreach (RepeaterItem item in rptmeal.Items)
            {
                Image imgRate = (Image)item.FindControl("imgRate");
                string Rate = ((imgRate.ImageUrl.ToString()).ElementAt(5)).ToString();
                //Response.Write(Rate + "<br>");

                if (RateData.Contains(Convert.ToInt32(Rate)))
                {
                    item.Visible = true;
                }
                else
                {
                    item.Visible = false;
                }
            }

        }


        List<int> SPData = new List<int>();
        foreach (ListItem lst in chkMealSer.Items)
        {
            if (lst.Selected)
            {
                //IList<int> Data = new int[] { Convert.ToInt32(lst.Value) };
                SPData.Add(Convert.ToInt32(lst.Value)); //Data[0] Convert.ToInt32(lst.Value)
            }
        }

        if (SPData.Count != 0)
        {
            foreach (RepeaterItem item in rptmeal.Items)
            {

                HiddenField hdnServiceProviderID = (HiddenField)item.FindControl("hdnServiceProviderID");

                //Response.Write(Rate + "<br>");

                if (SPData.Contains(Convert.ToInt32(hdnServiceProviderID.Value)))
                {
                    item.Visible = true;
                }
                else
                {
                    item.Visible = false;
                }
            }
        }


        List<int> LocationData = new List<int>();
        foreach (ListItem lst in chkLstLocation.Items)
        {
            if (lst.Selected)
            {
                //IList<int> Data = new int[] { Convert.ToInt32(lst.Value) };
                LocationData.Add(Convert.ToInt32(lst.Value)); //Data[0] Convert.ToInt32(lst.Value)
            }
        }
        var DC = new DataClassesDataContext();
        if (LocationData.Count != 0)
        {
            foreach (RepeaterItem item in rptmeal.Items)
            {

                HiddenField hdnServiceProviderID = (HiddenField)item.FindControl("hdnServiceProviderID");

                //Response.Write(Rate + "<br>");
                tblAddress AddData = (from obj in DC.tblAddresses
                                      join obj1 in DC.tblServiceProviders
                                      on obj.AddressID equals obj1.AddressID
                                      where obj1.ServiceProviderID == Convert.ToInt32(hdnServiceProviderID.Value)
                                      select obj).Single();

                if (LocationData.Contains(Convert.ToInt32(AddData.PincodeNo)))
                {
                    item.Visible = true;
                }
                else
                {
                    item.Visible = false;
                }
            }
        }
        if (SPData.Count == 0 && LocationData.Count == 0 && RateData.Count == 0)
        {
            foreach (RepeaterItem item in rptmeal.Items)
            {
                item.Visible = true;
            }
        }
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", 0 , 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    private void GetData()
    {
        try { 
        var DC = new DataClassesDataContext();






            //foreach (int cntData in SPData)
            //{
            //    Response.Write(cntData + "<br>");
            //}



            //foreach (int cntData in LocationData)
            //{
            //    Response.Write(cntData + "<br>");
            //}









            //var Data = from obj in DC.tblMealPlans
            //           join obj1 in DC.tblServiceProviders
            //           on obj.ServiceProviderID equals obj1.ServiceProviderID
            //           join obj2 in DC.tblAddresses
            //           on obj1.AddressID equals obj2.AddressID
            //           where obj.MealType == Session["Check"].ToString() && obj.Time == Session["ddltime"].ToString() 
            //           select new
            //           {
            //               img = (from o1 in DC.tblImages
            //                      where o1.ImagesID == obj.ImageID
            //                      select new
            //                      {
            //                          str = o1.Name

            //                      }).Take(1).SingleOrDefault().str,
            //               obj.MealID,
            //               obj.MealName,
            //               obj.MealType,
            //               obj.MealDescription,
            //               sp = (from ob in DC.tblServiceProviders
            //                     where ob.ServiceProviderID == obj.ServiceProviderID
            //                     select new
            //                     {
            //                         str = ob.FirstName + " " + ob.LastName
            //                     }).Take(1).SingleOrDefault().str,
            //           };
            //rptmeal.DataSource = Data;
            //rptmeal.DataBind();

        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", 0 , 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
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

    private void Binddata()
    {
        try { 
        ddlmtype.SelectedIndex = Convert.ToInt32(Session["ddlmemeal"]);
        ddltime.SelectedIndex = Convert.ToInt32(Session["ddltime"]);
        string ck;
        var DC = new DataClassesDataContext();
        var SPSelection = from obj in DC.tblPackages
                          orderby obj.Price descending
                          select obj;
        //rptServiceProvider.DataSource = SPSelection;
        //rptServiceProvider.DataBind();
        var Location = from obj in DC.tblAreas
                       select obj;
        chkLstLocation.DataSource = Location;
        chkLstLocation.DataTextField = "AreaName";
        chkLstLocation.DataValueField = "PinCode";
        chkLstLocation.DataBind();
        //int SPcnt = rptServiceProvider.Items.Count;
        //foreach (RepeaterItem item in rptServiceProvider.Items)
        //{
        //    CheckBox chk = (CheckBox)item.FindControl("chkServiceProvider");
        //    chk.Text = "&nbsp;&nbsp;&nbsp;" + SPcnt.ToString() + " Stars";
        //    SPcnt = SPcnt - 1;

        //}
        if (Session["ddlmemeal"].ToString() == "0")
        {
            ck = "Meal";

            Panel2.Visible = true;
            divMealTypeSelector.Visible = true;
            IQueryable<tblServiceProvider> SPData = from obj in DC.tblServiceProviders
                                                    join obj1 in DC.tblSPPackages
                                                    on obj.ServiceProviderID equals obj1.ServiceProviderID
                                                    where obj1.PackagesId == 1
                                                    select obj;
            chkMealSer.DataSource = SPData;
            chkMealSer.DataTextField = "CompanyName";
            chkMealSer.DataValueField = "ServiceProviderID";
            chkMealSer.DataBind();
            foreach (RepeaterItem item in rptmeal.Items)
            {
                HiddenField hdnMealID = (HiddenField)item.FindControl("hdnMealID");
                Image img = (Image)item.FindControl("imgRate");
                int MealData = (from obj in DC.tblRates
                                where obj.FoodID == Convert.ToInt32(hdnMealID.Value) && obj.IsItem == false
                                select obj).Count();
                if (MealData > 0)
                {
                    int TotalRate = 0;
                    IQueryable<tblRate> RateData = from obj in DC.tblRates
                                                   where obj.FoodID == Convert.ToInt32(hdnMealID.Value) && obj.IsItem == false
                                                   select obj;
                    foreach (tblRate item1 in RateData)
                    {
                        TotalRate += item1.Point;
                    }
                    int Rate = TotalRate / MealData;
                    img.ImageUrl = "Rate/" + Rate + ".jpg";
                }
                else
                {
                    img.ImageUrl = "Rate/0.jpg";
                }
            }
        }
        else
        {
            ck = "Menu";
            Panel3.Visible = true;
        }

        if (Session["Check"].ToString() == "Veg")
        {
            chkvegmeal.Checked = true;

        }
        else if (Session["Check"].ToString() == "Non-Veg")
        {
            chknonvegmeal.Checked = true;
        }
        else
        {
            Combo.Checked = true;
        }


        string ve;
        if (Session["ddltime"].ToString() == "1")
        {
            ve = "Lunch";

        }
        else
        {
            ve = "Dinner";
        }


        if (Session["Check"].ToString() != "Both")
        {
            var data = from obj in DC.tblMealPlans
                       where obj.Time == ve && obj.MealType == Session["Check"].ToString()
                       select new
                       {
                           img = (from o1 in DC.tblImages
                                  where o1.ImagesID == obj.ImageID
                                  select new
                                  {
                                      str = o1.Name

                                  }).Take(1).SingleOrDefault().str,
                           obj.MealID,
                           obj.MealName,
                           obj.ServiceProviderID,
                           obj.MealType,
                           obj.MealDescription,
                           sp = (from ob in DC.tblServiceProviders
                                 where ob.ServiceProviderID == obj.ServiceProviderID
                                 select new
                                 {
                                     str = ob.FirstName + " " + ob.LastName
                                 }).Take(1).SingleOrDefault().str,
                       };

            DC.SubmitChanges();
            rptmeal.DataSource = data;
            rptmeal.DataBind();

            foreach (RepeaterItem item in rptmeal.Items)
            {
                HiddenField hdnMealID = (HiddenField)item.FindControl("hdnMealID");
                Image img = (Image)item.FindControl("imgRate");
                int MealData = (from obj in DC.tblRates
                                where obj.FoodID == Convert.ToInt32(hdnMealID.Value) && obj.IsItem == false
                                select obj).Count();
                if (MealData > 0)
                {
                    int TotalRate = 0;
                    IQueryable<tblRate> RateData = from obj in DC.tblRates
                                                   where obj.FoodID == Convert.ToInt32(hdnMealID.Value) && obj.IsItem == false
                                                   select obj;
                    foreach (tblRate item1 in RateData)
                    {
                        TotalRate += item1.Point;
                    }
                    int Rate = TotalRate / MealData;
                    img.ImageUrl = "Rate/" + Rate + ".jpg";
                }
                else
                {
                    img.ImageUrl = "Rate/0.jpg";
                }
            }
            GetRateData();
            var data1 = from obj in DC.tblMenuDetails
                        where obj.MenuType == Session["Check"].ToString()
                        select new
                        {
                            img = (from o1 in DC.tblImages
                                   where o1.ImagesID == obj.ImageID
                                   select new
                                   {
                                       str = o1.Name

                                   }).Take(1).SingleOrDefault().str,
                            obj.MenuID,
                            obj.MenuName,
                            obj.MenuType,

                        };

            DC.SubmitChanges();
            rptmenu.DataSource = data1;
            rptmenu.DataBind();

            foreach (RepeaterItem item in rptmenu.Items)
            {
                HiddenField hdn = (HiddenField)item.FindControl("hdnMenuID");
                Repeater rpt = (Repeater)item.FindControl("rptitem");
                var str = from obj in DC.tblitems
                          join obj4 in DC.tblMenuDetails
                          on obj.MenuID equals obj4.MenuID
                          where obj.MenuID == Convert.ToInt32(hdn.Value)
                          select new
                          {
                              obj.MenuID,
                              obj.ItemID,
                              obj.ItemName,
                              obj.ItemPrice,
                              obj.ItemDescription,
                              obj.ItemType,
                              img = (from obj1 in DC.tblImages
                                     where obj1.ImagesID == obj.ImageID
                                     select obj1.Name).Single(),
                              SPname = (from obj2 in DC.tblServiceProviders
                                        where obj2.ServiceProviderID == obj4.ServiceProviderID
                                        select obj2.FirstName + " " + obj2.LastName).Single()

                          };
                int cnt = (from obj in DC.tblitems
                           where obj.MenuID == Convert.ToInt32(hdn.Value)
                           select obj).Count();
                if (cnt > 0)
                {
                    rpt.DataSource = str;
                    rpt.DataBind();
                }
                else
                {
                    item.Visible = false;
                }
                foreach (RepeaterItem item1 in rpt.Items)
                {
                    HiddenField hdnMealID = (HiddenField)item1.FindControl("hdnItemID");
                    Image img = (Image)item1.FindControl("imgRate");
                    int MealData = (from obj in DC.tblRates
                                    where obj.FoodID == Convert.ToInt32(hdnMealID.Value) && obj.IsItem == true
                                    select obj).Count();
                    if (MealData > 0)
                    {
                        int TotalRate = 0;
                        IQueryable<tblRate> RateData = from obj in DC.tblRates
                                                       where obj.FoodID == Convert.ToInt32(hdnMealID.Value) && obj.IsItem == true
                                                       select obj;
                        foreach (tblRate item2 in RateData)
                        {
                            TotalRate += item2.Point;
                        }
                        int Rate = TotalRate / MealData;
                        img.ImageUrl = "Rate/" + Rate + ".jpg";
                    }
                    else
                    {
                        img.ImageUrl = "Rate/0.jpg";
                    }
                }
            }
        }
        else
        {
            var data = from obj in DC.tblMealPlans
                       where obj.Time == ve
                       select new
                       {
                           img = (from o1 in DC.tblImages
                                  where o1.ImagesID == obj.ImageID
                                  select new
                                  {
                                      str = o1.Name

                                  }).Take(1).SingleOrDefault().str,
                           obj.MealID,
                           obj.MealName,
                           obj.ServiceProviderID,
                           obj.MealType,
                           obj.MealDescription,
                           sp = (from ob in DC.tblServiceProviders
                                 where ob.ServiceProviderID == obj.ServiceProviderID
                                 select new
                                 {
                                     str = ob.FirstName + " " + ob.LastName
                                 }).Take(1).SingleOrDefault().str,
                       };

            DC.SubmitChanges();
            rptmeal.DataSource = data;
            rptmeal.DataBind();

            foreach (RepeaterItem item in rptmeal.Items)
            {
                HiddenField hdnMealID = (HiddenField)item.FindControl("hdnMealID");
                Image img = (Image)item.FindControl("imgRate");
                int MealData = (from obj in DC.tblRates
                                where obj.FoodID == Convert.ToInt32(hdnMealID.Value) && obj.IsItem == false
                                select obj).Count();
                if (MealData > 0)
                {
                    int TotalRate = 0;
                    IQueryable<tblRate> RateData = from obj in DC.tblRates
                                                   where obj.FoodID == Convert.ToInt32(hdnMealID.Value) && obj.IsItem == false
                                                   select obj;
                    foreach (tblRate item1 in RateData)
                    {
                        TotalRate += item1.Point;
                    }
                    int Rate = TotalRate / MealData;
                    img.ImageUrl = "Rate/" + Rate + ".jpg";
                }
                else
                {
                    img.ImageUrl = "Rate/0.jpg";
                }
            }
            GetRateData();
            var data1 = from obj in DC.tblMenuDetails

                        select new
                        {
                            img = (from o1 in DC.tblImages
                                   where o1.ImagesID == obj.ImageID
                                   select new
                                   {
                                       str = o1.Name

                                   }).Take(1).SingleOrDefault().str,
                            obj.MenuID,
                            obj.MenuName,
                            obj.MenuType,

                        };

            DC.SubmitChanges();
            rptmenu.DataSource = data1;
            rptmenu.DataBind();

            foreach (RepeaterItem item in rptmenu.Items)
            {
                HiddenField hdn = (HiddenField)item.FindControl("hdnMenuID");
                Repeater rpt = (Repeater)item.FindControl("rptitem");
                var str = from obj in DC.tblitems
                          join obj4 in DC.tblMenuDetails
                          on obj.MenuID equals obj4.MenuID
                          where obj.MenuID == Convert.ToInt32(hdn.Value)
                          select new
                          {
                              obj.MenuID,
                              obj.ItemID,
                              obj.ItemName,
                              obj.ItemPrice,
                              obj.ItemDescription,
                              obj.ItemType,
                              img = (from obj1 in DC.tblImages
                                     where obj1.ImagesID == obj.ImageID
                                     select obj1.Name).Single(),
                              SPname = (from obj2 in DC.tblServiceProviders
                                        where obj2.ServiceProviderID == obj4.ServiceProviderID
                                        select obj2.FirstName + " " + obj2.LastName).Single()

                          };
                int cnt = (from obj in DC.tblitems
                           where obj.MenuID == Convert.ToInt32(hdn.Value)
                           select obj).Count();
                if (cnt > 0)
                {
                    rpt.DataSource = str;
                    rpt.DataBind();
                }
                else
                {
                    item.Visible = false;
                }
                foreach (RepeaterItem item1 in rpt.Items)
                {
                    HiddenField hdnMealID = (HiddenField)item1.FindControl("hdnItemID");
                    Image img = (Image)item1.FindControl("imgRate");
                    int MealData = (from obj in DC.tblRates
                                    where obj.FoodID == Convert.ToInt32(hdnMealID.Value) && obj.IsItem == true
                                    select obj).Count();
                    if (MealData > 0)
                    {
                        int TotalRate = 0;
                        IQueryable<tblRate> RateData = from obj in DC.tblRates
                                                       where obj.FoodID == Convert.ToInt32(hdnMealID.Value) && obj.IsItem == true
                                                       select obj;
                        foreach (tblRate item2 in RateData)
                        {
                            TotalRate += item2.Point;
                        }
                        int Rate = TotalRate / MealData;
                        img.ImageUrl = "Rate/" + Rate + ".jpg";
                    }
                    else
                    {
                        img.ImageUrl = "Rate/0.jpg";
                    }
                }
            }
        }
        Session["ddlmemeal"] = null;
        Session["ddltime"] = null;
        Session["Check"] = null;
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", 0 , 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }

    }

    protected void btnserch_Click(object sender, EventArgs e)
    {
        try { 
        var DC = new DataClassesDataContext();
        string Ve1;
        if (chkvegmeal.Checked == true)
        {
            Ve1 = "Veg";
        }
        else if (chknonvegmeal.Checked == true)
        {
            Ve1 = "Non-Veg";
        }
        else if (Combo.Checked == true)
        {
            Ve1 = "Both";

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
            Ve1 = "";
        }

        string ck;
        if (ddlmtype.SelectedIndex == 0)
        {
            ck = "Meal";
            Panel2.Visible = true;
            Panel3.Visible = false;

        }
        else
        {
            ck = "Menu";
            Panel3.Visible = true;
            Panel2.Visible = false;
        }

        string ve;
        if (ddltime.SelectedIndex == 1)
        {
            ve = "Lunch";

        }
        else
        {
            ve = "Dinner";
        }

        if (Ve1 != "Both")
        {
            var data = from obj in DC.tblMealPlans
                       where (obj.MealType == Ve1) && obj.Time == ve
                       select new
                       {
                           img = (from o1 in DC.tblImages
                                  where o1.ImagesID == obj.ImageID
                                  select new
                                  {
                                      str = o1.Name

                                  }).Take(1).SingleOrDefault().str,
                           obj.MealID,
                           obj.MealName,
                           obj.MealType,
                           obj.MealDescription,
                           obj.ServiceProviderID,
                           sp = (from ob in DC.tblServiceProviders
                                 where ob.ServiceProviderID == obj.ServiceProviderID
                                 select new
                                 {
                                     str = ob.FirstName + " " + ob.LastName
                                 }).Take(1).SingleOrDefault().str

                       };


            DC.SubmitChanges();
            rptmeal.DataSource = data;
            rptmeal.DataBind();

            foreach (RepeaterItem item in rptmeal.Items)
            {
                HiddenField hdnMealID = (HiddenField)item.FindControl("hdnMealID");
                Image img = (Image)item.FindControl("imgRate");
                int MealData = (from obj in DC.tblRates
                                where obj.FoodID == Convert.ToInt32(hdnMealID.Value) && obj.IsItem == false
                                select obj).Count();
                if (MealData > 0)
                {
                    int TotalRate = 0;
                    IQueryable<tblRate> RateData = from obj in DC.tblRates
                                                   where obj.FoodID == Convert.ToInt32(hdnMealID.Value) && obj.IsItem == false
                                                   select obj;
                    foreach (tblRate item1 in RateData)
                    {
                        TotalRate += item1.Point;
                    }
                    int Rate = TotalRate / MealData;
                    img.ImageUrl = "Rate/" + Rate + ".jpg";
                }
                else
                {
                    img.ImageUrl = "Rate/0.jpg";
                }
            }
            GetRateData();

            var data1 = from obj in DC.tblMenuDetails
                        where obj.MenuType == Ve1 || obj.MenuType == "Both"
                        select new
                        {
                            img = (from o1 in DC.tblImages
                                   where o1.ImagesID == obj.ImageID
                                   select new
                                   {
                                       str = o1.Name

                                   }).Take(1).SingleOrDefault().str,
                            obj.MenuID,
                            obj.MenuName,
                            obj.MenuType,

                        };

            DC.SubmitChanges();
            rptmenu.DataSource = data1;
            rptmenu.DataBind();

            foreach (RepeaterItem item in rptmenu.Items)
            {
                HiddenField hdn = (HiddenField)item.FindControl("hdnMenuID");
                Repeater rpt = (Repeater)item.FindControl("rptitem");
                var str = from obj in DC.tblitems
                          join obj4 in DC.tblMenuDetails
                          on obj.MenuID equals obj4.MenuID
                          where obj.MenuID == Convert.ToInt32(hdn.Value) && obj.Time == ve
                          select new
                          {
                              obj.MenuID,
                              obj.ItemID,
                              obj.ItemName,
                              obj.ItemPrice,
                              obj.ItemDescription,
                              obj.ItemType,
                              img = (from obj1 in DC.tblImages
                                     where obj1.ImagesID == obj.ImageID
                                     select obj1.Name).Single(),
                              SPname = (from obj2 in DC.tblServiceProviders
                                        where obj2.ServiceProviderID == obj4.ServiceProviderID
                                        select obj2.FirstName + " " + obj2.LastName).Single()

                          };
                int cnt = (from obj in DC.tblitems
                           where obj.MenuID == Convert.ToInt32(hdn.Value)
                           select obj).Count();
                if (cnt > 0)
                {
                    item.Visible = true;
                    rpt.DataSource = str;
                    rpt.DataBind();
                }
                else
                {
                    item.Visible = false;
                }
                foreach (RepeaterItem item1 in rpt.Items)
                {
                    HiddenField hdnMealID = (HiddenField)item1.FindControl("hdnItemID");
                    Image img = (Image)item1.FindControl("imgRate");
                    int MealData = (from obj in DC.tblRates
                                    where obj.FoodID == Convert.ToInt32(hdnMealID.Value) && obj.IsItem == true
                                    select obj).Count();
                    if (MealData > 0)
                    {
                        int TotalRate = 0;
                        IQueryable<tblRate> RateData = from obj in DC.tblRates
                                                       where obj.FoodID == Convert.ToInt32(hdnMealID.Value) && obj.IsItem == true
                                                       select obj;
                        foreach (tblRate item2 in RateData)
                        {
                            TotalRate += item2.Point;
                        }
                        int Rate = TotalRate / MealData;
                        img.ImageUrl = "Rate/" + Rate + ".jpg";
                    }
                    else
                    {
                        img.ImageUrl = "Rate/0.jpg";
                    }
                }
            }
        }
        else
        {
            var data = from obj in DC.tblMealPlans
                       where obj.Time == ve
                       select new
                       {
                           img = (from o1 in DC.tblImages
                                  where o1.ImagesID == obj.ImageID
                                  select new
                                  {
                                      str = o1.Name

                                  }).Take(1).SingleOrDefault().str,
                           obj.MealID,
                           obj.MealName,
                           obj.ServiceProviderID,
                           obj.MealType,
                           obj.MealDescription,
                           sp = (from ob in DC.tblServiceProviders
                                 where ob.ServiceProviderID == obj.ServiceProviderID
                                 select new
                                 {
                                     str = ob.FirstName + " " + ob.LastName
                                 }).Take(1).SingleOrDefault().str
                       };
            DC.SubmitChanges();
            rptmeal.DataSource = data;
            rptmeal.DataBind();

            foreach (RepeaterItem item in rptmeal.Items)
            {
                HiddenField hdnMealID = (HiddenField)item.FindControl("hdnMealID");
                Image img = (Image)item.FindControl("imgRate");
                int MealData = (from obj in DC.tblRates
                                where obj.FoodID == Convert.ToInt32(hdnMealID.Value) && obj.IsItem == false
                                select obj).Count();
                if (MealData > 0)
                {
                    int TotalRate = 0;
                    IQueryable<tblRate> RateData = from obj in DC.tblRates
                                                   where obj.FoodID == Convert.ToInt32(hdnMealID.Value) && obj.IsItem == false
                                                   select obj;
                    foreach (tblRate item1 in RateData)
                    {
                        TotalRate += item1.Point;
                    }
                    int Rate = TotalRate / MealData;
                    img.ImageUrl = "Rate/" + Rate + ".jpg";
                }
                else
                {
                    img.ImageUrl = "Rate/0.jpg";
                }
            }
            GetRateData();

            var data1 = from obj in DC.tblMenuDetails

                        select new
                        {
                            img = (from o1 in DC.tblImages
                                   where o1.ImagesID == obj.ImageID
                                   select new
                                   {
                                       str = o1.Name

                                   }).Take(1).SingleOrDefault().str,
                            obj.MenuID,
                            obj.MenuName,
                            obj.MenuType,

                        };

            DC.SubmitChanges();
            rptmenu.DataSource = data1;
            rptmenu.DataBind();

            foreach (RepeaterItem item in rptmenu.Items)
            {
                HiddenField hdn = (HiddenField)item.FindControl("hdnMenuID");
                Repeater rpt = (Repeater)item.FindControl("rptitem");
                var str = from obj in DC.tblitems
                          join obj4 in DC.tblMenuDetails
                          on obj.MenuID equals obj4.MenuID
                          where obj.MenuID == Convert.ToInt32(hdn.Value) && obj.Time == ve
                          select new
                          {
                              obj.MenuID,
                              obj.ItemID,
                              obj.ItemName,
                              obj.ItemPrice,
                              obj.ItemDescription,
                              obj.ItemType,
                              img = (from obj1 in DC.tblImages
                                     where obj1.ImagesID == obj.ImageID
                                     select obj1.Name).Single(),
                              SPname = (from obj2 in DC.tblServiceProviders
                                        where obj2.ServiceProviderID == obj4.ServiceProviderID
                                        select obj2.FirstName + " " + obj2.LastName).Single()

                          };
                int cnt = (from obj in DC.tblitems
                           where obj.MenuID == Convert.ToInt32(hdn.Value)
                           select obj).Count();
                if (cnt > 0)
                {
                    item.Visible = true;
                    rpt.DataSource = str;
                    rpt.DataBind();
                }
                else
                {
                    item.Visible = false;
                }
                foreach (RepeaterItem item1 in rpt.Items)
                {
                    HiddenField hdnMealID = (HiddenField)item1.FindControl("hdnItemID");
                    Image img = (Image)item1.FindControl("imgRate");
                    int MealData = (from obj in DC.tblRates
                                    where obj.FoodID == Convert.ToInt32(hdnMealID.Value) && obj.IsItem == true
                                    select obj).Count();
                    if (MealData > 0)
                    {
                        int TotalRate = 0;
                        IQueryable<tblRate> RateData = from obj in DC.tblRates
                                                       where obj.FoodID == Convert.ToInt32(hdnMealID.Value) && obj.IsItem == true
                                                       select obj;
                        foreach (tblRate item2 in RateData)
                        {
                            TotalRate += item2.Point;
                        }
                        int Rate = TotalRate / MealData;
                        img.ImageUrl = "Rate/" + Rate + ".jpg";
                    }
                    else
                    {
                        img.ImageUrl = "Rate/0.jpg";
                    }
                }
            }
        }
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", 0 , 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void rptmeal_ItemCommand1(object source, RepeaterCommandEventArgs e)
    {
        try { 
        var DC = new DataClassesDataContext();
        if (e.CommandName == "ViewSPProfile")
        {
            int SPID = (from obj in DC.tblMealPlans
                        where obj.MealID == Convert.ToInt32(e.CommandArgument)
                        select obj.ServiceProviderID).Single();
            Session["ViewServiceProviderID"] = SPID;
            Response.Write(Session["ViewServiceProviderID"]);
            Response.Redirect("Profile_SP.aspx");
        }
        else if (e.CommandName == "CartMeal")
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
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", 0 , 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void rptitem_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try { 
        var DC = new DataClassesDataContext();
        if (e.CommandName == "ViewSPProfile")
        {
            int SPID = (from obj in DC.tblitems
                        join obj1 in DC.tblMenuDetails
                         on obj.MenuID equals obj1.MenuID
                        where obj.ItemID == Convert.ToInt32(e.CommandArgument)
                        select obj1.ServiceProviderID).Single();
            Session["ViewServiceProviderID"] = SPID;
            Response.Write(Session["ViewServiceProviderID"]);
            Response.Redirect("Profile_SP.aspx");
        }
        else if (e.CommandName == "CartItem")
        {

            tblcart cart = new tblcart();
            cart.MealID = null;
            cart.MACAddress = GetMACAddress();
            int ItemID = Convert.ToInt32(e.CommandArgument);
            cart.ItemID = ItemID;
            cart.IsActive = true;
            cart.Quantity = 1;
            cart.Date = DateTime.Now;
            DC.tblcarts.InsertOnSubmit(cart);
            DC.SubmitChanges();
        }
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", 0 , 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void rptmenu_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try { 
        if (e.CommandName == "ViewItem")
        {
            Panel divItem = (Panel)e.Item.FindControl("divItem");
            if (divItem.Visible == false)
            {
                divItem.Visible = true;
            }
            else
            {
                divItem.Visible = false;
            }
        }
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", 0 , 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void chkMealSerAll_CheckedChanged(object sender, EventArgs e)
    {
        try { 
        //foreach(RepeaterItem item in rptMealType.Items)
        //{
        //    CheckBox chk = (CheckBox)item.FindControl("chkMealType");
        //    if (chkMealSerAll.Checked)
        //    {
        //        chk.Checked = true;
        //    }
        //    else
        //    {
        //        chk.Checked = false;
        //    }
        //}
        if (chkMealSerAll.Checked)
        {

            foreach (ListItem lst in chkMealSer.Items)
            {
                lst.Selected = true;
            }
        }
        else
        {
            foreach (ListItem lst in chkMealSer.Items)
            {
                lst.Selected = false;
            }
        }
        GetRateData();
            //GetData();
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", 0 , 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void chkSPRate_CheckedChanged(object sender, EventArgs e)
    {
        try { 
        if (chkSPRate.Checked)
        {
            chkRate1.Checked = true;
            chkRate2.Checked = true;
            chkRate3.Checked = true;
            chkRate4.Checked = true;
            chkRate5.Checked = true;
        }
        else
        {
            chkRate1.Checked = false;
            chkRate2.Checked = false;
            chkRate3.Checked = false;
            chkRate4.Checked = false;
            chkRate5.Checked = false;
        }
        //}
        GetRateData();
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", 0 , 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void chkLocation_CheckedChanged(object sender, EventArgs e)
    {
        try { 
        if (chkLocation.Checked)
        {

            foreach (ListItem lst in chkLstLocation.Items)
            {
                lst.Selected = true;
            }
        }
        else
        {
            foreach (ListItem lst in chkLstLocation.Items)
            {
                lst.Selected = false;
            }
        }
        GetRateData();
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", 0 , 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void chkRate5_CheckedChanged(object sender, EventArgs e)
    {
        try { 
        GetRateData();
        }
        catch (Exception ex)
        {
            /*int session = Convert.ToInt32(Session["UserID"].ToString())*/;
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", 0 , 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void chkRate4_CheckedChanged(object sender, EventArgs e)
    {
        try { 
        GetRateData();
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", 0 , 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void chkRate3_CheckedChanged(object sender, EventArgs e)
    {
        try { 
        GetRateData();
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", 0 , 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void chkRate2_CheckedChanged(object sender, EventArgs e)
    {
        try { 
        GetRateData();
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", 0 , 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void chkRate1_CheckedChanged(object sender, EventArgs e)
    {
        try { 
        GetRateData();
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", 0 , 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void chkMealSer_SelectedIndexChanged(object sender, EventArgs e)
    {
        try { 
        GetRateData();
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", 0 , 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }

    protected void chkLstLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        try { 
        GetRateData();
        }
        catch (Exception ex)
        {
            //int session = Convert.ToInt32(Session["UserID"].ToString());
            string PageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string MACAddress = GetMacAddress();
            AddErrorLog(ref ex, PageName, "User", 0 , 0, MACAddress);
            ClientScript.RegisterStartupScript(GetType(), "abc", "alert('Something went wrong! Try again');", true);
        }
    }
}




