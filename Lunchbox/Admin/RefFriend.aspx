<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="RefFriend.aspx.cs" Inherits="Admin_RefFriend" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="modal fade" id="myModal" role="dialog" style="margin-top: 5%; width: 400px;">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">

                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Data
                            </h4>
                        </div>
                        <div class="modal-body">

                            <asp:Repeater ID="rptViewDetail" runat="server">
                                <ItemTemplate>

                                    <div style="float: left; margin-left: 20px;">

                                        <h3>Name<asp:Label ID="Label1" runat="server" Text=":" Style="padding: 80px;"></asp:Label>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("CN")%>' Style="font-size: 15px; margin-left: -55px;"></asp:Label><br />
                                        </h3>

                                        <h3>Description<asp:Label ID="Label5" runat="server" Text=":" Style="padding: 25px;"></asp:Label>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("Discription") %>' Style="font-size: 15px;"></asp:Label><br />
                                        </h3>

                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>

                        </div>

                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <div id="divPage" runat="server">
        <div class="table-responsive">
            <!-- Table with toolbar -->
            <div class="widget">
                <div style="margin-bottom: 1px;">
                    <div class="navbar-inner">
                        <h6>Client</h6>
                    </div>
                </div>

                <div class="table-overflow">
                    <div class="table-responsive">
                        <asp:Repeater ID="rptrefrd" runat="server" OnItemCommand="rptrefrd_ItemCommand">
                            <HeaderTemplate>
                                <table class="table table-bordered table-checks">
                                    <thead>
                                        <tr>
                                            <th>
                                                <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="CheckBox3" runat="server" class="styled" style="opacity: 0;" CommandName="AllCheck" CommandArgument='<%# Eval("EmpID") %>' ></asp:CheckBox></span></div></center>
                                            </th>


                                            <th>Email</th>
                                            <th>Client</th>
                                            <th>ReferDate</th>


                                        </tr>
                                    </thead>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tbody>
                                    <tr>
                                        <td>
                                            <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="CheckBox3" runat="server" class="styled" style="opacity: 0;" CommandName="AllCheck" CommandArgument='<%# Eval("ReferFriendID") %>' ></asp:CheckBox></span></div></center>
                                        </td>
                                        <td>
                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("ReferFriendID") %>' />
                                            <%-- <asp:Label ID="Label3" runat="server" Text='<%# Eval("ReferEmailID") %>' /></td>--%>
                                            <asp:LinkButton ID="lnkbtnName" runat="server" CommandName="View" CommandArgument='<%# Eval("ReferFriendID") %>' OnClientClick=""><%# Eval("ReferEmailID") %></asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("CN") %>' /></td>

                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("ReferDate") %>' /></td>


                                    </tr>
                                </tbody>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
            <!-- /table with toolbar -->
        </div>
        <div class="table-responsive">
            <!-- Table with toolbar -->
            <div class="widget">
                <div style="margin-bottom: 1px;">
                    <div class="navbar-inner">
                        <h6>ServicePrvider</h6>
                    </div>
                </div>

                <div class="table-overflow">
                    <div class="table-responsive">
                        <asp:Repeater ID="rptservice" runat="server" OnItemCommand="rptservice_ItemCommand">
                            <HeaderTemplate>
                                <table class="table table-bordered table-checks">
                                    <thead>
                                        <tr>
                                            <th>
                                                <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="CheckBox3" runat="server" class="styled" style="opacity: 0;" CommandName="AllCheck" CommandArgument='<%# Eval("ReferFriendID") %>' ></asp:CheckBox></span></div></center>
                                            </th>
                                            <th>Email</th>
                                            <th>ServiceProvider</th>
                                            <th>ReferDate</th>

                                        </tr>
                                    </thead>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tbody>
                                    <tr>
                                        <td>
                                            <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="CheckBox3" runat="server" class="styled" style="opacity: 0;" CommandName="AllCheck" CommandArgument='<%# Eval("ReferFriendID") %>' ></asp:CheckBox></span></div></center>
                                        </td>
                                        <td>
                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("ReferFriendID") %>' />
                                            <%-- <asp:Label ID="Label3" runat="server" Text='<%# Eval("ReferEmailID") %>' /></td>--%>
                                            <asp:LinkButton ID="lnkbtnName" runat="server" CommandName="View" CommandArgument='<%# Eval("ReferFriendID") %>' OnClientClick=""><%# Eval("ReferEmailID") %></asp:LinkButton>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("CN") %>' /></td>

                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("ReferDate") %>' /></td>
                                    </tr>

                                </tbody>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
            <!-- /table with toolbar -->
        </div>
    </div>

    

</asp:Content>

