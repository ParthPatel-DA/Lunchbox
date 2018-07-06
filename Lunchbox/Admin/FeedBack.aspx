<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="FeedBack.aspx.cs" Inherits="Admin_FeedBack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="modal fade" id="myModal" role="dialog" style="margin-top: 5%; width: 900px;">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">

                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">ServiceProvider
                            </h4>
                        </div>
                        <div class="modal-body">

                            <asp:Repeater ID="rptViewDetail" runat="server">
                                <ItemTemplate>
                                    <h3>Name<asp:Label ID="Label8" runat="server" Text=":" Style="padding: 85px;" Font-Italic="False"></asp:Label>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Data") %>' Style="font-size: 15px; margin-left: -55px;"></asp:Label><br />
                                    </h3>

                                    <h3>Description<asp:Label ID="Label5" runat="server" Text=":" Style="padding: 30px;"></asp:Label>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("Description") %>' Style="font-size: 15px;"></asp:Label><br />
                                    </h3>

                                    <h3>CreatedOn<asp:Label ID="Label6" runat="server" Text=":" Style="padding: 38px;"></asp:Label>
                                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("CreatedOn") %>' Style="font-size: 15px; margin-left: -5px;"></asp:Label><br />

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



    <div class="table-responsive">
        <!-- Table with toolbar -->
        <div class="widget">

            <div style="margin-bottom: 1px;">
                <div class="navbar-inner">
                    <h6>Feedback</h6>
                </div>
            </div>

            <div class="table-overflow">
                <div class="table-responsive">
                    <table class="table table-bordered table-checks">
                        <thead>
                            <tr>
                                <th>
                                    <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="CheckBox3" runat="server" class="styled" style="opacity: 0;" CommandName="AllCheck" CommandArgument='<%# Eval("EmpID") %>' ></asp:CheckBox></span></div></center>
                                </th>

                                <th>Name</th>
                                <th>Email</th>
                                <th>ContectNo</th>
                                <asp:PlaceHolder ID="PlaceHolderActiveHeader" runat="server"><th>IsNotify</th></asp:PlaceHolder>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptfb" runat="server" OnItemCommand="rptfb_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="CheckBox2" runat="server" class="styled" style="opacity: 0;" ></asp:CheckBox></span></div></center>
                                        </td>
                                        <td>
                                            <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("FeedBackID") %>' />

                                            <asp:LinkButton ID="lnkbtnName" runat="server" CommandName="View" CommandArgument='<%# Eval("FeedBackID") %>' OnClientClick=""><%# Eval("Data") %></asp:LinkButton>
                                        </td>

                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Email") %>' /></td>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("ContactNo") %>' />
                                        </td>


                                        <asp:PlaceHolder ID="PlaceHolderActive" runat="server"><td><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# "img/" + Eval("IsNotify") + ".png" %>' Style="width: 25px;" CommandName="Notify" CommandArgument='<%# Eval("FeedBackID") %>' /></td></asp:PlaceHolder>

                                    </tr>

                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <!-- /table with toolbar -->
    </div>











</asp:Content>

