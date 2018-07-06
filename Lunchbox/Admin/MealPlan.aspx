<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="MealPlan.aspx.cs" Inherits="Admin_MealPlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="modal fade" id="myModal" role="dialog" style="margin-top: 5%; width: 800px; padding-left: 25px;">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">

                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Meal
                            </h4>
                        </div>
                        <div class="modal-body">

                            <asp:Repeater ID="rptViewDetail" runat="server">
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/ServiceProvider/Meal/" + Eval("img") %>' Height="250px" Width="150px" Style="float: left;" />
                                    <div style="float: left; margin-left: 20px;">

                                        <h3>Name<asp:Label ID="Label1" runat="server" Text=":" Style="padding: 108px;"></asp:Label>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("MealName")%>' Style="font-size: 15px; margin-left: -75px;"></asp:Label><br />
                                        </h3>

                                        <h3>Type<asp:Label ID="Label2" runat="server" Text=":" Style="padding: 118px;"></asp:Label>
                                            <asp:Image ID="Image3" runat="server" ImageUrl='<%# "~/Icon/" + Eval("MealType") + ".png" %>' Style="width: 25px; margin-left: -85px;" /><br />
                                        </h3>

                                        <h3>Description<asp:Label ID="Label5" runat="server" Text=":" Style="padding: 55px;"></asp:Label>
                                            <asp:Label ID="Label8" runat="server" Text='<%# Eval("MealDescription") %>' Style="font-size: 15px; margin-left: -25px;"></asp:Label><br />
                                        </h3>
                                        <h3>ServiceProvider<asp:Label ID="Label7" runat="server" Text=":" Style="padding: 13px;"></asp:Label>
                                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("CBy") %>' Style="font-size: 15px; margin-left: 15px;"></asp:Label><br />
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
                <h6>MealPlan Table</h6>
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
                            <th>Images</th>
                            <%-- <th>ServiceProvider</th>--%>
                            <th>MealName</th>
                            <%--<th>MealType</th>
                                        <th>MealDescription</th>--%>
                            <th>MealPrice</th>
                            <asp:PlaceHolder ID="PlaceHolderActiveHeader" runat="server">
                            <th>IsActive</th></asp:PlaceHolder>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptmeal" runat="server" OnItemCommand="rptmeal_ItemCommand">

                            <ItemTemplate>

                                <tr>
                                    <td>
                                        <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="CheckBox2" runat="server" class="styled" style="opacity: 0;" ></asp:CheckBox></span></div></center>
                                    </td>
                                    <%--<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("SPName") %>' /></td>--%>
                                    <td>
                                        <asp:Image ID="Image2" class="img-responsive" runat="server" Width="100px" Height="100px" Style="margin: 0px;" ImageUrl='<%# "~/ServiceProvider/Meal/" + Eval("img") %>' />
                                    </td>
                                    <%--<td>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("CBy") %>' /></td>
                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("MealID") %>' />--%>
                                    <td>
                                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("MealID") %>' />
                                        <asp:LinkButton ID="lnkbtnName" runat="server" CommandName="View" CommandArgument='<%# Eval("MealID") %>' OnClientClick=""><%# Eval("MealName") %></asp:LinkButton>
                                        <%--<td>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("MealType") %>' /></td>--%>

                                        <%--<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("ServiceProviderID") %>' /></td>--%>
                                        <%--<td>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("MealDescription") %>' /></td>--%>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("MealPrice") %>' /></td>

                                        <asp:PlaceHolder ID="PlaceHolderActive" runat="server">
                                       <%-- <td><asp:ImageButton ID="ImageButton4" runat="server" ImageUrl='<%# "img/AdminActive/" + Eval("IsActive") + ".png" %>' Style="width: 25px;" CommandName="Active" CommandArgument='<%# Eval("MealID") %>' /></td></asp:PlaceHolder>--%>
                                
                                            <td> <asp:Image ID="Image4" runat="server" ImageUrl='<%# "img/AdminActive/" + Eval("IsActive") + ".png" %>' Style="width: 25px;" CommandName="Active" CommandArgument='<%# Eval("MealID") %>'/></td></asp:PlaceHolder>
                                </tr>

                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

