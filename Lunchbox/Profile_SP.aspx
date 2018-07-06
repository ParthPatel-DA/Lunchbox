<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Profile_SP.aspx.cs" Inherits="Profile_SP" ValidateRequest="false" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--<title>LunchBox| Tiffin Service in Surat(Surat Tiffin Service)</title>
    <link rel="apple-touch-icon" sizes="57x57" href="../assets/favicon/apple-icon-57x57.png" />
    <link rel="apple-touch-icon" sizes="60x60" href="../assets/favicon/apple-icon-60x60.png" />
    <link rel="apple-touch-icon" sizes="72x72" href="../assets/favicon/apple-icon-72x72.png" />
    <link rel="apple-touch-icon" sizes="76x76" href="../assets/favicon/apple-icon-76x76.png" />
    <link rel="apple-touch-icon" sizes="114x114" href="../assets/favicon/apple-icon-114x114.png" />
    <link rel="apple-touch-icon" sizes="120x120" href="../assets/favicon/apple-icon-120x120.png" />
    <link rel="apple-touch-icon" sizes="144x144" href="../assets/favicon/apple-icon-144x144.png" />
    <link rel="apple-touch-icon" sizes="152x152" href="../assets/favicon/apple-icon-152x152.png" />
    <link rel="apple-touch-icon" sizes="180x180" href="../assets/favicon/apple-icon-180x180.png" />
    <link rel="icon" type="image/png" sizes="192x192" href="../assets/favicon/android-icon-192x192.png" />
    <link rel="icon" type="image/png" sizes="32x32" href="../assets/favicon/favicon-32x32.png" />
    <link rel="icon" type="image/png" sizes="96x96" href="../assets/favicon/favicon-96x96.png" />
    <link rel="icon" type="image/png" sizes="16x16" href="../assets/favicon/favicon-16x16.png" />
    <link rel="manifest" href="../assets/favicon/manifest.json" />
    <meta name="msapplication-TileColor" content="#ffffff" />
    <meta name="msapplication-TileImage" content="ms-icon-144x144.html" />
    <meta name="theme-color" content="#ffffff" />

    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- GENERAL CSS FILES -->
    <link href="../code.jquery.com/ui/1.9.2/themes/base/jquery-ui.css" rel="stylesheet" />
    <link href="../code.jquery.com/ui/1.10.4/themes/ui-lightness/jquery-ui.css" rel="stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Source+Sans+Pro:200,300,400,600,700,900,200italic,300italic,400italic,600italic,700italic,900italic' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Lobster+Two:400,400italic,700,700italic' rel='stylesheet' type='text/css'>

    <link rel="stylesheet" href="../assets/css/minified.css" />
    <link rel="stylesheet" type="text/css" href="../assets/css/cs-select.css" />
    <link rel="stylesheet" href="../assets/css/jquery.nouislider.css" />
    <link rel="stylesheet" href="../assets/css/isotope.css" />
    <link rel="stylesheet" href="../assets/css/innerpage.css" />
    <link rel="stylesheet" href="../assets/css/owl.carousel.css" />
    <link rel="stylesheet" href="../assets/css/owl.theme.css" />
    <link href="../assets/css/flexslider.css" rel="stylesheet" />
    <link rel="stylesheet" href="../assets/css/responsive.css">
    <link href="../assets/css/bootstrap.css" rel='stylesheet' type='text/css' />
    <link href="../assets/css/animate.css" rel='stylesheet' type='text/css' />
    <link href="../assets/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <!-- GENERAL JS FILES -->
    <script src="../assets/js/selectFx.js"></script>
    <script src="../assets/js/svgcheckbx.js"></script>
    <script src="../ajax.googleapis.com/ajax/libs/jqueryui/1.8.16/jquery-ui.min.js"></script>
    <script src="../code.jquery.com/jquery-1.10.2.js"></script>
    <script src="../code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
    <script src="../ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script src="../maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
    <!--Animation-->
    <script src="../assets/js/modernizr.min.js"></script>
    <script src="../assets/js/modernizr.custom.js"></script>
    <script src="../assets/js/wow.min.js"></script>
    <script>window.jQuery || document.write('<script src="../assets/js/jquery.min1.js"><\/script>');</script>
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
    <script>
        new WOW().init();
    </script>
    <script type="text/javascript">
        jQuery(document).ready(function ($) {
            $(".scroll").click(function (event) {
                event.preventDefault();
                $('html,body').animate({ scrollTop: $(this.hash).offset().top }, 1200);
            });
        });
    </script>
    <script type="text/javascript" src="../assets/js/move-top.js"></script>
    <script type="text/javascript" src="../assets/js/easing.js"></script>
    <script src="../assets/js/jquery.carouFredSel-6.1.0-packed.js"></script>
    <script src="../assets/js/tms-0.4.1.js"></script>
    <script src="../assets/js/jquery.easydropdown.js"></script>--%>


    <link href="code.jquery.com/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="code.jquery.com/bootstrap/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <%--<link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="bootstrap/js/bootstrap.min.js"></script>--%>
    <style>
        .header {
            border-top: 0px solid #5BBD50;
        }

        * {
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
            -ms-box-sizing: border-box;
            box-sizing: border-box;
        }

        .menutest {
            color: #494949;
            font-size: 16px;
            font-weight: 700;
        }

        .grow img {
            overflow: hidden;
            -webkit-transition: all 1s ease;
            -moz-transition: all 1s ease;
            -o-transition: all 1s ease;
            -ms-transition: all 1s ease;
            transition: all 1s ease;
        }

            .grow img:hover {
                width: 60%;
                padding-top: 0%;
            }

        a:hover {
            color: #5BBD50;
        }

        .sub-header {
            display: none;
            position: absolute;
            top: 22%;
            z-index: 1000;
            right: 0;
            margin-top: 6px;
            background: #E24425;
            color: #fff;
            box-shadow: 0 0 3px rgba(0,0,0,.15);
            -webkit-box-shadow: 0 0 3px rgba(0,0,0,.15);
        }

        #sub-cart {
            width: 550px;
        }

        @media screen and (max-width: 1200px) {
            #sub-cart {
                width: 250px;
            }
        }

        @media screen and (max-width: 750px) {
            #sub-cart {
                width: 250px;
            }
        }

        @media screen and (max-width: 500px) {
            #sub-cart {
                width: 250px;
            }
        }

        a:hover {
            color: black;
        }

        .top-menu ul li {
            display: inline-block;
            margin: 0 0px;
            padding: 0px 20px 0px 0px;
        }

        .header {
            background: url("<div style="border:1px solid #990000;
            padding-left: 20px;
            margin: 0 0 10px 0;
            "> <h4>A PHP Error was encountered</h4> <p>Severity: Notice</p> <p>Message: Undefined variable: path</p> <p>Filename: views/header.php</p> <p>Line Number: 149</p> </div><div style="border:1px solid #990000;
            padding-left: 20px;
            margin: 0 0 10px 0;
            "> <h4>A PHP Error was encountered</h4> <p>Severity: Notice</p> <p>Message: Undefined variable: image</p> <p>Filename: views/header.php</p> <p>Line Number: 149</p> </div>assets/upload/banner/") no-repeat;
        }

        .meta-title {
            background: rgba(0, 0, 0, 0.5);
            background: rgba(226, 69, 37, 0.8);
            display: block;
            color: white;
            width: 100%;
            padding: 10px 10px;
            font-size: 12px;
        }

        .meta-title-day {
            background: rgba(255, 255, 255, 1);
            color: white;
            //padding: 10px 5px;
            padding: 8px 16px;
            font-size: 14px;
            line-height: 1;
            font-weight: bold;
        }

        .populartriptitle {
            width: 310px;
            top: 121px;
            height: 55px;
            /* background: url(../../img/iti-toptitle-bg.png) repeat-x; */
            position: absolute;
            font-size: 15px;
            color: #fff;
            font-weight: bold;
            padding: 10 5px;
            text-transform: capitalize;
            -moz-border-top-left-radius: 0px;
            -webkit-border-top-left-radius: 0px;
            -o-border-top-left-radius: 0px;
            -ms-border-top-left-radius: 0px;
            border-top-left-radius: 0px;
            -moz-border-top-right-radius: 0px;
            -webkit-border-top-right-radius: 0px;
            -o-border-top-right-radius: 0px;
            -ms-border-top-right-radius: 0px;
            border-top-right-radius: 0px;
            z-index: 1;
        }

        .populartripbottom {
            background: rgba(0, 0, 0, 0.5);
            background: rgba(226, 69, 37, 0.8);
            color: white;
            width: 100%;
            padding: 8px 5px;
            font-size: 16px;
            position: absolute;
            top: 196px;
            -webkit-transform: translateY(10px);
            -moz-transform: translateY(10px);
            -o-transform: translateY(10px);
            -ms-transform: translateY(10px);
            transform: translateY(10px);
            width: 100%;
            -webkit-transition: all .4s ease;
            transition: all .4s ease;
        }

        .image-box .box img, .image-box.box img {
            width: 100%;
            height: 240px;
        }

        .populartripdays {
            height: 40px;
            position: absolute;
            font-size: 14px;
            color: #fff;
            padding: 10 5px;
            text-transform: uppercase;
            -moz-border-top-left-radius: 0px;
            -webkit-border-top-left-radius: 0px;
            -o-border-top-left-radius: 0px;
            -ms-border-top-left-radius: 0px;
            border-bottom-left-radius: 0px;
            border-top-left-radius: rpx;
            -moz-border-top-right-radius: 0px;
            -webkit-border-top-right-radius: 0px;
            -o-border-top-right-radius: 0px;
            -ms-border-top-right-radius: 0px;
            border-top-right-radius: 0px;
            z-index: 1;
            top: 127px;
            border-radius: 11px;
            text-align: right;
            //left: 208px;
            right: 30%;
            width: 23%;
        }

        .nbs-flexisel-inner {
            margin-left: -20px;
        }

        .nbs-flexisel-nav-left {
            margin-top: 130px;
        }

        .nbs-flexisel-nav-right {
            margin-top: 130px;
        }

        @media screen and (max-width: 480px) {
            .nbs-flexisel-nav-right {
                right: 110px;
            }
        }

        @media screen and (max-width: 480px) {
            .nbs-flexisel-nav-left {
                left: 110px;
            }
        }

        .cs-select.cs-active .cs-options {
            width: 160px;
            margin-top: 3px;
            border-radius: 6px;
        }

        .cs-select span {
            //font-size:1.2em;
        }

        .zocalo_logo {
            background: url(../assets/images/sprit.png) no-repeat 0px -30px;
            width: 388px;
            height: 104px;
            display: inline-block;
            margin-top: 50px;
        }
    </style>

    <style>
        .login-right p {
            color: red;
            display: block;
            font-size: 1.1em;
            margin: 1em 0 0 0;
            line-height: 1.5em;
        }
    </style>
    <style>
        media="all" @media screen and (max-width: 480px) {
            .contact-section-grid;

        {
            width: 55%;
            margin: 0 0 2em 0;
        }

        }

        media="all" @media screen and (max-width: 640px) {
            .contact-section-grid;

        {
            width: 55%;
            margin: 0 0 2em 0;
        }

        }
    </style>
    <style>
        * {
            padding: 0px;
            margin: 0px;
        }

        body {
            padding: 0px;
            margin: 0px;
        }

        .MealBox {
            border-radius: 5px;
            border: 1px solid;
            padding: 0px;
        }

            .MealBox:hover {
                box-shadow: 0px 0px 10px #000;
            }

        .inputProfile {
            width: 100%;
            border: 0px solid;
            margin-bottom: 5px;
            border-radius: 5px;
        }

            .inputProfile:focus {
                border: 1px solid;
            }

        .inputProfile-Name-box {
            width: 100%;
            border: 0px solid;
            margin-bottom: 5px;
            border-radius: 5px;
        }

            .inputProfile-Name-box:focus {
                border: 1px solid;
            }

        .inputProfile-Name {
            width: 20%;
            border: 0px solid;
            margin-bottom: 5px;
            border-radius: 5px;
        }

            .inputProfile-Name:focus {
                width: 40%;
                border: 0px solid;
            }
    </style>

    <style>
        .hide-bullets {
            list-style: none;
            margin-left: -40px;
            margin-top: 20px;
        }

        .thumbnail {
            padding: 0;
        }

        .carousel-inner > .item > img, .carousel-inner > .item > a > img {
            width: 100%;
        }
    </style>
    <style>
        .dropbtn {
            background-color: #4CAF50;
            color: white;
            padding: 16px;
            font-size: 16px;
            border: none;
            cursor: pointer;
        }

        .dropdown {
            position: relative;
            display: inline-block;
        }

        .dropdown-content {
            display: none;
            position: absolute;
            right: 0;
            background-color: #f9f9f9;
            min-width: 160px;
            box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
            z-index: 1;
        }

            .dropdown-content a {
                color: black;
                padding: 12px 16px;
                text-decoration: none;
                display: block;
            }

                .dropdown-content a:hover {
                    background-color: #f1f1f1;
                }

        .dropdown:hover .dropdown-content {
            display: block;
        }

        .dropdown:hover .dropbtn {
            background-color: #3e8e41;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="">

            <!-- Modal -->
            <div id="myModal" class="modal fade" role="dialog">
                <div id="divModule" runat="server" class="modal-dialog" style="width: 80%;">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header" style="background-color: #CA1A1A; color: #fff;">
                            <button type="button" class="close" data-dismiss="modal" style="color: #fff;">&times;</button>
                            <h4 class="modal-title">Order Detail</h4>
                        </div>
                        <div class="modal-body" style="margin-top: 20px; margin-bottom: 20px;">
                            <div class="container-fluid">
                                <div class="col-md-4" style="border: 0px solid;">
                                    <asp:Image ID="imgItemImage" runat="server" Width="300px" Height="300px" />
                                </div>
                                <div class="col-md-4" style="border-right: 1px solid #d9d9d9;">

                                    <h2>
                                        <asp:Label ID="lblItemName" runat="server" Text="" Style="color: #CA1A1A;"></asp:Label></h2>

                                    <h3>Price :
                                        <asp:Label ID="lblItemPrice" runat="server" Text=""></asp:Label></h3>
                                    <h4>
                                        <asp:Literal ID="ltrItemTime" runat="server" Text=""></asp:Literal></h4>
                                    <b>About Item :</b><br />
                                    <div class="text-justify" style="border-top: 1px solid; height: 80px; overflow-y: scroll;">
                                        <asp:Literal ID="ltrItemDescription" runat="server"></asp:Literal>
                                    </div>
                                    <div style="margin-top: 20px;">
                                        <asp:Image ID="imgItemType" runat="server" Width="30px" Height="30px" />
                                    </div>
                                </div>
                                <div id="divClientInfo" runat="server" class="col-md-4">
                                    <h2>
                                        <asp:Label ID="lblClientName" runat="server" Text="" Style="color: #CA1A1A;"></asp:Label></h2>
                                    <h4>
                                        <asp:Literal ID="ltrClientContactNo" runat="server" Text=""></asp:Literal></h4>
                                    <h4>
                                        <asp:Literal ID="ltrClientMailID" runat="server" Text=""></asp:Literal></h4>
                                    <div style="margin-top: 25px;">
                                        <b style="font-size: 18px;">Address :</b><br />
                                        Shipping Address :
                                        <br />
                                        <div style="height: 40px; border: 0px solid; overflow-y: scroll; margin-bottom: 20px;">
                                            <asp:Literal ID="ltrShippingAddress" runat="server"></asp:Literal>
                                        </div>
                                        Billing Address : 
                                        <div style="height: 40px; border: 0px solid; overflow-y: scroll;">
                                            <asp:Literal ID="ltrBillingAddress" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer" style="background-color: #808080;">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        </div>
                    </div>

                </div>
            </div>

            <div id="myModal1" class="modal fade" role="dialog">
                <div id="div1" runat="server" class="modal-dialog" style="width: 55%;">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header" style="background-color: #CA1A1A; color: #fff;">
                            <button type="button" class="close" data-dismiss="modal" style="color: #fff;">&times;</button>
                            <abbr title="Remove Menu" style="background-color: #5b5b5b; color: #CA1A1A;">
                                <asp:LinkButton ID="lnkDeleteItem" class="pull-right glyphicon glyphicon-remove" runat="server" Style="color: #fff; font-size: 20px; margin: 10px; margin-right: 40px;" OnClick="lnkDeleteItem_Click"></asp:LinkButton></abbr>
                            <abbr title="Hide Meal" style="background-color: #5b5b5b; color: #CA1A1A;">
                                <asp:LinkButton ID="lnkHideItem" class="pull-right glyphicon glyphicon-stop" runat="server" Style="color: #fff; font-size: 20px; margin: 10px;" Visible="false" OnClick="lnkHideMeal_Click"></asp:LinkButton></abbr>
                            <abbr title="Display Meal" style="background-color: #5b5b5b; color: #CA1A1A;">
                                <asp:LinkButton ID="lnkShowItem" class="pull-right glyphicon glyphicon-play" runat="server" Style="color: #fff; font-size: 20px; margin: 10px;" Visible="false" OnClick="lnkShowMeal_Click"></asp:LinkButton></abbr>
                            <abbr title="Submit Changes" style="background-color: #5b5b5b; color: #CA1A1A;">
                                <asp:LinkButton ID="lnkEditItemOK" class="pull-right glyphicon glyphicon-ok" runat="server" Style="color: #fff; font-size: 20px; margin: 10px;" Visible="false" OnClick="lnkEditItemOK_Click"></asp:LinkButton></abbr>
                            <h4 class="modal-title">Order Detail</h4>
                        </div>
                        <div class="modal-body" style="margin-top: 20px; margin-bottom: 20px;">
                            <div class="container-fluid">
                                <div class="col-md-6" style="border: 0px solid;">
                                    <asp:Image ID="imgItemImage1" runat="server" Width="300px" Height="300px" />
                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-11" style="padding: 0px;">
                                        <h2>
                                            <asp:Label ID="lblItemName1" runat="server" Text="" Style="color: #CA1A1A;" Visible="false"></asp:Label></h2>
                                        <asp:TextBox ID="txtItemName1" runat="server" Visible="false"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1" style="padding: 0px; margin-top: 20px;">
                                        <asp:HiddenField ID="hdnItemID" runat="server" Value='<%# Eval("ItemID") %>' />
                                        <asp:LinkButton ID="LinkButton10" runat="server" OnClick="LinkButton10_Click"><span class="glyphicon glyphicon-shopping-cart" style="margin-top: 0px; margin-right: 10px; font-size: 25px; color: #5BBD50;"></span></asp:LinkButton>
                                    </div>

                                    <h3>Price : 
                                        <asp:Label ID="lblItemPrice1" runat="server" Text="" Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtItemPrice1" runat="server" Visible="false"></asp:TextBox>
                                    </h3>
                                    <h4>
                                        <asp:Literal ID="ltrItemTime1" runat="server" Text=""></asp:Literal></h4>
                                    <b>About Item :</b><br />
                                    <div id="divItemDescltr" runat="server" class="text-justify" style="border-top: 1px solid; height: 80px; overflow-y: scroll;" visible="false">
                                        <asp:Literal ID="ltrItemDescription1" runat="server"></asp:Literal>
                                    </div>
                                    <div id="divItemDesctxt" runat="server" class="text-justify" style="border-top: 1px solid; height: 80px;" visible="false">
                                        <asp:TextBox ID="txtItemDescription1" runat="server" TextMode="MultiLine" Width="100%" Height="77px"></asp:TextBox>
                                    </div>
                                    <div style="margin-top: 20px;">
                                        <asp:Image ID="imgItemType1" runat="server" Width="30px" Height="30px" Visible="false" />
                                        <asp:ImageButton ID="imgbtnItemType1" runat="server" Width="30px" Height="30px" Visible="false" />
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="modal-footer" style="background-color: #808080;">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        </div>
                    </div>

                </div>
            </div>

            <div class="col-md-12" style="background-color: #d84747; height: 195px; background: url(../mainimg/main7.jpg) no-repeat; background-size: 100% 295px;">

                <div id="divLogout" runat="server" class="col-md-4 pull-right" style="border: 0px solid #ecee12;">
                    <div class="col-md-12" style="background-color: #5BBD50; padding: 10px; border-radius: 0px 0px 15px 15px;">
                        <div class="col-md-9 text-center" style="color: #fff; font-size: 16px; font-weight: 700;" class="menutest">
                            Welcome
                                    <asp:Literal ID="ltrServiceProviderName" runat="server"></asp:Literal>
                        </div>

                        <div class="col-md-2" style="border-left-color: #fff; border-left: 2px solid #fff;">
                            <asp:LinkButton ID="lnkLogout" runat="server" Style="color: #fff; font-size: 16px; font-weight: 700; text-decoration: none;" class="menutest" OnClick="lnkLogout_Click">Logout</asp:LinkButton>
                        </div>
                    </div>
                </div>
                <div id="divCart" runat="server">
                    <div class="dropdown" style="float: right; margin-right: 50px;">
                        <div class="col-md-12" style="background-color: #5BBD50; padding: 5px 10px 5px 10px; border-radius: 0px 0px 15px 15px;">
                            <button class="dropbtn" style="padding: 0px; background-color: transparent;"><i class="glyphicon glyphicon-shopping-cart round-icon" style="margin-top: -15px; margin-bottom: 0px; padding-bottom: 0px; font-size: 20px; background-color: transparent; color: #fff;"></i></button>
                            <div class="dropdown-content">
                                <div class="col-md-12" style="width: 800px; margin-right: -50px; background-color: transparent; padding: 0px;">
                                    <div class="col-md-12 text-center" style="background-color: #E24425; font-size: 20px; padding: 5px;">
                                        Products on Your Shopping Cart
                                    </div>
                                    <div class="col-md-12" style="max-height: 400px; overflow: scroll; background-color: #fff;">
                                        <table class="table table-responsive" style="color: black; width: 100%;" border="1">
                                            <tr>
                                                <td></td>
                                                <td>Item Image</td>
                                                <td>Name</td>
                                                <td>Price</td>
                                                <td>Quentity</td>
                                                <td>Amount</td>
                                                <td>Cancel</td>
                                            </tr>
                                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <asp:Repeater ID="repitem" runat="server" OnItemCommand="repitem_ItemCommand">
                                                        <ItemTemplate>
                                                            <tr style="height: -30px;">
                                                                <td>
                                                                    <asp:CheckBox ID="chkItemSelect" runat="server" Text='<%# Eval("CartID") %>' Style="font-size: 0px;" /></td>
                                                                <td style="text-align: center;">
                                                                    <asp:Image ID="Image2" class="img-responsive" runat="server" ImageUrl='<%# "~/ServiceProvider/Iteam/" + Eval("img") %>' Width="80px" Height="80px" Style="margin: 10px 30px 40px 40px;"></asp:Image>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblproduct" runat="server" Text='<%# Eval("ItemName") %>'></asp:Label>
                                                                </td>
                                                                <td>

                                                                    <label id="lblprice" style="margin-left: 20px;"><%# Eval("ItemPrice") %> </label>
                                                                    <%--  <asp:Label ID="lblprice" runat="server" Text='<%# Eval("ItemPrice") %>' Style="margin-left :20px;"></asp:Label>--%>
                                                                </td>

                                                                <td style="width: 150px; padding-left: 0px;">
                                                                    <div class="col-md-4" style="margin-top: -20px; margin-left: -20px; margin-right: 20px;">
                                                                        <asp:LinkButton ID="LinkButton1" runat="server" Style="background-color: transparent; color: #E24425; border: 0px solid;" CommandName="itemInc" CommandArgument='<%# Eval("CartID") %>'><i class="glyphicon glyphicon-plus"></i></asp:LinkButton>
                                                                    </div>
                                                                    <div class="col-md-2" style="padding: 0px;">
                                                                        <asp:TextBox ID="txtquan" type="number" runat="server" Width="35px" Height="30px" Text='<%# Eval("Quantity") %>'></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-md-4" style="margin-top: -20px; border: 0px solid; padding: 0px; margin-left: 10px;">
                                                                        <asp:LinkButton ID="LinkButton2" runat="server" Style="background-color: transparent; color: #E24425;" CommandName="itemDec" CommandArgument='<%# Eval("CartID") %>'><i class="glyphicon glyphicon-minus"></i></asp:LinkButton>
                                                                    </div>

                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblTotal" runat="server" Text='<%# Eval("Total") %>'></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:LinkButton ID="lnkitem" runat="server" Style="background-color: transparent; margin-top: -15px;" CommandName="diactiveitem" CommandArgument='<%# Eval("CartID") %>'><i class="round-icon" style="border-color: #FFF!important; background: #fff;color: red;margin-top: -5px;">X</i></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                    <asp:Repeater ID="repmeal" runat="server" OnItemCommand="repmeal_ItemCommand">

                                                        <ItemTemplate>
                                                            <tr style="height: -30px;">
                                                                <td>
                                                                    <asp:CheckBox ID="chkItemSelect" runat="server" Text='<%# Eval("CartID") %>' Style="font-size: 0px;" /></td>
                                                                <td style="text-align: center;">
                                                                    <asp:Image ID="Image2" class="img-responsive" runat="server" ImageUrl='<%# "~/ServiceProvider/Meal/" + Eval("imge") %>' Width="80px" Height="80px" Style="margin: 10px 30px 40px 40px;"></asp:Image>
                                                                </td>
                                                                <td>

                                                                    <asp:Label ID="lblproduct" runat="server" Text='<%# Eval("MealName") %>'></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("MealPrice") %>' Style="margin-left: 20px;"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <%--<asp:TextBox ID="txtquan" runat="server" type="number" Height="25px" Width="50px" Style="margin-top: 0px;"></asp:TextBox>--%>
                                                                    <%-- <asp:TextBox ID="txtQuantity1" runat="server" Text ="0"></asp:TextBox>--%>
                                                                    <div class="col-md-4" style="margin-top: -20px; margin-left: -20px; margin-right: 20px;">
                                                                        <asp:LinkButton ID="LinkButton1" runat="server" Style="background-color: transparent; color: #E24425; border: 0px solid;" CommandName="itemInc" CommandArgument='<%# Eval("CartID") %>'><i class="glyphicon glyphicon-plus"></i></asp:LinkButton>
                                                                    </div>
                                                                    <div class="col-md-2" style="padding: 0px;">
                                                                        <asp:TextBox ID="txtquan" runat="server" Width="35px" Height="30px" Text='<%# Eval("Quantity") %>'></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-md-4" style="margin-top: -20px; border: 0px solid; padding: 0px; margin-left: 10px;">
                                                                        <asp:LinkButton ID="LinkButton2" runat="server" Style="background-color: transparent; color: #E24425;" CommandName="itemDec" CommandArgument='<%# Eval("CartID") %>'><i class="glyphicon glyphicon-minus"></i></asp:LinkButton>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblTotal" runat="server" Text='<%# Eval("Total") %>'></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:LinkButton ID="lnkMeal" runat="server" CommandName="diactiveMeal" CommandArgument='<%# Eval("CartID") %>'>   <h3 style="color:red"><i class="round-icon" style="border-color: #FFF!important; background: #fff;color: red;margin-top: -5px;">X</i></h3></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <tr style="background: white;">
                                                <td style="background-color: #fff; text-align: center;"><b>Order Total:</b></td>
                                                <td style="background-color: #fff; text-align: right;" colspan="4"></td>
                                                <td><b>
                                                    <asp:Literal ID="ltrTotalAmount" runat="server"></asp:Literal></b></td>
                                                <td style="background-color: #fff;"></td>
                                            </tr>
                                        </table>
                                    </div>

                                    <div class="col-md-12" style="background-color: #808080; padding: 15px;">
                                        <asp:Button ID="btnOrder" runat="server" Text="Order Now" class='buttont  btn-danger pull-right' Style="margin-right: 20px; background: #E24425" OnClick="btnOrder_Click"></asp:Button>
                                        <asp:Button ID="btnCheckOut" runat="server" Text="Checkout" Style="margin-right: 20px;" class='buttont btn-success pull-right' OnClick="btnCheckOut_Click"></asp:Button>
                                        <asp:Button ID="btnClearCart" runat="server" Text="clear cart" class='buttont  btn-danger pull-right' Style="margin-right: 20px; background: #E24425" OnClick="btnClearCart_Click"></asp:Button>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <asp:Image ID="imgSPImage" runat="server" Width="200px" Height="200px" Style="border: 7px solid #fff; border-radius: 20px; margin-left: 30px; margin-top: 50px;" />

                </div>
                <div class="col-md-5" style="margin-top: 125px; color: #fff">
                    <h2 style="margin-left: -50px;">
                        <asp:Literal ID="ltrSPName" runat="server"></asp:Literal></h2>
                </div>

            </div>

            <div class="col-md-12" style="box-shadow: 0px 3px 3px #350202; color: #808080; padding: 10px;">
                <div class="col-md-4">
                    <asp:FileUpload ID="FileUpload3" runat="server" Style="border: 1px solid; width: 184px; margin-left: 43px; margin-top: -147px; opacity: 0;" Height="183px" /><asp:Button ID="btnUpload" Text="Upload" runat="server" OnClick="Upload" Style="display: none" />
                </div>
                <script type="text/javascript">
                    function UploadFile(fileUpload) {
                        if (fileUpload.value != '') {
                            document.getElementById("<%=btnUpload.ClientID %>").click();
                        }
                    }
                </script>
                <div class="col-md-1">
                    <center><h4><asp:LinkButton ID="lnkHome" runat="server" OnClick="lnkHome_Click">Home</asp:LinkButton></h4></center>
                </div>
                <div class="col-md-1">
                    <center><h4><asp:LinkButton ID="lnkprofile" runat="server" OnClick="lnkprofile_Click">Profile</asp:LinkButton></h4></center>
                </div>
                <div class="col-md-1">
                    <center><h4><asp:LinkButton ID="lnkOrder" runat="server" OnClick="lnkOrder_Click">Order</asp:LinkButton></h4></center>
                </div>
                <div class="col-md-1">
                    <center><h4><asp:LinkButton ID="lnkmeal" runat="server" OnClick="lnkmeal_Click">Meal</asp:LinkButton></h4></center>
                </div>
                <div class="col-md-1">
                    <center><h4><asp:LinkButton ID="lnkmenu" runat="server" OnClick="lnkmenu_Click">Menu</asp:LinkButton></h4></center>
                </div>
                

            </div>


            <div class="col-md-12">
                <div id="divSPSidePanel" runat="server" class="col-md-3" style="border: 0px solid; margin-top: 50px; padding-left: 30px; min-height: 800px;" visible="false">
                    <div id="divPackage" runat="server" class="col-md-11" style="border: 1px solid #aeaeae; border-radius: 5px; height: 150px;" visible="false">
                        <h4>Package Name :
                            <asp:Label ID="lblPackName" runat="server" Text=""></asp:Label></h4>
                        <h5>Start From :
                            <asp:Label ID="lblStartDate" runat="server" Text=""></asp:Label></h5>
                        <h5>Expire On :
                            <asp:Label ID="lblEndDate" runat="server" Text=""></asp:Label></h5>
                        <asp:Button ID="btnRenew" class="btn btn-default" runat="server" Text="Renew" PostBackUrl="~/Package.aspx" Style="background-color: #5BBD50; color: #fff; margin-top: 8px;" />
                    </div>
                    <div class="col-md-11" style="border: 1px solid #aeaeae; border-radius: 5px; height: 200px; margin-top: 20px;">
                        <center><h3>Wallet</h3></center>
                        <hr style="border: 1px solid #aeaeae; margin-top: -3px;" />
                        <h4>Wallet Amount :
                            <asp:Label ID="Label7" runat="server" Text="100000"></asp:Label></h4>
                        <h5>Claim Amount :
                            <asp:Label ID="Label8" runat="server" Text="4000"></asp:Label></h5>
                        <asp:Button ID="Button1" class="btn btn-default" runat="server" Text="Add Amount" Style="background-color: #5BBD50; color: #fff; margin-top: 20px;" />
                    </div>
                </div>

                <div id="divClientSidePanel" runat="server" class="col-md-3" style="border: 0px solid; margin-top: 50px; padding-left: 30px; min-height: 800px;" visible="false">
                    <h4>Today Spacial</h4>
                    <hr style="border: 1px solid #d9d9d9; margin-top: 5px; padding: 0px;" />
                    <asp:Repeater ID="rptClientSidePanel" runat="server" OnItemCommand="rptClientSidePanel_ItemCommand">
                        <ItemTemplate>
                            <div class="col-md-12" style="border: 1px solid #aeaeae; border-radius: 5px; padding: 15px; margin-bottom: 20px;">
                                <div class="col-md-6" style="padding: 0px; border: 0px solid;">
                                    <asp:Image ID="Image1" runat="server" Width="125px" Height="125px" Style="border: 3px solid #5b5b5b; border-radius: 10px;" />
                                    <asp:HiddenField ID="hdnImageID" runat="server" Value='<%# Eval("ImageID") %>' />
                                </div>
                                <div class="col-md-6" style="padding: 0px; padding-left: 20px;">
                                    <h4 style="color: #CA1A1A; font-weight: 700;"><%# Eval("MealName") %></h4>
                                    <h5 style="font-weight: 600;">Price : <%# Eval("MealPrice") %></h5>
                                    * * * * *<br />
                                    <asp:LinkButton ID="LinkButton10" runat="server" CommandName="CartSpecialMeal" CommandArgument='<%# Eval("MealID") %>'><span class="glyphicon glyphicon-shopping-cart" style="margin-top: 0px; margin-right: 10px; font-size: 25px; color: #5BBD50;"></span></asp:LinkButton>
                                </div>
                                <div class="col-md-12" style="padding: 10px; margin-top: 10px;">
                                    <%# Eval("MealDescription") %>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                </div>

                <div id="divHome" runat="server" class="col-md-9" style="padding: 0px 50px 20px 0px;" visible="false">
                    <div id="divTodayStatus" runat="server" class="col-md-12" style="margin-top: 50px;" visible="false">
                        <div class="col-md-12" style="border: 1px solid; padding: 20px 5px 20px 5px; border: 1px solid #aeaeae; border-radius: 5px; color: #5b5b5b;">
                            <div class="col-md-4">
                                <div class="col-md-12" style="border: 0px solid;">
                                    <h4>
                                        <asp:Literal ID="Literal1" runat="server">Lunch Order : </asp:Literal><asp:Label ID="lblLunchOrder" runat="server" Text="40"></asp:Label></h4>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="col-md-12" style="border: 0px solid;">
                                    <h4>
                                        <asp:Literal ID="Literal2" runat="server">Dinner Order  : </asp:Literal><asp:Label ID="lblDinnerOrder" runat="server" Text="50"></asp:Label></h4>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="col-md-12" style="border: 0px solid;">
                                    <h4>
                                        <asp:Literal ID="Literal3" runat="server">Total Payment : </asp:Literal><asp:Label ID="lblTotalPayment" runat="server" Text="50000"></asp:Label></h4>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="divTodayOrder" runat="server" class="col-md-12" style="margin-top: -10px;" visible="false">
                        <div class="col-md-12" style="padding: 20px 5px 20px 5px; border: 0px solid #aeaeae; border-radius: 5px; color: #5b5b5b;">
                            <div class="row" style="padding-bottom: 20px;">
                                <div class="col-md-12">
                                    <div class="col-md-12" style="border: 0px solid;">
                                        <h3>Upcoming Order</h3>
                                        <hr style="border: 1px solid #aeaeae; margin-top: 0px;" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12" style="margin-top: -20px;">
                                <h4>: : Meal Order : :</h4>
                            </div>
                            <div class="col-md-12">
                                <div class="col-md-12" style="border: 0px solid; padding: 0px; box-shadow: 0px 0px 4px #aeaeae;">
                                    <div class="col-md-12" style="border: 1px solid #CA1A1A; border-bottom: 0px; font-size: 20px; border-radius: 5px 5px 0px 0px; padding: 0px; background-color: #CA1A1A; font-weight: bolder; color: #fff;">
                                        <div class="col-md-3 text-center" style="padding: 10px; border-right: 1px solid #CA1A1A;">Meal Name</div>
                                        <div class="col-md-2 text-center" style="padding: 10px; border-right: 1px solid #CA1A1A;">Time</div>
                                        <div class="col-md-3 text-center" style="padding: 10px; border-right: 1px solid #CA1A1A;">Price</div>
                                        <div class="col-md-2 text-center" style="padding: 10px; border-right: 1px solid #CA1A1A;">Quentity</div>
                                        <div class="col-md-2 text-center" style="padding: 10px;">Status</div>
                                    </div>
                                    <asp:Repeater ID="rptTodayMealOrder" runat="server" OnItemCommand="rptTodayMealOrder_ItemCommand">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkOrderRecord" runat="server" Style="color: #5b5b5b;" CommandName="ShowOrderDetail" CommandArgument='<%# Eval("OrderID") %>'>
                                                <div class="col-md-12" style="border: 1px solid; border-width: 0px 1px 1px 1px; font-size: 20px; padding: 0px;">
                                                    <div class="col-md-3 text-center" style="padding: 12px; border-right: 1px solid;"><%# Eval("MealName") %></div>
                                                    <div class="col-md-2 text-center" style="padding: 12px; border-right: 1px solid;"><%# Eval("Time") %></div>
                                                    <div class="col-md-3 text-center" style="padding: 12px; border-right: 1px solid;"><%# Eval("MealPrice") %></div>
                                                    <div class="col-md-2 text-center" style="padding: 12px; border-right: 1px solid;"><%# Eval("Qty") %></div>
                                                    <div class="col-md-2 text-center" style="padding: 5px;">
                                                        <%--<asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("OrderID") %>' />--%>
                                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# "Admin/img/" + Eval("OrderStatus") + ".png" %>' Width="30px" Height="30px" CommandName="EditOrderStatus" CommandArgument='<%# Eval("OrderID") %>' />
                                                    </div>
                                                </div>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                            <div class="col-md-12" style="margin-top: 40px;">
                                <h4>: : Item Order : :</h4>
                            </div>
                            <div class="col-md-12">
                                <div class="col-md-12" style="border: 0px solid; padding: 0px; box-shadow: 0px 0px 4px #aeaeae;">
                                    <div class="col-md-12" style="border: 1px solid #CA1A1A; border-bottom: 0px; font-size: 20px; border-radius: 5px 5px 0px 0px; padding: 0px; background-color: #CA1A1A; font-weight: bolder; color: #fff;">
                                        <div class="col-md-3 text-center" style="padding: 10px; border-right: 1px solid #CA1A1A;">Item Name</div>
                                        <div class="col-md-2 text-center" style="padding: 10px; border-right: 1px solid #CA1A1A;">Time</div>
                                        <div class="col-md-3 text-center" style="padding: 10px; border-right: 1px solid #CA1A1A;">Price</div>
                                        <div class="col-md-2 text-center" style="padding: 10px; border-right: 1px solid #CA1A1A;">Quentity</div>
                                        <div class="col-md-2 text-center" style="padding: 10px;">Status</div>
                                    </div>
                                    <asp:Repeater ID="rptTodayMenuOrder" runat="server" OnItemCommand="rptTodayMenuOrder_ItemCommand">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton6" runat="server" Style="color: #5b5b5b;" CommandName="ShowOrderDetail" CommandArgument='<%# Eval("OrderID") %>'>
                                                <div class="col-md-12" style="border: 1px solid; border-width: 0px 1px 1px 1px; font-size: 20px; padding: 0px;">
                                                    <div class="col-md-3 text-center" style="padding: 12px; border-right: 1px solid;"><%# Eval("ItemName") %></div>
                                                    <div class="col-md-2 text-center" style="padding: 12px; border-right: 1px solid;"><%# Eval("Time") %></div>
                                                    <div class="col-md-3 text-center" style="padding: 12px; border-right: 1px solid;"><%# Eval("ItemPrice") %></div>
                                                    <div class="col-md-2 text-center" style="padding: 12px; border-right: 1px solid;"><%# Eval("Qty") %></div>
                                                    <div class="col-md-2 text-center" style="padding: 5px;">
                                                        <%--<asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("OrderID") %>' />--%>
                                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# "Admin/img/" + Eval("OrderStatus") + ".png" %>' Width="30px" Height="30px" CommandName="EditOrderStatus" CommandArgument='<%# Eval("OrderID") %>' />
                                                    </div>
                                                </div>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>


                        </div>
                    </div>
                </div>

                <div id="divMeal" runat="server" class="col-md-9" style="margin-top: 20px; padding: 0px;" visible="false">
                    <div class="col-md-12">
                        <asp:Button ID="btnAddMeal" class="btn btn-default" runat="server" Text="Add Meal" Style="float: right; margin-right: 0px; margin-bottom: 35px; background-color: #5BBD50; color: #fff;" OnClick="btnAddMeal_Click" />
                    </div>
                    <asp:Repeater ID="rptSPMeal" runat="server" OnItemCommand="rptSPMeal_ItemCommand">
                        <ItemTemplate>
                            <div class="col-md-4" style="margin-bottom: 30px;">
                                <div class="col-md-12 MealBox">
                                    <div style="/*background: url(../mainimg/main7.jpg) no-repeat; */ background-color: #ca1a1a; height: 110px; width: 100%;">
                                        <%--<asp:Button ID="Button2" class="pull-right" runat="server" Text="Button" />--%>
                                        <abbr title="Remove Meal" style="background-color: #5b5b5b; color: #CA1A1A;">
                                            <asp:LinkButton ID="lnkDeleteItem" class="pull-right glyphicon glyphicon-remove" runat="server" Style="color: #fff; font-size: 20px; margin: 10px;" CommandName="DeleteMeal" CommandArgument='<%# Eval("MealID") %>'></asp:LinkButton></abbr>
                                        <asp:HiddenField ID="hdnMealStatus" runat="server" Value='<%# Eval("MealStatus") %>' />
                                        <abbr title="Hide Meal" style="background-color: #5b5b5b; color: #CA1A1A;">
                                            <asp:LinkButton ID="lnkHideMeal" class="pull-right glyphicon glyphicon-stop" runat="server" Style="color: #fff; font-size: 20px; margin: 10px;" CommandName="ShowMeal" CommandArgument='<%# Eval("MealID") %>' Visible="false"></asp:LinkButton></abbr>
                                        <abbr title="Display Meal" style="background-color: #5b5b5b; color: #CA1A1A;">
                                            <asp:LinkButton ID="lnkShowMeal" class="pull-right glyphicon glyphicon-play" runat="server" Style="color: #fff; font-size: 20px; margin: 10px;" CommandName="HideMeal" CommandArgument='<%# Eval("MealID") %>' Visible="false"></asp:LinkButton></abbr>
                                        <abbr title="Edit Meal" style="background-color: #5b5b5b; color: #CA1A1A;">
                                            <asp:LinkButton ID="lnkShowEditerItem" class="pull-right glyphicon glyphicon-edit" runat="server" Style="color: #fff; font-size: 20px; margin: 10px;" CommandName="ShowEditerItem" CommandArgument='<%# Eval("MealID") %>'></asp:LinkButton></abbr>
                                        <abbr title="Submit Changes" style="background-color: #5b5b5b; color: #CA1A1A;">
                                            <asp:LinkButton ID="lnkEditItem" class="pull-right glyphicon glyphicon-ok" runat="server" Style="color: #fff; font-size: 20px; margin: 10px;" CommandName="EditItem" CommandArgument='<%# Eval("MealID") %>' Visible="false"></asp:LinkButton></abbr>
                                        <asp:HiddenField ID="hdnImageID" runat="server" Value='<%# Eval("ImageID") %>' />
                                        <asp:Image ID="imgMealImage" runat="server" Width="100px" Height="100px" Style="margin-top: 50px; margin-left: 20px; border: 5px solid #fff; border-radius: 10px;" />
                                    </div>
                                    <div class="pull-right" style="margin-top: -40px; margin-right: 0px;">
                                        <asp:HiddenField ID="hdnSpacial" runat="server" Value='<%# Eval("TodaySpacial") %>' />
                                        <abbr title="Make Special Meal" style="background-color: #5b5b5b; color: #CA1A1A;">
                                            <asp:LinkButton ID="lnkMakeSpacial" class="pull-right glyphicon glyphicon-star" runat="server" Style="color: #fff; font-size: 20px; margin: 10px;" CommandName="HideSpacialMeal" CommandArgument='<%# Eval("MealID") %>' Visible="false"></asp:LinkButton></abbr>
                                        <abbr title="Remove Special Meal" style="background-color: #5b5b5b; color: #CA1A1A;">
                                            <asp:LinkButton ID="lnkRemoveSpacial" class="pull-right glyphicon glyphicon-star-empty" runat="server" Style="color: #fff; font-size: 20px; margin: 10px;" CommandName="ShowSpacialMeal" CommandArgument='<%# Eval("MealID") %>' Visible="false"></asp:LinkButton></abbr>
                                    </div>
                                    <div style="height: 33px; border: 0px solid;">
                                        <h4 style="margin-top: 8px; margin-left: 130px; font-weight: bolder;">
                                            <asp:Literal ID="ltrMealName" runat="server" Text='<%# Eval("MealName") %>'></asp:Literal>
                                            <asp:TextBox ID="txtMealName" runat="server" pattern="[A-Za-z]*" oninvalid="setCustomValidity('enter The Meal Name in Proper Format  ')" oninput="setCustomValidity('')" MaxLength="15" Text='<%# Eval("MealName") %>' Width="90%" Visible="false"></asp:TextBox>
                                        </h4>
                                    </div>
                                    <div class="col-md-12" style="padding-left: 28px; min-height: 150px; padding-bottom: 10px;">

                                        <div class="col-md-8" style="padding: 0px;">
                                            <h5 style="font-weight: bolder;">Price : 
                                                <asp:Literal ID="ltrPrice" runat="server" Text='<%# Eval("MealPrice") %>'></asp:Literal>
                                                <asp:TextBox ID="txtPrice" runat="server" pattern="\d+(\.\d{2})?" oninvalid="setCustomValidity('Enter The Meal Price')" oninput="setCustomValidity('')" Text='<%# Eval("MealPrice") %>' Width="40%" Visible="false"></asp:TextBox>
                                            </h5>
                                        </div>
                                        <div class="col-md-4" style="padding: 0px;">
                                            <asp:Image ID="imgMealType" runat="server" ImageUrl='<%# "Icon/" + Eval("MealType") + ".png" %>' Width="25px" Height="25px" Style="float: right; margin-right: 6px;" />
                                            <asp:ImageButton ID="imgbtnMealType" runat="server" ImageUrl='<%# "Icon/" + Eval("MealType") + ".png" %>' Width="25px" Height="25px" Style="float: right; margin-right: 6px;" Visible="false" CommandName="EditMealType" CommandArgument='<%# Eval("MealID") %>' />
                                            <asp:LinkButton ID="LinkButton10" runat="server" CommandName="CartMeal" CommandArgument='<%# Eval("MealID") %>'><span class="glyphicon glyphicon-shopping-cart" style="float: right; margin-top: 0px; margin-right: 10px; font-size: 25px; color: #5BBD50;"></span></asp:LinkButton>
                                        </div>
                                        <img src="" />
                                        <div class="col-md-12" id="divDesc" runat="server" style="padding: 0px; text-align: justify; text-justify: inter-word; padding-right: 5px;">
                                            <asp:Literal ID="ltrDesc" runat="server" Text='<%# Eval("MealDescription") %>'></asp:Literal>
                                            <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" pattern="[A-Za-z0-9]+$" oninvalid="setCustomValidity('Enter Meal Description')" oninput="setCustomValidity('')" MaxLength="100" Width="100%" Rows="3" Text='<%# Eval("MealDescription") %>' Visible="false"></asp:TextBox>
                                        </div>

                                        <div class="col-md-12" style="padding: 0px;">* * * * *</div>

                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                </div>

                <div id="divMenu" runat="server" class="col-md-9" style="margin-top: 20px; padding: 0px; padding-right: 50px;" visible="false">
                    <div class="container-fluid">
                        <div class="col-md-12">
                            <asp:Button ID="btnAddMenu" class="btn btn-default" runat="server" Text="Add Menu" Style="float: right; margin-bottom: 35px; background-color: #5BBD50; color: #fff;" OnClick="btnAddMenu_Click" />
                        </div>
                        <asp:Repeater ID="rptSPMenu" runat="server" OnItemCommand="rptSPMenu_ItemCommand">
                            <ItemTemplate>

                                <asp:Panel ID="PanelMenuData" runat="server">
                                    <div class="col-md-12" style="margin-bottom: 40px;">
                                        <div class="col-md-12 MealBox">
                                            <abbr title="Remove Menu" style="background-color: #5b5b5b; color: #CA1A1A;">
                                                <asp:LinkButton ID="lnkDeleteItem" class="pull-right glyphicon glyphicon-remove" runat="server" Style="color: #fff; font-size: 20px; margin: 10px;" CommandName="DeleteMenu" CommandArgument='<%# Eval("MenuID") %>'></asp:LinkButton></abbr>
                                            <abbr title="Edit Menu" style="background-color: #5b5b5b; color: #CA1A1A;">
                                                <asp:LinkButton ID="lnkShowEditerItem" class="pull-right glyphicon glyphicon-edit" runat="server" Style="color: #fff; font-size: 20px; margin: 10px;" CommandName="ShowEditerItem" CommandArgument='<%# Eval("MenuID") %>'></asp:LinkButton></abbr>
                                            <abbr title="Submit Changes" style="background-color: #5b5b5b; color: #CA1A1A;">
                                                <asp:Button ID="lnkEditItem" class="pull-right glyphicon glyphicon-ok" runat="server" Text="Edit" Style="color: #fff; font-size: 20px; margin: 10px;" CommandName="EditMenu" CommandArgument='<%# Eval("MenuID") %>' Visible="false"></asp:Button></abbr>
                                            <div style="/*background: url(../mainimg/main7.jpg) no-repeat; */ background-color: #ca1a1a; height: 180px; width: 100%;">
                                                <asp:HiddenField ID="hdnImageID" runat="server" Value='<%# Eval("ImageID") %>' />
                                                <asp:Image ID="imgMenuImage" runat="server" Width="160px" Height="160px" Style="margin-top: 60px; margin-left: 30px; border: 5px solid #fff; border-radius: 10px;" />
                                            </div>
                                            <div style="height: 33px; border: 0px solid;">
                                                <asp:HiddenField ID="hdnMenuID" runat="server" Value='<%# Eval("MenuID") %>' />
                                                <h4 style="margin-top: 8px; margin-left: 200px; font-weight: bolder;">
                                                    <asp:Literal ID="ltrMenuName" runat="server" Text='<%# Eval("MenuName") %>'></asp:Literal></h4>
                                                <asp:TextBox ID="txtMenuName" runat="server" pattern="[A-Za-z]*" oninput="setCustomValidity('')" oninvalid="setCustomValidity('Enter Menu Name in character format')" MaxLength="15" Style="margin-top: 3px; margin-left: 200px;" Text='<%# Eval("MenuName") %>' Visible="false"></asp:TextBox>
                                            </div>
                                            <div class="col-md-12" style="padding-left: 28px; min-height: 150px; padding-bottom: 10px;">
                                                <!-- Slider -->
                                                <div class="col-md-12">
                                                    <asp:Repeater ID="rptItemList" runat="server" OnItemCommand="rptItemList_ItemCommand">
                                                        <ItemTemplate>
                                                            <div class="col-md-4" style="padding: 10px; margin-top: 35px;">
                                                                <asp:ImageButton ID="imgItemImage" runat="server" ImageUrl='<%# "~/ServiceProvider/Iteam/" + Eval("Name") %>' CommandName="ViewItem" CommandArgument='<%# Eval("ItemID") %>' formnovalidate Style="height: 200px; width: 200px;" />
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                                <%--<div class="col-md-5">
                                                    <div class="col-md-12">
                                                        <div class="col-md-12" style="background-color: #fff; height: 320px; padding: 0px; border: 2px solid #CA1A1A;">
                                                            <div class="col-md-12" style="background-color: #CA1A1A; height: 130px;">
                                                                <div class="col-md-6" style="border: 0px solid;">
                                                                    <asp:Image ID="imgItem" runat="server" Style="width: 120px; height: 120px; margin-top: 40px; border: 7px solid #fff; border-radius: 5px;" />
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <h3 style="margin-top: 90px; margin-left: -15px; color: #fff;">
                                                                        <asp:Literal ID="ltrItemName" runat="server"></asp:Literal></h3>
                                                                </div>
                                                                <div class="col-md-12" style="padding-left: 20px;">
                                                                    <div class="col-md-6">
                                                                        <h4>Price :
                                                                            <asp:Literal ID="ltrItemPrice" runat="server"></asp:Literal></h4>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <asp:Image ID="imgItemType" runat="server" Width="30px" Height="30px" Style="float: right; margin-top: 5px; margin-left: 10px;" />
                                                                        <asp:LinkButton ID="lnkBuy" runat="server"><span class="glyphicon glyphicon-shopping-cart" style="float: right; margin-top: 5px; font-size: 25px; color: #5BBD50;"></span></asp:LinkButton>
                                                                    </div>

                                                                    <div class="col-md-12">
                                                                        <p class="text-justify">
                                                                            <asp:Literal ID="ltrItemDescription" runat="server"></asp:Literal>
                                                                        </p>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>--%>
                                            </div>
                                        </div>
                                    </div>

                                </asp:Panel>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>

                <div id="divProfile" runat="server" class="col-md-9" style="padding: 0px 60px 20px 0px;" visible="false">
                    <div class="col-md-12" style="margin-top: 80px; font-size: 16px; color: #5b5b5b;">
                        <div class="col-md-1"></div>
                        <div class="col-md-8">
                            <asp:LinkButton ID="lnkEditProfile" runat="server" class="pull-right" Style="margin-right: 40px; text-decoration: none;" OnClick="lnkEditProfile_Click">Edit Profile</asp:LinkButton>
                            <asp:Button ID="lnkUpdateProfile" runat="server" Text="Update Profile"  class="pull-right" Style="background-color: transparent; border: 0px solid; margin-right: 40px; text-decoration: none;" OnClick="lnkUpdateProfile_Click" Visible="false" />
                            <table style="margin-top: 50px;">
                                <tr>
                                    <td>Comapany Name</td>
                                    <td style="width: 100px;"></td>
                                    <td>
                                        <asp:Label ID="lblComName" runat="server" Text="Label"></asp:Label>
                                        <asp:TextBox ID="textCompanyName" class="form-control" runat="server" pattern="[A-Za-z]*" Style="width: 100%;" oninput="setCustomValidity('')" oninvalid="setCustomValidity('Enter Company Name in character format')" MaxLength="30" Visible="false"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Name</td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="lnkSPNAME" runat="server" Style="text-decoration: none; color: #5b5b5b;"></asp:Label>
                                        <asp:TextBox ID="txtFName" required="true" class="form-control " runat="server" pattern="[A-Za-z]*" Style="width: 100%;" oninput="setCustomValidity('')" oninvalid="setCustomValidity('Enter First Name in character format')" Text="XYZ" Visible="false"></asp:TextBox>
                                        <asp:TextBox ID="txtLName" required="true" class="form-control"  runat="server" pattern="[A-Za-z]*" Style="width: 100%;" oninput="setCustomValidity('')" oninvalid="setCustomValidity('Enter Last Name in character format')" Text="XYZ" Visible="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td style="padding-top: 30px;">
                                        <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label>
                                        <asp:TextBox ID="txtEmailID" required="" class="form-control" runat="server" Text="abc@gmail.com" Visible="false"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="lblContectNo" runat="server" Text="Label"></asp:Label>
                                        <asp:TextBox ID="txtContactNo" required="" class="form-control" runat="server" Text="+91 9854-985-652" Visible="false"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td style="padding-top: 20px;">
                                        <asp:LinkButton ID="lnkbtnChangePwd" runat="server" Font-Size="18px" Style="text-decoration: none;" OnClick="lnkbtnChangePwd_Click">Change Password</asp:LinkButton>
                                        <asp:TextBox ID="txtOldPassword" required="" TextMode="Password" class="form-control" placeholder="Enter Old Password" runat="server" pattern="^[A-Za-z0-9]+{5,15}$" oninvalid="setCustomValidity('Enter minimum 5 and maximum 15 characters for password')" oninput="setCustomValidity('')" Visible="false"></asp:TextBox>
                                        <asp:TextBox ID="txtPwd" required="" TextMode="Password" class="form-control" placeholder="Enter Password" runat="server" pattern="^[A-Za-z0-9]+{5,15}$" oninvalid="setCustomValidity('Enter minimum 5 and maximum 15 characters for password')" oninput="setCustomValidity('')" Visible="false"></asp:TextBox>
                                        <asp:TextBox ID="txtRPwd" required="" TextMode="Password" class="form-control" placeholder="Enter Conform Password" runat="server" pattern="^[A-Za-z0-9]+{5,15}$" oninvalid="setCustomValidity('Enter minimum 5 and maximum 15 characters for password')" oninput="setCustomValidity('')" OnTextChanged="txtRPwd_TextChanged" Visible="false" AutoPostBack="true"></asp:TextBox>
                                        <asp:Label ID="errorChangePassword" runat="server" Text="Please Enter Same Password." Style="color: #b00b0b;" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="vertical-align: top; padding-top: 20px;">Address</td>
                                    <td style="padding-top: 20px;"></td>
                                    <td style="padding-top: 20px;">
                                        <div id="divAddressDetail" runat="server">
                                            <asp:Literal ID="ltrAddress" runat="server"></asp:Literal>,
                                                <asp:Literal ID="ltrLandmark" runat="server"></asp:Literal>,<br />
                                            <asp:Literal ID="ltrCity" runat="server"></asp:Literal>,
                                                <asp:Literal ID="ltrState" runat="server"></asp:Literal>,<br />
                                            <asp:Literal ID="ltrCountry" runat="server"></asp:Literal>
                                            -
                                            <asp:Literal ID="ltrZipCode" runat="server"></asp:Literal>
                                        </div>
                                        <div id="divAddress" runat="server">
                                            <asp:TextBox ID="textStreet" class="form-control" runat="server"  Text="3, Bhagyoday Soc." OnTextChanged="textStreet_TextChanged"></asp:TextBox>
                                            <asp:TextBox ID="textLandmark" class="form-control" runat="server"  Text="Near Palanpur Patiya" OnTextChanged="textLandmark_TextChanged"></asp:TextBox>
                                            <asp:DropDownList ID="ddCountry" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddCountry_SelectedIndexChanged"></asp:DropDownList>
                                            <asp:DropDownList ID="ddState" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddState_SelectedIndexChanged"></asp:DropDownList>
                                            <asp:DropDownList ID="ddCity" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddCity_SelectedIndexChanged"></asp:DropDownList>
                                            <asp:TextBox ID="textZipCode" class="form-control" runat="server" Text="340900" OnTextChanged="textZipCode_TextChanged"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>



                </div>

                <div id="divOrder" runat="server" class="col-md-9" style="padding: 0px 50px 20px 0px;" visible="false">
                    <div class="col-md-12" style="margin-top: 0px;">
                        <div class="col-md-12">
                            <h2>Order Detail</h2>
                            <hr style="margin-top: 5px; border: 1px solid #808080;" />
                        </div>
                        <asp:Repeater ID="rptOrder" runat="server">
                            <ItemTemplate>
                                <div class="col-md-12" style="margin-top: -20px; margin-bottom: 40px;">
                                    <h3>Date :
                                    <asp:Literal ID="ltrOrderDate" runat="server" Text='<%# Convert.ToDateTime(Eval("Date")).ToShortDateString() %>'></asp:Literal></h3>
                                    <hr style="margin-top: -5px;" />
                                </div>

                                <asp:Repeater ID="rptMealOrder" runat="server" OnItemCommand="rptMealOrder_ItemCommand">
                                    <HeaderTemplate>
                                        <div class="col-md-12" style="margin-top: -20px;">
                                            <h4>: : Meal Order : :</h4>
                                        </div>
                                        <div class="col-md-12">
                                            <div class="col-md-12" style="border: 0px solid; padding: 0px; box-shadow: 0px 0px 4px #aeaeae;">

                                                <div class="col-md-12" style="border: 1px solid #CA1A1A; border-bottom: 0px; font-size: 20px; border-radius: 5px 5px 0px 0px; padding: 0px; background-color: #CA1A1A; color: #fff; font-weight: bolder;">
                                                    <div class="col-md-3 text-center" style="padding: 10px; border-right: 1px solid #CA1A1A;">Meal Name</div>
                                                    <div class="col-md-2 text-center" style="padding: 10px; border-right: 1px solid #CA1A1A;">Time</div>
                                                    <div class="col-md-3 text-center" style="padding: 10px; border-right: 1px solid #CA1A1A;">Price</div>
                                                    <div class="col-md-2 text-center" style="padding: 10px; border-right: 1px solid #CA1A1A;">Quentity</div>
                                                    <div class="col-md-2 text-center" style="padding: 10px;">Status</div>
                                                </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkOrderRecord" runat="server" Style="color: #5b5b5b;" CommandName="ShowOrderDetail" CommandArgument='<%# Eval("OrderID") %>'>
                                            <div class="col-md-12" style="border: 1px solid; border-width: 0px 1px 1px 1px; font-size: 20px; padding: 0px;">
                                                <div class="col-md-3 text-center" style="padding: 12px; border-right: 1px solid;"><%# Eval("MealName") %></div>
                                                <div class="col-md-2 text-center" style="padding: 12px; border-right: 1px solid;"><%# Eval("Time") %></div>
                                                <div class="col-md-3 text-center" style="padding: 12px; border-right: 1px solid;"><%# Eval("MealPrice") %></div>
                                                <div class="col-md-2 text-center" style="padding: 12px; border-right: 1px solid;"><%# Eval("Qty") %></div>
                                                <div class="col-md-2 text-center" style="padding: 5px;">
                                                    <%--<asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("OrderID") %>' />--%>
                                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# "Admin/img/" + Eval("OrderStatus") + ".png" %>' Width="30px" Height="30px" CommandName="EditOrderStatus" CommandArgument='<%# Eval("OrderID") %>' />
                                                </div>
                                            </div>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </div>
                            </div>
                                    </FooterTemplate>
                                </asp:Repeater>



                                <asp:Repeater ID="rptMenuOrder" runat="server" OnItemCommand="rptMenuOrder_ItemCommand">
                                    <HeaderTemplate>
                                        <div class="col-md-12" style="margin-top: 30px;">
                                            <h4>: : Item Order : :</h4>
                                        </div>

                                        <div class="col-md-12" style="margin-bottom: 70px;">
                                            <div class="col-md-12" style="border: 0px solid; padding: 0px; box-shadow: 0px 0px 4px #aeaeae;">

                                                <div class="col-md-12" style="border: 1px solid #CA1A1A; border-bottom: 0px; font-size: 20px; border-radius: 5px 5px 0px 0px; padding: 0px; background-color: #CA1A1A; color: #fff; font-weight: bolder;">
                                                    <div class="col-md-3 text-center" style="padding: 10px; border-right: 1px solid #CA1A1A;">Item Name</div>
                                                    <div class="col-md-2 text-center" style="padding: 10px; border-right: 1px solid #CA1A1A;">Time</div>
                                                    <div class="col-md-3 text-center" style="padding: 10px; border-right: 1px solid #CA1A1A;">Price</div>
                                                    <div class="col-md-2 text-center" style="padding: 10px; border-right: 1px solid #CA1A1A;">Quentity</div>
                                                    <div class="col-md-2 text-center" style="padding: 10px;">Status</div>
                                                </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton6" runat="server" Style="color: #5b5b5b;" CommandName="ShowOrderDetail" CommandArgument='<%# Eval("OrderID") %>'>
                                            <div class="col-md-12" style="border: 1px solid; border-width: 0px 1px 1px 1px; font-size: 20px; padding: 0px;">
                                                <div class="col-md-3 text-center" style="padding: 12px; border-right: 1px solid;"><%# Eval("ItemName") %></div>
                                                <div class="col-md-2 text-center" style="padding: 12px; border-right: 1px solid;"><%# Eval("Time") %></div>
                                                <div class="col-md-3 text-center" style="padding: 12px; border-right: 1px solid;"><%# Eval("ItemPrice") %></div>
                                                <div class="col-md-2 text-center" style="padding: 12px; border-right: 1px solid;"><%# Eval("Qty") %></div>
                                                <div class="col-md-2 text-center" style="padding: 5px;">
                                                    <%--<asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("OrderID") %>' />--%>
                                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# "Admin/img/" + Eval("OrderStatus") + ".png" %>' Width="30px" Height="30px" CommandName="EditOrderStatus" CommandArgument='<%# Eval("OrderID") %>' />
                                                </div>
                                            </div>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </div>
                            </div>
                                    </FooterTemplate>
                                </asp:Repeater>




                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>

                <div id="AddMeal" runat="server" class="col-md-9" visible="false">
                    <div class="col-md-11" style="box-shadow: 0px 0px 8px #350202; color: #808080; padding: 50px; margin-left: 15px; margin-top: 50px; border-radius: 10px;">

                        <h2 style="color: #000000;">Meal</h2>
                        <br />
                        <div class="col-md-6">
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label for="email">Meal Name:</label>
                                    <%-- <input type="email" class="form-control" id="email" placeholder="Enter email">--%>
                                    <asp:TextBox ID="txtmnm" runat="server" AutoPostBack="true" pattern="[A-Za-z ]*[0-9]*" oninvalid="setCustomValidity('enter The Meal Name proper Format  ')" oninput="setCustomValidity('')" MaxLength="15" Class="form-control" OnTextChanged="txtmnm_TextChanged"></asp:TextBox>
                                    <asp:Label ID="errorSameMeal" runat="server" Text="Meal already exist." style="color: #b40a0a;" Visible="false"></asp:Label>
                                </div>

                                <div class="form-group">
                                    <label for="pwd">Meal Description</label>
                                    <asp:TextBox ID="txtmdes" Class="form-control" TextMode="MultiLine" pattern="[A-Za-z]*" oninvalid="setCustomValidity('enter The Meal Desciption in Character Format  ')" oninput="setCustomValidity('')" MaxLength="100" runat="server"></asp:TextBox>
                                </div>


                                <div class="form-group">
                                    <label for="pwd">Meal Time</label>
                                    <asp:DropDownList ID="ddlMeal" runat="server" Class="form-control">
                                        <asp:ListItem Value="Lunch">Lunch</asp:ListItem>
                                        <asp:ListItem Value="Dinner">Dinner</asp:ListItem>
                                        <asp:ListItem Value="Dinner">Both</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label for="pwd">Meal Price</label>
                                    <asp:TextBox ID="txtmprice" Class="form-control" pattern="\d+(\.\d{2})?" oninvalid="setCustomValidity('Enter Meal Price')" oninput="setCustomValidity('')" runat="server"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <label for="pwd">Meal Type:</label><br />
                                    <asp:RadioButton ID="rdVeg" GroupName="MealType" runat="server" Style="padding: 10px;" />Veg<br />
                                    <asp:RadioButton ID="rdNonVeg" GroupName="MealType" runat="server" Style="padding: 10px;" />Non-Veg<br />
                                    <asp:RadioButton ID="rdBoth" GroupName="MealType" runat="server" Style="padding: 10px;" />Both<br />
                                </div>

                                <div class="form-group">
                                    <label for="pwd">Image</label>
                                    <asp:FileUpload ID="FileUpload1" runat="server" /><br />
                                </div>

                            </div>
                        </div>
                        <div class="col-md-12">
                            <asp:Button ID="btnMealAdd" runat="server" Text="Add Meal" class="btn btn-default" Style="float: left; margin-left: 16px; margin-top: 10px;" OnClick="btnMealAdd_Click" />
                        </div>
                    </div>
                </div>

                <div id="AddMenu" runat="server" class="col-md-9" visible="false">
                    <div class="col-md-11" style="box-shadow: 0px 0px 8px #350202; color: #808080; padding: 50px; margin-top: 50px; margin-left: 15px; border-radius: 10px;">

                        <h2 style="color: #000000;">Menu</h2>
                        <br />
                        <div class="col-md-6">
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label id="lblMenu" runat="server" for="email">Menu Name:</label>
                                    <asp:DropDownList ID="ddlMenu" runat="server" Class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMenu_SelectedIndexChanged">
                                    </asp:DropDownList>

                                </div>
                                <asp:LinkButton ID="lnkaddmenu" runat="server" OnClick="lnkaddmenu_Click">Add New Menu</asp:LinkButton>
                                <asp:Panel ID="Panel1" runat="server" Visible="false">

                                    <div class="form-group">

                                        <label for="email">Menu Name:</label>


                                        <asp:TextBox ID="txtaddmnm" runat="server" AutoPostBack="true" pattern="[A-Za-z ]*" oninvalid="setCustomValidity('enter The Menu Name in Character Format  ')" oninput="setCustomValidity('')" MaxLength="15" Class="form-control" OnTextChanged="txtaddmnm_TextChanged"></asp:TextBox>
                                        <asp:Label ID="errorSameManu" runat="server" Text="Menu already exist." style="color: #b40a0a;" Visible="false"></asp:Label>
                                    </div>



                                    <div class="form-group">
                                        <label for="email">Menu Type:</label>
                                        <br />
                                        <asp:RadioButton ID="rptmenuveg" runat="server" Style="padding: 10px;" GroupName="rad" />Veg<br />
                                        <asp:RadioButton ID="rptmenunonveg" runat="server" Style="padding: 10px;" GroupName="rad"/>Non-Veg<br />
                                        <asp:RadioButton ID="rptmenuboth" runat="server" Style="padding: 10px;" GroupName="rad" />Both<br />

                                    </div>

                                    <div class="form-group">
                                        <label for="pwd">Image</label>
                                        <asp:FileUpload ID="FileUpload2" runat="server" /><br />
                                    </div>

                                    <%--<asp:Button ID="btnMenuAdd" runat="server" Text="Add Menu" class="btn btn-default" OnClick="btnMenuAdd_Click" />--%>
                                    <asp:Button ID="btnMenuAdd" runat="server" Text="Add Menu" OnClick="btnMenuAdd_Click" class="btn btn-default" />
                                </asp:Panel>
                            </div>

                            <div class="form-group">
                            </div>

                        </div>
                        <div id="divItem" runat="server" class="col-md-6 control-group" visible="false">

                            <div class="controls">
                                <div class="form-group">
                                    <label id="Label1" runat="server" for="email">Item Name:</label>
                                    <asp:TextBox ID="txtItemName" runat="server" AutoPostBack="true" pattern="[A-Za-z0-9 ]*" oninvalid="setCustomValidity('enter The Item Name in Proper Format  ')" oninput="setCustomValidity('')" MaxLength="15" class="span12 form-control" Style="margin-bottom: 20px; width: 60%;" placeholder="Enter Item Name" OnTextChanged="txtItemName_TextChanged"></asp:TextBox>
                                    <asp:Label ID="errorSameItem" runat="server" Text="Item already exist." style="color: #b40a0a;" Visible="false"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <label for="pwd">Item Description</label>
                                    <asp:TextBox ID="txtItemDesc" Class="form-control" TextMode="MultiLine" pattern="[A-Za-z]*" oninvalid="setCustomValidity('enter The Item Description in Character Format  ')" oninput="setCustomValidity('')" MaxLength="100" runat="server" Style="width: 60%;"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <label for="pwd">Item Price</label>
                                    <asp:TextBox ID="txtItemPrice" Class="form-control" pattern="\d+(\.\d{2})?" oninvalid="setCustomValidity('Enter Item Price')" oninput="setCustomValidity('')" runat="server" Style="width: 60%;"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <label for="email">Item Type:</label>
                                    <br />
                                    <asp:RadioButton ID="rdVegItem" GroupName="ItemType" runat="server" Style="padding: 10px;" />Veg<br />
                                    <asp:RadioButton ID="rdNonVegItem" GroupName="ItemType" runat="server" Style="padding: 10px;" />Non-Veg<br />
                                    <asp:RadioButton ID="rdBothItem" GroupName="ItemType" runat="server" Style="padding: 10px;" />Both<br />

                                </div>

                                <div class="form-group">
                                    <label for="pwd">Meal Time</label>
                                    <asp:DropDownList ID="ddItemType" runat="server" Class="form-control">
                                        <asp:ListItem Value="Lunch">Lunch</asp:ListItem>
                                        <asp:ListItem Value="Dinner">Dinner</asp:ListItem>
                                        <asp:ListItem Value="Dinner">Both</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <div class="form-group">
                                    <label for="pwd">Image</label>
                                    <asp:FileUpload ID="imgImageItem" runat="server" /><br />
                                </div>
                                <asp:Button ID="btnSumbitItem" runat="server" Text="Add Item" class="btn btn-default" Style="margin-top: -10px;" OnClick="btnSumbitItem_Click" />
                            </div>
                        </div>


                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                        </div>
                        <div class="form-group">
                        </div>

                    </div>
                </div>



            </div>
    </form>
</body>
</html>
