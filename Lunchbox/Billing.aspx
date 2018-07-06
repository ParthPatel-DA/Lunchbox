<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Billing.aspx.cs" Inherits="Billing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                <div class="col-xs-12 col-md-3 col-lg-3 pull-left">
                    <div class="panel panel-default height">
                        <div class="panel-heading">
                            <asp:label runat="server" text=" Billing Details"></asp:label>

                        </div>
                        <div class="panel-body">
                            <strong>
                                <asp:label runat="server" text="David Peere:"></asp:label>
                                </strong><br>
                            1111 Army Navy Drive<br>
                            Arlington<br>
                            VA<br>
                            <strong>22 203</strong><br>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12 col-md-3 col-lg-3">
                    <div class="panel panel-default height">
                        <div class="panel-heading">
                             <asp:label runat="server" text=" Payment Information"></asp:label></div>
                        <div class="panel-body">
                            <strong>
                                 <asp:label runat="server" text=" Card Name:"></asp:label></strong> Visa<br>
                            <strong>
                                 <asp:label runat="server" text="Card Number:"></asp:label></strong> ***** 332<br>
                            <strong>
                                 <asp:label runat="server" text="Exp Date:"></asp:label></strong> 09/2020<br>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12 col-md-3 col-lg-3">
                    <div class="panel panel-default height">
                        <div class="panel-heading">
                            <asp:Label ID="Label1" runat="server" Text="Order Preferences"></asp:Label></div>
                        <div class="panel-body">
                            <strong>
                               <asp:Label runat="server" Text="Gift:"></asp:Label> </strong> No<br>
                            <strong>
                                <asp:Label runat="server" Text="Express Delivery:"></asp:Label></strong> Yes<br>
                            <strong>
                                <asp:Label runat="server" Text="Insurance:"></asp:Label></strong> No<br>
                            <strong>
                                <asp:Label runat="server" Text="Coupon:"></asp:Label></strong> No<br>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12 col-md-3 col-lg-3 pull-right">
                    <div class="panel panel-default height">
                        <div class="panel-heading">
                            <asp:Label ID="Label3" runat="server" Text="Shipping Address"></asp:Label></div>
                        <div class="panel-body">
                            <strong>
                                <asp:Label ID="Label2" runat="server" Text="David Peere:"></asp:Label> </strong><br>
                            1111 Army Navy Drive<br>
                            Arlington<br>
                            VA<br>
                            <strong>22 203</strong><br>
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
                                <%--<tr>
                                <td>Item Name</td>
                                <th>Item Price</th>
                                <th>Item Quantity</th>
                                <th>Total</th>
                                </tr> --%>
                                 <td><strong>
                                     <asp:Label ID="Label5" runat="server" Text="Item Name"></asp:Label></strong></td>
                                    <td class="text-center"><strong>Item Price</strong></td>
                                    <td class="text-center"><strong>Item Quantity</strong></td>
                                    <td class="text-right"><strong>Total</strong></td>
                                </thead> 
                           </table> 
                          <%--  </HeaderTemplate>
                        </asp:Repeater--%>>
                        
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

