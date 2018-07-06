<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="ServiceLogin.aspx.cs" Inherits="ServiceLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content" style="margin-top:14px;">
<div class="container">
   <div class="login-page">
     
       
      <div class="account_grid">      
         <div class="col-md-6 login-left wow fadeInLeft" data-wow-delay="0.4s">
		 <br/>
		 <br/>
             
            <h3>NEW DELIVERY BOY</h3>
            <p>By creating an account you will be able to shop faster, be up to date on an order's status, and keep track of the orders you have previously made.</p>
      <%--      <a class="acount-btn" href="signup_view.html" style="border-radius: 10px;">Create an Account</a>--%>
             <asp:Button ID="btnclient" runat="server" Text="Client" style="border-radius: 10px;background-color:#E24425;color :#FFF;height :40px; Width:100px;"  OnClick ="btnclient_Click" />
              <asp:Button ID="btnserviceprovider" runat="server" Text="Delivery Boy" style="border-radius: 10px;background-color:#E24425;color :#FFF;height :40px"  OnClick ="btnserviceprovider_Click" />
         </div>
  
          <asp:Panel ID="Panel1" runat="server" Visible="true">
         <div class="col-md-6 login-right wow fadeInRight" data-wow-delay="0.4s">
		 <br/>
		 <br/>
            
            <h3>REGISTERED DELIVERY BOY</h3>
            <p style="color:#555;margin:0 0 0 0">If you have an account with us, please log in.</p>
             <br />
            <h3 style="color:red;margin-top:-22px"> </h3>
     
           
               <div>
                  <span>Email Address<label>*</label></span>
                 <%-- <input type="text" name="email" class="form-control" required style="border: 1px solid #EEE;
                     outline-color: #FF5B36;
                     width: 96%;
                     font-size: 1em;
                     padding: 0.5em;"> --%>
                    <asp:TextBox ID="txtSpmail" runat="server"   TextMode="Email"  pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$"  oninvalid="setCustomValidity('enter the proper Email ')"	oninput="setCustomValidity('')" class="form-control" Style="border:1px solid #EEE;outline-color: #FF5B36;
                     width: 96%;
                     font-size: 1em;
                     padding: 0.5em;" ></asp:TextBox>
                   
               </div>
                 <div>
                     <br />
                  <span>Password<label>*</label></span>
                 <%-- <input type="text" name="email" class="form-control" required style="border: 1px solid #EEE;
                     outline-color: #FF5B36;
                     width: 96%;
                     font-size: 1em;
                     padding: 0.5em;"> --%>
                    <asp:TextBox ID="txtsppwd" runat="server" TextMode="Password" pattern="^[A-Za-z0-9]+{5,15}$"  oninvalid="setCustomValidity('Enter minimum 5 and maximum 15 characters for password')"  oninput="setCustomValidity('')"    class="form-control" Style="border:1px solid #EEE;outline-color: #FF5B36;
                     width: 96%;
                     font-size: 1em;
                     padding: 0.5em;" TabIndex="1"></asp:TextBox>
               </div>
                 <br />
             <%--<center>--%>
             <asp:Label ID="errorLogin" runat="server" Text="Email ID or Password is incorrect." style="color: #ba2a0e; font-size: 18px; font-weight: bolder;" Visible="false"></asp:Label>
            <%-- </center>--%>
                <br />
                
              <input type="text"  name="page" value="" hidden>
             <%--  <a class="forgot" href="forgot_password.html" style="color:#E74C3C">Forgot Your Password?</a>--%>
          <asp:LinkButton ID="LinkButton1" runat="server" Class="forget"  style="color:#E74C3C" OnClick ="LinkButton1_Click" >Forgot Your Password?</asp:LinkButton>
               
           <%--<input type="submit" value="Login" style="border-radius: 10px;">--%>
              <asp:Button ID="btnlogin" runat="server" Text="Login" style="border-radius0: 10px;" OnClick ="btnlogin_Click"  TabIndex="1" />
            </div>
              </asp:Panel>   
             
          <asp:Panel ID="Panel2" runat="server" Visible="false">
                <div class="col-md-6 login-right wow fadeInRight" data-wow-delay="0.4s">
		 <br/>
		 <br/>
             
            <h3>Forget Password</h3>
            <p style="color:#555;margin:0 0 0 0">If you have an account with us, please log in.</p>
             <br />
            <h3 style="color:red;margin-top:-22px"> </h3>
           
               <div>
                   <asp:Panel id="panel4" runat="server" Visible ="false" >
                <span>Email Address<label>*</label></span>
                 <%-- <input type="text" name="email" class="form-control" required style="border: 1px solid #EEE;
                     outline-color: #FF5B36;
                     width: 96%;
                     font-size: 1em;
                     padding: 0.5em;"> --%>
                    <asp:TextBox ID="txteid" runat="server"    TextMode="Email"  pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$"  oninvalid="setCustomValidity('enter the proper Email ')"	oninput="setCustomValidity('')"  class="form-control" Style="border:1px solid #EEE;outline-color: #FF5B36;
                     width: 96%;
                     font-size: 1em;
                     padding: 0.5em;" ></asp:TextBox>
                    <div class="login-btn">
                     <asp:Button ID="Button3" runat="server" Text="Get Code" OnClick ="Button3_Click"  style="border-radius: 10px; border-bottom  :10px" />
                            </div>
                   </asp:Panel>
               </div>
                      <div>
           
               </div>
                 <div>
                     <br />
                     <asp:Panel ID="panel5" runat="server" Visible ="false" >
                  <span>Code<label>*</label></span>
                 <%-- <input type="text" name="email" class="form-control" required style="border: 1px solid #EEE;
                     outline-color: #FF5B36;
                     width: 96%;
                     font-size: 1em;
                     padding: 0.5em;"> --%>
                    <asp:TextBox ID="txtcodd" runat="server" TextMode="Password"  class="form-control" Style="border:1px solid #EEE;outline-color: #FF5B36;
                     width: 96%;
                     font-size: 1em;
                     padding: 0.5em;"></asp:TextBox>
                     <div class="login-btn">
                         <br />
                        <%-- <center>--%>
                             <asp:Label ID="errorCode" runat="server" Text="Please enter correct verification code." style="color: #ba2a0e; font-size: 18px; font-weight: bolder;" Visible="false"></asp:Label>
                         <%--</center>--%>
                         <br />
                      <asp:Button ID="cheking" runat="server" Text="Verify Code"  style="border-radius: 10px;"  OnClick ="cheking_Click"   />
                      </div>
                         </asp:Panel>
               </div>
                 <br />
                <br />
                
              <input type="text"  name="page" value="" hidden>
             <%--  <a class="forgot" href="forgot_password.html" style="color:#E74C3C">Forgot Your Password?</a>--%>
        
               
           <%--<input type="submit" value="Login" style="border-radius: 10px;">--%>
                <asp:Button ID="Button1" runat="server" Text="Login" style="border-radius: 10px;"  Visible ="false" />
            </div>
          </asp:Panel>
          <asp:Panel ID="Panel3" runat="server" Visible="false">
                <div class="col-md-6 login-right wow fadeInRight" data-wow-delay="0.4s">
		 <br/>
		 <br/>
             
            <h3>Password</h3>
            <p style="color:#555;margin:0 0 0 0">If you have an account with us, please log in.</p>
             <br />
            <h3 style="color:red;margin-top:-22px"> </h3>
           
               <div>
                  <span>New Password<label>*</label></span>
                 <%-- <input type="text" name="email" class="form-control" required style="border: 1px solid #EEE;
                     outline-color: #FF5B36;
                     width: 96%;
                     font-size: 1em;
                     padding: 0.5em;"> --%>
                    <asp:TextBox ID="txtnepass" runat="server"  Required=""  TextMode="password" pattern="^[A-Za-z0-9]+{5,15}$"  oninvalid="setCustomValidity('Enter minimum 5 and maximum 15 characters for password')"  oninput="setCustomValidity('')"  class="form-control" Style="border:1px solid #EEE;outline-color: #FF5B36;
                     width: 96%;
                     font-size: 1em;
                     padding: 0.5em;" ></asp:TextBox>
                   
               </div>
                 <div>
                     <br />
                  <span>Conform Password<label>*</label></span>
                 <%-- <input type="text" name="email" class="form-control" required style="border: 1px solid #EEE;
                     outline-color: #FF5B36;
                     width: 96%;
                     font-size: 1em;
                     padding: 0.5em;"> --%>
                    <asp:TextBox ID="txtcopass" runat="server" TextMode="Password" pattern="^[A-Za-z0-9]+{5,15}$"  oninvalid="setCustomValidity('Enter minimum 5 and maximum 15 characters for password')"  oninput="setCustomValidity('')"   required="" class="form-control" Style="border:1px solid #EEE;outline-color: #FF5B36;
                     width: 96%;
                     font-size: 1em;
                     padding: 0.5em;"></asp:TextBox>
                     <div class="login-btn">
                                <asp:Button ID="btnsub" runat="server" Text="Submit" style="border-radius: 10px;" OnClick ="btnsub_Click"  />
                            </div>
               </div>
                 <br />
                <br />
              <input type="text"  name="page" value="" hidden>
             <%--  <a class="forgot" href="forgot_password.html" style="color:#E74C3C">Forgot Your Password?</a>--%>
          <%--<asp:LinkButton ID="LinkButton3" runat="server" Class="forget"  style="color:#E74C3C">Forgot Your Password?</asp:LinkButton>--%>
               
           <%--<input type="submit" value="Login" style="border-radius: 10px;">--%>
                <asp:Button ID="Button2" runat="server" Text="Login" style="border-radius: 10px;"  Visible ="false" />
            </div>
          </asp:Panel>

         </div>
         <div class="clearfix"> </div>
      </div>
   </div>
</div>	

</asp:Content>

