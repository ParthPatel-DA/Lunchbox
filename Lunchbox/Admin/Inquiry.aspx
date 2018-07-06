<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Inquiry.aspx.cs" Inherits="Admin_Inquiry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   


    <div id="head">
        <h5 class="widget-name"><i class="icon-columns"></i>Inquiry Table</h5>

        <!-- Default datatable -->
        <div class="widget">
            <div class="navbar">
                <div class="navbar-inner">
                    <h6>Inquiry datatable</h6>
                </div>
            </div>
            <asp:Repeater ID="rptin" runat="server" OnItemCommand="rptin_ItemCommand">
                <HeaderTemplate>
                    <div class="table-overflow">
                        <table class="table table-striped table-bordered" id="data-table">
                            <thead>
                                <tr>
                                    <%--   <th>InquiryID</th>--%>
                                    <th>
                                        <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="CheckBox2" runat="server" class="styled" style="opacity: 0;" ></asp:CheckBox></span></div></center>
                                    </th>
                                    <th>Email</th>
                                    <th>ContactNO</th>
                                    <th>Subject</th>
                                    <th>CreatedOn</th>
                                    <th>IsNotify</th>
                                </tr>
                            </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr>
                            <td>
                                <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="CheckBox2" runat="server" class="styled" style="opacity: 0;" ></asp:CheckBox></span></div></center>
                            </td>
                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("InquiryID") %>' />
                            <td>
                                <%--<asp:Label ID="Label1" runat="server" Text='<%# Eval("Email") %>' /></td>--%>
                                <asp:HiddenField ID="HiddenField3" runat="server" Value='<%# Eval("InquiryID") %>' />
                                <asp:LinkButton ID="lnkbtnName" runat="server" CommandArgument='<%#Eval("InquiryID") + ";" + Eval("Email") + ";" + Eval("ContactNO") + ";" + Eval("Discription") %>' onclick="lnkbtnName_Click"><%# Eval("Email") %></asp:LinkButton>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("ContactNO") %>' /></td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Discription") %>' /></td>

                                <td>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("CreatedOn") %>' /></td>
                                <td>
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# "img/" + Eval("IsNotify") + ".png" %>' Style="width: 25px;" CommandName="Notify" CommandArgument='<%# Eval("InquiryID") %>' /></td>
                        </tr>



                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
    <!-- /default datatable -->



</asp:Content>

