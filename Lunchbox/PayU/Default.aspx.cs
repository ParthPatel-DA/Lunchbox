using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PayU_Default : System.Web.UI.Page
{
    public string action1 = string.Empty;
    public string hash1 = string.Empty;
    public string txnid1 = string.Empty;

    public string MERCHANT_KEY = "gtKFFx";
    public string SALT = "eCwWELxi";
    public string PAYU_BASE_URL = "https://test.payu.in";
    public string action = "";
    public string hashSequence = "key|txnid|amount|productinfo|firstname|email|udf1|udf2|udf3|udf4|udf5|udf6|udf7|udf8|udf9|udf10";

    public string Amount;
    public string FirstName;
    public string Email;
    public string PhoneNo;
    public string ProductInfo;
    public string SURL;
    public string FURL;
    public string Key;
    public string Hash;
    public string TxnID;

    public string LastName = "";
    public string CURL = "";
    public string Address1 = "";
    public string Address2 = "";
    public string City = "";
    public string State = "";
    public string Country = "";
    public string ZipCode = "";
    public string UDF1 = "";
    public string UDF2 = "";
    public string UDF3 = "";
    public string UDF4 = "";
    public string UDF5 = "";
    public string PG = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {

            Amount = Session["Amount"].ToString();
            FirstName = Session["FirstName"].ToString();
            Email = Session["Email"].ToString();
            PhoneNo = Session["PhoneNo"].ToString();
            ProductInfo = Session["ProductInfo"].ToString();
            SURL = Session["SuccessURL"].ToString();
            FURL = Session["FailureURL"].ToString();

            //set merchant key from web.config or AppSettings
            Key = MERCHANT_KEY;

            if (!IsPostBack)
            {
                frmError.Visible = false; // error form
            }
            else
            {
                //frmError.Visible = true;
            }
            //if (string.IsNullOrEmpty(Request.Form["hash"]))
            //{
            //    submit.Visible = true;
            //}
            //else
            //{
            //    submit.Visible = false;
            //}
            //Button1_Click(this.submit,e);
            #region ButtonClick

            try
            {

                string[] hashVarsSeq;
                string hash_string = string.Empty;


                if (string.IsNullOrEmpty(TxnID)) // generating txnid
                {
                    Random rnd = new Random();
                    string strHash = Generatehash512(rnd.ToString() + DateTime.Now);
                    txnid1 = strHash.ToString().Substring(0, 20);

                }
                else
                {
                    txnid1 = TxnID;
                }
                if (string.IsNullOrEmpty(Hash)) // generating hash value
                {
                    if (
                        string.IsNullOrEmpty(MERCHANT_KEY) ||
                        string.IsNullOrEmpty(txnid1) ||
                        string.IsNullOrEmpty(Amount) ||
                        string.IsNullOrEmpty(FirstName) ||
                        string.IsNullOrEmpty(Email) ||
                        string.IsNullOrEmpty(PhoneNo) ||
                        string.IsNullOrEmpty(ProductInfo) ||
                        string.IsNullOrEmpty(SURL) ||
                        string.IsNullOrEmpty(FURL)
                        )
                    {
                        //error

                        frmError.Visible = true;
                        return;
                    }

                    else
                    {
                        frmError.Visible = false;
                        hashVarsSeq = hashSequence.Split('|'); // spliting hash sequence from config
                        hash_string = "";
                        foreach (string hash_var in hashVarsSeq)
                        {
                            if (hash_var == "key")
                            {
                                hash_string = hash_string + MERCHANT_KEY;
                                hash_string = hash_string + '|';
                            }
                            else if (hash_var == "txnid")
                            {
                                hash_string = hash_string + txnid1;
                                hash_string = hash_string + '|';
                            }
                            else if (hash_var == "amount")
                            {
                                hash_string = hash_string + Convert.ToDecimal(Amount).ToString("g29");
                                hash_string = hash_string + '|';
                            }
                            else if (hash_var == "productinfo")
                            {
                                hash_string = hash_string + ProductInfo;
                                hash_string = hash_string + '|';
                            }
                            else if (hash_var == "firstname")
                            {
                                hash_string = hash_string + FirstName;
                                hash_string = hash_string + '|';
                            }
                            else if (hash_var == "email")
                            {
                                hash_string = hash_string + Email;
                                hash_string = hash_string + '|';
                            }
                            else
                            {

                                hash_string = hash_string + "";//(Request.Form[hash_var] != null ? Request.Form[hash_var] : "");// isset if else
                                hash_string = hash_string + '|';
                            }
                        }

                        hash_string += SALT;// appending SALT

                        hash1 = Generatehash512(hash_string).ToLower();         //generating hash
                        action1 = PAYU_BASE_URL + "/_payment";// setting URL

                    }


                }

                else if (!string.IsNullOrEmpty(Hash))
                {
                    hash1 = Hash;
                    action1 = PAYU_BASE_URL + "/_payment";

                }




                if (!string.IsNullOrEmpty(hash1))
                {
                    Hash = hash1;
                    TxnID = txnid1;

                    System.Collections.Hashtable data = new System.Collections.Hashtable(); // adding values in gash table for data post
                    data.Add("hash", Hash);
                    data.Add("txnid", TxnID);
                    data.Add("key", Key);
                    string AmountForm = Convert.ToDecimal(Amount.Trim()).ToString("g29");// eliminating trailing zeros
                    //amount.Text = AmountForm;
                    data.Add("amount", AmountForm);
                    data.Add("firstname", FirstName.Trim());
                    data.Add("email", Email.Trim());
                    data.Add("phone", PhoneNo.Trim());
                    data.Add("productinfo", ProductInfo.Trim());
                    data.Add("surl", SURL.Trim());
                    data.Add("furl", FURL.Trim());
                    data.Add("lastname", LastName.Trim());
                    data.Add("curl", CURL.Trim());
                    data.Add("address1", Address1.Trim());
                    data.Add("address2", Address2.Trim());
                    data.Add("city", City.Trim());
                    data.Add("state", State.Trim());
                    data.Add("country", Country.Trim());
                    data.Add("zipcode", ZipCode.Trim());
                    data.Add("udf1", UDF1.Trim());
                    data.Add("udf2", UDF2.Trim());
                    data.Add("udf3", UDF3.Trim());
                    data.Add("udf4", UDF4.Trim());
                    data.Add("udf5", UDF5.Trim());
                    data.Add("pg", PG.Trim());


                    string strForm = PreparePOSTForm(action1, data);
                    Page.Controls.Add(new LiteralControl(strForm));

                }

                else
                {
                    //no hash

                }

            }

            catch (Exception ex)
            {
                Response.Write("<span style='color:red'>" + ex.Message + "</span>");

            }
            #endregion
            // Button Click

        }
        catch (Exception ex)
        {
            Response.Write("<span style='color:red'>" + ex.Message + "</span>");

        }
        
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


    private string PreparePOSTForm(string url, System.Collections.Hashtable data)      // post form
    {
        //Set a name for the form
        string formID = "PostForm";
        //Build the form using the specified data to be posted.
        StringBuilder strForm = new StringBuilder();
        strForm.Append("<form id=\"" + formID + "\" name=\"" +
                       formID + "\" action=\"" + url +
                       "\" method=\"POST\">");

        foreach (System.Collections.DictionaryEntry key in data)
        {

            strForm.Append("<input type=\"hidden\" name=\"" + key.Key +
                           "\" value=\"" + key.Value + "\">");
        }


        strForm.Append("</form>");
        //Build the JavaScript which will do the Posting operation.
        StringBuilder strScript = new StringBuilder();
        strScript.Append("<script language='javascript'>");
        strScript.Append("var v" + formID + " = document." +
                         formID + ";");
        strScript.Append("v" + formID + ".submit();");
        strScript.Append("</script>");
        //Return the form and the script concatenated.
        //(The order is important, Form then JavaScript)
        return strForm.ToString() + strScript.ToString();
    }

}