<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Area1.aspx.cs" Inherits="Admin_Abc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="table-responsive">
        <div class="widget">
         
            <asp:Label ID="lblArea" runat="server" Text="AreaName"></asp:Label>
            <asp:TextBox ID="txtArea" runat="server" Style="margin-left:30px;"></asp:TextBox><br /><br />
            <asp:Label ID="lblPincode" runat="server" Text="PinCode"></asp:Label>
            <asp:TextBox ID="txtPinCode" runat="server"  Style="margin-left:8px;"></asp:TextBox><br /><br />
            <asp:Button ID="Button1" runat="server" Text="Button" style="margin-left:50px; height:30px;width:80px;" OnClick="Button1_Click"/><br /><br />
            <div style="margin-bottom: 1px;">
                <div class="navbar-inner">
                    <h6>Area Page</h6>
                </div>
            </div>
            <div class="table-overflow">
                <div class="table-responsive">
                    <table class="table table-bordered table-checks">
                        <thead>
                            <tr>                     
                                <th>AreaID</th>
                                <th>AreaName</th>
                                <th>PinCode</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rpterror" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblUserID" runat="server" Text='<%# Eval("AreaID") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblpagenm" runat="server" Text='<%# Eval("AreaName") %>' />
                                        </td>
                                         <td>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Pincode") %>' />
                                        </td>
                                    </tr>

                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

