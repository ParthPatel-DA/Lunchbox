<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="OrderDetail.aspx.cs" Inherits="OrderDetail" ValidateRequest="false" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="http://netdna.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css"/>
<style>
    * {
        margin-left: 10px;
        padding-left: 10px;
        font-family: roboto;
    }


    div.stars {
        width: 270px;
        display: inline-block;
    }

    input.star {
        display: none;
    }

    label.star {
        float: right;
        padding: 5px;
        font-size: 30px;
        color: #444;
        transition: all .2s;
    }

    input.star:checked ~ label.star:before {
        content: '\f005';
        color: #FD4;
        transition: all .25s;
    }

    input.star-5:checked ~ label.star:before {
        color: #FE7;
        text-shadow: 0 0 20px #952;
    }

    input.star-1:checked ~ label.star:before {
        color: #F62;
    }

    label.star:hover {
        transform: rotate(-15deg) scale(1.3);
    }

    label.star:before {
        content: '\f006';
        font-family: FontAwesome;
    }
</style>
<script src="//ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js" type="text/javascript"></script>
<script type="text/javascript">
    jQuery(document).ready(function () {
        var v = $("#<%=txtRate.ClientID %>").val();
        //alert(v);
        $("input[name=star][value=" + v + "]").attr('checked', 'checked');

        $('input:radio[name="star"]').change(function () {
            //alert($("input[type=radio]:checked").val());
            $("#<%=txtRate.ClientID %>").val($("input[type=radio]:checked").val());
        });
    });


</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="~/code.jquery.com/ui/1.10.4/themes/ui-lightness/jquery-ui.css" rel="stylesheet">
    <script src="~/code.jquery.com/jquery-1.10.2.js"></script>
    <script src="~/code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
    <!--<script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>-->

    <style>
        .checkout .panel-body {
            background: white;
        }

        .panel-title .step {
            background-color: #595858;
        }

        .panel-default .panel-title > a {
            color: #FFFFFF;
        }

        .panel-default > .panel-heading {
            color: #FFF;
            background-color: #A0A0A0;
            border-color: #FFF;
        }
    </style>


    <main id="main-content" role="main">



        <div class="container">
            <div class="row">

                <div class="m-t-b clearfix">

