<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="VerifySP.aspx.cs" Inherits="Admin_VerifyEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="divPage" runat="server" class="table-responsive">
        <!-- Table with toolbar -->
        <div class="widget">
            <div style="margin-bottom: 1px;">
                <div class="navbar-inner">
                    <h6>Verify Delivery Boy</h6>
                </div>
            </div>

            <div class="table-overflow">
                <div class="table-responsive">
                    <asp:Repeater ID="rptVerifyEmployee" runat="server" OnItemCommand="rptVerifyEmployee_ItemCommand">
                        <HeaderTemplate>
                            <table class="table table-bordered table-checks">
                                <thead>
                                    <tr>
                                        <th></th>
                                        <th>Delivery Boy Name</th>
                                        <th>Email</th>
                                        <th>Contact Number</th>
                                        <th>Registration Date</th>
                                        <th>Verify</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td></td>
                                <td><%# Eval("FirstName") + " " + Eval("LastName") %></td>
                                <td><%# Eval("Email") %></td>
                                <td><%# Eval("ContactNo") %></td>
                                <td><%# Eval("CreatedOn") %></td>
                                <td>
                                    <asp:Button ID="btnVerify" class="btn-danger" runat="server" Text="Verify" CommandName="Email" CommandArgument='<%# Eval("ServiceProviderID") %>'/>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>

    <div id="divError" class="text-center col-md-12" runat="server" visible="false" style="margin-top: 50px;">
        <h1>You Can't Access this Page. You don't have  Permission.</h1>
        <h3>Please contact to Admin.</h3>
    </div>
</asp:Content>

