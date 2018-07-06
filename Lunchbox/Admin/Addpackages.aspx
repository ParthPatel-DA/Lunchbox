<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Addpackages.aspx.cs" Inherits="Admin_Addpackages" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .control-group1 {
            padding: 16px 14px;
        }

        http://localhost:52822/Admin/Addpackages.aspx .control-group1 {
            box-shadow: 0 1px 0 #fff inset;
            -webkit-box-shadow: 0 1px 0 #fff inset;
            -moz-box-shadow: 0 1px 0 #fff inset;
            padding: 18px 16px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="divPage" runat="server" class="col-md-12">
        <div style="margin-bottom: 1px;">
            <div class="navbar-inner">
                <h6>Add New Package</h6>
            </div>
        </div>

        <div style="border: 1px solid #CAC8C8; display: inline-block; width: 94.8%; padding: 20px;">

            <div class="col-md-6 control-group">
                <span>Name:</span>
                <div class="controls">
                    <asp:TextBox ID="txtfnm" runat="server" required="" AutoPostBack="true" pattern="[A-Za-z]*" Style="width: 100%;" oninput="setCustomValidity('')" oninvalid="setCustomValidity('Enter Package Name in character format')" MaxLength="20">

                    </asp:TextBox>
                </div>

            </div>

            <div class="col-md-6 control-group">
                <span>Duration</span>
                <div class="controls">
                    <asp:TextBox ID="txtduration" runat="server" required="required" pattern="^\d*$" Style="width: 100%;" oninput="setCustomValidity('')" oninvalid="setCustomValidity('Enter Package Duration Month In Digit')" MaxLength="3"></asp:TextBox>
                </div>
            </div>

            <div class="col-md-6 control-group">
                <span>Price</span>
                <div class="controls">
                    <asp:TextBox ID="txtpri" runat="server" required="required" pattern="\d+(\.\d{2})?" oninvalid="setCustomValidity('Enter Package Price')" oninput="setCustomValidity('')" Style="width: 100%;" MaxLength="7"></asp:TextBox>
                </div>
            </div>



            <div class="col-md-6 control-group">
                <span>Description:</span>
                <div class="controls">
                    <asp:TextBox ID="txtdesc" runat="server" TextMode="MultiLine" required="required" pattern="[A-Za-z0-9]+$" oninvalid="setCustomValidity('Enter Package Description')" oninput="setCustomValidity('')" Style="width: 100%;" MaxLength="100"></asp:TextBox>
                </div>
            </div>

            <div class="col-md-6 control-group">
                <span>Image:</span>
                <div class="controls">
                    <asp:FileUpload ID="FileUpload1" runat="server" Style="width: 100%;" />


                </div>
                <asp:Panel ID="pnlact" runat="server">

                <div class="col-md-6 control-group">
                    <%-- <span>IsActive</span>--%>
                    <div class="controls">
                        <asp:CheckBox ID="CheckBox4" runat="server" />
                        <font style="font-size: 14px; margin-right: 10px;">IsActive</font>
                    </div>
                </div>
                </asp:Panel>
                <div class="col-md-6">
                </div>
                <div class="col-md-6">
                </div>

                <div class="col-md-6">
                </div>
                <div class="col-md-6">
                </div>
                <div class="col-md-6">
                </div>
                <div class="col-md-6">
                </div>

                <div class="col-md-6 group-control">
                    <div class="controls">
                        <asp:Button ID="btninsert" runat="server" Text="Insert" class="btn  btn-primary " BackColor="#4d4d4d" Style="width: 15%; margin-right: -150px;" OnClick="btninsert_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>

        <div id="divError" class="text-center col-md-12" runat="server" visible="false" style="margin-top: 50px;">
            <h1>You Can't Access this Page. You don't have  Permission.</h1>
            <h3>Please contact to Admin.</h3>
        </div>
</asp:Content>

