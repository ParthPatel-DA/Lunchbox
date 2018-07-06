<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Success.aspx.cs" Inherits="Success" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .height {
            min-height: 200px;
        }

        .icon {
            font-size: 47px;
            color: #5CB85C;
        }

        .iconbig {
            font-size: 77px;
            color: #5CB85C;
        }

        .table > tbody > tr > .emptyrow {
            border-top: none;
        }

        .table > thead > tr > .emptyrow {
            border-bottom: none;
        }

        .table > tbody > tr > .highrow {
            border-top: 3px solid;
            /*http: //localhost:63464/assets/images/;*/
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="col-md-12 text-center" style="margin-top: 100px; margin-bottom: 100px;">
            <div class="col-md-12">
                <asp:Label ID="lblSuccess" runat="server" Text="Your Order is Successful. Please Give Feedback." Style="color: #029d16; font-size: 35px;" Visible="false"></asp:Label>
            </div>
            <div class="col-md-12">
                <asp:Label ID="lblSuccess2" runat="server" Text="Label" Style="color: #808080; font-size: 16px;" Visible="false"></asp:Label>
            </div>
            <div class="col-md-12">
                <asp:Label ID="lblFail" runat="server" Text="Opps! Something goes wrong. Please try again." Style="color: #aa0d0d; font-size: 35px;" Visible="false"></asp:Label>
            </div>
            <div class="col-md-12">
                <asp:Label ID="lblFail2" runat="server" Text="Label" Style="color: #808080; font-size: 16px;" Visible="false"></asp:Label>
            </div>
        </div>
        <asp:Button ID="lnkPDF" runat="server" Text="Genrate PDF" OnClick="lnkPDF_Click" Style="float: right; margin-right: 90px; padding: 10px 20px 10px 20px; background-color: #5CB85C; color: #fff; font-size: 20px; font-weight: bolder; border: 0px solid;" Visible="false" />
        <asp:Panel ID="PanelClient" runat="server" Visible="false">
            <div class="container">
                <div class="row">
                    <div class="col-xs-12">
                        <div class="text-center">
                            <i class="fa fa-search-plus pull-left icon"></i>
                            <br />

                            <h2>Invoice for purchase</h2>
                        </div>
                        <hr>
                        <div class="row">
                            <div class="col-xs-12 col-md-3 col-lg-3">
                                <div class="panel panel-default height">
                                    <div class="panel-heading">
                                        <asp:Label ID="Label1" runat="server" Text="Client Information"></asp:Label>
                                    </div>
                                    <div class="panel-body">
                                        <strong>
                                            <asp:Label runat="server" Text="Name:"></asp:Label>
                                        </strong>
                                        <asp:Label ID="lblClientName" runat="server" Text=""></asp:Label><br>
                                        <strong>
                                            <asp:Label runat="server" Text="Email:"></asp:Label></strong>
                                        <asp:Label ID="lblClientEmail" runat="server" Text=""></asp:Label><br>
                                        <strong>
                                            <asp:Label runat="server" Text="Contect Number:"></asp:Label></strong>
                                        <asp:Label ID="lblClientContectNo" runat="server" Text=""></asp:Label><br>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-12 col-md-3 col-lg-3">
                                <div class="panel panel-default height">
                                    <div class="panel-heading">
                                        <asp:Label runat="server" Text=" Payment Information"></asp:Label>
                                    </div>
                                    <div class="panel-body">
                                        <strong>
                                            <asp:Label runat="server" Text=" Card Name:"></asp:Label></strong> Visa<br>
                                        <strong>
                                            <asp:Label runat="server" Text="Card Number:"></asp:Label></strong> ***** 346<br>
                                        <strong>
                                            <asp:Label runat="server" Text="Exp Date:"></asp:Label></strong> 05/2017<br>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-12 col-md-3 col-lg-3 pull-left">
                                <div class="panel panel-default height">
                                    <div class="panel-heading">
                                        <asp:Label runat="server" Text=" Billing Details"></asp:Label>

                                    </div>
                                    <div class="panel-body">
                                        <strong>
                                            <asp:Label runat="server" Text="David Peere:"></asp:Label>
                                        </strong>
                                        <br>
                                        <asp:Label ID="lblBillAddress" runat="server" Text="Label"></asp:Label><br>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-12 col-md-3 col-lg-3 pull-right">
                                <div class="panel panel-default height">
                                    <div class="panel-heading">
                                        <asp:Label ID="Label3" runat="server" Text="Shipping Address"></asp:Label>
                                    </div>
                                    <div class="panel-body">
                                        <strong>
                                            <asp:Label ID="Label2" runat="server" Text="David Peere:"></asp:Label>
                                        </strong>
                                        <br>
                                        <asp:Label ID="lblShippingAddress" runat="server" Text="Label"></asp:Label><br>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="text-center"><strong>
                                    <asp:Label ID="Label4" runat="server" Text="Order summary"></asp:Label></strong></h3>
                            </div>
                            <div class="panel-body">
                                <div class="table-responsive">
                                    <%--<asp:Repeater ID="Repeater1" runat="server">
                            <HeaderTemplate >--%>
                                    <table class="table table-condensed">
                                        <thead>
                                            <tr>
                                                <td><strong>
                                                    <asp:Label ID="Label5" runat="server" Text="Item Name"></asp:Label></strong></td>
                                                <td class="text-center"><strong>Item Price</strong></td>
                                                <td><strong>Date of Delivery</strong></td>
                                                <td class="text-center"><strong>Item Quantity</strong></td>

                                                <td class="text-right"><strong>Total</strong></td>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="Repeater1" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:HiddenField ID="hdnOrder" runat="server" Value='<%# Eval("OrderID") %>' />
                                                            <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("CN") %>'></asp:Label></td>
                                                        <td class="text-center">
                                                            <asp:Label ID="lblItemPrice" runat="server" Text='<%# Eval("CNN") %>'></asp:Label></td>
                                                        <td class="text-center">
                                                            <asp:Label ID="lblItemQty" runat="server" Text='<%# Eval("Qty") %>'></asp:Label></td>
                                                        <td class="text-center">
                                                            <asp:Label ID="Label6" runat="server" Text='<%# Convert.ToDateTime(Eval("Date")).ToShortDateString() %>'></asp:Label></td>
                                                        <td class="text-right">
                                                            <asp:Label ID="lblItemAmount" runat="server" Text='<%# Eval("Total") %>'></asp:Label></td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            <asp:Repeater ID="Repeater2" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:HiddenField ID="hdnOrder" runat="server" Value='<%# Eval("OrderID") %>' />
                                                            <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("CN") %>'></asp:Label></td>
                                                        <td class="text-center">
                                                            <asp:Label ID="lblItemPrice" runat="server" Text='<%# Eval("CNN") %>'></asp:Label></td>
                                                        <td class="text-center">
                                                            <asp:Label ID="lblItemQty" runat="server" Text='<%# Eval("Qty") %>'></asp:Label></td>
                                                        <td class="text-center">
                                                            <asp:Label ID="Label6" runat="server" Text='<%# Convert.ToDateTime(Eval("Date")).ToShortDateString() %>'></asp:Label></td>
                                                        <td class="text-right">
                                                            <asp:Label ID="lblItemAmount" runat="server" Text='<%# Eval("Total") %>'></asp:Label></td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>
                                    <%--  </HeaderTemplate>
                        </asp:Repeater>--%>

                                    <%--  <table class="table table-condensed">
                            <thead>
                                <tr>
                                    <td><strong>Item Name</strong></td>
                                    <td class="text-center"><strong>Item Price</strong></td>
                                    <td class="text-center"><strong>Item Quantity</strong></td>
                                    <td class="text-right"><strong>Total</strong></td>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>Samsung Galaxy S5</td>
                                    <td class="text-center">$900</td>
                                    <td class="text-center">1</td>
                                    <td class="text-right">$900</td>
                                </tr>
                                <tr>
                                    <td>Samsung Galaxy S5 Extra Battery</td>
                                    <td class="text-center">$30.00</td>
                                    <td class="text-center">1</td>
                                    <td class="text-right">$30.00</td>
                                </tr>
                                <tr>
                                    <td>Screen protector</td>
                                    <td class="text-center">$7</td>
                                    <td class="text-center">4</td>
                                    <td class="text-right">$28</td>
                                </tr>
                                <tr>
                                    <td class="highrow"></td>
                                    <td class="highrow"></td>
                                    <td class="highrow text-center"><strong>Subtotal</strong></td>
                                    <td class="highrow text-right">$958.00</td>
                                </tr>
                                <tr>
                                    <td class="emptyrow"></td>
                                    <td class="emptyrow"></td>
                                    <td class="emptyrow text-center"><strong>Shipping</strong></td>
                                    <td class="emptyrow text-right">$20</td>
                                </tr>
                                <tr>
                                    <td class="emptyrow"><i class="fa fa-barcode iconbig"></i></td>
                                    <td class="emptyrow"></td>
                                    <td class="emptyrow text-center"><strong>Total</strong></td>
                                    <td class="emptyrow text-right">$978.00</td>
                                </tr>
                            </tbody>
                        </table>--%>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Button ID="lnkSPPDF" runat="server" Text="Genrate PDF" Style="float: right; margin-right: 90px; padding: 10px 20px 10px 20px; background-color: #5CB85C; color: #fff; font-size: 20px; font-weight: bolder; border: 0px solid;" Visible="false" />
        <asp:Panel ID="PanelSP" runat="server" Visible="false">
            <div class="container">
                <div class="row">
                    <div class="col-xs-12 col-md-12">
                        <div class="text-center">
                            <i class="fa fa-search-plus pull-left icon"></i>
                            <br />

                            <h2>Invoice for purchase</h2>
                        </div>
                        <hr>
                        <div class="row">
                            <div class="col-xs-12 col-md-6">
                                <div class="panel panel-default height">
                                    <div class="panel-heading">
                                        <asp:Label ID="Label7" runat="server" Text="Delivery Boy Information"></asp:Label>
                                    </div>
                                    <div class="panel-body">
                                        <strong>
                                            <asp:Label runat="server" Text="Name:"></asp:Label>
                                        </strong>
                                        <asp:Label ID="lblSPName" runat="server" Text=""></asp:Label><br>
                                        <strong>
                                            <asp:Label runat="server" Text="Email:"></asp:Label></strong>
                                        <asp:Label ID="lblSPEmail" runat="server" Text=""></asp:Label><br>
                                        <strong>
                                            <asp:Label runat="server" Text="Contect Number:"></asp:Label></strong>
                                        <asp:Label ID="lblSPContectNumber" runat="server" Text=""></asp:Label><br>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-12 col-md-6">
                                <div class="panel panel-default height">
                                    <div class="panel-heading">
                                        <asp:Label runat="server" Text="Package Information"></asp:Label>
                                    </div>
                                    <div class="panel-body">

                                        <div class="col-md-3"><strong>
                                            <asp:Label runat="server" Text="Package Name:"></asp:Label></div>
                                        </strong><div class="col-md-9">
                                            <asp:Label ID="lblPackageName" runat="server" Text=""></asp:Label>
                                        </div>
                                        <br>

                                        <div class="col-md-3"><strong>
                                            <asp:Label runat="server" Text="Package Price:"></asp:Label></div>
                                        </strong><div class="col-md-9">
                                            <asp:Label ID="lblPackagePrice" runat="server" Text=""></asp:Label>
                                        </div>
                                        <br>
                                    </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </div>
    </asp:Panel>
    </div>



</asp:Content>

