<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Client.aspx.cs" Inherits="Client" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="modal fade" id="myModal" role="dialog" style="margin-top: 5%;">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Client
                            </h4>
                        </div>
                        <div class="modal-body">

                            <asp:Repeater ID="rptViewDetail" runat="server">
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/Client/Upload/" + Eval("img") %>' Height="250px" Width="200px" Style="float: left;" />
                                    <div style="float: left; margin-left: 20px;">

                                        <h3>Name<asp:Label ID="Label1" runat="server" Text=":" Style="padding: 60px;"></asp:Label>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("CBy") %>' Style="font-size: 15px; margin-left: -33px;"></asp:Label><br />
                                        </h3>

                                        <h3>Address<asp:Label ID="Label2" runat="server" Text=":" Style="padding: 35px;"></asp:Label>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("Add") %>' Style="font-size: 15px; margin-left: -10px;"></asp:Label><br />
                                        </h3>


                                        <h3>CreatedOn
                                            <asp:Label ID="Label8" runat="server" Text=":" Style="padding: 8px;"></asp:Label>
                                            <asp:Label ID="Label7" runat="server" Text='<%# Eval("CreatedOn") %>' Style="font-size: 15px; margin-left: 15px;"></asp:Label><br />

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





    <div class="widget">
        <div style="margin-bottom: 1px;">
            <div class="navbar-inner">
                <h6>Client Table</h6>
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
                            <th>Image</th>
                            <th>Name</th>
                            <th>Email</th>
                            <th>ContactNo</th>
                            <asp:PlaceHolder ID="PlaceHolderActiveHeader" runat="server"><th>IsActive</th></asp:PlaceHolder>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptmenu" runat="server" OnItemCommand="rptfb_ItemCommand">
                            <ItemTemplate>

                                <tr>
                                    <td>
                                        <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="CheckBox2" runat="server" class="styled" style="opacity: 0;" ></asp:CheckBox></span></div></center>
                                    </td>
                                    <td>
                                        <asp:Image ID="Image2" class="img-responsive" runat="server" Width="100px" Height="100px" Style="margin: 0px;" ImageUrl='<%# "~/Client/Upload/" + Eval("img") %>' />
                                    </td>

                                    <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("ClientID") %>' />
                                    <td>
                                        <asp:LinkButton ID="lnkbtnName" runat="server" CommandName="View" CommandArgument='<%# Eval("ClientID") %>' OnClientClick=""><%# Eval("CBy") %></asp:LinkButton>
                                    </td>

                                    <td>
                                        <asp:Label ID="lblemail" runat="server" Text='<%# Eval("Email") %>' /></td>
                                    <td>
                                        <asp:Label ID="lblconno" runat="server" Text='<%# Eval("ContactNo") %>' /></td>


                                    <asp:PlaceHolder ID="PlaceHolderActive" runat="server"><td><asp:ImageButton ID="ImageButton4" runat="server" ImageUrl='<%# "img/AdminActive/" + Eval("IsActive") + ".png" %>' Style="width: 25px;" CommandName="Active" CommandArgument='<%# Eval("ClientID") %>' /></td></asp:PlaceHolder>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>


            <!-- /table with toolbar -->
</asp:Content>

