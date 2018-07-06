<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Package.aspx.cs" Inherits="Admin_Package" %>

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
                            <h4 class="modal-title">Packages
                            </h4>
                        </div>
                        <div class="modal-body">

                            <asp:Repeater ID="rptViewDetail" runat="server">
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/Admin/Packimg/" + Eval("img") %>' Height="300px" Width="200px" Style="float: left;" />
                                    <div style="float: left; margin-left: 20px;">

                                        <h3>Name<asp:Label ID="Label9" runat="server" Text=":" Style="padding: 80px;"></asp:Label>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Name") %>' Style="font-size: 15px; margin-left: -55px;"></asp:Label><br />
                                        </h3>

                                        <h3>Description<asp:Label ID="Label2" runat="server" Text=":" Style="padding: 25px;"></asp:Label>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("Description") %>' Style="font-size: 15px;"></asp:Label><br />
                                        </h3>

                                        <h3>CreatedBy<asp:Label ID="Label5" runat="server" Text=":" Style="padding: 35px;"></asp:Label>
                                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("CBy") %>' Style="font-size: 15px; margin-left: -10px;"></asp:Label><br />
                                        </h3>

                                        <h3>CreatedOn<asp:Label ID="Label8" runat="server" Text=":" Style="padding: 33px;"></asp:Label>
                                            <asp:Label ID="Label7" runat="server" Text='<%# Eval("CreatedOn") %>' Style="font-size: 15px; margin-left: -10px;"></asp:Label><br />

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
                    <h6>Pakage Table</h6>
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
                                <th>Duration</th>
                                <th>Price</th>
                                <asp:PlaceHolder ID="PlaceHolderActiveHeader" runat="server">
                                 <th>IsActive</th>
                                  <th>Edit</th>
                                </asp:PlaceHolder>

                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptadmin" runat="server" OnItemCommand="rptadmin_ItemCommand1">
                                <ItemTemplate>

                                    <tr>
                                        <td>

                                            <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="CheckBox3" runat="server" class="styled" style="opacity: 0;" CommandName="AllCheck" CommandArgument='<%# Eval("PackagesID") %>' ></asp:CheckBox></span></div></center>

                                        </td>
                                        <td>
                                            <asp:Image ID="Image2" class="img-responsive" runat="server" ImageUrl='<%# "~/Admin/Packimg/" + Eval("img") %>' Width="100px" Height="100px" Style="margin: 0px;" />

                                        </td>
                                        <td>
                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("PackagesID") %>' />

                                            <asp:LinkButton ID="lnkbtnName" runat="server" CommandName="View" CommandArgument='<%# Eval("PackagesID") %>' OnClientClick=""><%# Eval("Name") %></asp:LinkButton>

                                        </td>
                                        <td>
                                            <asp:Label ID="DurationLabel" runat="server" Text='<%# Eval("Duration") +" " + "month"%>' />
                                        </td>

                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("cv") %>' />
                                        </td>
                                              
                                        <asp:PlaceHolder ID="PlaceHolderActive" runat="server">
                                     
                                            <td>
                                                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl='<%# "img/AdminActive/" + Eval("IsActive") + ".png" %>' Style="width: 25px;" CommandName="Active" CommandArgument='<%# Eval("PackagesID") %>' />

                                            </td>
                            
                                                   
                                            
                                            <td>
                                                <%-- <asp:ImageButton ID="ImageButton1" runat="server"  ImageUrl="img/edit.png" Style="width:25px; height :25px;" CommandName ="package" CommandArgument='<%# Eval("PackagesID") + ";" + Eval("Name") + ";" + Eval("Duration") + ";" + Eval("Prices") + ";" + Eval("Description") + ";" + Eval("Image")%>' OnClick ="ImageButton1_Click"/></td>--%>
                                                <asp:LinkButton ID="lnkRowSelection" runat="server" CommandName="Package" CommandArgument='<%# Eval("PackagesID") %>'><img src="img/edit.png" style="width: 25px;" /></asp:LinkButton>
                                            </td>
                                                            
                                           </asp:PlaceHolder>
                                    </tr>

                                </ItemTemplate>

                            </asp:Repeater>
                        </tbody>
                    </table>
                    <%--  </table>--%>
                </div>
            </div>
        </div>
        <!-- /table with toolbar -->
    </div>
</asp:Content>

