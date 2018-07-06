using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;
using System.Net.NetworkInformation;
using System.Net;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public partial class Success : System.Web.UI.Page
{
    int TotalQty, TotalAmount = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        var DC = new DataClassesDataContext();

        //if (Session["ServiceProviderID"] == null)
        //{
        //    Response.Redirect("ServiceLogin.aspx");
        //}

        try
        {

            string[] merc_hash_vars_seq;
            string merc_hash_string = string.Empty;
            string merc_hash = string.Empty;
            string order_id = string.Empty;
            string hash_seq = "key|txnid|amount|productinfo|firstname|email|udf1|udf2|udf3|udf4|udf5|udf6|udf7|udf8|udf9|udf10";

            if (Request.Form["status"] == "success")
            {

                merc_hash_vars_seq = hash_seq.Split('|');
                Array.Reverse(merc_hash_vars_seq);
                merc_hash_string = ConfigurationManager.AppSettings["SALT"] + "|" + Request.Form["status"];


                foreach (string merc_hash_var in merc_hash_vars_seq)
                {
                    merc_hash_string += "|";
                    merc_hash_string = merc_hash_string + (Request.Form[merc_hash_var] != null ? Request.Form[merc_hash_var] : "");

                }
                merc_hash = Generatehash512(merc_hash_string).ToLower();



                if (merc_hash != Request.Form["hash"])
                {
                    //Value didn't match that means some paramter value change between transaction 
                    lblFail2.Text = "Hash value did not matched.";
                    lblSuccess.Visible = false;
                    lblSuccess2.Visible = false;
                    lblFail2.Visible = true;
                    lblFail.Visible = true;

                }
                else
                {
                    //if hash value match for before transaction data and after transaction data
                    //that means success full transaction  , see more in response
                    order_id = Request.Form["txnid"];
                    string prod_info = Request.Form["productinfo"];
                    lblSuccess2.Text = "value matched" + order_id + "<br/>" + "Product :" + prod_info;
                    lblSuccess.Visible = true;
                    lblSuccess2.Visible = true;
                    lblFail2.Visible = false;
                    lblFail.Visible = false;
                    if (Session["ClientID"] != null)
                    {
                        var ClientData = (from obj in DC.tblClients
                                          where obj.ClientID == Convert.ToInt32(Session["ClientID"])
                                          select obj).Single();

                        lblClientName.Text = ClientData.FirstName + " " + ClientData.LastName;
                        lblClientEmail.Text = ClientData.Email;
                        lblClientContectNo.Text = ClientData.ContactNo;

                        tblOrder OrderData = (from obj in DC.tblOrders
                                              where obj.ClientID == Convert.ToInt32(Session["ClientID"]) && (obj.IsActive == false || obj.IsActive == null)
                                              select obj).First();
                        lblBillAddress.Text = OrderData.BillingAddress;
                        lblShippingAddress.Text = OrderData.ShippingAddress;

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
                                      obj.Date,
                                      obj.OrderID,
                                      obj.Qty,
                                      Total = (Convert.ToInt32((from ob in DC.tblitems
                                                                where ob.ItemID == obj.ItemID
                                                                select new
                                                                {
                                                                    Data = Convert.ToInt32(ob.ItemPrice).ToString(),
                                                                }).Take(1).SingleOrDefault().Data) * obj.Qty),
                                  };

                        Repeater1.DataSource = str;
                        Repeater1.DataBind();
                        var str1 = from obj in DC.tblOrders
                                   where obj.MACAddress == GetMACAddress() && obj.ClientID == Convert.ToInt32(Session["ClientID"]) && (obj.IsActive == false || obj.IsActive == null) && obj.MealID != null
                                   select new
                                   {

                                       CN = (from ob in DC.tblMealPlans
                                             where ob.MealID == obj.MealID
                                             select new
                                             {
                                                 Data = ob.MealName,

                                             }).Take(1).SingleOrDefault().Data,

                                       CNN = (from ob in DC.tblMealPlans
                                              where ob.MealID == obj.MealID
                                              select new
                                              {
                                                  Data = Convert.ToInt32(ob.MealPrice).ToString(),
                                              }).Take(1).SingleOrDefault().Data,
                                       obj.Date,
                                       obj.OrderID,
                                       obj.Qty,
                                       Total = (Convert.ToInt32((from ob in DC.tblMealPlans
                                                                 where ob.MealID == obj.MealID
                                                                 select new
                                                                 {
                                                                     Data = Convert.ToInt32(ob.MealPrice).ToString(),
                                                                 }).Take(1).SingleOrDefault().Data) * obj.Qty),
                                   };

                        Repeater2.DataSource = str1;
                        Repeater2.DataBind();
                        foreach (RepeaterItem item in Repeater1.Items)
                        {
                            HiddenField hdnOrder = (HiddenField)item.FindControl("hdnOrder");
                            tblOrder Data = DC.tblOrders.Single(ob => ob.OrderID == Convert.ToInt32(hdnOrder.Value));
                            Data.IsActive = true;
                            DC.SubmitChanges();
                        }
                        foreach (RepeaterItem item in Repeater2.Items)
                        {
                            HiddenField hdnOrder = (HiddenField)item.FindControl("hdnOrder");
                            tblOrder Data = DC.tblOrders.Single(ob => ob.OrderID == Convert.ToInt32(hdnOrder.Value));
                            Data.IsActive = true;
                            DC.SubmitChanges();
                        }
                        //lnkPDF.Visible = true;
                        PanelClient.Visible = true;
                    }
                    if (Session["ServiceProviderID"] != null)
                    {
                        tblServiceProvider SP = (from obj in DC.tblServiceProviders
                                                 where obj.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"])
                                                 select obj).Single();
                        lblSPName.Text = SP.FirstName + " " + SP.LastName;
                        lblSPEmail.Text = SP.Email;
                        lblSPContectNumber.Text = SP.ContactNo;
                        tblPackage Package = (from obj in DC.tblPackages
                                              join obj2 in DC.tblSPPackages
                                              on obj.PackagesID equals obj2.PackagesId
                                              where obj2.ServiceProviderID == Convert.ToInt32(Session["ServiceProviderID"]) && obj2.IsActive == false
                                              orderby obj.PackagesID descending
                                              select obj).First();
                        lblPackageName.Text = Package.Name;
                        lblPackagePrice.Text = Package.Price.ToString();
                        //lnkSPPDF.Visible = true;
                        PanelSP.Visible = true;
                    }
                }

            }

            else
            {
                lblFail2.Text = "Hash value did not matched.";
                lblSuccess.Visible = false;
                lblSuccess2.Visible = false;
                lblFail2.Visible = true;
                lblFail.Visible = true;

                // osc_redirect(osc_href_link(FILENAME_CHECKOUT, 'payment' , 'SSL', null, null,true));

            }
        }

        catch (Exception ex)
        {
            Response.Write("<span style='color:red'>" + ex.Message + "</span>");

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


    public string Generatehash512(string text)
    {

        byte[] message = Encoding.UTF8.GetBytes(text);

        UnicodeEncoding UE = new UnicodeEncoding();
        byte[] hashValue;
        SHA512Managed hashString = new SHA512Managed();
        string hex = "";
        hashValue = hashString.ComputeHash(message);
        foreach (byte x in hashValue)
        {
            hex += String.Format("{0:x2}", x);
        }
        return hex;

    }

    protected void lnkPDF_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Panel.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        PanelClient.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
    }

    protected void lnkSPPDF_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Panel.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        PanelSP.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
    }
}