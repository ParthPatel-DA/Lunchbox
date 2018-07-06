<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Feedback.aspx.cs" Inherits="Feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="contact-section-page">
        <!--<div class="contact-head">
		    <div class="container">
				<h3>Contact</h3>
				<p>Home/Contact</p>
			</div>
		</div>-->
        <div class="contact_top">
            <div class="container">
                <div class="col-md-6 contact_left wow fadeInRight" data-wow-delay="0.4s">
                    <h2 style="font-size: 2em; margin-top: 8px; font-weight: 700; font-family: 'Lobster Two', cursive;">
                        <asp:Label runat="server" Text="Feedback Form"></asp:Label>

                    </h2>

                    <p></p>
                    <%--	  <form action="http://takeurpick.com/user/feedback_form" method="post">--%>
                    <div class="form_details">

                        <asp:TextBox ID="txtemail" runat="server" class="text" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$" oninvalid="setCustomValidity('enter the proper Email ')" oninput="setCustomValidity('')" name="email" value="Email Address" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Email Address';}" Style="padding: 10px; width: 80%; font-size: 1.2em; margin: 10px 0px; border: 1px solid #8A8888; color: #8A8888; background: none; -webkit-appearance: none; float: left; outline: none; font-weight: 500;"></asp:TextBox>

                        <asp:TextBox ID="txtdis" runat="server" Text="Discription" pattern="[A-Za-z]*" oninvalid="setCustomValidity('enter The Description  Format  ')" oninput="setCustomValidity('')" TextMode="MultiLine" name="message" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Message';}" Style="padding: 10px; width: 80%; font-size: 1.2em; margin: 10px 0px; border: 1px solid #8A8888; color: #8A8888; background: none; -webkit-appearance: none; float: left; outline: none; font-weight: 500;"></asp:TextBox>

                       
     
                        <div class="clearfix"></div>
                          <asp:Label ID="errorCode" runat="server" Text="Plz register Form" style="color: #ba2a0e; font-size: 18px; font-weight: bolder;" Visible="false"></asp:Label>
                        <div class="sub-button wow swing animated" data-wow-delay="0.4s">
                            <%--<input name="submit" type="submit" value="Send Feedback">--%>
                            <asp:Button ID="btnfeedback" runat="server" Text="Send Feedback" OnClick="btnfeedback_Click"></asp:Button>
                        </div>
                    </div>
                    <%-- </form>--%>
                </div>

            </div>
        </div>

    </div>
</asp:Content>

