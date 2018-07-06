<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/LoginMaster.master" AutoEventWireup="true" CodeFile="Adlogin.aspx.cs" Inherits="Admin_Adlogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="mailer" runat="server" class="alert alert-error alert-dismissable fade in" Visible="false">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
            <strong>  User Email or Password Invalied.</strong>
        </asp:Panel>
    <asp:Panel ID="palLogin" runat="server">
        <!-- Login block -->
        
        <div class="login">
            <div class="navbar">
                
                <div class="navbar-inner">
                    <h6><i class="icon-user"></i>Login page</h6>
                </div>
            </div>
            <div class="well" style="padding: 15px;">
                <div class="control-group">
                    <asp:Panel ID="AlertPanal" runat="server" Visible="false" text="plz enter write value"></asp:Panel>
                    <label class="control-label">UserEmail</label>
                    <div class="controls">
                        <asp:TextBox ID="txtmail" runat="server" required="required" TextMode="Email"  pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$"  oninvalid="setCustomValidity('enter the proper Email ')"	oninput="setCustomValidity('')" Width="100%"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label">Password:</label>
                    <div class="controls">
                        <asp:TextBox ID="txtpass" runat="server" required="required" TextMode="Password" pattern="^[A-Za-z0-9]+{5,15}$"  oninvalid="setCustomValidity('Enter minimum 5 and maximum 15 characters for password')"  oninput="setCustomValidity('')" Width="100%" ></asp:TextBox>
                    </div>
                </div>
                <div class="login-btn">
                    <asp:Button ID="btnlogin" runat="server" Text="Login" OnClick="Button1_Click" class="btn-danger btn-block" Style="font-size: 18px; margin-top: 30px; font-weight: bold; padding: 5px;" />
                </div>
                <div class="contact-group">
                    <asp:LinkButton ID="lnkfgpass" runat="server" OnClick="LinkButton1_Click" Style="margin-left: 124px; font-size: 15px;">Forget Password</asp:LinkButton>
                </div>
            </div>
        </div>
        <!-- /login block -->
    </asp:Panel>

    <asp:Panel ID="Panel2" runat="server">
        <!-- Forgot block -->
        <asp:Panel ID="Panel3" runat="server" class="alert alert-error alert-dismissable fade in" Visible="false">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
            <strong> User Email or Password Invalied.</strong>
        </asp:Panel>
        <div class="login">
            <div class="navbar">
                <div class="navbar-inner">
                    <h6><i class="icon-user"></i>Forget Password</h6>
                </div>
                <div class="well" style="padding: 15px;">                                       
                    <asp:Panel ID="Panel4" runat="server" Visible="true">
                        <div class="control-group">
                            <asp:Panel ID="Panel5" runat="server" Visible="false" text="plz enter write value"></asp:Panel>
                            <label class="control-label">Email</label>
                            <div class="controls">
                                <asp:TextBox ID="TextBox1" runat="server" TextMode="Email"  pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$"  oninvalid="setCustomValidity('enter the proper Email ')"	oninput="setCustomValidity('')" Width="100%"></asp:TextBox>
                            </div>
                            <div class="login-btn">
                                <asp:Button ID="Button2" runat="server" Text="Get Code" OnClick="Button2_Click" class="btn-danger btn-block" Style="font-size: 18px; margin-top: 30px; font-weight: bold; padding: 5px;" />
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="Panel6" runat="server" Visible="false">
                        <div class="control-group">
                            <label class="control-label">Code</label>
                            <div class="controls">
                                <asp:TextBox ID="TextBox2" runat="server" Width="100%"></asp:TextBox>
                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                <div class="login-btn">
                                    <asp:Button ID="cheking" runat="server" Text="Verify Code" class="btn-danger btn-block" OnClick="cheking_Click" Style="font-size: 18px; margin-top: 30px; font-weight: bold; padding: 5px;" />
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
        <!-- /Forgot block -->
    </asp:Panel>

    <asp:Panel ID="Panel8" runat="server" Visible="false">
        <!-- Forgot block -->
        <asp:Panel ID="Panel9" runat="server" class="alert alert-error alert-dismissable fade in" Visible="false">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
            <strong> User Email or Password Invalied.</strong>
        </asp:Panel>
        <div class="login">
            <div class="navbar">
                <div class="navbar-inner">
                    <h6><i class="icon-user"></i>Change Password</h6>
                </div>
                <div class="well" style="padding: 15px;">
                    <div class="control-group">
                        <asp:Panel ID="Panel11" runat="server" Visible="false" text="plz enter write value"></asp:Panel>
                        <label class="control-label">Password</label>
                        <div class="controls">
                            <asp:TextBox ID="txtrpass" runat="server" TextMode="Password" pattern="^[A-Za-z0-9]+{5,15}$"  oninvalid="setCustomValidity('Enter minimum 5 and maximum 15 characters for password')"  oninput="setCustomValidity('')" required="required"  title="Six or more characters" Width="100%"></asp:TextBox>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">Re-Password</label>
                        <div class="controls">
                            <asp:TextBox ID="txtrepass" runat="server" TextMode="Password" pattern="^[A-Za-z0-9]+{5,15}$"  oninvalid="setCustomValidity('Enter minimum 5 and maximum 15 characters for password')"  oninput="setCustomValidity('')" Width="100%"></asp:TextBox>
                            <asp:Label ID="lblerrorPwd" runat="server" Text="Please Enter Same Password." style="color: #ff0000; font-weight: bolder;" Visible="false"></asp:Label>
                            <div class="login-btn">
                                <asp:Button ID="btnsub" runat="server" Text="Submit" class="btn-danger btn-block" OnClick="btnsub_Click" Style="font-size: 18px; margin-top: 30px; font-weight: bold; padding: 5px;" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- /Forgot block -->
    </asp:Panel>
</asp:Content>

