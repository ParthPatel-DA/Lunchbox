<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="CMSPage.aspx.cs" Inherits="Admin_CMSPage" ValidateRequest="false" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="ckeditor/ckeditor.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-md-12" style="margin-bottom: 50px;" id="divPage" runat="server">
        <div class="col-md-12" style="margin-bottom: 40px;">
            <div style="margin-bottom: 1px;">
                <div class="navbar-inner">
                    <h6>CMS Page</h6>
                </div>
            </div>
            <div style="border: 1px solid #CAC8C8; display: inline-block; width: 100%; padding: 20px;">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel2" runat="server">
                            <div class="col-md-6 control-group">
                                <h3>Edit CMS Page</h3>
                                <h4><small>(Select page from the dropdown for edit CMS Page...)</small></h4>
                                <span>CMS Page :</span>
                                <div class="controls">
                                    <asp:DropDownList ID="ddCMSList" runat="server" class="span12 form-control" Style="margin-bottom: 20px; width: 40%;" OnSelectedIndexChanged="ddCMSList_SelectedIndexChanged" AutoPostBack="true">
                                        <%--<asp:ListItem>Select CMS Page</asp:ListItem>--%>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </asp:Panel>
                        <div class="col-md-12 control-group">
                            <asp:Panel ID="Panel1" runat="server">
                                <h3>Add CMS Page</h3>
                            </asp:Panel>
                            <span>CMS Page Title :</span>
                            <div class="controls">
                                <asp:TextBox ID="txtTitle" runat="server" class="span12 form-control" Style="margin-bottom: 20px; width: 40%;" AutoPostBack="true" placeholder="Enter Category Name" OnTextChanged="txtTitle_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <asp:TextBox ID="txtCkEditor" class="ckeditor" runat="server" TextMode="MultiLine"></asp:TextBox>
                            <asp:Button ID="btnSaveCMS" runat="server" Text="Save Page" class="btn  btn-primary form-control" BackColor="#4d4d4d" Style="width: 40%; margin-right: 10px; margin-top: 20px;" OnClick="btnSaveCMS_Click" /><br />
                            <asp:Button ID="btnEditCMS" runat="server" Text="Edit Page" class="btn  btn-primary form-control" BackColor="#4d4d4d" Style="width: 40%; margin-right: 10px; margin-top: 20px;" Visible="false" OnClick="btnEditCMS_Click" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="ddCMSList" />
                        <asp:PostBackTrigger ControlID="txtTitle" />
                        <asp:PostBackTrigger ControlID="btnSaveCMS" />
                        <asp:PostBackTrigger ControlID="btnEditCMS" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <div id="divError" class="text-center col-md-12" runat="server" visible="false" style="margin-top: 50px;">
        <h1>You Can't Access this Page. You don't have  Permission.</h1>
        <h3>Please contact to Admin.</h3>
    </div>
</asp:Content>
