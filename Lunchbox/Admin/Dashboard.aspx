<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Admin_Dashboard" Debug="true" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-header">
        <div class="page-title">
            <h5>Dashboard</h5>
           <%-- <span>Statistic elements and widgets</span>--%>
        </div>
    </div>
    <hr />
    <!-- Content -->
    <div class="row-fluid">
        <div class="span4" style="margin-top: 60px;">
            <div class="widget">
                <div class="navbar">
                    <div class="navbar-inner">
                        <h6>Total Delivery Boy</h6>
                    </div>
                </div>
                <div class="well body">
                    <ul class="stats-details">
                        <li>
                            <img src="../ServiceProvider/Upload/Ser.png" style="height :130px;width :120px;" />
                            <%--<strong>Current balance</strong>
				            			<span>latest update on 12:39 am</span>--%>
                        </li>

                    </ul>
                    <div class="number">
                        <span>
                            <asp:Label ID="lblser" runat="server" Style="font-size: 45px; margin-top: -100px; margin-right: 40px;"></asp:Label></span>
                    </div>
                </div>
            </div>
        </div>
        <div class="span4" style="margin-top: 60px;">
            <div class="widget">
                <div class="navbar">
                    <div class="navbar-inner">
                        <h6>Total Client</h6>
                    </div>
                </div>
                <div class="well body">
                    <ul class="stats-details">
                        <li>
                              <img src="../Client/Upload/Client.png" style="height :130px;width :120px;" />
                            <%--<strong>Current balance</strong>
				            			<span>latest update on 12:39 am</span>--%>
                        </li>

                    </ul>
                    <div class="number">
                        <span>
                            <asp:Label ID="lblcli" runat="server" Style="font-size: 45px; margin-top: -100px; margin-right: 40px;"></asp:Label></span>
                    </div>
                </div>
            </div>
        </div>


      <div class="span4" style="margin-top: 60px;">
            <div class="widget">
                <div class="navbar">
                    <div class="navbar-inner">
                        <h6>Total Meal & Menu</h6>
                    </div>
                </div>
                <div class="well body">
                    <ul class="stats-details">
                        <li>
                          <%--  <img src="../img/photo.JPG" height="200" width="200" />--%>
                            <img src="../Client/Upload/17.jpg" style="height :130px; width :110px;"/>
                            <%--<strong>Current balance</strong>
				            			<span>latest update on 12:39 am</span>--%>
                        </li>

                    </ul>
                    <div class="number">
                        
                           <span><asp:Label ID="Label1" runat="server" Text="Meal :" Style="margin-top :-120px;margin-left :-170px;"></asp:Label></span>

                      <asp:Label ID="lblMeal" runat="server" Style="font-size: 20px; margin-top: -110px; margin-left:-90px; "></asp:Label>

                    <span>    <asp:Label ID="Label2" runat="server" Text="Menu :" Style="margin-top :-90px;margin-left :-170px;"></asp:Label></span>
                         <span >   <asp:Label ID="lblMenu" runat="server" Style="font-size: 20px; margin-top: -90px; margin-left :-90px;"></asp:Label>
                        </span>
                    </div>
                </div>
            </div>
        </div>


    </div>
    <div id="content">

        <!-- Content wrapper -->
        <%-- <div class="wrapper">

            <!-- Breadcrumbs line -->
            <div class="crumbs">
                <ul id="breadcrumbs" class="breadcrumb">
                    <li><a href="#">Dashboard</a></li>
                </ul>
                <ul class="alt-buttons">
                    <li><a href="#" title=""><i class="icon-signal"></i><span>Stats</span></a></li>
                    <li><a href="#" title=""><i class="icon-comments"></i><span>Messages</span></a></li>
                </ul>
            </div>
            <!-- /breadcrumbs line -->
            <h1>Welcome, Admin</h1>
        </div>--%>
        <!-- Page header -->
       <%-- <div class="page-header">
            <div class="page-title">
                <h3 style="padding-left: 50px;">Meal Records</h3>
            </div>
        </div>
        <!-- /page header -->
        <div>
            <asp:Chart ID="meal" runat="server" Height="300px" Width="800px">
                <Titles>
                    <asp:Title ShadowOffset="3" Name="Records" />
                </Titles>
                <Legends>
                    <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Legends" LegendStyle="Row" />

                </Legends>
                <Series>
                    <asp:Series Name="Total Meals"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea" BorderWidth="0"></asp:ChartArea>
                </ChartAreas>

            </asp:Chart>
        </div>
        <br />--%>
      <%--  <div class="page-header">
            <div class="page-title">
                <h3 style="padding-left: 50px;">Menu Records</h3>
            </div>
        </div>--%>
     <%--   <div>
              <asp:Chart ID="menu" runat="server" Height="300px" Width="800px">
                <Titles>
                <asp:Title ShadowOffset="3" Name="Records" />
            </Titles>
                 <Legends>
                <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Legends" LegendStyle="Row" />
            
                 </Legends> 
                <Series>
                    <asp:Series Name="Total Menus" ></asp:Series>
                    
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea" BorderWidth="0"></asp:ChartArea>
                </ChartAreas>
                
            </asp:Chart>
        </div>
        <br />--%>
        <%--    <!-- Page header -->
        <div class="page-header">
            <div class="page-title">
                <h3 style="padding-left:50px;">Meal , Menu</h3>
            </div>
        </div>
        <!-- /page header -->
        <div>
             <asp:Chart ID="chartmealmenu" runat="server" Height="300px" Width="800px">
                <Titles>
                    <asp:Title ShadowOffset="3" Name="Service Provider wise Meal & Menu" />
                </Titles>
                <Legends>
                    <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Legends" LegendStyle="Row" />
                </Legends> 
                <Series>
                </Series>

                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1" BorderWidth="0"></asp:ChartArea>               
                </ChartAreas>                
            </asp:Chart>
        </div>--%>
    </div>
</asp:Content>

