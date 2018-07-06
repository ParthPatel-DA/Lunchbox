<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Home" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <style>
        @import url(http://weloveiconfonts.com/api/?family=entypo);

        /* entypo */
        [class*="entypo-"]:before {
            font-family: "entypo", sans-serif;
        }
        a {
            text-decoration: none;
        }
        .sticky-ul {
            list-style: none;
            margin: 0;
            padding: 0;
        }

        #sticky-social {
            padding: 5px;
            border: 1px solid #000000;
            right: 5px;
            position: fixed;
            top: 200px;
            z-index: 100000;
            background: #FFFFFF;
        }
        #sticky-social a {
            background: #333;
            color: #fff;
            display: block;
            height: 35px;
            font: 16px "Open Sans", sans-serif;
            line-height: 35px;
            position: relative;
            text-align: center;
            width: 35px;
        }
        #sticky-social a[class*="facebook"],
        #sticky-social a[class*="facebook"]:hover,
        #sticky-social a[class*="facebook"] span { background: #3b5998; }
      
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="banner wow fadeInUp" data-wow-delay="0.4s" id="Home" style="background: url(../mainimg/main7.jpg) no-repeat; background-size: 100%;">
        <div class="container">
            <aside id="sticky-social">
             <ul class="sticky-ul">
                <li class="sticky-li"><a href="https://www.facebook.com/LunchBox-1201730896561469/?ref=bookmarks" class="entypo-facebook" target="_blank"></a></li>
                 </ul> 
                </aside> 
            <div class="banner-info">
                <div class="banner-info-head text-center wow fadeInLeft" data-wow-delay="0.5s" style="margin-top: -8px;">
                    <h1 style="text-transform: uppercase; font-weight: bold;">ORDER TIFFINS ONLINE IN SURAT</h1>
                    <br />
                    <h3 style="text-transform: uppercase; color: white">Surat tiffin service at its best</h3>
                    <div class="line">
                        <h2>Pick. Order. Eat</h2>
                    </div>
                   
                </div>
                <div class="banner-info-head text-center wow " data-wow-delay="0.5s" style="margin-top: 50px; margin-bottom: 70px;">
                    <%--<form action="http://takeurpick.com/user/order_search" method="post" onsubmit="return validateForm()" name="searchform">--%>

                   <center>
                  <div class="row" style="background: rgba(255,255,255,0.9);
                     border-radius: 10px;
                     padding: 15px 0px 0px 15px;width:75%">
                       <div class="col-md-2 col-sm-6  col-xs-10">
                        <!--<label style="color:white;font-size:20px">Meal Type</label>-->
                        <div class="form-group">
                           <section  style="border: 0.2em solid rgb(226, 68, 37);border-radius: 10px;">
                              <%--<select class="cs-select cs-skin-overlay" name="meal_type" id="meal_type" style="height:40px">--%>
                            <asp:DropDownList ID="DropDownList1" runat="server" Cssclass="cs-select cs-skin-overlay" name="meal_type"  style="height:40px" >
                                <asp:ListItem Value ="1">Lunch</asp:ListItem>
                                <asp:ListItem Value ="2">Dinner</asp:ListItem>
                            </asp:DropDownList>
                          
                           </section>
                        </div>
                     </div>
                      
                     <div class="col-md-2 col-sm-6 col-xs-10">
                        <!--<label style="color:white;font-size:20px">Select City</label>-->
                        <div class="form-group">
                           <section style="border: 0.2em solid rgb(226, 68, 37);border-radius: 10px;">
                                <asp:DropDownList ID="DropDownList2" runat="server" CssClass ="cs-select cs-skin-overlay" name="order"  style="height:40px" >
                                <asp:ListItem Value ="4">Meal</asp:ListItem>
                                <asp:ListItem Value ="5">Menu</asp:ListItem>
                            </asp:DropDownList>
                            
                           </section>
                        
                        </div>
                     </div>
                     <div class="col-md-2 col-sm-6 col-xs-10" style="display:none;">
                        <!--<label style="color:white;font-size:20px">Select City</label>-->
                        <div class="form-group">
                           <section style="border: 0.2em solid rgb(226, 68, 37);border-radius: 10px;">
                              <select class="cs-select cs-skin-overlay" name="city" required style="height:40px">
                                 <!--<option value="" selected disabled>Select City</option>	-->
                                 <option value="Surat" selected>Surat</option>
                              </select>
                           </section>
                        </div>
                     </div>

                     <div id="checkArray">
                      
           <%--        <div class="col-md-2 col-xs-12" style="text-align:left">--%>
                              <div class="col-md-2 col-xs-6 col-sm-6" style="margin-right: -20px">
                           <label style="margin-top:13px;font-size:17px;color:#444;cursor:pointer">
                               <asp:CheckBox ID="chkvege" runat="server"  value="1" style="margin-right: 5px;"></asp:CheckBox> Veg</label>
                        </div>
                    <%--   <div class="col-md-2 col-xs-12" style="text-align:left">--%>
                              <div class="col-md-2 col-xs-6 col-sm-6" style="margin-right :-13px">
                                  <%-- <div class="col-md-2 col-xs-6 col-sm-6" style="margin-right: -40px">--%>
                           <!--<span>Non-Veg</span>-->
                           <label style="margin-top:13px; font-size:17px;color:#444;cursor:pointer"> <%--<input type="checkbox" class="checkbox" name="food_type[]" value="2" style="margin-right: 5px;" > Non-Veg--%>
                               <asp:CheckBox ID ="chknonvege" runat="server"   value="2" style="margin-right:5px;"></asp:CheckBox>Non-Vege
                           </label>
                        </div>
                 <%--       <div class="col-md-2 col-xs-12" style="text-align:left;margin-bottom:15px">--%>
                              <div class="col-md-2 col-xs-6 col-sm-6" style="margin-right:-1px">
                           <!--<span>Combo</span>-->
                           <label style="margin-top:13px;font-size:17px;color:#444;cursor:pointer"> <%--<input type="checkbox" class="checkbox" name="food_type[]" value="3" style="margin-right: 5px;" >--%> 
                              <asp:CheckBox ID ="chkcombo" runat="server" value="3" style="margin-right: 5px;"></asp:CheckBox> Combo</label>
                        </div>
                     </div>
                     <div class="col-md-2 col-xs-12" >
                        <!--<div class="srch">-->
                       <%-- <button class="btn btn-danger" type="submit" style="height: 39px;margin-right: 75px;width: 100px;background-color: #E24425;border-color: #E24425;font-size: 17px;order-radius: 6px;margin-top:5px;margin-bottom: 15px;">SEARCH</button>--%>
                         <asp:Button ID ="btnserch" runat="server" Text="SERCH" AutoPostBack="true" class="btn btn-danger" type="submit" style="height: 39px;margin-right: 75px;width: 100px;background-color: #E24425;border-color: #E24425;font-size: 17px;order-radius: 6px;margin-top:5px;margin-bottom: 15px;" OnClick="btnserch_Click"></asp:Button>
                       <asp:Panel ID="panel1" runat="server" visible="false" style="margin-bottom:10px;" > 
                           <asp:Label runat="server" Text="chose any one"  style="color:red; font-size :15px;" >
                            </asp:Label></asp:Panel>
                         <!--</div>-->
                     </div>
           <%-- </form>--%>
            </div>	
            </center>
                </div>
            </div>
        </div>
    </div>
    <!-- header-section-ends -->
    <!-- content-section-starts -->
    <script>
        function validateForm() {
            //alert('Search');
            var x = document.getElementById("meal_type");
            var xvalue = x.value;
            if (xvalue == null || xvalue == "") {
                alert("Select Meal Type");
                return false;
            }

            var atLeastOneIsChecked = $('#checkArray :checkbox:checked').length > 0;
            var v = atLeastOneIsChecked;
            if (v == false) {
                alert('Please select options from Veg / Non-Veg / Combo');
                return false;
            }


        }
    </script>
    <script>
        (function () {
            [].slice.call(document.querySelectorAll('select.cs-select')).forEach(function (el) {
                new SelectFx(el, {
                    stickyPlaceholder: false
                });
            });
        })();
    </script>
    <div class="content">
        <div class="service-section">
            <div class="service-section-bottom-row">
                <div class="container">
                    <div class="ordering-section-head text-center wow " data-wow-delay="0.4s" style="margin-bottom: 10px">
                        <h3 style="font-weight: bold;">Why Choose us?</h3>
                        <!--<div class="dotted-line">
               <h4>Just 4 steps to follow </h4>
               </div>-->
                    </div>
                    <div class="col-md-3 col-xs-12 service-section-bottom-grid wow fadeIn " data-wow-delay="0.2s">
                        <div class="icon">
                            <%--               <img src="http://takeurpick.com/assets/images/icon1.jpg" class="img-responsive" alt="" />--%>
                            <img src="assets/images/icon1.jpg" class="img-responsive" alt="" />
                        </div>
                        <div class="icon-data">
                            <h4>Swad Ghar Jaisa</h4>
                            <p></p>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div class="col-md-3 col-xs-12  service-section-bottom-grid wow fadeIn " data-wow-delay="0.2s">
                        <div class="icon">
                            <%--<img src="http://takeurpick.com/assets/images/icon2.jpg" class="img-responsive" alt="" />--%>
                            <img src="assets/images/icon2.jpg" class="img-responsive" alt="" />
                        </div>
                        <div class="icon-data">
                            <h4>Home Chefs</h4>
                            <p></p>
                        </div>
                    </div>
                    <div class="col-md-3 col-xs-12  service-section-bottom-grid wow fadeIn " data-wow-delay="0.2s">
                        <div class="icon">
                            <%--<img src="http://takeurpick.com/assets/images/icon3.jpg" class="img-responsive" alt="" />--%>
                            <img src="assets/images/icon3.jpg" class="img-responsive" alt="" />
                        </div>
                        <div class="icon-data">
                            <h4>Well Planned Menus</h4>
                            <p></p>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div class="col-md-3 col-xs-12  service-section-bottom-grid wow fadeIn " data-wow-delay="0.2s">
                        <div class="icon">
                            <%-- <img src="http://takeurpick.com/assets/images/icon3.jpg" class="img-responsive" alt="" />--%>
                            <img src="assets/images/icon3.jpg" class="img-responsive" alt="" />
                        </div>
                        <div class="icon-data">
                            <h4>Badhiya Service</h4>
                            <p></p>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div class="clearfix"></div>
                </div>
            </div>
        </div>
        <div class="special-offers-section">
            <div class="container" style="margin-bottom: -40px;">
                <div class="special-offers-section-head text-center dotted-line">
                    <h4>Tiffins</h4>
                </div>
               <%-- <div class="special-offers-section-grids">
                    <div class="m_3"><span class="middle-dotted-line"></span></div>
                    <div class="container">--%>
                    <div class="special-offers-section-grids">
                    <div class="m_3"><span class="middle-dotted-line"></span></div>
                    <div class="container">

                        <asp:Repeater ID="rptsp" runat="server">
                            <ItemTemplate>
                                <div class="col-md-3" style="background-color: #fff; height: 225px; margin: 6px; padding: 20px;">
                                    <center><h4 style="font-size: 19px; color: rgb(226, 68, 37);"><%# Eval("SN")  %></h4></center>
                                   <hr style="border: 1px solid rgb(226, 68, 37);" />
                                    <asp:Image ID="img1" runat="server" ImageUrl='<%# "~/ServiceProvider/Upload/" + Eval("img") %>' Width="250px" Height="120px" />
                                    <%--<h6 style="font-size: 14px; margin-top: 5px;"> </h6>--%>
                                </div>
                                <div class="col-md-1"></div>
                            </ItemTemplate>
                        </asp:Repeater>



                        <script type="text/javascript">
                            $(window).load(function () {

                                $("#flexiselDemo4").flexisel({
                                    visibleItems: 3,
                                    animationSpeed: 1000,
                                    autoPlay: false,
                                    autoPlaySpeed: 3000,
                                    pauseOnHover: true,
                                    enableResponsiveBreakpoints: true,
                                    responsiveBreakpoints: {
                                        portrait: {
                                            changePoint: 480,
                                            visibleItems: 1
                                        },
                                        landscape: {
                                            changePoint: 640,
                                            visibleItems: 2
                                        },
                                        tablet: {
                                            changePoint: 768,
                                            visibleItems: 3
                                        }
                                    }
                                });

                            });

            </script>
                        <!--<script type="text/javascript" src="js/jquery.flexisel.js"></script>-->
                    </div>
                </div>
                       <%-- <asp:Repeater ID="rptsp" runat="server">
                            <ItemTemplate>
                                <li>
                                    <div class="offer row" style="width: 350px; height: 170px; margin-left: -40px;">
                                        <!--<div class="offer-image col-md-4" style="  width: 36%;">	
                        <img src="http://admin.takeurpick.com/assets/upload/testimonial/1426492533" class="img-responsive" alt=""/>
                        </div>-->
                                        <div class="offer-text" style="width: 100%; padding: 0 0 0 16px">
                                            <div class="col-md-12">
                                                <h4 style="font-size: 19px"><%# Eval("SN")  %></h4>
                                                <%--<h6 style="font-size: 14px"><%# Eval("")  %></h6>--%>
                                                <!--<input type="button" value="Grab It">
                              <span></span>-->
                                         <%--   </div>
                                        </div>
                                        <div class="clearfix"></div>
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>--%>

                        <%--     <ul id="flexiselDemo3">
                              <li>
                 <%-- <figure>
                    <form action="http://takeurpick.com/user/order_all" method="post">
                        <div class="meta-title populartriptitle" style="width:310px"><label style="margin-left: -150px;margin-top: 15px;font-size: 18px;">Ruchira Tiffins</label></div>
                        <input type="text" name="id" value="21" style="display:none;visibility:hidden">
                        <div class="meta-title-day populartripdays pull-right" style="">
                            <button type="submit" onclick="location.href='';"style="color:#E24425;font-size:15px;background:transparent;border-color: transparent;padding-top: 3px;padding-right: 13px;width:70px">Grab it</button> 
                              <asp:Button runat="server" Text="Garb It" style="color:#E24425;font-size:15px;background:transparent;border-color: transparent;padding-top: 3px;padding-right: 13px;width:70px"></asp:Button></div>
                        <img src="http://admin.takeurpick.com/assets/upload/tiffin_vendor/1426401583.jpg" class="img-responsive" alt=""  style="width:310px;height:200px;border-radius:15px" />
                         
                        <div class="offer-image">
                           <!--<img src="http://admin.takeurpick.com/assets/upload/tiffin_vendor/1426401583.jpg" class="img-responsive" alt="" />-->
                                     
                            <asp:Image runat="server"  src="~/upload/1426401583.jpg" class="img-responsive" alt=""  style="width:310px;height:200px;border-radius:15px"></asp:Image>
                             </div>
                         <div class="offer-text" style="display:none">
                         
                           <h4></h4>
                           <p>A home made tiffin service in mumbai who are specialist for the last 10 years in the Santacruz area.</p>
                           <input type="button" value="Grab It" onclick="location.href='http://takeurpick.com/user/order_all';">
                            <asp:Button runat="server" Text="Grab It" ></asp:Button>
                           <span></span>
                        </div>
                     </form>
                  </figure>--%>
                        <%--<div class="clearfix"></div>
               </li>
                              <li>--%>
                        <%-- <figure>
                  <form runat="server" id="form1">
                        <div class="meta-title populartriptitle" style="width:310px"><label style="margin-left: -150px;margin-top: 15px;font-size: 18px;">Mumbai Aroma</label></div>
                        <input type="text" name="id" value="48" style="display:none;visibility:hidden">
                        <div class="meta-title-day populartripdays pull-right" style="">
                            <button type="submit" onclick="location.href='';"style="color:#E24425;font-size:15px;background:transparent;border-color: transparent;padding-top: 3px;padding-right: 13px;width:70px">Grab it</button
                           <asp:Button runat="server" Text="Grab It" style="color:#E24425;font-size:15px;background:transparent;border-color: transparent;padding-top: 3px;padding-right: 13px;width:70px"></asp:Button>
                        </div> 
                        <img src="http://admin.takeurpick.com/assets/upload/tiffin_vendor/1444802935.jpg" class="img-responsive" alt=""  style="width:310px;height:200px;border-radius:15px" />
                                <asp:Image runat="server"  ImageUrl="~/upload/1426401583.jpg"  class="img-responsive"  style="width:310px;height:200px;border-radius:15px"></asp:Image>
                        <div class="offer-image">
                           <!--<img src="http://admin.takeurpick.com/assets/upload/tiffin_vendor/1444802935.jpg" class="img-responsive" alt="" />-->
                           
                        </div>
                        <div class="offer-text" style="display:none">
                           <h4>Mumbai Aroma</h4>
                           <p>A pure Veg Vendor-Mr Sachein Mehta is a new entrant to the tiffin service industry but is slowly establishing himself for Gujarathi Punjabi & Rajhasthani Cusine in the Dadar to Bandra Belt</p>
                           <input type="button" value="Grab It" />
                            <asp:Button runat="server" Text="Grab It"></asp:Button>
                           <span></span>
                        </div>
                   </form>
                  </figure>--%>
                        <%-- <div class="clearfix"></div>
               </li>
                              <li>--%>
                        <%--  <figure>
                     <form action="http://takeurpick.com/user/order_all" method="post">
                        <div class="meta-title populartriptitle" style="width:310px"><label style="margin-left: -150px;margin-top: 15px;font-size: 18px;">Dayas Homemade Tiffin services</label></div>
                        <input type="text" name="id" value="31" style="display:none;visibility:hidden">
                        <div class="meta-title-day populartripdays pull-right" style="">
                            <button type="submit" onclick="location.href='';"style="color:#E24425;font-size:15px;background:transparent;border-color: transparent;padding-top: 3px;padding-right: 13px;width:70px">Grab it</button>
                            <asp:Button runat="server" Text="Grab It" style="color:#E24425;font-size:15px;background:transparent;border-color: transparent;padding-top: 3px;padding-right: 13px;width:70px"></asp:Button>
                        </div>
                        <img src="http://admin.takeurpick.com/assets/upload/tiffin_vendor/1426404915.jpg" class="img-responsive" alt=""  style="width:310px;height:200px;border-radius:15px" />
                         <asp:Image runat="server" src="http://admin.takeurpick.com/assets/upload/tiffin_vendor/1426404915.jpg" class="img-responsive" alt=""  style="width:310px;height:200px;border-radius:15px"></asp:Image>
                        <div class="offer-image">
                           <!--<img src="http://admin.takeurpick.com/assets/upload/tiffin_vendor/1426404915.jpg" class="img-responsive" alt="" />-->
                        </div>
                        <div class="offer-text" style="display:none">
                           <h4><asp:Label runat="server" Text="Dayas Homemade Tiffin services"></asp:Label></h4>
                           <p>A venture started by a 55 year old with the intent of providing motherly tiffin service in mumbai to everyone who needs it.</p>
                           <input type="button" value="Grab It" onclick="location.href='http://takeurpick.com/user/order_all';">
                            <asp:Button runat="server"  Text="Grab It" ></asp:Button>
                           <span></span>
                        </div>
                     </form>
                  </figure>--%>
                        <%--    <div class="clearfix"></div>
               </li>
                              <li>--%>
                        <%--   <figure>
                     <form action="http://takeurpick.com/user/order_all" method="post">
                        <div class="meta-title populartriptitle" style="width:310px"><label style="margin-left: -150px;margin-top: 15px;font-size: 18px;">Sejal Tiffins</label></div>
                        <input type="text" name="id" value="32" style="display:none;visibility:hidden">
                        <div class="meta-title-day populartripdays pull-right" style="">
                            <button type="submit" onclick="location.href='';"style="color:#E24425;font-size:15px;background:transparent;border-color: transparent;padding-top: 3px;padding-right: 13px;width:70px">Grab it</button>
                            <asp:Button runat="server" Text="Garb It" style="color:#E24425;font-size:15px;background:transparent;border-color: transparent;padding-top: 3px;padding-right: 13px;width:70px"></asp:Button>
                        <img src="http://admin.takeurpick.com/assets/upload/tiffin_vendor/1426405243.jpg" class="img-responsive" alt=""  style="width:310px;height:200px;border-radius:15px" />
                            <asp:Image runat="server" src="http://admin.takeurpick.com/assets/upload/tiffin_vendor/1426405243.jpg" class="img-responsive" alt=""  style="width:310px;height:200px;border-radius:15px"></asp:Image>
                        <div class="offer-image">
                           <!--<img src="http://admin.takeurpick.com/assets/upload/tiffin_vendor/1426405243.jpg" class="img-responsive" alt="" />-->
                        </div>
                        <div class="offer-text" style="display:none">
                           <h4><asp:Label runat="server" Text="Sejal Tiffins"></asp:Label></h4>
                           <p>Fire is lit as early as 0400hrs in the morning at Sejal Tiffin service in Mumbai. No, there is no water problem but  Sejal Tiffins prepares and packs 200 tiffins for lunch on a daily basis.</p>
                           <input type="button" value="Grab It" onclick="location.href='http://takeurpick.com/user/order_all';">
                            <asp:Button runat="server" Text="Grab It"></asp:Button>
                           <span></span>
                        </div>
                     </form>
                  </figure>--%>
                        <%--   <div class="clearfix"></div>
               </li>
                              <li>--%>
                        <%--  <figure>
                     <form action="http://takeurpick.com/user/order_all" method="post">
                        <div class="meta-title populartriptitle" style="width:310px"><label style="margin-left: -150px;margin-top: 15px;font-size: 18px;">Moms Touch Tiffin Services</label></div>
                        <input type="text" name="id" value="49" style="display:none;visibility:hidden">
                        <div class="meta-title-day populartripdays pull-right" style="">
                            <button type="submit" onclick="location.href='';"style="color:#E24425;font-size:15px;background:transparent;border-color: transparent;padding-top: 3px;padding-right: 13px;width:70px">Grab it</button>
                            <asp:Button runat="server" Text="Grab It" style="color:#E24425;font-size:15px;background:transparent;border-color: transparent;padding-top: 3px;padding-right: 13px;width:70px"></asp:Button>
                        </div>
                        <img src="http://admin.takeurpick.com/assets/upload/tiffin_vendor/1452919553.jpg" class="img-responsive" alt=""  style="width:310px;height:200px;border-radius:15px" />
                        <asp:Image runat="server" src="http://admin.takeurpick.com/assets/upload/tiffin_vendor/1452919553.jpg" class="img-responsive" alt=""  style="width:310px;height:200px;border-radius:15px"></asp:Image>
                         <div class="offer-image">
                           <!--<img src="http://admin.takeurpick.com/assets/upload/tiffin_vendor/1452919553.jpg" class="img-responsive" alt="" />-->
                        </div>
                        <div class="offer-text" style="display:none">
                           <h4><asp:Label runat="server" Text="Moms Touch Tiffin Services"></asp:Label></h4>
                           <p>A homemade vendor Mrs Kumar has been delighting customers with food that she prepares from her kitchen and thiis just an extension of what she feeds her children.Shes a one stop solution for homemade tiffin service in Mumbai</p>
                           <input type="button" value="Grab It" onclick="location.href='http://takeurpick.com/user/order_all';">
                            <asp:Button runat="server" Text="Grab It"></asp:Button>
                           <span></span>
                        </div>
                     </form>
                  </figure>--%>
                        <%--<div class="clearfix"></div>
               </li>
                              <li>--%>
                        <%--<figure>
                     <form action="http://takeurpick.com/user/order_all" method="post">
                        <div class="meta-title populartriptitle" style="width:310px"><label style="margin-left: -150px;margin-top: 15px;font-size: 18px;">RNP Tiffins</label></div>
                        <input type="text" name="id" value="50" style="display:none;visibility:hidden">
                        <div class="meta-title-day populartripdays pull-right" style="">
                            <button type="submit" onclick="location.href='';"style="color:#E24425;font-size:15px;background:transparent;border-color: transparent;padding-top: 3px;padding-right: 13px;width:70px">Grab it</button>
                            <asp:Button runat="server" Text="Button" style="color:#E24425;font-size:15px;background:transparent;border-color: transparent;padding-top: 3px;padding-right: 13px;width:70px"></asp:Button>
                        </div>
                        <img src="http://admin.takeurpick.com/assets/upload/tiffin_vendor/1453095490.jpg" class="img-responsive" alt=""  style="width:310px;height:200px;border-radius:1 />
                        <asp:Image runat="server" src="http://admin.takeurpick.com/assets/upload/tiffin_vendor/1453095490.jpg" class="img-responsive" alt=""  style="width:310px;height:200px;border-radius:15px"></asp:Image>
                          <div class="offer-image">
                           <!--<img src="http://admin.takeurpick.com/assets/upload/tiffin_vendor/1453095490.jpg" class="img-responsive" alt="" />-->
                        </div>
                        <div class="offer-text" style="display:none">
                           <h4<asp:Label runat="server" Text="RNP Tiffins"></asp:Label>></h4>
                           <p>For The Love of North Indian Food Mr Paras has started this venture after leaving his corporate Job</p>
                           <input type="button" value="Grab It" onclick="location.href='http://takeurpick.com/user/order_all';">
                            <asp:Button runat="server" Text="Grab It"></asp:Button>
                           <span></span>
                        </div>
                     </form>
                  </figure>--%>
                        <%-- <div class="clearfix"></div>
               </li>
                              <li>--%>
                        <%--   <figure>
                     <form action="http://takeurpick.com/user/order_all" method="post">
                        <div class="meta-title populartriptitle" style="width:310px"><label style="margin-left: -150px;margin-top: 15px;font-size: 18px;">Happy Meal</label></div>
                        <input type="text" name="id" value="39" style="display:none;visibility:hidden">
                        <div class="meta-title-day populartripdays pull-right" style="">
                         <button type="submit" onclick="location.href='';"style="color:#E24425;font-size:15px;background:transparent;border-color: transparent;padding-top: 3px;padding-right: 13px;width:70px">Grab it</button>
                             <asp:Button runat="server" Text="Button" style="color:#E24425;font-size:15px;background:transparent;border-color: transparent;padding-top: 3px;padding-right: 13px;width:70px"></asp:Button>
                        </div>
                       
                         <img src="http://admin.takeurpick.com/assets/upload/tiffin_vendor/1432624255.jpg" class="img-responsive" alt=""  style="width:310px;height:200px;border-radius:15px" />
                            <asp:Image runat="server" src="http://admin.takeurpick.com/assets/upload/tiffin_vendor/1432624255.jpg" class="img-responsive" alt=""  style="width:310px;height:200px;border-radius:15px"></asp:Image>
                          <div class="offer-image">
                           <!--<img src="http://admin.takeurpick.com/assets/upload/tiffin_vendor/1432624255.jpg" class="img-responsive" alt="" />-->
                        </div>
                        <div class="offer-text" style="display:none">
                           <h4><asp:Label runat="server" Text="Happy Meal"></asp:Label></h4>
                           <p>Ms Gulnaaz Known for her delicious homemade cuisine that is freshly made and delivered on order.Shes a specialist for non veg tiffin service in Mumbai.</p>
                           <input type="button" value="Grab It" onclick="location.href='http://takeurpick.com/user/order_all';">
                          <asp:Button runat="server" Text="Grab It"></asp:Button>
                             <span></span>
                        </div>
                     </form>
                  </figure>--%>
                        <%--<div class="clearfix"></div>
               </li>--%>
                        <%--    <script type="text/javascript">
                                  $(window).load(function () {

                                      $("#flexiselDemo3").flexisel({
                                          visibleItems: 3,
                                          animationSpeed: 1000,
                                          autoPlay: false,
                                          autoPlaySpeed: 3000,
                                          pauseOnHover: true,
                                          enableResponsiveBreakpoints: true,
                                          responsiveBreakpoints: {
                                              portrait: {
                                                  changePoint: 480,
                                                  visibleItems: 1
                                              },
                                              landscape: {
                                                  changePoint: 640,
                                                  visibleItems: 2
                                              },
                                              tablet: {
                                                  changePoint: 768,
                                                  visibleItems: 3
                                              }
                                          }
                                      });

                                  });

               </script>--%>

                        <%--            <script type="text/javascript" src="http://takeurpick.com/assets/js/jquery.flexisel.js"></script>--%>
                    </div>
                </div>
            </div>
        </div>
        <style>
            .test {
                background: url("http://takeurpick.com/assets/images/food_3.jpg") no-repeat;
                background-size: 1360px;
            }
        </style>
        <div class="test">
            <div class="ordering-section" id="Order" style="background-color: rgba(0, 0, 0, 0.71);">
                <div class="container">
                    <div class="ordering-section-head text-center wow " data-wow-delay="0.4s">
                        <h3 style="color: white">Ordering food was never so easy</h3>
                        <br>
                        <h3 style="color: white">Pick. Order. Eat</h3>
                        <div class="dotted-line">
                            <h4 style="color: white">Just 3 steps to follow </h4>
                        </div>
                    </div>
                    <div class="ordering-section-grids">
                        <div class="col-md-4 ordering-section-grid">
                            <div class="ordering-section-grid-process wow " data-wow-delay="0.4s">
                                <i class="one"></i>
                                <br>
                                <i class="one-icon"></i>
                                <p>
                                    Pick
                                    <br>
                                    <span>Your Supplier</span>
                                </p>
                                <label></label>
                            </div>
                        </div>
                        <div class="col-md-4 ordering-section-grid">
                            <div class="ordering-section-grid-process wow " data-wow-delay="0.4s">
                                <i class="two"></i>
                                <br>
                                <i class="two-icon"></i>
                                <p>
                                    Order 
                                    <br>
                                    <span>Your Cuisine</span>
                                </p>
                                <label></label>
                            </div>
                        </div>
                        <div class="col-md-4 ordering-section-grid">
                            <div class="ordering-section-grid-process wow " data-wow-delay="0.4s">
                                <i class="three"></i>
                                <br>
                                <i class="three-icon"></i>
                                <p>
                                    Eat  
                                    <br>
                                    <span>Enjoy Your Tiffin </span>
                                </p>

                            </div>
                        </div>
                        <!-- <div class="col-md-3 ordering-section-grid">
               <div class="ordering-section-grid-process wow " data-wow-delay="0.4s">
                  <i class="four"></i><br>
                  <i class="four-icon"></i>
                  <p>Enjoy <span>Your Tiffin </span></p>
               </div>
            </div>-->
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
        </div>



        <div class="special-offers-section">
            <div class="container">
                <div class="special-offers-section-head text-center dotted-line">
                    <h4 style="font-size: 3em">Testimonials</h4>
                </div>
                <div class="special-offers-section-grids">
                    <div class="m_3"><span class="middle-dotted-line"></span></div>
                    <div class="container">

                        <asp:Repeater ID="rptfb" runat="server">
                            <ItemTemplate>
                                <div class="col-md-3" style="background-color: #fff; height: 160px; margin: 6px; padding: 20px;">
                                    <center><h4 style="font-size: 19px; color: rgb(226, 68, 37);"><%# Eval("FN")  %></h4></center>
                                    <hr style="border: 1px solid rgb(226, 68, 37);" />
                                    <h6 style="font-size: 14px; margin-top: 5px;"><%# Eval("FD")  %></h6>
                                </div>
                                <div class="col-md-1"></div>
                            </ItemTemplate>
                        </asp:Repeater>



                        <script type="text/javascript">
                            $(window).load(function () {

                                $("#flexiselDemo4").flexisel({
                                    visibleItems: 3,
                                    animationSpeed: 1000,
                                    autoPlay: false,
                                    autoPlaySpeed: 3000,
                                    pauseOnHover: true,
                                    enableResponsiveBreakpoints: true,
                                    responsiveBreakpoints: {
                                        portrait: {
                                            changePoint: 480,
                                            visibleItems: 1
                                        },
                                        landscape: {
                                            changePoint: 640,
                                            visibleItems: 2
                                        },
                                        tablet: {
                                            changePoint: 768,
                                            visibleItems: 3
                                        }
                                    }
                                });

                            });

            </script>
                        <!--<script type="text/javascript" src="js/jquery.flexisel.js"></script>-->
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            $(window).load(function () {

                $("#flexiselDemo4").flexisel({
                    visibleItems: 3,
                    animationSpeed: 1000,
                    autoPlay: false,
                    autoPlaySpeed: 3000,
                    pauseOnHover: true,
                    enableResponsiveBreakpoints: true,
                    responsiveBreakpoints: {
                        portrait: {
                            changePoint: 480,
                            visibleItems: 1
                        },
                        landscape: {
                            changePoint: 640,
                            visibleItems: 2
                        },
                        tablet: {
                            changePoint: 768,
                            visibleItems: 3
                        }
                    }
                });

            });

        </script>
        <script type="text/javascript" src="js/jquery.flexisel.js"></script>
    </div>
    </div>
   </div>
