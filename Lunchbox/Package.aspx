<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Package.aspx.cs" Inherits="Package" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="col-md-12 col-xs-12" style="padding: 0px; background-color: #fff; margin-bottom: 50px;">
        <div class="col-md-12" style="border: 0px solid #eaeaea; padding-top: 50px; margin-top: 50px; padding-bottom: 120px; border-width: 0px 0px 0px 0px;">
            <div class="container-fluid">
                <div>
                    <div class="col-md-12" style="border: 0px solid; margin-bottom: 50px; width: 100%; padding: 0px;">
                        <asp:Repeater ID="rptpack" runat="server" OnItemCommand="rptpack_ItemCommand">
                            <ItemTemplate>
                                <%-- <div class="col-md-6" style="padding:20px; border: 0px solid;">--%>
                                <div class="col-md-6" style="padding: 20px; padding-bottom: 0px; border: 0px solid;">
                                    <div class="col-md-12" style="border: 0px solid; padding: 0px; border-radius: 10px 10px 10px 10px">
                                        <%-- <div class="col-md-12" style="border: 0px solid; padding: 0px; box-shadow: 10px 0px 10px #000000; border-radius: 10px;">--%>
                                        <div style="margin-bottom: 30px;">
                                            <div style="background: #ca1a1a; border-radius: 10px 10px 0px 0px;">
                                                <div class="container-fluid">
                                                    <div class="col-md-8" style="padding: 10px;">
                                                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("Name") %>' Style="color: #fff; font-weight: bolder; font-size: 20px;"></asp:Label></th>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12" style="background-color: #e2e2e2; height: 250px;">
                                                <div class="col-md-4" style="margin: 40px 0px 40px 0px; height: 250px; width: 250px;">
                                                    <asp:Image ID="Image8" runat="server" ImageUrl='<%# "~/Admin/Packimg/" + Eval("img") %>' Width="180px" Height="180px" />
                                                </div>
                                                <div class="col-md-6" style="margin: 40px 0px 40px 0px; text-align: justify; text-justify: inter-word; font-size: 15px; margin-top: 50px;">
                                                    <div class="col-md-12">
                                                        <asp:Literal ID="Literal4" runat="server" Text='<%# Eval("Description") %>'></asp:Literal>
                                                    </div>
                                                </div>
                                                <div class="col-md-6" style="margin: 60px 0px 40px 0px; font-size: 18px; font-weight: bolder;">
                                                    <div class="col-md-4">
                                                        Price:<asp:Label runat="server" Text='<%# Eval("Price") %> '></asp:Label>
                                                    </div>
                                                    <div class="col-md-3"></div>
                                                    <div class="col-md-4">
                                                        Duration:<asp:Label runat="server" Text='<%# Eval("Duration") %>'></asp:Label><br />
                                                    </div>
                                                    <%--<div class="col-md-7">
                                                        <asp:Label ID="Label11" runat="server" Text="₹ 300"></asp:Label><br />
                                                        <asp:Label ID="Label12" runat="server" Text="Free"></asp:Label><br />
                                                        <asp:Label ID="Label10" runat="server" Text=""></asp:Label><br />
                                                        <asp:DropDownList ID="DropDownList1" runat="server" style="font-size: 10px;">
                                                            <asp:ListItem Value="1">1</asp:ListItem>
                                                            <asp:ListItem Value="2">2</asp:ListItem>
                                                            <asp:ListItem Value="3">3</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>--%>
                                                </div>
                                            </div>

                                            <div style="background: #ca1a1a; height: -1px; border-radius: 0px 0px 10px 10px;">
                                                <div class="container-fluid">

                                                    <asp:Button ID="Button5" runat="server" Text="Buy" Style="float: right; background: #5BBD50; border: 0px solid; border-radius: 5px; padding: 5px 25px 5px 25px; font-size: 17px; font-weight: bolder; color: #fff; margin: 15px 0px 15px 0px;" CommandName="Buy" CommandArgument='<%# Eval("PackagesID") %>' />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>

                        </asp:Repeater>


                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>

