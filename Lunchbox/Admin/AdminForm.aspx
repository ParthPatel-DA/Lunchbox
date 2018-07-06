<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AdminForm.aspx.cs" Inherits="Admin_Default2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/admin.css" rel="stylesheet" />
    <style>
        span{
            font-size: 12px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Form elements -->
   <!-- Form elements -->
    <div class="col-md-12" id="divPage" runat="server">
        <div style="margin-bottom: 1px;">
            <div class="navbar-inner">
                <h6>Add New Admin</h6>
            </div>
        </div>
        <div style="border: 1px solid #CAC8C8; display: inline-block; width: 94.8%; ; padding: 20px;">

            <div class="col-md-6 control-group">
                <span>Admin First Name:</span>
                <div class="controls">
                    <asp:TextBox ID="txtfnm" runat="server" required="" pattern="[A-Za-z]*" oninvalid="setCustomValidity('Enter First Name in character format')" oninput="setCustomValidity('')" Style="width: 100%;" MaxLength="20"></asp:TextBox>
                </div>
            </div>

            <div class="col-md-6 control-group">
                <span>Admin Last Name:</span>
                <div class="controls">
                    <asp:TextBox ID="txtlnm" runat="server" required="required" pattern="[A-Za-z]*" oninvalid="setCustomValidity('Enter Last Name in character format')" oninput="setCustomValidity('')" Style="width: 100%;" MaxLength="20"></asp:TextBox>
                </div>
            </div>

            <div class="col-md-6 control-group">
                <span>Admin EmailId:</span>
                <div class="controls">
                    <asp:TextBox ID="txtmail" runat="server" required="required" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$"  Style="width: 100%;" oninvalid="setCustomValidity('Enter Email_ID in proper format')" oninput="setCustomValidity('')" MaxLength="30"></asp:TextBox>
                </div>
            </div>

            <div class="col-md-6 control-group">
                <span>Admin Password:</span>
                <div class="controls">
                    <asp:TextBox ID="txtpass" runat="server"  required="required" pattern=".{6,}"  oninvalid="setCustomValidity('Enter minimum 5 and maximum 15 characters for password')" TextMode="password" oninput="setCustomValidity('')" Style="width: 100%;" MaxLength="30"></asp:TextBox>
                    
                </div>
            </div>

            <div class="col-md-6 control-group">
                <span>ContactNo:</span>
                <div class="controls">
                    <asp:TextBox ID="txtcno" runat="server" pattern="^[7/8/9][0-9]{9}" required="required" oninvalid="setCustomValidity('enter 10 digit contact_No')" oninput="setCustomValidity('')" Style="width: 100%;"></asp:TextBox>
                </div>
            </div>

            <div class="col-md-6 control-group">
                <span>Admin Profile Image:</span>
                <div class="controls">
                    <asp:FileUpload ID="FileUpload1" runat="server" Style="width: 100%;" />
                </div>
            </div>
            <div class="col-md-12 control-group">
                <div class="col-md-6 ">
                    <span>Admin Permissions:</span>
                    <div class="controls">
                        <asp:CheckBox ID="CheckBox1" runat="server" /><font style="font-size: 14px; margin-right: 10px;"> IsInsert</font>
                        <asp:CheckBox ID="CheckBox2" runat="server" /><font style="font-size: 14px; margin-right: 10px;"> IsUpdate</font>
                        <asp:CheckBox ID="CheckBox3" runat="server" /><font style="font-size: 14px; margin-right: 10px;"> IsDelete</font><br />

                    </div>
                </div>
                <asp:Panel ID="pnlsup" runat="server">
               <div class="col-md-12 control-group">
                <div class="col-md-6 ">
                    <span>Admin Type:</span>
                    <div class="controls">
                        <asp:CheckBox ID="CheckBox4" runat="server" /><font style="font-size: 14px; margin-right: 10px;"> IsSupper</font>
                    </div>
                </div>
                        </div>
            </asp:Panel>
            </div>

            <div class="col-md-6 group-control">
                <div class="controls">
                    <asp:Button ID="Button1" runat="server" Text="Insert" class="btn  btn-primary " BackColor="#4d4d4d" style="width: 15%; margin-right:10px;" OnClick="Button1_Click" />
                  
                </div>
            </div>


        </div>
    </div>
    <!-- /form elements -->
    
    <div id="divError" class="text-center col-md-12" runat="server" visible="false" style="margin-top: 50px;">
        <h1>You Can't Access this Page. You don't have  Permission.</h1>
        <h3>Please contact to Admin.</h3>
    </div>

</asp:Content>

