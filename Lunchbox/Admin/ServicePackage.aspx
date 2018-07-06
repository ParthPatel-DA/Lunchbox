<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ServicePackage.aspx.cs" Inherits="Admin_ServicePackage" %>

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
                            <h4 class="modal-title">SPPackage
                            </h4>
                        </div>
                        <div class="modal-body">

                            <asp:Repeater ID="rptViewDetail" runat="server">
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/Admin/Packimg/" + Eval("img") %>' Height="300px" Width="200px" Style="float: left;" />
                                    <div style="float: left; margin-left: 20px;">

                                        <h3>Name<asp:Label runat="server" Text=":" Style="padding: 50px;"></asp:Label>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("PN")  %>' Style="font-size: 15px; margin-left: -28px;"></asp:Label><br />
                                        </h3>

                                        <h3>Duration<asp:Label runat="server" Text=":" Style="padding: 25px;"></asp:Label>
                                            <asp:Label ID="Label8" runat="server" Text='<%# Eval("Du") %>' Style="font-size: 15px;"></asp:Label><br />
                                        </h3>

                                        <h3>Days<asp:Label runat="server" Text=":" Style="padding: 25px;"></asp:Label>
                                            <asp:HiddenField ID="h1" runat="server" Value='<%# Eval("Start_Date") %>' />
                                            <asp:HiddenField ID="h2" runat="server" Value='<%# Eval("End_Date") %>' />
                                            <asp:Label ID="lblday" runat="server" Style="font-size: 15px;"></asp:Label><br />
                                        </h3>


                                        <h3>Price<asp:Label runat="server" Text=":" Style="padding: 54px;"></asp:Label>
                                            <asp:Label ID="Label7" runat="server" Text='<%# Eval("Price") %>' Style="font-size: 15px; margin-left: -28px;"></asp:Label><br />
                                        </h3>

                                        <h3>Description<asp:Label runat="server" Text=":" Style="padding: 15px;"></asp:Label>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("Des") %>' Style="font-size: 15px; margin-left: 11px;"></asp:Label><br />
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
                    <h6>ServiceProvider Package Table</h6>
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
                                <th>ServiceProviderName</th>
                                <th>PackageName</th>
                                <th>Start_Date</th>
                                <th>End_Date</th>
                                <asp:PlaceHolder ID="PlaceHolderActiveHeader" runat="server"><th>IsActive</th></asp:PlaceHolder>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptSP" runat="server" OnItemCommand="rptSP_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="CheckBox2" runat="server" class="styled" style="opacity: 0;" ></asp:CheckBox></span></div></center>
                                        </td>
                                        <td>
                                            <asp:Image ID="Image2" class="img-responsive" runat="server" Style="margin: 0px;" ImageUrl='<%# "~/Admin/Packimg/" + Eval("img") %>' Width="100px" Height="100px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("SPN") %>' />
                                        </td>
                                        <td>
                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("SPPackagesID") %>' />

                                            <asp:LinkButton ID="lnkbtnName" runat="server" CommandName="View" CommandArgument='<%# Eval("SPPackagesID") %>' OnClientClick=""><%# Eval("PN") %></asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("SPPackagesID") %>' />
                                            <asp:Label ID="lblSD" runat="server" Text='<%# Eval("Start_Date") %>' /></td>
                                        <td>
                                            <asp:Label ID="lblED" runat="server" Text='<%# Eval("End_Date") %>' /></td>

                                        <asp:PlaceHolder ID="PlaceHolderActive" runat="server">
                                        <td>
                                            <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl='<%# "img/AdminActive/" + Eval("IsActive") + ".png" %>' Style="width: 25px;" CommandName="Active" CommandArgument='<%# Eval("SPPackagesID") %>' /></td></asp:PlaceHolder>
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

