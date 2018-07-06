<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Menu1.aspx.cs" Inherits="Menu" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .chkChoice input {
            margin-left: -20px;
        }

        .chkChoice td {
            padding-left: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container ct" style="margin-top: 0px; background: rgba(0, 0, 0, 0.7); width: 100%;">
                <div class="row">
                    <!-- SIDEBAR -->
                    <div class="col-xs-12 col-sm-3 col-md-2">
                    </div>
                    <div class="col-xs-12 col-sm-9 col-md-10" style="top: 15px; height: 50px;">
                        <%--       <form  method="post"  onsubmit="return validateForm1()" >--%>
                        <!--<label>Search</label>-->
                        <form method="post">
                            <div class="col-md-1 col-sm-6 col-xs-3" style="padding-right: 9em;">
                                <!--<label style="color:white;font-size:20px">Select City</label>-->
                                <div class="form-group">
                                    <section>
                                        <%-- <select class="cs-select cs-skin-overlay" name="order" id="order_s" style="height:40px;  width: 100px;border-color: transparent;background: grey;color: white;" required >
                        <option value="" disabled style="color:white">Select</option>
                        <option value="tiffin"  style="color:white" >Tiffin</option>
                        <!--<option value="instant_ordering"  style="color:white" >Instant Ordering</option>-->
                     </select>--%>
                                        <asp:DropDownList ID="ddltime" runat="server" Style="height: 40px; width: 100px; border-color: transparent; background: grey; color: white; border-radius: 5px;">
                                            <asp:ListItem Value="1" Text="Lunch" style="color: white;"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Dinner" style="color: white;"></asp:ListItem>
                                        </asp:DropDownList>
                                    </section>
                                </div>
                            </div>
                            <div class="col-md-1 col-sm-6  col-xs-3" style="padding-right: 10em;">
                                <!--<label style="color:white;font-size:20px">Meal Type</label>-->
                                <div class="form-group">
                                    <section>
                                        <%--<select class="cs-select cs-skin-overlay" name="meal_type" id="meal" style="height:40px;border-color: transparent;background: grey;color: white;width: 120px;" required >
                        <option value="" selected disabled style="color:white">Meal Type</option>
                        <option value="Lunch" style="color:white">Lunch</option>
                        <!-- <option value="Breakfast">Breakfast</option>-->
                        <option value="Dinner" style="color:white">Dinner</option>
                     </select>--%>
                                        <asp:DropDownList ID="ddlmtype" runat="server" Style="height: 40px; width: 120px; border-color: transparent; background: grey; color: white; border-radius: 5px;">
                                            <asp:ListItem Value="4" Text="Meal" style="color: white;"></asp:ListItem>
                                            <asp:ListItem Value="5" Text="Menu" style="color: white;"></asp:ListItem>
                                            <%-- <asp:ListItem Value="Select" Text="Dinner" style="color:white;"></asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </section>
                                </div>
                            </div>
                            <div id="checkArray1">
                                <div class="col-md-2 col-xs-6 col-sm-6" style="margin-right: -60px">
                                    <!--<span>Veg</span>-->
                                    <label style="margin-top: 8px; color: #E24425">
                                        <asp:CheckBox runat="server" ID="chkvegmeal" Style="margin-right: 5px; margin-top: 0px;" value="1"></asp:CheckBox>
                                        <%--        <input type="checkbox" class="checkbox" id="vegmeal" style="margin-right: 5px;margin-top: 0px;" value="1" name="food_type[]" checked>--%> veg</label>
                                </div>
                                <div class="col-md-2 col-xs-6 col-sm-6" style="margin-right: -40px">
                                    <!--<span>Non-Veg</span>-->
                                    <label style="margin-top: 8px; color: #E24425">
                                        <%--<input type="checkbox" id="nonvegmeal" style="margin-right: 5px;margin-top: 0px;" value="2" name="food_type[]" 
                     >--%>
                                        <asp:CheckBox runat="server" ID="chknonvegmeal" Style="margin-right: 5px; margin-top: 0px;" value="2"></asp:CheckBox>
                                        Non-Veg</label>
                                </div>
                                <div class="col-md-2 col-xs-6 col-sm-6" style="margin-right: -50px">
                                    <!--<span>Combo</span>-->
                                    <label style="margin-top: 8px; color: #E24425">
                                        <%--<input type="checkbox" id="combomeal" style="margin-right: 5px;margin-top: 0px;" value="3"  name="food_type[]" /> --%>
                                        <asp:CheckBox runat="server" ID="Combo" Style="margin-right: 5px; margin-top: 0px;" value="3"></asp:CheckBox>
                                        Combo</label>
                                    <!--<button type="submit" style="margin-top: 6px; margin-left: 15px"><i class="iconfont-search"></i></button>-->
                                </div>
                            </div>
                            <div class="col-md-2 col-xs-12 col-sm-6">
                                <!--<div class="srch">-->
                                <asp:Button ID="btnserch" runat="server" Text="SERCH" class="btn btn-danger" type="submit" Style="height: 39px; margin-right: 75px; width: 100px; background-color: #E24425; border-color: #E24425; font-size: 17px; order-radius: 6px; margin-top: 4px; margin-bottom: 15px;" OnClick="btnserch_Click" formnovalidate=""></asp:Button>
                                <asp:Panel ID="panel1" runat="server" Visible="false" Style="margin-bottom: 10px;">
                                    <asp:Label runat="server" Text="chose any one" Style="color: red; font-size: 15px;"></asp:Label>
                                </asp:Panel>
                                <%-- <button class="btn btn-danger" type="submit" style="height: 35px;margin-right: 30px;margin-top:2px;width: 100px;background-color: #E24425;border-color: #E24425;font-size: 15px;border-radius: 6px;">SEARCH</button>--%>
                                <!--</div>-->
                            </div>
                            <%-- <div class="col-md-2 col-xs-12 col-sm-6" style="margin-top:7px;margin-left:-42px;">
                <ul class="unstyled inline-li li-m-r-l-sm pull-right ">
               <%--   <li><a class="round-icon active" href="#" data-toggle="tooltip" data-layout="grid" data-title="Switch to List Grid Mode"><i class="iconfont-th"style="font-size:25px"></i></a></li>--%>
                            <%--<li><a class="round-icon" href="#" data-toggle="tooltip" data-layout="list" data-title="Switch to List View Mode"><i class="iconfont-list"style="font-size:25px"></i></a></li>
               </ul>--%>
                    </div>
                    --%>
        <%-- </form>--%>
                </div>
            </div>

            <!-- SITE MAIN CONTENT -->
            <main id="main-content" role="main">
                <div class="container-fluid" style="margin-top: 100px; padding-left: 30px; padding-right: 30px;">
                    <div class="row">
                        <div class="m-t-b clearfix">
                            <!-- SIDEBAR -->
                            <aside class="col-xs-12 col-sm-3 col-md-3">
                                <section class="sidebar push-up" style="background: rgba(76, 76, 76, 1); border-radius: 15px;">
                                    <!-- PRODUCT FILTER -->
                                    <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                                        <div class="panel panel-default" style="height: 33px">
                                            <div class="panel-heading" role="tab" id="heading2" style="border-radius: 8px; background-color: rgb(76, 76, 76); height: 90px;">
                                                <h4 class="panel-title">
                                                    <a class="collapsed" data-toggle="" data-parent="#accordion" href="#collapse2" aria-expanded="false" aria-controls="collapse2" style="color: white"></a>
                                                </h4>
                                            </div>
                                        </div>
                                        <div class="panel panel-default" style="height: 45px; margin-top: 0px;">
                                            <div class="panel-heading" role="tab" id="heading2" style="background-color: rgb(226, 68, 37); height: 46px">
                                                <h4 class="panel-title" style="padding-top: 5px">
                                                    <%-- <a class="collapsed" data-toggle="" data-parent="#accordion" href="#collapse2" aria-expanded="false" aria-controls="collapse2" style="color:white">
                              Search Filter
                              </a>--%>
                                                    <asp:LinkButton runat="server" class="collapsed" data-toggle="" data-parent="#accordion" href="#collapse2" aria-expanded="false" aria-controls="collapse2" Style="color: white">serch filter</asp:LinkButton>

                                                </h4>
                                            </div>
                                        </div>
                                        <div id="divMealTypeSelector" runat="server" class="panel panel-default" visible="false">
                                            <div class="panel-heading" role="tab" id="heading2" style="background-color: rgb(76, 76, 76);">
                                                <h4 class="panel-title">
                                                    <asp:LinkButton runat="server" class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapse2" aria-expanded="false" aria-controls="collapse2">Delivery Boy</asp:LinkButton>
                                                </h4>
                                            </div>
                                            <div id="collapse2" class="panel-collapse collapse" role="tabpanel" aria-labelledby="heading2">
                                                <div class="panel-body">
                                                    <div class="side-section-content">
                                                        <ul id="filter-by-cash" class="vmenu unstyled">
                                                            <li>
                                                                <asp:CheckBox ID="chkMealSerAll" runat="server" AutoPostBack="true" data-labelposition="right" Style="margin-right: 5px;" value="" OnCheckedChanged="chkMealSerAll_CheckedChanged"></asp:CheckBox>
                                                                All
                                                       <ul>
                                                           <%--<input type="checkbox" id="c1" class="prettyCheckable" data-label="50-100" data-labelPosition="right" value="c1" />--%>
                                                           <%--<asp:Repeater ID="rptMealType" runat="server">
                                                               <ItemTemplate>
                                                                   <li><asp:CheckBox ID="chkMealType" runat="server" on data-labelPosition="right" Style="margin-right: 5px;" Text='<%# "&nbsp;&nbsp;&nbsp;" + Eval("CompanyName") %>'></asp:CheckBox></li>
                                                               </ItemTemplate>
                                                           </asp:Repeater>--%>
                                                           <asp:CheckBoxList ID="chkMealSer" AutoPostBack="true" runat="server" CssClass="chkChoice" OnSelectedIndexChanged="chkMealSer_SelectedIndexChanged"></asp:CheckBoxList>
                                                       </ul>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="divServiceProviderSelector" runat="server" class="panel panel-default">
                                            <div class="panel-heading" role="tab" id="heading4" style="background-color: rgb(76, 76, 76);">
                                                <%-- <h4 class="panel-title">
                              <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapse4" aria-expanded="false" aria-controls="collapse4" >
                               Home Chefs                               </a>
                           </h4>--%>
                                                <h4 class="panel-title">
                                                    <asp:LinkButton runat="server" class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapse4" aria-expanded="false" aria-controls="collapse4">Rateing Wise</asp:LinkButton>
                                                </h4>
                                            </div>
                                            <div id="collapse4" class="panel-collapse collapse" role="tabpanel" aria-labelledby="heading4">
                                                <div class="panel-body">
                                                    <div class="side-section-content">
                                                        <ul id="filter-by-food_partners" class="vmenu unstyled">

                                                            <li>
                                                                <%-- <input type="checkbox" id="check-women" class="prettyCheckable" data-label="All" data-labelPosition="right" value="partner" />--%>
                                                                <asp:CheckBox ID="chkSPRate" runat="server" AutoPostBack="true" data-labelposition="right" Style="margin-right: 5px;" value="Jain" OnCheckedChanged="chkSPRate_CheckedChanged"></asp:CheckBox>
                                                                All
                                 <ul>
                                     <li>
                                         <asp:CheckBox ID="chkRate5" runat="server" AutoPostBack="true" data-labelPosition="right" Style="margin-right: 5px;" Text="&nbsp;&nbsp;&nbsp;5 Stars" OnCheckedChanged="chkRate5_CheckedChanged"></asp:CheckBox></li>
                                     <li>
                                         <asp:CheckBox ID="chkRate4" runat="server" AutoPostBack="true" data-labelPosition="right" Style="margin-right: 5px;" Text="&nbsp;&nbsp;&nbsp;4 Stars" OnCheckedChanged="chkRate4_CheckedChanged"></asp:CheckBox></li>
                                     <li>
                                         <asp:CheckBox ID="chkRate3" runat="server" AutoPostBack="true" data-labelPosition="right" Style="margin-right: 5px;" Text="&nbsp;&nbsp;&nbsp;3 Stars" OnCheckedChanged="chkRate3_CheckedChanged"></asp:CheckBox></li>
                                     <li>
                                         <asp:CheckBox ID="chkRate2" runat="server" AutoPostBack="true" data-labelPosition="right" Style="margin-right: 5px;" Text="&nbsp;&nbsp;&nbsp;2 Stars" OnCheckedChanged="chkRate2_CheckedChanged"></asp:CheckBox></li>
                                     <li>
                                         <asp:CheckBox ID="chkRate1" runat="server" AutoPostBack="true" data-labelPosition="right" Style="margin-right: 5px;" Text="&nbsp;&nbsp;&nbsp;1 Stars" OnCheckedChanged="chkRate1_CheckedChanged"></asp:CheckBox></li>
                                     <%--<asp:Repeater ID="rptServiceProvider" runat="server">
                                         <itemtemplate>
                                             <li>
                                                 <asp:CheckBox ID="chkServiceProvider" runat="server" data-labelPosition="right" Style="margin-right: 5px;"></asp:CheckBox>
                                             </li>
                                         </itemtemplate>
                                     </asp:Repeater>--%>
                                 </ul>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="panel panel-default" style="border-bottom-right-radius: 15px; border-bottom-left-radius: 15px;">
                                            <div class="panel-heading" role="tab" id="heading8" style="background-color: rgb(76, 76, 76);">
                                                <h4 class="panel-title">
                                                    <%-- <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapse8" aria-expanded="false" aria-controls="collapse8" >
                              Deliverable Locations : Other
                              </a>--%>

                                                    <asp:LinkButton runat="server" class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapse8" aria-expanded="false" aria-controls="collapse8">Location</asp:LinkButton>
                                                </h4>
                                            </div>
                                            <div id="collapse8" class="panel-collapse collapse" role="tabpanel" aria-labelledby="heading8">
                                                <div class="panel-body">
                                                    <div class="side-section-content">
                                                        <ul id="filter-by-other" class="vmenu unstyled">
                                                            <li>
                                                                <%-- <input type="checkbox" id="check-women" class="prettyCheckable" data-label="All" data-labelPosition="right" value="meal_type" />--%>
                                                                <asp:CheckBox ID="chkLocation" runat="server" AutoPostBack="true" data-labelposition="right" Style="margin-right: 5px;" value="All" OnCheckedChanged="chkLocation_CheckedChanged"></asp:CheckBox>
                                                                All
                                      
                                        <ul>
                                            <asp:CheckBoxList ID="chkLstLocation" runat="server" AutoPostBack="true" CssClass="chkChoice" OnSelectedIndexChanged="chkLstLocation_SelectedIndexChanged"></asp:CheckBoxList>
                                        </ul>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </section>
                            </aside>
                            <section class="col-xs-12 col-sm-9 col-md-9" style="margin-top: -150px; border: 0px solid;">
                                <%--<section class="products-wrapper" style="margin-top: 80px;">--%>
                                <%--<div class="panel-heading" role="tab" id="heading2" style="background-color: transparent" style="display: none">
                                <h4 class="panel-title">
                                    <a class="collapsed" data-toggle="collapse" data-parent="#" href="#" aria-expanded="false" aria-controls="collapse2" style="color: white">
                                        <header class="products-header">
                                            <div class="row">
                                                <div class="col-xs-12 col-sm-12 col-md-6 center-xs">
                                                </div>
                                                <div class="space30 visible-xs"></div>
                                                <!-- PAGINATION -->
                                                <div class="col-xs-12 col-sm-12 col-md-6 center-xs" style="display: none">
                                                    <ul class="unstyled inline-li li-m-r-l-sm pull-right">
                                                        <li><a class="round-icon" href="#" data-toggle="tooltip" data-layout="list" data-title="Switch to List View Mode"><i class="iconfont-list"></i></a></li>
                                                    </ul>
                                                    
                                                </div>
                                            </div>
                                        </header>
                                    </a>
                                </h4>
                            </div>--%>

                                <%-- <script type="text/javascript">
                         $(document).ready(function () {
                             $(document).on('click', '.like21', function () {
                                 var i = $(this).attr('value');
                                 $.ajax({
                                     'url': 'http://takeurpick.com/user/like',
                                     'type': 'POST', //the way you want to send data to your URL
                                     'data': { 'product': i },
                                     'success': function (data) {

                                         //probably this request will return anything, it'll be put in var "data"
                                         //alert(data);
                                         $('#like21').html(data);


                                     }

                                 }
                                 );


                             });
                         });
                     </script>--%>


                                <asp:Panel ID="Panel3" runat="server" Visible="false" Style="padding-top: 70px;">
                                    <asp:Repeater ID="rptmenu" runat="server" OnItemCommand="rptmenu_ItemCommand">
                                        <ItemTemplate>
                                            <div id="divViewMenu" runat="server" class="col-md-12" style="border: 1px solid rgba(0, 0, 0, 0.8); padding: 0px; margin-top: 20px; border-width: 2px 2px 2px 2px; border-radius: 10px;">

                                                <div class="col-md-12" style="border: 0px solid rgba(0,0,0,0.8); margin-top: 20px;">

                                                    <div class="col-md-4">
                                                        <asp:HiddenField ID="hdnMenuID" runat="server" Value='<%# Eval("MenuID") %>' />
                                                        <asp:Image ID="Image1" class="img-responsive" runat="server" ImageUrl='<%# "/ServiceProvider/Menu/" + Eval("img") %>' Style="border-radius: 5px;" Width="200px" Height="200px" />
                                                    </div>
                                                    <div class="col-md-8" style="padding: 0px; margin-bottom: 20px;">
                                                        <div class="col-md-12" style="margin-top: 120px;">
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("MenuName") %>' Style="font-size: 35px; margin-left: -35px;"></asp:Label><br />
                                                            <asp:LinkButton ID="LinkButton1" runat="server" Style="margin-left: -35px;" CommandName="ViewItem" CommandArgument='<%# Eval("MenuID") %>'>View Item</asp:LinkButton>
                                                            <asp:Image ID="Image9" class="img-responsive" runat="server" ImageUrl='<%# "~/Icon/" + Eval("MenuType") + ".png" %>' Height="20px" Width="20px" Style="float: right; margin-top: 20px; margin-right: 20px;" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12"></div>
                                                    <asp:Panel ID="divItem" runat="server" class="col-md-12" Style="margin-bottom: 50px;" Visible="false">
                                                        <hr style="border: 1px solid rgba(76, 76, 76, 1);" />
                                                        <asp:Repeater ID="rptitem" runat="server" OnItemCommand="rptitem_ItemCommand">
                                                            <ItemTemplate>

                                                                <div class="col-md-6" style="border: 0px solid rgba(0,0,0,0.8); margin-top: 20px; border: 0px solid; margin-bottom: 10px;">
                                                                    <div class="col-md-12" style="padding: 0px; border: 1px solid; padding: 20px 10px 20px 10px;">
                                                                        <div class="col-md-6">
                                                                            <asp:Image ID="Image3" class="img-responsive" runat="server" ImageUrl='<%# "ServiceProvider/Iteam/" + Eval("img") %>' Style="border-radius: 5px;" Width="200px" Height="200px" />
                                                                        </div>
                                                                        <div class="col-md-6" style="padding: 0px;">
                                                                            <div class="col-md-12">
                                                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("ItemName") %>' Style="font-size: 25px;"></asp:Label>
                                                                                <%-- <span class="glyphicon glyphicon-shopping-cart" style="float: right; color: rgb(91, 189, 80); font-size: 20px; margin-right: 13px; margin-top: 10px;"></span>--%>
                                                                                <asp:LinkButton ID="LinkButton10" runat="server" CommandName="CartItem" CommandArgument='<%# Eval("ItemID") %>'><span class="glyphicon glyphicon-shopping-cart" style="float: right; margin-top:10px; margin-right: 13px; font-size: 20px; color: #5BBD50;"></span></asp:LinkButton>
                                                                                <asp:Image ID="Image4" class="img-responsive" runat="server" ImageUrl='<%# "~/Icon/" + Eval("ItemType") + ".png" %>' Height="20px" Width="20px" Style="float: right; margin-top: 10px; margin-right: 20px;" />
                                                                                <h4 style="margin-bottom: 10px;">
                                                                                    <%--                                                                            <asp:Label ID="Label9" runat="server" Text='<%# Eval("SPname") %>' Style="color: #E24425;"></asp:Label></h4>--%>
                                                                                    <asp:LinkButton ID="lnkSPName" runat="server" Text='<%# Eval("SPname") %>' CommandName="ViewSPProfile" CommandArgument='<%# Eval("ItemID") %>' Style="color: #E24425;"></asp:LinkButton></h4>
                                                                                <div class="col-md-12 text-justify" style="padding: 0px; height: 70px; border: 0px solid; overflow: scroll; overflow-x: hidden; margin-top: 10px;">
                                                                                    <asp:Literal ID="Literal3" runat="server" Text='<%# Eval("ItemDescription") %>'></asp:Literal>
                                                                                </div>
                                                                                <div class="col-md-12" style="padding: 0px; margin-top: 10px;">
                                                                                    <asp:HiddenField ID="hdnItemID" runat="server" Value='<%# Eval("ItemID") %>' />
                                                                                    <asp:Image ID="imgRate" runat="server" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>


                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </asp:Panel>
                                                </div>




                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </asp:Panel>

                                <asp:Panel ID="Panel2" runat="server" Visible="false">

                                    <asp:Repeater ID="rptmeal" runat="server" OnItemCommand="rptmeal_ItemCommand1">
                                        <ItemTemplate>
                                            <div class="col-md-6" style="">

                                                <div class="col-md-12" style="border: 0px solid rgba(0,0,0,0.8); margin-top: 30px; margin-bottom: 30px; border: 1px solid rgba(0, 0, 0, 0.8); padding: 10px 0px 10px 0px; margin-top: 90px; border-width: 2px 2px 2px 2px; border-radius: 10px;">

                                                    <div class="col-md-6">
                                                        <asp:Image ID="Image17" class="img-responsive" runat="server" ImageUrl='<%# "~/ServiceProvider/Meal/" + Eval("img") %>' Style="border-radius: 0px; border: 0px outset rgba(76, 76, 76, 1);" Width="150px" Height="150px" />
                                                    </div>
                                                    <div class="col-md-6" style="padding: 0px;">
                                                        <div class="col-md-12" style="padding: 0px;">
                                                            <div class="col-md-7">
                                                                <asp:Label ID="Label16" runat="server" Text='<%# Eval("MealName") %>' Style="font-size: 35px; margin-left: -35px;"></asp:Label>
                                                            </div>
                                                            <div class="col-md-1">
                                                                <asp:LinkButton ID="LinkButton10" runat="server" CommandName="CartMeal" CommandArgument='<%# Eval("MealID") %>' Style="float: right;"><span class="glyphicon glyphicon-shopping-cart" style="margin-top:20px; font-size: 20px; color: #5BBD50;"></span></asp:LinkButton>

                                                            </div>
                                                            <div class="col-md-3">
                                                                <asp:Image ID="Image18" class="img-responsive" runat="server" ImageUrl='<%# "~/Icon/" + Eval("MealType") + ".png" %>' Height="20px" Width="20px" Style="margin-top: 20px;" />
                                                            </div>
                                                            <%--   <span class="glyphicon glyphicon-shopping-cart" style="float: right; color: rgb(91, 189, 80); font-size: 20px; margin-right: 30px; margin-top: 20px;"></span>--%>
                                                        </div>
                                                        <h4 style="margin-bottom: 10px; margin-left: -18px;">
                                                            <asp:HiddenField ID="hdnServiceProviderID" runat="server" Value='<%# Eval("ServiceProviderID") %>' />
                                                            <asp:LinkButton ID="lnkSPName" runat="server" Text='<%# Eval("sp") %>' CommandName="ViewSPProfile" CommandArgument='<%# Eval("MealID") %>' Style="color: #E24425;"></asp:LinkButton></h4>
                                                        <div class="col-md-12 text-justify" style="padding: 0px; padding-right: 20px; margin-left: -18px;"><%# Eval("MealDescription") %></div>
                                                        <div class="col-md-12" style="padding: 0px;">
                                                            <asp:HiddenField ID="hdnMealID" runat="server" Value='<%# Eval("MealID") %>' />
                                                            <asp:Image ID="imgRate" runat="server" style="margin-left: -30px;" />
                                                        </div>
                                                    </div>
                                                </div>



                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                </asp:Panel>

                            </section>
                            <%--</section>--%>
                        </div>



                        <!-- // PRODUCT LAYOUT -->
                        <style>
                            /* END EXTER
                  ;
                     
                     */
                            /* END EX
                        </style>
                        <div class="products-layout grid m-t-b add-cart" data-product=".product" data-thumbnail=".entry-media .thumb" data-title=".entry-title > a" data-url=".entry-title > a" data-price=".entry-price > .price" id="test" style="display: none">
                            <div class="product"
                                data-product-id="28"
                                data-food_partners="Ruchira Tiffins"
                                data-cash="c2"
                                data-meal="Economy"
                                data-food="Lunch|Dinner|"
                                data-menu="1|2|3|"
                                data-western="Churchgate|Marine Lines|Charni Road|Grant Road|Mumbai Central|Mahalaxmi|Lower Parel (W)|Lower Parel (E)|Elphistone|Matunga|Mahim (W)|Mahim (E)|Bandra (W)|Bandra (E)|Khar Road (W)|Khar Road (E)|Santacruz (W)|Santacruz (E)|Vile Parle (W)|Vile Parle (E)|Andheri (W)|Andheri (E)|Jogeshwari (W)|Jogeshwari (E)|Goregaon (W)|Goregaon (E)|Malad (W)|"
                                data-central="CST|Masjid|Sandhurst Road|Byculla|Chinchpokli|Currey Road|Parel|Dadar (W)|Dadar (E)|Matunga|Sion| "
                                data-harbour="CST|Masjid|Sandhurst Road|Dockyard Road|Cotton Green|Sewri|Wadala|Kings Circle|Mahim (W)|Mahim (E)|Bandra (W)|Bandra (E)|Khar Road|Santacruz (W)|Santacruz (E)|Vile Parle (W)|Vile Parle (E)|Andheri (W)|Andheri (E)|"
                                data-other="Powai|Oshiwara|Juhu|Worli|BKC|">
                                <div class="entry-media">
                                    <img data-src="" alt="" class="lazyLoad thumb"
                                        style="z-index: 0; width: 260px; height: 175px" />
                                    <div class="hover">
                                        <ul class="icons unstyled">
                                            <li>
                                                <a class="circle" href="#" data-toggle="tooltip" data-layout="list"><i class="iconfont-search"></i></a>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                                <div class="entry-main">
                                    <h5 class="entry-title">Ruchira Tiffins<br>
                                        (Veg-Economy Meal)
                                    </h5>
                                    <div class="entry-description visible-list">
                                        <p style="font-size: 16px; font-weight: initial;">1 vegetable ,1 dal, 4 rotis , Salad</p>
                                    </div>
                                    <div class="entry-price ">
                                        <strong class="accent-color price visible-list">Per Meal Cost</strong>
                                        <strong class="accent-color price visible-list">Rs. 120/-</strong>
                                        <button type="button" class="btn btn-round btn-default add-to-cart " data-toggle="modal" data-target="#myModal28" style="color: white; background: rgb(91, 189, 80);">
                                            <i class="iconfont-shopping-cart"></i>Buy
                                        </button>
                                    </div>
                                </div>
                            </div>
                            <div class="product"
                                data-product-id="57"
                                data-food_partners="Al Lazeez"
                                data-cash="c2"
                                data-meal="Regular"
                                data-food="Lunch|Dinner|"
                                data-menu="1|2|3|"
                                data-western="Malad|"
                                data-central="| "
                                data-harbour="|"
                                data-other="|">
                                <div class="entry-media">
                                    <img data-src="" alt="" class="lazyLoad thumb"
                                        style="z-index: 0; width: 260px; height: 175px" />
                                    <div class="hover">
                                        <ul class="icons unstyled">
                                            <li>
                                                <a class="circle" href="#" data-toggle="tooltip" data-layout="list"><i class="iconfont-search"></i></a>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                                <div class="entry-main">
                                    <h5 class="entry-title">Al Lazeez<br>
                                        (Veg-Regular Meal)
                                    </h5>
                                    <div class="entry-description visible-list">
                                        <p style="font-size: 16px; font-weight: initial;">Dal ,Rice, 2 Chapatis,1 Sabji Salad</p>
                                    </div>
                                    <div class="entry-price ">
                                        <strong class="accent-color price visible-list">Per Meal Cost</strong>
                                        <strong class="accent-color price visible-list">Rs. 115/-</strong>
                                        <button type="button" class="btn btn-round btn-default add-to-cart " data-toggle="modal" data-target="#myModal57" style="color: white; background: rgb(91, 189, 80);">
                                            <i class="iconfont-shopping-cart"></i>Buy
                                        </button>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <!-- // PRODUCT LAYOUT -->
                        </form>
                    </div>
                </div>

            </main>
            <!-- // SITE MAIN CONTENT -->
            <div id="modaltest">

                <div class="modal fade bs-example-modal-lg" id="mm21" tabindex="-1" role="dialog" aria-labelledby="myModalLabel1" aria-hidden="true">
                    <div class="modal-dialog modal-lg">
                        <div class="modal-content">
                            <div class="modal-header" style="background: rgba(0, 0, 0, 0.8); color: rgb(211, 210, 210);">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true" style="color: red;">&times;</span></button>
                                <h4 class="modal-title" id="myModalLabel1">Food Order (Lunch)</h4>
                            </div>
                            <div class="modal-body">
                                <form id="myform28" name="myform28">
                                    <div class="product">
                                        <div class="row">
                                            <!-- <div class="col-md-4"><img src="http://admin.takeurpick.com/assets/upload/tiffin_vendor/1426401583.jpg" alt="" class="lazyLoad thumb" 
                           style="z-index:0;width: 300px;height: 200px;padding: 10px 10px 10px 10px;" /></div>-->
                                            <div class="col-md-12" style="margin-top: 18px; padding-left: 30px; padding-right: 30px;">
                                                <div class="row">
                                                    <div class="pull-left">
                                                        <h6 class="entry-title" style="font-size: 16px">Ruchira Tiffins - Economy Meal - <span style="color: rgb(91, 189, 80);">Veg</span><span style="color: rgb(197, 195, 195); font-size: 17px"> | </span><span style="font-size: 16px; font-weight: initial;">1 vegetable ,1 dal, 4 rotis , Salad</span>
                                                        </h5>
                                                    </div>
                                                    <div class="pull-right">
                                                        <strong class="accent-color price">Per Cost Meal : Rs.120/- </strong>
                                                        <button type="button" class="btn btn-round btn-default add-to-cart heading" style="color: white; background: rgb(91, 189, 80); margin-bottom: 5px; border-radius: 7px; margin-left: 7px;"
                                                            data-toggle="collapse" data-target="#trial28" aria-expanded="false"
                                                            aria-controls="collapseExample">
                                                            <i class="iconfont-shopping-cart"></i>Buy</button>
                                                    </div>
                                                </div>
                                                <div class="collapse" id="trial28">
                                                    <div class="table-responsive">
                                                        <table class="table">
                                                            <thead style="background: silver;">
                                                                <tr>
                                                                    <th></th>
                                                                    <th>
                                                                        <center>Type Meal</center>
                                                                    </th>
                                                                    <th>Meal Cost</th>
                                                                    <th>Delivery Cost</th>
                                                                    <th>Total Cost</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody style="background: rgb(242, 242, 242);">
                                                                <tr>
                                                                    <td>
                                                                        <div class="radio">
                                                                            <input type="radio" name="cart" class="radiocart28" value="Trial Meal 5 days" id="fiv28" required>
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <label for="fiv28">Trial Meal 5 Days</label></td>
                                                                    <td>
                                                                        <label for="fiv28">Rs.600</label></td>
                                                                    <td>
                                                                        <label for="fiv28">Rs.0</label></td>
                                                                    <td>
                                                                        <label for="fiv28">Rs.600</label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <div class="radio">
                                                                            <input type="radio" name="cart" class="radiocart28" id="twe28" value="1 Month (20 days)" required>
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <label for="twe28">1 Month(20 Days)</label></td>
                                                                    <td>
                                                                        <label for="twe28">Rs.2400</label></td>
                                                                    <td>
                                                                        <label for="twe28">Rs.0</label></td>
                                                                    <td>
                                                                        <label for="twe28">Rs.2400</label></td>
                                                                </tr>
                                                                <tr>
                                                                    <input type="text" name="id" value="28" hidden id="prod_id28" />
                                                                    <input type="text" name="name" value="Ruchira Tiffins - Economy Meal" hidden id="name28" />
                                                                    <input type="text" name="delivery_cost" value="" hidden id="delivery_cost28" />
                                                                    <input type="text" name="food_provided" value="1" hidden id="food_provided" />
                                                                    <input type="text" name="food_type" value="Lunch" hidden id="food_type" />
                                                                    <input type="text" name="price" value="120" hidden id="price28" />
                                                                    <input type="text" name="email" value="takeurpicktiffins@gmail.com" hidden id="email" />
                                                                    <td colspan="5">
                                                                        <button type="submit" class="select" id="submit" style="background: grey; color: white; height: 30px; border-radius: 7px;">
                                                                            Add to cart</button></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <span class="error28" style="display: none">Please Select</span>
                                                        <span class="success28" style="display: none; color: rgb(91, 189, 80); font-weight: bold">Added to Cart Successfully
								  <span>
                                      <button onclick="window.location.href='http://takeurpick.com/tiffinserviceinmumbai/cart';" class="btn btn-round btn-default add-to-cart heading" style="color: white; background: rgb(91, 189, 80); margin-bottom: 5px; border-radius: 7px; margin-left: 7px;">
                                          View cart</button></span>
                                                    </div>
                                                </div>
                                                <!--
                              <div class="entry-links clearfix">
                              	<a href="#" class="pull-left m-r">+ Add to Wishlist</a>
                              	<a href="#" class="pull-right">+ Add to Compare</a>
                              </div>-->
                                            </div>
                                        </div>
                                    </div>
                                    <br>
                                </form>
                                <script>
                                    $('#myform28').submit(function (event) {
                                        dataString = $("#myform28").serialize();


                                        $.ajax({
                                            type: "POST",
                                            url: "http://takeurpick.com/user/add_to_cart",
                                            data: dataString,

                                            success: function (data) {
                                                // alert(data);

                                                //  $("#cart").html(data);
                                                $('.success28').fadeIn(200).show();
                                                //  $('.error28').fadeOut(200).hide();



                                                // setInterval(function() {


                                                $('#show').load(document.URL + ' #show');
                                                // $('#mm21').load(document.URL +  ' #mm21');
                                                //$('#mm21').modal('hide');
                                                //alert('c');
                                                // }, 1000);

                                                //  setTimeout(function(){
                                                //  $('#mm21').modal('hide')
                                                // }, 4000);



                                            }



                                        });
                                        event.preventDefault();


                                    });
                                </script>
                            </div>
                            <div class="modal-footer" style="padding: 12px 20px 12px; background: #E24425;">
                                <button type="button" class="btn btn-default" data-dismiss="modal" style="color: white; background: rgb(91, 189, 80); border-color: transparent;">Close</button>
                                <!--<button type="button" class="btn btn-primary">Save changes</button>-->
                            </div>
                        </div>
                        </form>
                    </div>
                </div>


            </div>

            <div class="modal fade" id="myModal28" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header" style="background: rgba(0, 0, 0, 0.8); color: rgb(211, 210, 210);">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true" style="color: red;">&times;</span></button>
                            <h4 class="modal-title" id="myModalLabel">Food Order (Lunch)</h4>
                        </div>
                        <div class="modal-body">
                            <form id="myformm28" name="myformm28">
                                <div class=" table-responsive">
                                    <table class="table">
                                        <thead style="background: silver;">
                                            <tr style="background: white">
                                                <th colspan="5">
                                                    <span style="font-size: 16px;"><b style="font-size: 17px;">Menu :</b>  <span>1 vegetable ,1 dal, 4 rotis , Salad</span></span>
                                                </th>
                                            </tr>
                                            <tr style="background: white">
                                                <th colspan="5">
                                                    <center style="color: black; font-size: 16px; font-weight: bold; color: rgb(226, 68, 37);">Per Meal Cost - Rs.120/-</center>
                                                </th>
                                            </tr>
                                            <tr>
                                                <th></th>
                                                <th>
                                                    <center>Type Meal</center>
                                                </th>
                                                <th>Meal Cost</th>
                                                <th>Delivery Cost</th>
                                                <th>Total Cost</th>
                                            </tr>
                                        </thead>
                                        <tbody style="background: rgb(242, 242, 242);">
                                            <tr>
                                                <td>
                                                    <div class="radio">
                                                        <input type="radio" name="cart" class="radiocart28" id="fi28" value="Trial Meal 5 days" required>
                                                    </div>
                                                </td>
                                                <td>
                                                    <label for="fi28">Trial Meal 5 Days</label></td>
                                                <td>
                                                    <label for="fi28">Rs.600</label></td>
                                                <td>
                                                    <label for="fi28">Rs.0</label></td>
                                                <td>
                                                    <label for="fi28">Rs.600</label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="radio">
                                                        <label>
                                                            <input type="radio" name="cart" class="radiocart28" id="tw28" value="1 Month (20 days)" required></label>
                                                    </div>
                                                </td>
                                                <td>
                                                    <label for="tw28">1 Month(20 Days)</label></td>
                                                <td>
                                                    <label for="tw28">Rs.2400</label></td>
                                                <td>
                                                    <label for="tw28">Rs.0</label></td>
                                                <td>
                                                    <label for="tw28">Rs.2400</label></td>
                                            </tr>
                                            <tr>
                                                <input type="text" name="id" value="28" hidden id="prod_id" />
                                                <input type="text" name="name" value="Ruchira Tiffins-Economy" hidden id="name" />
                                                <input type="text" name="price" value="120" hidden id="price" />
                                                <input type="text" name="delivery_cost" value="" hidden id="delivery_cost" />
                                                <input type="text" name="food_provided" value="1" hidden id="food_provided" />
                                                <input type="text" name="food_type" value="Lunch" hidden id="food_type" />
                                                <input type="text" name="email" value="takeurpicktiffins@gmail.com" hidden id="email" />
                                                <td colspan="5">
                                                    <button type="submit" id="submit" class="select" style="background: grey; color: white; height: 30px; border-radius: 7px;">Add to cart</button></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <span class="error128" style="display: none">Please Select</span>
                                    <span class="success128" style="display: none; color: rgb(91, 189, 80); font-weight: bold">Added to Cart Successfully
				  <span>
                      <button onclick="window.location.href='';" class="btn btn-round btn-default add-to-cart heading" style="color: white; background: rgb(91, 189, 80); margin-bottom: 5px; border-radius: 7px; margin-left: 7px;">
                          View cart</button></span>
                                    </span>
                                </div>
                                <br>
                            </form>
                            <script>
                                $('#myformm28').submit(function (event) {
                                    dataString = $("#myformm28").serialize();

                                    //alert(dataString);

                                    $.ajax({
                                        type: "POST",
                                        url: "http://takeurpick.com/user/add_to_cart",
                                        data: dataString,

                                        success: function (data) {
                                            //alert('test');
                                            $('.success128').fadeIn(200).show();
                                            //$('.error128').fadeOut(200).hide();

                                            //   setInterval(function() {


                                            $('#show').load(document.URL + ' #show');
                                            //$('#myModal28').modal('hide');
                                            //alert('c');
                                            //  }, 1000);


                                            /*setTimeout(function(){
                                            $('#myModal28').modal('hide')
                                            }, 4000);  */
                                        }

                                    });
                                    event.preventDefault();


                                });
                            </script>
                        </div>
                        <div class="modal-footer" style="padding: 12px 20px 12px; background: #E24425;">
                            <button type="button" class="btn btn-default" data-dismiss="modal" style="color: white; background: rgb(91, 189, 80); border-color: transparent;">Close</button>
                            <!--<button type="button" class="btn btn-primary">Save changes</button>-->
                        </div>
                    </div>
                </div>
            </div>
            </form>
    <script>
        $(document).ready(function () {

            $('#per_page').change(function () {

                window.location = "" + $(this).val();


            });


            var per_page = document.getElementById("per_page");
            //alert(per_page.value);
            per_page.value = '';


            $('.prettyCheckable').change(function () {
                var test = document.getElementById("test");
                var test1 = document.getElementById("test1");
                test.style.display = 'block';
                test1.style.display = 'none';
            });

            jQuery(".content").hide();
            //toggle the componenet with class msg_body
            jQuery(".heading").click(function () {
                jQuery(".content").slideToggle(500);

            });




        });

    </script>
            <script type="text/javascript">
                $(document).ready(function () {

                });
            </script>



            <style>
                }

                media "all" @m a 640px {
                    onta -ri th: 55%;
                    margin: 0 022m 0;

                /* END EXTERNAL SOURCE */
            </style>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="chkLocation" />
            <asp:PostBackTrigger ControlID="chkMealSerAll" />
            <asp:PostBackTrigger ControlID="btnserch" />
            
            <%--<asp:AsyncPostBackTrigger ControlID="" EventName="chkLocation_CheckedChanged" />--%>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

