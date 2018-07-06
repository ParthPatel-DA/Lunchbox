<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ReplyInquiry.aspx.cs" Inherits="Admin_ReplyInquiry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--  <style>
        .control-group1 {
            padding: 16px 14px;
        }
        http://localhost:1644/Admin/Addpackages.aspx .control-group1 {
            box-shadow: 0 1px 0 #fff inset;
            -webkit-box-shadow: 0 1px 0 #fff inset;
            -moz-box-shadow: 0 1px 0 #fff inset;
            padding: 18px 16px;
        }
    </style>--%>
    <link href="../css/admin.css" rel="stylesheet" />
    <style>
        span {
            font-size: 12px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="col-md-12" id="divPage" runat="server">
        <div style="margin-bottom: 1px;">
            <div class="navbar-inner">
                <h6>Reply Inquiry</h6>
            </div>
        </div>
        <div style="border: 1px solid #CAC8C8; display: inline-block; width: 1013px; padding: 20px;">

            <%--<div class="col-md-6 control-group">
                <span>Subject</span>
                <div class="controls">
                    <asp:Label ID="lbl" runat="server" Text="Label"></asp:Label>
                   <%-- <asp:DropDownList ID="ddlsub" runat="server" Style="width: 100%;" OnSelectedIndexChanged="ddlsub_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>--%>
            <%--</div>--%>

            <div class="col-md-6 control-group">
                <span>ContectNo</span>
                <div class="controls">
                    <%--<asp:TextBox ID="txtmail" runat="server" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$"  Style="width: 100%;" oninvalid="setCustomValidity('Enter Email_ID in proper format')" oninput="setCustomValidity('')"></asp:TextBox>--%>
                    <asp:Label ID="lblcon" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="col-md-6 control-group">
                <span>Email</span>
                <div class="controls">
                    <%--<asp:TextBox ID="txtnm" runat="server" required="" pattern="[A-Za-z]*" oninvalid="setCustomValidity('Enter First Name in character format')" oninput="setCustomValidity('')" Style="width: 100%;"></asp:TextBox>--%>
                    <asp:Label ID="txtmail" runat="server"></asp:Label>
                </div>
            </div>
            <div class="col-md-6 control-group">
                <span>Subject</span>
                <div class="controls">
                    <%-- <asp:TextBox ID="txtsub" runat="server" required="" pattern="[A-Za-z]*" TextMode="MultiLine" oninvalid="setCustomValidity('Enter Valid content')" oninput="setCustomValidity('')" Style="width: 100%;"></asp:TextBox>--%>
                    <asp:Label ID="txtsub" runat="server"></asp:Label>
                </div>
            </div>
            <div class="col-md-6 control-group">
                <span>Message</span>
                <div class="controls">
                    <asp:TextBox ID="txtmsg" runat="server" required="" pattern="[A-Za-z]*" TextMode="MultiLine" oninvalid="setCustomValidity('Enter First Name in character format')" oninput="setCustomValidity('')" Style="width: 100%;"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6 group-control">
                <div class="controls">
                    <asp:Button ID="btnsubmit" runat="server" Text="Submit" class="btn  btn-primary " BackColor="#4d4d4d" Style="width: 15%; margin-right: 10px;" OnClick="btnsubmit_Click" />

                </div>
            </div>

        </div>
    </div>

    <div id="divError" class="text-center col-md-12" runat="server" visible="false" style="margin-top: 50px;">
        <h1>You Can't Access this Page. You don't have  Permission.</h1>
        <h3>Please contact to Admin.</h3>
    </div>

</asp:Content>

