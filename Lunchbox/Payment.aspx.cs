using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Configuration;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Communication;
using PayPal.Payments.DataObjects;

public partial class Payment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    //    if (Page.IsPostBack)
    //    {
    //        return;
    //    }

    //    //populate month
    //    string[] Month = new string[]
    //{ "", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
    //    ddlMonth.DataSource = Month;
    //    ddlMonth.DataBind();
    //    //pre-select one for testing
    //    ddlMonth.SelectedIndex = 4;

    //    //populate year
    //    ddlYear.Items.Add("");
    //    int Year = DateTime.Now.Year;
    //    for (int i = 0; i & lt; 10; i++)
    //    {
    //        ddlYear.Items.Add((Year + i).ToString());
    //    }
    //    //pre-select one for testing
    //    ddlYear.SelectedIndex = 3;
    }

    //protected void btnSubmit_Click(object sender, EventArgs e)
    //{
    //    //try
    //    //{
    //    //    string PayPalRequest = "TRXTYPE=S" //S - sale transaction
    //    //         + "&TENDER=C" //C - Credit card
    //    //         + "&ACCT=" + txtCardNumber.Text //card number
    //    //         + "&EXPDATE=" + ddlMonth.SelectedValue +
    //    //    ddlYear.SelectedValue.Substring(2, 2)
    //    //         + "&CVV2=" + txtCvv.Text   //card validation value (card security code)
    //    //         + "&AMT=" + txtAmount.Text
    //    //         + "&COMMENT1=My Product Sale"
    //    //         + "&USER=" + ConfigurationManager.AppSettings["USER"]
    //    //         + "&VENDOR=" + ConfigurationManager.AppSettings["VENDOR"]
    //    //         + "&PARTNER=" + ConfigurationManager.AppSettings["PARTNER"]
    //    //         + "&PWD=" + ConfigurationManager.AppSettings["PWD"];

    //    //    // Create an instance of PayflowNETAPI.
    //    //    PayflowNETAPI PayflowNETAPI = new PayflowNETAPI();

    //    //    // RequestId is a unique string that is required for each & every transaction. 
    //    //    // The merchant can use her/his own algorithm to generate 
    //    //    // this unique request id or use the SDK provided API to generate this
    //    //    // as shown below (PayflowUtility.RequestId).
    //    //    string PayPalResponse = PayflowNETAPI.SubmitTransaction
    //    //        (PayPalRequest, PayflowUtility.RequestId);

    //    //    //place data from PayPal into a namevaluecollection
    //    //    NameValueCollection RequestCollection =
    //    //GetPayPalCollection(PayflowNETAPI.TransactionRequest);
    //    //    NameValueCollection ResponseCollection = GetPayPalCollection(PayPalResponse);

    //    //    //show request
    //    //    lblResult.Text = "&lt;span class=\"heading\">
    //    //PayPal Payflow Pro transaction request & lt;/ span > &lt; br /> ";
    //    //    lblResult.Text += ShowPayPalInfo(RequestCollection);

    //    //    //show response
    //    //    lblResult.Text += "&lt;br />&lt;br />&lt;span class=\"heading\">
    //    //PayPal Payflow Pro transaction response & lt;/ span > &lt; br /> ";
    //    //    lblResult.Text += ShowPayPalInfo(ResponseCollection);

    //    //    //show transaction errors if any
    //    //    string TransErrors = PayflowNETAPI.TransactionContext.ToString();
    //    //    if (TransErrors != null && TransErrors.Length > 0)
    //    //    {
    //    //        lblResult.Text += "&lt;br />&lt;br />&lt;span class=\"bold-text\">
    //    //        Transaction Errors:&lt;/ span > " + TransErrors;
    //    //    }

    //    //    //show transaction status
    //    //    lblResult.Text += "&lt;br />&lt;br />&lt;span class=\"bold-text\">
    //    //Status: &lt;/ span > " + PayflowUtility.GetStatus(PayPalResponse);
    //    //}
    //    //catch (Exception ex)
    //    //{
    //    //    lblError.Text = ex.Message.ToString();
    //    //}
    //}

    //private NameValueCollection GetPayPalCollection(string payPalInfo)
    //{
    //    ////place the responses into collection
    //    //NameValueCollection PayPalCollection =
    //    //new System.Collections.Specialized.NameValueCollection();
    //    //string[] ArrayReponses = payPalInfo.Split('&');

    //    //for (int i = 0; i < ArrayReponses.Length; i++)
    //    //{
    //    //    string[] Temp = ArrayReponses[i].Split('=');
    //    //    PayPalCollection.Add(Temp[0], Temp[1]);
    //    //}
    //    //return PayPalCollection;
    //}
    //private string ShowPayPalInfo(NameValueCollection collection)
    //{
    //    //string PayPalInfo = "";
    //    //foreach (string key in collection.AllKeys)
    //    //{
    //    //    PayPalInfo += "&lt;br />&lt;span class=\"bold-text\">" +
    //    //        key + ":&lt;/span> " + collection[key];
    //    //}
    //    //return PayPalInfo;
    //}
}