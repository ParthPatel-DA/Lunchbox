<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AdSProvider.aspx.cs" Inherits="Admin_AdSProvider" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="modal fade" id="myModal" role="dialog" style="margin-top: 5%; width: 700px;">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">

                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">ServiceProvider</h4>
                        </div>
                        <div class="modal-body">

                            <asp:Repeater ID="rptViewDetail" runat="server">
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/ServiceProvider/Upload/" + Eval("img") %>' Height="300px" Width="200px" Style="float: left;" />
                                    <div style="float: left; margin-left: 20px;">

                                        <h3>Name<asp:Label runat="server" Text=":" Style="padding: 110px;"></asp:Label>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("FirstName") + " " + Eval("LastName") %>' Style="font-size: 15px; margin-left: -85px;"></asp:Label><br />
                                        </h3>

                                        <h3>CompanyName<asp:Label runat="server" Text=":" Style="padding: 20px;"></asp:Label>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("CompanyName") %>' Style="font-size: 15px; margin-left: 5px;"></asp:Label><br />
                                        </h3>

                                        <h3>Address<asp:Label runat="server" Text=":" Style="padding: 85px;"></asp:Label>
                                            <asp:Label ID="Label8" runat="server" Text='<%# Eval("Add") %>' Style="font-size: 15px; margin-left: -60px;"></asp:Label><br />
                                        </h3>

                                        <h3>Veg_NonVeg
                                            <asp:Label runat="server" Text=":" Style="padding: 40px;"></asp:Label>
                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("Veg_NonVeg") %>' Style="font-size: 15px; margin-left: -15px;"></asp:Label><br />
                                        </h3>

                                        <h3>VerifyBy<asp:Label runat="server" Text=":" Style="padding: 87px;"></asp:Label>
                                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("CBy") %>' Style="font-size: 15px; margin-left: -45px;"></asp:Label><br />
                                        </h3>
                                        <h3>CreatedOn<asp:Label runat="server" Text=":" Style="padding: 66px;"></asp:Label>
                                            <asp:Label ID="Label7" runat="server" Text='<%# Eval("CreatedOn") %>' Style="font-size: 15px; margin-left: -40px;"></asp:Label><br />

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


    <!-- \Modal -->



    <div class="table-responsive">
        <!-- Table with toolbar -->
        <div class="widget">

            <div style="margin-bottom: 1px;">
                <div class="navbar-inner">
                    <h6>ServiceProvider Table</h6>
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
                            <asp:Repeater ID="rptSPprovider" runat="server" OnItemCommand="rptSPprovider_ItemCommand1">
                                <ItemTemplate>

                                    <tr>
                                        <td>
                                            <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="CheckBox2" runat="server" class="styled" style="opacity: 0;" ></asp:CheckBox></span></div></center>
                                        </td>
                                        <td>
                                            <asp:Image ID="Image2" class="img-responsive" runat="server" Width="100px" Height="100px" Style="margin: 0px;" ImageUrl='<%# "~/ServiceProvider/Upload/" + Eval("img") %>' />
                                        </td>
                                        <td>
                                            <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("ServiceProviderID") %>' />

                                            <asp:LinkButton ID="lnkbtnName" runat="server" CommandName="View" CommandArgument='<%# Eval("ServiceProviderID") %>' OnClientClick=""><%# Eval("str1") %></asp:LinkButton>
                                        </td>

                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Email") %>' /></td>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("ContactNo") %>' /></td>

                                        <asp:PlaceHolder ID="PlaceHolderActive" runat="server"><td><asp:ImageButton ID="ImageButton4" runat="server" ImageUrl='<%# "img/AdminActive/" + Eval("IsActive") + ".png" %>' Style="width: 25px;" CommandName="Active" CommandArgument='<%# Eval("ServiceProviderID") %>' /></td></asp:PlaceHolder>
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