</div>
    <div class="service-section">
        <div class="service-section-bottom-row">
            <div class="container">
                <div class="ordering-section-head text-center wow bounceInRight" data-wow-delay="0.4s" style="margin-bottom: 10px">
                    <h3 style="margin-bottom: 30px">Media / Affiliation </h3>
                    <!--<div class="dotted-line">
               <h4>Just 4 steps to follow </h4>
               </div>-->
                </div>
                <div class="col-md-4 col-xs-12 service-section-bottom-grid wow bounceIn " data-wow-delay="0.2s">
                    <div class="">
                        <a href="http://yourstory.com/2015/04/tiffin-services-marketplace-mumbai-takeurpick/" target="_blank">
                            <img src="http://takeurpick.com/assets/images/your_story.png" class="img-responsive" alt="" data-toggle="tooltip" data-placement="top" title="Your Story" /></a>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <div class="col-md-4 col-xs-12  service-section-bottom-grid wow bounceIn " data-wow-delay="0.2s">
                    <div class="">
                        <a href="http://www.socialproma.com/takeurpick-pickordereat-best-homely-food/" target="_blank">
                            <img src="http://takeurpick.com/assets/images/social_promo.png" class="img-responsive" data-toggle="tooltip" data-placement="top" title="Social Promo" alt="" /></a>
                    </div>
                </div>
                <div class="col-md-4 col-xs-12  service-section-bottom-grid wow bounceIn " data-wow-delay="0.2s">
                    <div class="" style="margin-top: -60px;">
                        <a class="zocalo_logo" href="http://zocalo.in/" target="_blank" data-toggle="tooltip" data-placement="top" title="Zocalo"></a>
                    </div>
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>

</asp:Content>

