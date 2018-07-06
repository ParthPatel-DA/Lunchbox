<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="empgrid.aspx.cs" Inherits="Admin_empgrid" EnableEventValidation="false" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        //function fnGetData ()   {    
        //    alert(window.localStorage.getItem("UserID"));
        //    alert(window.localStorage.getItem("Password"));
        //}   
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<input id="Button1" type="button" value="button" onclick="fnGetData();" />--%>
    <asp:Panel ID="Panel1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="modal fade" id="myModal" role="dialog" style="margin-top: 5%; width: 700px;">
            <div class="modal-dialog">
                <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">

                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Admin
                                </h4>
                            </div>
                            <div class="modal-body">

                                <asp:Repeater ID="rptViewDetail" runat="server">
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/Admin/Upload/" + Eval("img") %>' Height="300px" Width="200px" Style="float: left;" />
                                        <div style="float: left; margin-left: 20px;">


                                            <h3>Name<asp:Label runat="server" Text=":" Style="padding: 63px;"></asp:Label>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("FirstName") + " " + Eval("LastName") %>' Style="font-size: 15px; margin-left: -45px;"></asp:Label><br />
                                            </h3>

                                            <h3>Contactno<asp:Label runat="server" Text=":" Style="padding: 20px;"></asp:Label>
                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("ContactNO") %>' Style="font-size: 15px; margin-left: -5px;"></asp:Label><br />
                                            </h3>

                                            <h3>CreatedBy<asp:Label runat="server" Text=":" Style="padding: 20px;"></asp:Label>
                                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("CBy") %>' Style="font-size: 15px; margin-left: -5px;"></asp:Label><br />
                                            </h3>

                                            <h3>CreatedOn<asp:Label runat="server" Text=":" Style="padding: 17px;"></asp:Label>
                                                <asp:Label ID="Label7" runat="server" Text='<%# Eval("CreatedOn") %>' Style="font-size: 15px;"></asp:Label><br />

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
                        <h6>Admin Table</h6>
                    </div>
                </div>

                <div class="table-overflow">
                    <div class="table-responsive">
                        <table class="table table-bordered table-checks">
                            <thead>
                                <tr>
                                    <th>
                                        <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="CheckBox3" runat="server" class="styled" style="opacity: 0;" CommandName="AllCheck" CommandArgument='<%# Eval("EmpID") %>' ></asp:CheckBox></span></div></center>
                                        <%--<asp:ImageButton runat="server" ImageUrl="img/edit.png" Height="20px" Width="20px" ></asp:ImageButton>--%>
                                    </th>
                                    <th>Image</th>
                                    <th>Name</th>
                                    <th>Email</th>
                                    <asp:PlaceHolder ID="PlaceHolderActiveHeader" runat="server">
                                        <th>Super</th>
                                        <th>Insert</th>
                                        <th>Update</th>
                                        <th>Active</th>
                                    </asp:PlaceHolder>
                                    <asp:PlaceHolder ID="PlaceHolderDeleteHeader" runat="server"><th>Delete</th></asp:PlaceHolder>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptAdmin" runat="server" OnItemCommand="rptAdmin_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <center><div class="checker" id="uniform-undefined"><span><asp:CheckBox ID="CheckBox2" runat="server" class="styled" style="opacity: 0;" ></asp:CheckBox></span></div></center>


                                            </td>
                                            <td>
                                                <asp:Image ID="Image2" class="img-responsive" runat="server" ImageUrl='<%# "~/Admin/Upload/" + Eval("img") %>' Width="100px" Height="100px" Style="margin: 0px;" />
                                            </td>
                                            <td>
                                                <asp:HiddenField ID="hidid" runat="server" Value='<%# Eval("AdminID") %>' />

                                                <asp:LinkButton ID="lnkbtnName" runat="server" CommandName="View" CommandArgument='<%# Eval("AdminID") %>' OnClientClick=""><%# Eval("FirstName") + " " + Eval("LastName")  %></asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:Label ID="UserIDLabel" runat="server" Text='<%# Eval("Email") %>' />
                                            </td>
                                            <asp:PlaceHolder ID="PlaceHolderActive" runat="server">
                                                <td>

                                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("AdminID") %>' />
                                                    <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl='<%# "img/" + Eval("IsSuper") + ".png" %>' Style="width: 25px;" CommandName="Super" CommandArgument='<%# Eval("AdminID") %>' />
                                                </td>
                                                <td>

                                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# "img/" + Eval("IsInsert") + ".png" %>' Style="width: 25px;" CommandName="Insert" CommandArgument='<%# Eval("AdminID") %>' />
                                                </td>
                                                <td>

                                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl='<%# "img/" + Eval("IsUpdate") + ".png" %>' Style="width: 25px;" CommandName="Update" CommandArgument='<%# Eval("AdminID") %>' />
                                                </td>

                                                <td>
                                                    <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl='<%# "img/AdminActive/" + Eval("IsActive") + ".png" %>' Style="width: 25px;" CommandName="Active" CommandArgument='<%# Eval("AdminID") %>' /></td>
                                            </asp:PlaceHolder>
                                            <asp:PlaceHolder ID="PlaceHolderDelete" runat="server">
                                                <td>
                                                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl='<%# "img/" + Eval("IsDelete") + ".png" %>' Style="width: 25px;" CommandName="Delete" CommandArgument='<%# Eval("AdminID") %>' /></td>
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
    </asp:Panel>
    <asp:Literal ID="Literal1" runat="server" Visible="false"><h1>You are Sub Admin. You Can't see Admin Records.</h1></asp:Literal>


</asp:Content>