<%--                    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>--%>


                    <section class="col-xs-12 col-sm-12 col-md-12">
                        <div class="panel-group" id="accordion" role="tablist">
                            <div class="panel panel-default">
                                <div class="panel-heading" id="panel-heading1">
                                    <h4 class="panel-title">
                                        <a class="panel-title1" data-parent="#accordion" data-toggle="collapse" data-target="#collapseOne" style="cursor: pointer">
                                            <span class="step">01</span>
                                            <asp:Label runat="server" Text="Checkout Infomation"></asp:Label>
                                        </a>
                                    </h4>
                                </div>
                                <div id="collapseOne" class="panel-collapse collapse in">
                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="col-md-12" style="margin-top: 10px; margin-bottom: 10px;">

                                                <div class="col-md-12">
                                                    <h4 style="color: #808080; margin-left: 5px; margin-bottom: 5px;">Meal Information</h4>
                                                    <%--<hr style="border: 1PX solid #A0A0A0; margin: 0px; margin-bottom: 20px;" />--%>
                                                    <div class="col-md-12" style="border: 2px solid #A0A0A0; padding: 0px; margin-bottom: 5px;">
                                                        <div style="border: 1px solid #A0A0A0; width: 140px;"></div>
                                                    </div>
                                                    <asp:Repeater ID="rptchekoutinfo" runat="server" OnItemCommand="chekoutinfo_ItemCommand">
                                                        <ItemTemplate>
                                                            <div class="col-md-4" style="padding: 10px;">
                                                                <div class="col-md-12" style="border: 2px solid #A0A0A0; padding: 10px;">
                                                                    <div class="col-md-5" style="border: 1px solid; padding: 0px;">
                                                                        <asp:Image ID="Image1" runat="server" Height="90px" Width="100%" ImageUrl='<%# "~/ServiceProvider/Iteam/" + Eval("Image") %>' />
                                                                    </div>
                                                                    <div class="col-md-7">
                                                                        <div class="pull-right" style="font-size: 15px; margin-right: -17px; margin-top: -9px;">
                                                                            <asp:LinkButton ID="lnkDeleteItem" runat="server" CommandName="DeleteItem" CommandArgument='<%# Eval("OrderID") %>'>&times;</asp:LinkButton>
                                                                        </div>
                                                                        <h3 style="padding-top: 3px;"><%# Eval("MealName") %></h3>
                                                                        <h4 style="margin-top: 5px;">Price : ₹
                                                                            <asp:Literal ID="ltrPrice" runat="server" Text='<%# Eval("MealPrice") %>'></asp:Literal></h4>
                                                                        <div class="col-md-12" style="padding: 0px; margin-top: 5px;">
                                                                            <div class="col-md-5" style="padding: 0px;">Quentity : </div>
                                                                            <div class="col-md-3" style="margin-left: -10px; margin-top: 3px;">
                                                                                <asp:LinkButton ID="LinkButton1" runat="server" Style="background-color: transparent; color: #E24425; border: 0px solid;" CommandName="itemInc" CommandArgument='<%# Eval("OrderID") %>'><i class="glyphicon glyphicon-plus"></i></asp:LinkButton>
                                                                            </div>
                                                                            <div class="col-md-2" style="padding: 0px;">
                                                                                <asp:TextBox ID="txtquan" runat="server" Style="padding: 6px;" MaxLength="3" Width="35px" Height="25px" Text='<%# Eval("Qty").ToString() %>'></asp:TextBox>
                                                                            </div>
                                                                            <div class="col-md-2" style="margin-top: 3px; border: 0px solid; padding: 0px; padding-left: 15px;">
                                                                                <asp:LinkButton ID="LinkButton2" runat="server" Style="background-color: transparent; color: #E24425;" CommandName="itemDec" CommandArgument='<%# Eval("OrderID") %>'><i class="glyphicon glyphicon-minus"></i></asp:LinkButton>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:Repeater>

                                                </div>
                                                <div class="col-md-12" style="margin-top: 20px;">
                                                    <h4 style="color: #808080; margin-left: 5px; margin-bottom: 5px;">Menu Item Information</h4>
                                                    <%--<hr style="border: 1PX solid #A0A0A0; margin: 0px; margin-bottom: 20px;" />--%>
                                                    <div class="col-md-12" style="border: 2px solid #A0A0A0; padding: 0px; margin-bottom: 5px;">
                                                        <div style="border: 1px solid #A0A0A0; width: 183px;"></div>
                                                    </div>
                                                    <asp:Repeater ID="rptItem" runat="server" OnItemCommand="rptItem_ItemCommand">
                                                        <ItemTemplate>
                                                            <div class="col-md-4" style="padding: 10px;">
                                                                <div class="col-md-12" style="border: 2px solid #A0A0A0; padding: 10px;">
                                                                    <div class="col-md-5" style="border: 1px solid; padding: 0px;">
                                                                        <asp:Image ID="Image1" runat="server" Width="100%" Height="90px" ImageUrl='<%# "~/ServiceProvider/Iteam/" + Eval("Image") %>' />
                                                                    </div>
                                                                    <div class="col-md-7">
                                                                        <div class="pull-right" style="font-size: 15px; margin-right: -17px; margin-top: -9px;">
                                                                            <asp:LinkButton ID="lnkDeleteItem" runat="server" CommandName="DeleteItem" CommandArgument='<%# Eval("OrderID") %>'>&times;</asp:LinkButton>
                                                                        </div>
                                                                        <h3 style="padding-top: 3px;"><%# Eval("ItemName") %></h3>
                                                                        <h4 style="margin-top: 5px;">Price : ₹
                                                                            <asp:Literal ID="ltrPrice" runat="server" Text='<%# Eval("ItemPrice") %>'></asp:Literal></h4>
                                                                        <div class="col-md-12" style="padding: 0px; margin-top: 5px;">
                                                                            <div class="col-md-5" style="padding: 0px;">Quentity : </div>
                                                                            <div class="col-md-3" style="margin-left: -10px; margin-top: 3px;">
                                                                                <asp:LinkButton ID="LinkButton1" runat="server" Style="background-color: transparent; color: #E24425; border: 0px solid;" CommandName="itemInc" CommandArgument='<%# Eval("OrderID") %>'><i class="glyphicon glyphicon-plus"></i></asp:LinkButton>
                                                                            </div>
                                                                            <div class="col-md-2" style="padding: 0px;">
                                                                                <asp:TextBox ID="txtquan" runat="server" Style="padding: 6px;" MaxLength="3" Width="35px" Height="25px" Text='<%# Eval("Qty").ToString() %>'></asp:TextBox>
                                                                            </div>
                                                                            <div class="col-md-2" style="margin-top: 3px; border: 0px solid; padding: 0px; padding-left: 15px;">
                                                                                <asp:LinkButton ID="LinkButton2" runat="server" Style="background-color: transparent; color: #E24425;" CommandName="itemDec" CommandArgument='<%# Eval("OrderID") %>'><i class="glyphicon glyphicon-minus"></i></asp:LinkButton>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:Repeater>

                                                </div>
                                                <div class="col-md-12" style="margin-top: 20px;">
                                                    <h4 style="color: #808080; margin-left: 5px; margin-bottom: 5px;">Order Information</h4>
                                                    <%--<hr style="border: 1PX solid #A0A0A0; margin: 0px; margin-bottom: 20px;" />--%>
                                                    <div class="col-md-12" style="border: 2px solid #A0A0A0; padding: 0px; margin-bottom: 0px;">
                                                        <div style="border: 1px solid #A0A0A0; width: 148px;"></div>
                                                    </div>
                                                    <div class="col-md-12" style="padding: 10px;">
                                                        <div class="col-md-12" style="border: 0px solid #A0A0A0; padding: 10px;">
                                                            <h4 style="color: #808080; width: 100%; margin-bottom: 10px;">Total Quentity :
                                                                <asp:Literal ID="ltrTotalQty" runat="server"></asp:Literal></h4>
                                                            <h4 style="color: #808080; width: 100%;">Total Amount :
                                                                <asp:Literal ID="ltrTotalAmount" runat="server"></asp:Literal></h4>
                                                            <%--<asp:Button ID="btnCheckOut" class="btn btn-default btn-success" runat="server" Text="Check Out" formnovalidate Style="margin-top: 20px;" OnClick="btnCheckOut_Click" />--%>
                                                            <a class="panel-title2 btn btn-default btn-success" data-parent="#accordion" data-toggle="collapse" data-target="#collapseTwo" style="cursor: pointer; margin-top: 20px;">Check Out</a>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="panel panel-default">
                                <div class="panel-heading" id="panel-heading2">
                                    <h4 class="panel-title">
                                        <a class="panel-title2" data-parent="#accordion" data-toggle="collapse" data-target="#collapseTwo" style="cursor: pointer">
                                            <span class="step">02</span>
                                            <asp:Label runat="server" Text="Account & Billing Information"></asp:Label>
                                        </a>
                                    </h4>
                                </div>
                                <div id="collapseTwo" class="panel-collapse collapse">

                                    <div class="panel-body">

                                        <h3 class="error" style="color: red"></h3>
                                        <!--<form class="form-horizontal" role="form" action="http://takeurpick.com/login/new_signup_checkout" method="post">-->
                                        <%--         <form id="myform1" name="myform1" class="form-horizontal">--%>
                                        <form method="post">
                                            <div class="form-horizontal">
                                                <div class="row" id="showform">
                                                    <asp:UpdatePanel ID="updpanel1" runat="server">
                                                        <ContentTemplate>
                                                            <div class="col-xs-12 col-sm-12 col-md-6">
                                                                <asp:Label runat="server" Text="Personal Details"></asp:Label>
                                                                <div class="form-group stylish-input">
                                                                    <%--<label for="inputFirstname" class="col-sm-4 col-lg-4 control-label required">First Name</label>--%>
                                                                    <asp:Label runat="server" Text="First Name" class="col-sm-4 col-lg-4 control-label"></asp:Label>
                                                                    <div class="col-sm-8 col-lg-8">
                                                                        <%-- <input type="text" class="form-control" name="firstname" required />--%>
                                                                        <asp:TextBox ID="txtfnm" runat="server" required="" pattern="[A-Za-z]*" oninvalid="setCustomValidity('enter The First Name in Character Formet  ')" oninput="setCustomValidity('')" class="form-control" name="firstname"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group stylish-input">
                                                                    <%--	<label for="inputLastname" class="col-sm-4 col-lg-4 control-label required">Last Name</label>--%>
                                                                    <asp:Label runat="server" Text="Last Name" class="col-sm-4 col-lg-4 control-label"></asp:Label>
                                                                    <div class="col-sm-8 col-lg-8">
                                                                        <%--<input type="text" class="form-control" name="lastname"  />--%>
                                                                        <asp:TextBox ID="txtlnm" runat="server" required="" pattern="[A-Za-z]*" oninvalid="setCustomValidity('enter The last Name in Character Formet ')" oninput="setCustomValidity('')" class="form-control" name="lastname"></asp:TextBox>
                                                                    </div>
                                                                </div>


                                                                <div class="form-group stylish-input">
                                                                    <%--	<label for="inputPhone" class="col-sm-4 col-lg-4 control-label required">Phone No.</label>--%>
                                                                    <asp:Label runat="server" Text="ContactNo" class="col-sm-4 col-lg-4 control-label  "></asp:Label>
                                                                    <div class="col-sm-8 col-lg-8">
                                                                        <%-- <input type="text" class="form-control" name="contact" id="contact1" placeholder="0123456789" onblur="myFunctioncall()"  />--%>
                                                                        <asp:TextBox ID="txtcontact" runat="server" required="" class="form-control" name="ContactNo" pattern="^(7|8|9)[0-9]{9}$" oninvalid="setCustomValidity(' enter only 10 Digits')" oninput="setCustomValidity('')"></asp:TextBox>
                                                                        <span style="display: none; color: red" id="mobileinvalid">Not a valid Mobile number </span>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group stylish-input">
                                                                    <%--	<label for="inputPhone" class="col-sm-4 col-lg-4 control-label required">Phone No.</label>--%>
                                                                    <asp:Label runat="server" Text="Email" class="col-sm-4 col-lg-4 control-label  "></asp:Label>
                                                                    <div class="col-sm-8 col-lg-8">
                                                                        <%-- <input type="text" class="form-control" name="contact" id="contact1" placeholder="0123456789" onblur="myFunctioncall()"  />--%>
                                                                        <asp:TextBox ID="txtemail" runat="server" required="" class="form-control" name="Email" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$" oninvalid="setCustomValidity(' enter proper emailid)" oninput="setCustomValidity('')"></asp:TextBox>

                                                                    </div>
                                                                </div>

                                                                <!--<div class="form-group stylish-input">
															<label for="inputFax" class="col-sm-4 col-lg-4 control-label">Fax</label>
															<div class="col-sm-8 col-lg-8">
																<input type="text" class="form-control" id="inputFax" />
															</div>
														</div>-->

                                                            </div>
                                                            <div class="col-xs-12 col-sm-12 col-md-6">
                                                                <%--<label>Your Address</label>--%>
                                                                <asp:Label runat="server" Text="Your Address"></asp:Label>

                                                                <div class="form-group stylish-input">
                                                                    <%--<label for="inputAddress1" class="col-sm-4 col-lg-4 control-label required">Address 1</label>--%>
                                                                    <asp:Label runat="server" Text="ShippingAddress" class="col-sm-4 col-lg-4 control-label "></asp:Label>
                                                                    <div class="col-sm-8 col-lg-8">
                                                                        <%-- <textarea class="form-control" name="address1" required></textarea>--%>
                                                                        <asp:TextBox ID="txtShippingAddress" class="form-control" runat="server" Style="margin-bottom: 10px;"></asp:TextBox>
                                                                        <asp:TextBox ID="txtShippingAddressLandmark" class="form-control" runat="server"></asp:TextBox>
                                                                        <%--<asp:Label ID="ltrshiadd" class="form-control" runat="server" Visible="false"></asp:Label>--%>
                                                                        <%--<asp:LinkButton ID="lnkChangeShippingAddress" runat="server" Visible="false" Style="color: #2949ff;" OnClick="lnkChangeShippingAddress_Click">Change Shipping Address</asp:LinkButton>--%>
                                                                        <%--<asp:TextBox ID="txtshiadd" runat="server" required="required" pattern="[A-Za-z0-9]*" oninvalid="setCustomValidity('Enter the address in proper formet')" oninput="setCustomValidity('')" class="form-control" name="address" TextMode="MultiLine"></asp:TextBox>--%>
                                                                        <%--<asp:HiddenField ID="hdnAddress" runat="server" />--%>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group stylish-input">
                                                                    <%--<label for="inputAddress2" class="col-sm-4 col-lg-4 control-label">Address 2</label>--%>
                                                                    <asp:Label runat="server" Text="BillingAddress" class="col-sm-4 col-lg-4 control-label"></asp:Label>
                                                                    <div class="col-sm-8 col-lg-8">
                                                                        <%-- <textarea class="form-control" name="address2"></textarea>--%>
                                                                        <%--<asp:TextBox ID="txtbiladd" runat="server" required="required" pattern="[A-Za-z0-9]*" oninvalid="setCustomValidity('Enter the area in proper format')" oninput="setCustomValidity('')" class="form-control" TextMode="MultiLine" name="Area"></asp:TextBox>--%>
                                                                        <asp:TextBox ID="txtBillingAddress" class="form-control" runat="server" Style="margin-bottom: 10px;"></asp:TextBox>
                                                                        <asp:TextBox ID="txtBillingAddressLandmark" class="form-control" runat="server"></asp:TextBox>
                                                                        <%--<asp:Label ID="ltrbiladd" class="form-control" runat="server" Visible="false"></asp:Label>--%>
                                                                        <%--<asp:LinkButton ID="lnkChangeBillingAddress" runat="server" Style="color: #2949ff;" Visible="false" OnClick="lnkChangeBillingAddress_Click">Change Billing Address</asp:LinkButton>--%>
                                                                    </div>
                                                                </div>


                                                                



                                                                <div class="form-group stylish-input">

                                                                    <span>
                                                                        <asp:Label ID="lblselectedtext" runat="server" class="col-sm-4 col-lg-4 control-label " Text="Country"></asp:Label>

                                                                    </span>
                                                                    <div class="col-sm-8 col-lg-8">
                                                                        <asp:DropDownList ID="ddlcountry" runat="server" class="form-control" required="true" AutoPostBack="true" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group stylish-input">
                                                                    <span>
                                                                        <asp:Label ID="lblselectedtext1" runat="server" class="col-sm-4 col-lg-4 control-label " Text="Region/State"></asp:Label>
                                                                    </span>
                                                                    <div class="col-sm-8 col-lg-8">
                                                                        <asp:DropDownList runat="server" ID="ddlstate" class="form-control" required="true" AutoPostBack="true" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group stylish-input">
                                                                    <span>
                                                                        <asp:Label ID="lblselectedtext2" runat="server" class="col-sm-4 col-lg-4 control-label " Text="City"></asp:Label>
                                                                    </span>
                                                                    <div class="col-sm-8 col-lg-8">
                                                                        <asp:DropDownList runat="server" ID="ddlcity" required="true" class="form-control">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group stylish-input">
                                                                    <span>
                                                                        <asp:Label ID="Label4" runat="server" class="col-sm-4 col-lg-4 control-label " Text="Zip Code"></asp:Label>
                                                                    </span>
                                                                    <div class="col-sm-8 col-lg-8">
                                                                        <asp:TextBox ID="txtZipCode" class="form-control" runat="server"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </div>
                                                <div class="space20 clearfix"></div>

                                                <%--   <button type="submit" class="btn btn-primary" id="test2">Continue</button>--%>
                                                <%--<a class="panel-title2 btn btn-default btn-success" data-parent="#accordion" data-toggle="collapse" data-target="#collapseThree" style="cursor: pointer; margin-top: 20px; margin-left: 20px;">Submit</a>--%>
                                                <asp:Button ID="btnSubmitAddress" class="panel-title2 btn btn-default btn-success" runat="server" Text="Update Infomation" OnClick="btnSubmitAddress_Click" style="margin-left: 20px;" />
                                                <%--<asp:Button ID="btncontinue" runat="server" Text="Continue" class="btn btn-primary" OnClick="btncontinue_Click"></asp:Button>--%>
                                            </div>
                                        </form>
                                        <%-- </form>--%>
                                        <br>

                                        <!--<button class="error1 btn btn-primary" style="display:none" id="test2" > Continue</button>-->



                                    </div>
                                </div>
                            </div>

                            

                            <div class="panel panel-default">
                                <div class="panel-heading" id="panel-heading4">
                                    <h4 class="panel-title"><a class="panel-title4" data-toggle="collapse" data-target="#collapseFour" style="cursor: pointer">
                                        <span class="step">03</span>
                                        <asp:Label runat="server" Text="Confirm Order"></asp:Label>
                                    </a>
                                    </h4>
                                </div>

                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div id="collapseFour" class="panel-collapse collapse">
                                            <div class="panel-body">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <div class="col-md-12">
                                                            <asp:CheckBox ID="chkisrecurring" runat="server" OnCheckedChanged="chkisrecurring_CheckedChanged" Checked="false" name="food_type[]" value="1" Style="margin-right: 5px;" AutoPostBack="True" Text="&nbsp;&nbsp;&nbsp;IsRecurring"></asp:CheckBox>
                                                        </div>
                                                        <asp:Panel ID="panelPlanSelection" runat="server" Visible="false">
                                                            <div class="col-md-12">
                                                                <div class="col-md-6" style="padding: 0px;">
                                                                    <asp:RadioButton ID="rdPlan" GroupName="selectPlan" runat="server" AutoPostBack="true" Text="&nbsp;&nbsp;&nbsp;Select As Plan" OnCheckedChanged="rdPlan_CheckedChanged" /></div>
                                                                <div class="col-md-6">
                                                                    <asp:RadioButton ID="rdCustom" GroupName="selectPlan" runat="server" AutoPostBack="true" Text="&nbsp;&nbsp;&nbsp;Custom Duretion" OnCheckedChanged="rdCustom_CheckedChanged" /></div>
                                                            </div>
                                                        </asp:Panel>
                                                        <asp:Panel ID="panelCustom" runat="server" Visible="false">
                                                            <%--<div class="col-md-12" style="margin-top: 20px;">
                                                                <div class="col-md-5" style="padding: 0px;"><asp:Label runat="server" ID="lblselected" Text="Recurring Type"></asp:Label></div>
                                                                <div class="col-md-7" style="padding: 0px;"><asp:DropDownList ID="ddlrecurringtype" runat="server" Style="width: 180px;">
                                                                    <asp:ListItem Text="1 week" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="15 days" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="1 month" Value="0"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                    </div>
                                                            </div>--%>
                                                            <div class="col-md-12">
                                                                <div class="col-md-5" style="padding: 0px;"><span style="padding-right: 33px;"><b>Start Date:</b></span></div>

                                                                <div class="col-md-7" style="padding: 0px;"><asp:TextBox ID="txtstartdate" type="date" AutoPostBack="true" runat="server" Style="width: 180px;" OnTextChanged="txtstartdate_TextChanged"></asp:TextBox></div>
                                                            </div>
                                                            <div class="col-md-12">
                                                                <div class="col-md-5" style="padding: 0px;"><span style="padding-right: 40px;"><b>End Date:</b></span></div>

                                                                <div class="col-md-7" style="padding: 0px;"><asp:TextBox ID="txtenddate" type="date" runat="server" Style="width: 180px;"></asp:TextBox></div>
                                                            </div>
                                                            <div class="col-md-12">
                                                                <asp:Label ID="errorPlan1" runat="server" Text="" style="color: #c72404;" Visible="false"></asp:Label>
                                                            </div>
                                                        </asp:Panel>
                                                        <asp:Panel ID="panelPlan" runat="server" Visible="false">
                                                            <div class="col-md-12" style="margin-top: 20px;">
                                                                <div class="col-md-5" style="padding: 0px;"><asp:Label runat="server" ID="Label5" Text="Recurring Type"></asp:Label></div>
                                                                <%-- <span style="padding-right: 6px;"><b>Recurring Type</b></span>--%>
                                                                <div class="col-md-7" style="padding: 0px;"><asp:DropDownList ID="DropDownList1" runat="server" Style="width: 180px;" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
                                                                    <asp:ListItem Text="Select Days" Value=""></asp:ListItem>
                                                                    <asp:ListItem Text="1 week" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="15 days" Value="2"></asp:ListItem>
                                                                    <asp:ListItem Text="1 month" Value="3"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                    </div>
                                                            </div>
                                                            <div class="col-md-12">
                                                                <div class="col-md-5" style="padding: 0px;"><span style="padding-right: 33px;"><b>Start Date:</b></span></div>

                                                                <div class="col-md-7" style="padding: 0px;"><asp:TextBox ID="TextBox1" type="date" runat="server" Style="width: 180px;" AutoPostBack="true" OnTextChanged="TextBox1_TextChanged"></asp:TextBox></div>
                                                            </div
                                                            
                                                            <div class="col-md-12" style="margin-top: 10px;">
                                                                <div class="col-md-5""><span style="padding-right: 40px;"><b>End Date:</b></span></div

                                                                
                                                                <div class="col-md-7"><asp:Label ID="Label6" runat="server" Width="180px" style="margin-left:10px;"></asp:Label></div>
                                                            </div>
                                                            <div class="col-md-12">
                                                                <asp:Label ID="errorPlan" runat="server" Text="" style="color: #c72404;" Visible="false"></asp:Label>
                                                            </div>
                                                        </asp:Panel>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <center><h4><b>Order Details</b></h4></center>
                                                        <hr>
                                                        <asp:Repeater ID="repcart" runat="server">
                                                            <HeaderTemplate>
                                                                <table class="table">
                                                                    <thead>
                                                                        <tr>

                                                                            <td><b></b></td>

                                                                            <td><b>Name</b></td>

                                                                            <td><b>Unit Price</b></td>

                                                                            <td><b>Qty</b></td>

                                                                            <%--<td><b>Amount</b></td>--%>
                                                                        </tr>

                                                                    </thead>
                                                                    <tbody style="background: white;">
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                

                                                                    <tr style="height: -15px;">
                                                                        <td style="text-align: center;">
                                                                            <asp:HiddenField ID="hdnOrder" runat="server" Value='<%# Eval("OrderID") %>' />
                                                                            <asp:Image ID="Image2" class="img-responsive" runat="server" ImageUrl='<%# "~/ServiceProvider/Iteam/" + Eval("Image") %>' Width="80px" Height="80px" Style="margin: 10px 30px 40px 40px;" />
                                                                        </td>

                                                                        <td>
                                                                            <asp:Label ID="lblproduct" runat="server" Text='<%# Eval("CN") %>'></asp:Label>

                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("CNN") %>'></asp:Label>
                                                                        </td>

                                                                        <%--<td >
                                      <asp:Label ID="Label1" runat="server" Text='<%# Eval("CNNN") %>'></asp:Label>
                                 </td> 
                                                                        --%>

                                                                        <td>



                                                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Qty") %>'></asp:Label>
                                                                        </td>


                                                                    </tr>

                                                                
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                        <asp:Repeater ID="repca" runat="server">
                                                            <ItemTemplate>

                                                                    <tr style="height: -15px;">
                                                                        <td style="text-align: center;">
                                                                            <asp:HiddenField ID="hdnOrder" runat="server" Value='<%# Eval("OrderID") %>' />
                                                                            <asp:Image ID="Image2" class="img-responsive" runat="server" ImageUrl='<%# "~/ServiceProvider/Meal/" + Eval("Image") %>' Width="80px" Height="80px" Style="margin: 10px 30px 40px 40px;" />
                                                                        </td>

                                                                        <td>

                                                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("mealnm") %>'></asp:Label>
                                                                        </td>
                                                                        <td>

                                                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("mealpri") %>'></asp:Label>
                                                                        </td>
                                                                        <td>



                                                                            <asp:Label ID="lblquntity" runat="server" Text='<%# Eval("Qty") %>'></asp:Label>
                                                                        </td>


                                                                    </tr>
                                                                

                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                
                                                            </FooterTemplate>
                                                        </asp:Repeater>
                                                        <tr>
                                                            <td colspan="2">Total Amount</td>
                                                            <td>
                                                                <asp:Literal ID="ltrTotalAmountO" runat="server"></asp:Literal></td>
                                                            <td>
                                                                <asp:Literal ID="ltrTotalQtyO" runat="server"></asp:Literal></td>
                                                        </tr>
                                                        </tbody>
                                                                </table>
                                                        
                                                                <asp:Button ID="btnplace" runat="server" Text="Place Order" class="btn btn-primary btn-round uppercase pull-left" formnovalidate OnClick="btnplace_Click"></asp:Button>
                                                            
                                                        
                                                    </div>
                                                    

                                                    
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                            <div class="panel panel-default">
                                <div class="panel-heading" id="panel-heading3">
                                    <h4 class="panel-title">
                                        <a class="panel-title3" data-toggle="collapse" data-target="#collapseFive" style="cursor: pointer">
                                            <span class="step">04</span>
                                            <asp:Label runat="server" Text=" Ratting"></asp:Label>
                                        </a>
                                    </h4>
                                </div>
                                <div id="collapseFive" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="col-xs-12 col-sm-12 col-md-12">
                                                <div class="cont" >
                                    <div class="stars" style="margin-left: -80px;">
                                      <input class="star star-5" id="star-5" type="radio" name="star" value="5" />
                                      <label class="star star-5" for="star-5"></label>
                                      <input class="star star-5" id="star-4" type="radio" name="star" value="4" />
                                      <label class="star star-4" for="star-4"></label>
                                      <input class="star star-5" id="star-3" type="radio" name="star" value="3" />
                                      <label class="star star-3" for="star-3"></label>
                                      <input class="star star-5" id="star-2" type="radio" name="star" value="2" />
                                      <label class="star star-2" for="star-2"></label>
                                      <input class="star star-5" id="star-1" type="radio" name="star" value="1" />
                                      <label class="star star-1" for="star-1"></label>
                                      <input type="hidden" id="txtRate" runat ="server"/>
                                    </div>
                                </div>
                                                <div class="space20 clearfix"></div>
                                                

                                            </div>

                                            <br>
                                            <br>
                                            <div style="margin-left: 17px">
                                                <%--   <button class="btn btn-primary btn-round uppercase" id="check2">Continue</button>--%>
                                                <asp:Button runat="server" Text="Rate" formnovalidate class="btn btn-primary btn-round uppercase" ID="Button1" OnClick="Button1_Click"></asp:Button>
                                            </div>


                                        </div>

                                    </div>
                                </div>
                            </div>

                            <div class="panel panel-default">
                                <div class="panel-heading" id="panel-heading3">
                                    <h4 class="panel-title">
                                        <a class="panel-title3" data-toggle="collapse" data-target="#collapseThree" style="cursor: pointer">
                                            <span class="step">05</span>
                                            <asp:Label runat="server" Text=" Payment Method "></asp:Label>
                                        </a>
                                    </h4>
                                </div>
                                <div id="collapseThree" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="col-xs-12 col-sm-12 col-md-12">

                                                <div class="form-group stylish-input">
                                                    <label style="font-size: 20px;">
                                                        <%-- <input type="radio" id="deliverymethod1" class="prettyCheckable" name="deliverymethod" data-label="" checked />Cash On Delivery--%>
                                                        <asp:RadioButton runat="server" ID="deliverymethod1" class="prettyCheckable" name="deliverymethod" data-label=""></asp:RadioButton>
                                                        <asp:Label runat="server" Text="Cash On Delivery"></asp:Label>
                                                    </label>
                                                    <p>Please select the preferred payment method to use on this order.</p>
                                                </div>
                                                <!--<div class="form-group stylish-input">
												<label>Add Comments About Your Order </label>
												 <textarea   class="form-control"  name="comment" style="border: 1px solid #EEE;
													outline-color: #FF5B36;
													width: 30%;
													height: 100%;
													font-size: 1em;
													padding: 0.5em;"></textarea>
												</div>-->
                                                <div class="space20 clearfix"></div>
                                                <label style="margin-bottom: 25px;">
                                                    <input type="checkbox" id="check1" />
                                                    I have read and agree to the <a href="#" target="_blank" style="color: red">Terms & Conditions</a>
                                                </label>

                                            </div>

                                            <br>
                                            <br>
                                            <div style="margin-left: 17px">
                                                <%--   <button class="btn btn-primary btn-round uppercase" id="check2">Continue</button>--%>
                                                <asp:Button runat="server" Text="Continue" formnovalidate class="btn btn-primary btn-round uppercase" ID="check2" OnClick="check2_Click"></asp:Button>
                                            </div>


                                        </div>

                                    </div>
                                </div>
                            </div>

                        </div>
                    </section>
                </div>
            </div>
            
        </div>
    </main>
    <script type="text/javascript">
        function callThree() {
            //$('collapseTwo').removeClass('panel-collapse collapse').addClass('panel-collapse collapse in');
            //$('collapseOne').removeClass('panel-collapse collapse in').addClass('panel-collapse collapse');
            //$("collapseTwo").addClass("panel-collapse collapse in");
            //$("collapseOne").addClass("panel-collapse collapse");
        }
    </script>

</asp:Content>

