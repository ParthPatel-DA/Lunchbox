using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(! IsPostBack )
        {
           
            binddata();
        }
        var DC = new DataClassesDataContext();
        var str = (from ob in DC.tblAdmins
                   join obj in DC.tblImages
                   on ob.ImageID equals obj.ImagesID
                   where ob.AdminID == Convert.ToInt32(Session["AdminID"])
                   select new
                   {
                       
                        obj.Name,
                        UName = ob.FirstName + " " + ob.LastName
                   }).SingleOrDefault();
        DC.SubmitChanges();
        imgUserPic.ImageUrl = "~/Admin/Upload/" + str.Name;
        lblUserName.Text = str.UName.ToString();
        tblAdmin result = (from u in DC.tblAdmins
                           where u.AdminID == Convert.ToInt32(Session["AdminID"])
                           select u).Single();
        if (result.IsSuper == false)
        {
            //Panel1.Visible = false;
            lnkAdView.Visible = false;
        }
        var dc = new DataClassesDataContext();
       
    }
    
    private void binddata()
    {
        var dc = new DataClassesDataContext();
        var str = (from ob in dc.tblNotifications
                   join obj in dc.tblNotificationDetails
                   on ob.NotificationID equals obj.NotificationID
                   where obj.IsRead == false
                   select new {
                       ob.Title,
                       ob.Description,
                       obj.NotificationdetailID
                   });
        repnotifi.DataSource = str;
        repnotifi.DataBind();
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session["AdminID"] = null;
        Response.Redirect("Adlogin.aspx");
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("ChangePwd.aspx");
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        Response.Redirect("Addpackages.aspx");
    }

    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        Response.Redirect("Package.aspx");
    }

    //protected void LinkButton8_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("Package.aspx");
    //}

    protected void lnkAddress_Click(object sender, EventArgs e)
    {
        Response.Redirect("Address.aspx");
    }

    protected void lnkvMeal_Click(object sender, EventArgs e)
    {
        Response.Redirect("MealPlan.aspx");
    }

    protected void lnkVMenu_Click(object sender, EventArgs e)
    {
        Response.Redirect("Admenu.aspx");
    }

    protected void lnkODetail_Click(object sender, EventArgs e)
    {
        Response.Redirect("tblAdODetail.aspx");
    }

    protected void lnkInq_Click(object sender, EventArgs e)
    {
        Response.Redirect("Inquiry.aspx");
    }

    protected void lnkLog_Click(object sender, EventArgs e)
    {
        Response.Redirect("Log.aspx");
    }

    protected void lnkFeed_Click(object sender, EventArgs e)
    {
        Response.Redirect("FeedBack.aspx");
    }

    protected void lnkRef_Click(object sender, EventArgs e)
    {
        Response.Redirect("RefFriend.aspx");
    }

    protected void lnkCMS_Click(object sender, EventArgs e)
    {
        Response.Redirect("CMSPages.aspx");
    }

    
    //protected void lnkClient_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("Client.aspx");
    //}





    protected void LinkButton3_Click1(object sender, EventArgs e)
    {
        Response.Redirect("SPPackages.aspx");
    }

    protected void LinkButton4_Click1(object sender, EventArgs e)
    {
        //Response.Redirect("Address.aspx");
    }

    protected void lnkverify_Click(object sender, EventArgs e)
    {
        Response.Redirect("VerifySP.aspx");
    }

    protected void repnotifi_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        var dc = new DataClassesDataContext();
        if(e.CommandName == "Read")
        {
            var Data = dc.tblNotificationDetails.Single(ob => ob.NotificationdetailID == Convert.ToInt32(e.CommandArgument));
            Data.IsRead = true;
            dc.SubmitChanges();
            binddata();
        }
    }

    protected void lnkcmspage_Click(object sender, EventArgs e)
    {
        Response.Redirect("CMSPage.aspx");
    }

    protected void lnkAdView_Click(object sender, EventArgs e)
    {
        Response.Redirect("empgrid.aspx");
    }

    protected void lnkAdForm_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminForm.aspx");
    }

    protected void lnksprovider_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdSProvider.aspx");
    }

    protected void lnkclient_Click(object sender, EventArgs e)
    {
        Response.Redirect("Client.aspx");
    }
}
