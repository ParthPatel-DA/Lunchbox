using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Net.NetworkInformation;

public partial class Admin_Dashboard : System.Web.UI.Page
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
                BindData();
            }
            var dc = new DataClassesDataContext();
            int SerCnt = dc.tblServiceProviders.Count(ob => ob.IsVerify == true);
            lblser.Text = SerCnt.ToString();

            int ClientCnt = dc.tblClients.Count(ob => ob.IsActive == true);
            lblcli.Text = ClientCnt.ToString();

            int Mealcnt = dc.tblMealPlans.Count(ob => ob.IsActive == true);
            lblMeal.Text = Mealcnt.ToString();

            int Menucnt = dc.tblMealPlans.Count(ob => ob.IsActive == true);
            lblMenu.Text = Menucnt.ToString();
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
            //var DC = new DataClassesDataContext();
            //var Data = DC.tblMealPlans.ToList();

            //string[] x = new string[Data.Count];
            //int[] y = new int[Data.Count];
            //int i = 0;
            //int j = 0;
            //foreach (tblMealPlan al in Data)
            //{
            //    x[i] = (from ob in DC.tblServiceProviders
            //            where ob.ServiceProviderID == al.ServiceProviderID
            //            select new
            //            {
            //                Data = ob.FirstName + " " + ob.LastName

            //            }).Take(1).SingleOrDefault().Data;

            //    y[j] = DC.tblServiceProviders.Count(ob => ob.ServiceProviderID == al.ServiceProviderID);
            //    j++;

            //}


            //    meal.Series[0].Points.DataBindXY(x, y);
            //    meal.Series[0].ChartType = SeriesChartType.Column;
            //    meal.ChartAreas[0].Area3DStyle.Enable3D = true;
            //    meal.Legends[0].Enabled = true;

            //var Data1 = DC.tblMenuDetails.ToList();
            //string[] x1 = new string[Data1.Count];
            //int[] y1 = new int[Data.Count];
            //int j = 0;
            //foreach (tblMenuDetail ml in Data1)
            //{
            //    x1[j] = (from ob in DC.tblServiceProviders
            //             where ob.ServiceProviderID == ml.ServiceProviderID
            //             select new
            //             {
            //                 Data = ob.FirstName + " " + ob.LastName
            //             }).Take(1).SingleOrDefault().Data;
            //    y1[j] = DC.tblMealPlans.Count(ob => ob.ServiceProviderID == ml.ServiceProviderID);
            //    j++;
            //}
            //menu.Series[0].Points.DataBindXY(x1, y1);
            //menu.Series[0].ChartType = SeriesChartType.Column;
            //menu.ChartAreas[0].Area3DStyle.Enable3D = true;
            //menu.Legends[0].Enabled = true;
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
        
