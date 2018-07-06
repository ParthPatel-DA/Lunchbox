<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Address.aspx.cs" Inherits="Admin_Address" %>

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
                            <h4 class="modal-title">Client_Address
                            </h4>
                        </div>
                        <div class="modal-body">

                            <asp:Repeater ID="rptViewDetail" runat="server">
                                <ItemTemplate>

                                    <div style="float: left; margin-left: 20px;">

                                        <h3>Name<asp:Label runat="server" Text=":" Style="padding: 45px;"></asp:Label>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("data") %>' Style="font-size: 15px; margin-left: -10px;"></asp:Label><br />
                                        </h3>

                                        <h3>Address<asp:Label runat="server" Text=":" Style="padding: 30px;"></asp:Label>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("Address") %>' Style="font-size: 15px; margin-left: 1px;"></asp:Label><br />
                                        </h3>

                                        <h3>Landmark<asp:Label runat="server" Text=":" Style="padding: 20px;"></asp:Label>
                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("Landmark") %>' Style="font-size: 15px; margin-left: 10px;"></asp:Label><br />
                                        </h3>

                                        <h3>City<asp:Label runat="server" Text=":" Style="padding: 60px;"></asp:Label>
                                            <asp:Label ID="Label8" runat="server" Text='<%# Eval("city") %>' Style="font-size: 15px; margin-left: -27px"></asp:Label>
                                            <asp:HiddenField ID="HiddenField1" Value='<%# Eval("CityID") %>' runat="server" />
                                            <br />
                                        </h3>

                                        <h3>State<asp:Label runat="server" Text=":" Style="padding: 50px;"></asp:Label>
                                            <asp:Label ID="Label6" runat="server" Style="font-size: 15px; margin-left: -20px;"></asp:Label>
                                            <asp:HiddenField ID="HiddenField3" runat="server" />
                                            <br />
                                        </h3>

                                        <h3>Country<asp:Label runat="server" Text=":" Style="padding: 35px;"></asp:Label>
                                            <asp:Label ID="Label7" runat="server" Style="font-size: 15px; margin-left: -5px;"></asp:Label><br />

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
                    <h6>Client_Address</h6>
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
                                <th>Area</th>
                                <th>CityID</th>
                                <asp:PlaceHolder ID="PlaceHolderActiveHeader" runat="server">
                                    <th>IsActive</th>
                                </asp:PlaceHolder>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptCliadd" runat="server" OnItemCommand="rptCliadd_ItemCommand">
                                <ItemTemplate>

                                    <tr>
                                        <td>
                                            <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="CheckBox2" runat="server" class="styled" style="opacity: 0;" ></asp:CheckBox></span></div></center>
                                        </td>

                                        <td>
                                            <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("AddressID") %>' />

                                            <asp:LinkButton ID="lnkbtnName" runat="server" CommandName="View" CommandArgument='<%# Eval("AddressID") %>' OnClientClick=""><%# Eval("data") %></asp:LinkButton>
                                        </td>

                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Area") %>' /></td>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("city") %>' /></td>
                                        <asp:PlaceHolder ID="PlaceHolderActive" runat="server">
                                            <td>
                                                <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl='<%# "img/AdminActive/" + Eval("IsActive") + ".png" %>' Style="width: 25px;" CommandName="Active" CommandArgument='<%# Eval("AddressID") %>' /></td>
                                        </asp:PlaceHolder>
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




    <div class="table-responsive">
        <!-- Table with toolbar -->
        <div class="widget">

            <div style="margin-bottom: 1px;">
                <div class="navbar-inner">
                    <h6>Service_Address</h6>
                </div>
            </div>

            <div class="table-overflow">
                <div class="table-responsive">
                    <table class="table table-bordered table-checks">
                        <thead>
                            <tr>
                                <th>
                                    <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="CheckBox1" runat="server" class="styled" style="opacity: 0;" CommandName="AllCheck" CommandArgument='<%# Eval("EmpID") %>' ></asp:CheckBox></span></div></center>
                                </th>
                                <th>Name</th>
                                <th>Area</th>
                                <th>CityID</th>
                                <asp:PlaceHolder ID="PlaceHolderActiveHeader1" runat="server">
                                    <th>IsActive</th>
                                </asp:PlaceHolder>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptservice" runat="server" OnItemCommand="rptservice_ItemCommand">

                                <ItemTemplate>

                                    <tr>
                                        <td>
                                            <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="CheckBox2" runat="server" class="styled" style="opacity: 0;" ></asp:CheckBox></span></div></center>
                                        </td>

                                        <td>
                                            <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("AddressID") %>' />

                                            <asp:LinkButton ID="lnkbtnName" runat="server" CommandName="View" CommandArgument='<%# Eval("AddressID") %>' OnClientClick=""><%# Eval("data") %></asp:LinkButton>
                                        </td>

                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Area") %>' /></td>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("city") %>' /></td>

                                        <asp:PlaceHolder ID="PlaceHolderActive" runat="server">
                                            <td>
                                                <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl='<%# "img/AdminActive/" + Eval("IsActive") + ".png" %>' Style="width: 25px;" CommandName="Active" CommandArgument='<%# Eval("AddressID") %>' /></td>
                                        </asp:PlaceHolder>
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

