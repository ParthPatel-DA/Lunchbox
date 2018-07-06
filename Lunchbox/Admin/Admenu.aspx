<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Admenu.aspx.cs" Inherits="Admin_Admenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="modal fade" id="myModal" role="dialog" style="margin-top: 5%; padding-left: 25px; width: 750px;">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>

                    <div class="modal-content">
                        <div class="modal-header">

                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Menu
                            </h4>
                        </div>
                        <div class="modal-body">

                            <asp:Repeater ID="rptViewDetail" runat="server">
                                <ItemTemplate>
                                    <div class="col-md-12">

                                        <div class="col-md-4" style="margin-top: 30px;">
                                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/ServiceProvider/Iteam/" + Eval("img") %>' Height="185px" Width="150px" Style="float: left;" />
                                        </div>
                                        <div class="col-md-8" style="padding-left: 20px;">
                                            <h3>
                                                <asp:Label ID="Label4" runat="server" Text="Name" Style="padding-left: 10px;"></asp:Label>
                                                <asp:Label ID="Label1" runat="server" Text=":" Style="padding: 108px;"></asp:Label>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("ItemName")%>' Style="font-size: 15px; margin-left: -75px;"></asp:Label><br />
                                            </h3>
                                              <h3>
                                                <asp:Label ID="Label11" runat="server" Text="ServiceProvider" Style="padding-left: 10px;"></asp:Label>
                                                <asp:Label ID="Label7" runat="server" Text=":" Style="padding: 13px;"></asp:Label>
                                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("Name")  %>' Style="font-size: 15px; margin-left: 15px;"></asp:Label><br />
                                            </h3>

                                            <h3>
                                                <asp:Label ID="Label9" runat="server" Text="Type" Style="padding-left: 10px;"></asp:Label>
                                                <asp:Label ID="Label2" runat="server" Text=":" Style="padding: 118px;"></asp:Label>
                                                <asp:Image ID="Image3" runat="server" ImageUrl='<%# "~/Icon/" + Eval("ItemType") + ".png" %>' Style="width: 25px; margin-left: -85px;" />
                                            </h3>

                                            <h3>
                                                <asp:Label ID="Label10" runat="server" Text="Description" Style="padding-left: 10px;"></asp:Label>
                                                <asp:Label ID="Label5" runat="server" Text=":" Style="padding: 55px;"></asp:Label>
                                                <asp:Label ID="Label8" runat="server"  Text='<%# Eval("ItemDescription") %>' Style="font-size: 15px; margin-left: -25px; text-align: justify;"></asp:Label><br />
                                            </h3>

                                          



                                        </div>
                                    </div>
                                    <hr />
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>

                    </div>

                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>




    <!-- Table with toolbar -->
    <div class="widget" id="divPage" runat="server">
        <div style="margin-bottom: 1px;">
            <div class="navbar-inner">
                <h6>Menu Detail</h6>
            </div>
        </div>

        <div class="table-overflow">
            <table class="table table-bordered table-checks">
                <thead>
                    <tr>
                        <th>
                            <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="CheckBox3" runat="server" class="styled" style="opacity: 0;" CommandName="AllCheck" CommandArgument='<%# Eval("EmpID") %>' ></asp:CheckBox></span></div></center>
                        </th>
                        <th>Image</th>
                        <th>MenuName</th>
                        <%--<th>ServiceProvider</th>--%>
                        <th>MenuTye</th>
                        <asp:PlaceHolder ID="PlaceHolderActiveHeader" runat="server">
                            <th>IsActive</th>
                        </asp:PlaceHolder>
                    </tr>
                </thead>
                <asp:Repeater ID="rptmenu" runat="server" OnItemCommand="rptmenu_ItemCommand">

                    <ItemTemplate>
                        <tbody>
                            <tr>

                                <td>
                                    <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="CheckBox3" runat="server" class="styled" style="opacity: 0;" CommandName="AllCheck" CommandArgument='<%# Eval("MenuID") %>' ></asp:CheckBox></span></div></center>
                                </td>
                                <td>
                                    <asp:Image ID="Image2" class="img-responsive" runat="server" Width="100px" Height="100px" Style="margin: 0px;" ImageUrl='<%# "~/ServiceProvider/Menu/" + Eval("img") %>' />
                                </td>

                                <td>
                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("MenuID") %>' />
                                    <asp:LinkButton ID="lnkbtnName" runat="server" CommandName="View" CommandArgument='<%# Eval("MenuID") %>' OnClientClick=""><%# Eval("MenuName") %></asp:LinkButton>


                                    <td>

                                        <asp:Image ID="Image3" runat="server" ImageUrl='<%# "~/Icon/" + Eval("MenuType") + ".png" %>' Style="width: 25px;" />
                                        <asp:PlaceHolder ID="PlaceHolderActive" runat="server">
                                            <td>
                                                <%--<asp:ImageButton ID="ImageButton4" runat="server" ImageUrl='<%# "img/AdminActive/" + Eval("IsActive") + ".png" %>' Style="width: 25px;" CommandName="Active" CommandArgument='<%# Eval("MenuID") %>' />--%>
                                                <asp:Image ID="Image4" runat="server" ImageUrl='<%# "img/AdminActive/" + Eval("IsActive") + ".png" %>' Style="width: 25px;" CommandName="Active" CommandArgument='<%# Eval("MenuID") %>' />
                                            </td>
                                        </asp:PlaceHolder>
                            </tr>
                        </tbody>
                    </ItemTemplate>

                </asp:Repeater>
            </table>
        </div>




    </div>
    <!-- /table with toolbar -->



</asp:Content>

