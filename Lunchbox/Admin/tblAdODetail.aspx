<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="tblAdODetail.aspx.cs" Inherits="Admin_tblAdODetail" %>

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
                            <h4 class="modal-title">Detail
                            </h4>
                        </div>
                        <div class="modal-body">

                            <asp:Repeater ID="rptViewDetail" runat="server">
                                <ItemTemplate>
                                    <div style="float: left; margin-left: 20px;">

                                     <h3>
                                      <asp:Label ID="Label3" runat="server" Text='<%# "Delivery Boy Name : " + Eval("FirstName") + " " + Eval("LastName") %>' Style="font-size: 15px;"></asp:Label><br />
                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("ServiceProviderID") %>' />
                                        </h3>
                                        <asp:Repeater ID="rptMenuOrderDetail" runat="server">
                                                <HeaderTemplate>
                                                    <table class="table table-bordered table-checks">
                                                        <thead>
                                                            <tr>
                                                                
                                                                <th>Client Name</th>
                                                                <th>Price</th>
                                                                <th>Quantity</th>
                                                                <th>Total Price</th>

                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td style="height:100px;width:150px">
                                                           <asp:Label ID="Label1" runat="server" Text='<%# Eval("Name")%>' Style="font-size: 15px;"></asp:Label><br />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Price")%>' Style="font-size: 15px;"></asp:Label><br />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("qty") %>' Style="font-size: 15px;"></asp:Label><br />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label8" runat="server" Text='<%# Eval("TotalPrice") %>' Style="font-size: 15px;"></asp:Label><br />
                                                        </td>

                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    </tbody>
                                            </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                       
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
                    <h6>Meal Order Detail</h6>
                </div>
            </div>

            <div class="table-overflow">
                <div class="table-responsive">
                    <asp:Repeater ID="rptorder" runat="server" OnItemCommand="rptorder_ItemCommand">
                        <HeaderTemplate>
                            <table class="table table-bordered table-checks">
                                <thead>
                                    <tr>
                                        <th>
                                            <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="CheckBox3" runat="server" class="styled" style="opacity: 0;" CommandName="AllCheck" ></asp:CheckBox></span></div></center>
                                        </th>
                                        <th>Image</th>
                                        <th>Name</th>
                                        <th>ContactNo</th>
                                        <th>Date</th>
                                        <th>IsActive</th>
                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tbody>
                                <tr>

                                    <td>
                                        <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="CheckBox3" runat="server" class="styled" style="opacity: 0;" CommandName="AllCheck"  ></asp:CheckBox></span></div></center>
                                    </td>


                                    <td>

                                        <asp:Image ID="Image2" class="img-responsive" runat="server" Width="100px" Height="100px" Style="margin: 0px;" ImageUrl='<%# "~/ServiceProvider/Meal/" + Eval("img") %>' />
                                    </td>
                                    <td>
                                        <%--  <asp:Label ID="Label1" runat="server" Text='<%# Eval("MealName") %>'></asp:Label>--%>
                                        <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("OrderID") %>' />

                                        <asp:LinkButton ID="lnkbtnName" runat="server" CommandName="View" CommandArgument='<%# Eval("OrderID") %>' OnClientClick=""><%# Eval("MealName") %></asp:LinkButton>
                                    </td>


                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("PhoneNo") %>' />
                                    </td>

                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Date") %>' /></td>
                                    <td>
                                        <%--<asp:ImageButton ID="ImageButton4" runat="server" ImageUrl='<%# "img/AdminActive/" + Eval("IsActive") + ".png" %>' Style="width: 25px;" CommandName="Active" CommandArgument='<%# Eval("OrderID") %>' />--%>
                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# "img/AdminActive/" + Eval("IsActive") + ".png" %>' Style="width: 25px;" CommandName="Active" CommandArgument='<%# Eval("OrderID") %>'/>
                                    </td>
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
                    <h6>Menu Order Detail</h6>
                </div>
            </div>

            <div class="table-overflow">
                <div class="table-responsive">
                    <asp:Repeater ID="reptMenu" runat="server" OnItemCommand="reptMenu_ItemCommand">
                        <HeaderTemplate>
                            <table class="table table-bordered table-checks">
                                <thead>
                                    <tr>
                                        <th>
                                            <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="CheckBox3" runat="server" class="styled" style="opacity: 0;" CommandName="AllCheck" ></asp:CheckBox></span></div></center>
                                        </th>
                                        <th>Image</th>
                                        <th>Name</th>
                                        <th>ContactNo</th>
                                        <th>Date</th>
                                        <th>IsActive</th>
                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tbody>
                                <tr>

                                    <td>
                                        <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="CheckBox3" runat="server" class="styled" style="opacity: 0;" CommandName="AllCheck"  ></asp:CheckBox></span></div></center>
                                    </td>


                                    <td>

                                        <asp:Image ID="Image2" class="img-responsive" runat="server" Width="100px" Height="100px" Style="margin: 0px;" ImageUrl='<%# "~/ServiceProvider/Iteam/" + Eval("img") %>' />
                                    </td>

                                    <td>
                                        <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("OrderID") %>' />


                                        <asp:LinkButton ID="lnkbtnName" runat="server" CommandName="View" CommandArgument='<%# Eval("OrderID") %>' OnClientClick=""><%# Eval("ItemName") %></asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("PhoneNo") %>' />
                                    </td>

                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Date") %>' /></td>
                                    <td>
                                        <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl='<%# "img/AdminActive/" + Eval("IsActive") + ".png" %>' Style="width: 25px;" CommandName="Active" CommandArgument='<%# Eval("OrderID") %>' /></td>
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


    <!-- /default datatable -->

</asp:Content>

