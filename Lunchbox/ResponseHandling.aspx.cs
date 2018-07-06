using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PayUDemo
{
    public partial class ResponseHandling : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                        Response.Write("Hash value did not matched");

                    }
                    else
                    {
                        //if hash value match for before transaction data and after transaction data
                        //that means success full transaction  , see more in response
                        order_id = Request.Form["txnid"];
                        string prod_info = Request.Form["productinfo"];
                        Response.Write("value matched" + order_id + "<br/>" + "Product :" + prod_info );

                        //Hash value did not matched
                    }

                }

                else
                {

                    Response.Write("Hash value did not matched");
                    // osc_redirect(osc_href_link(FILENAME_CHECKOUT, 'payment' , 'SSL', null, null,true));

                }
            }

            catch (Exception ex)
            {
                Response.Write("<span style='color:red'>" + ex.Message + "</span>");

            }
        }
        /// <summary>
        /// Generate HASH for encrypt all parameter passing while transaction
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
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




    }

}