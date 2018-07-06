<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Log.aspx.cs" Inherits="Admin_Log" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div id="head">
        <h5 class="widget-name"><i class="icon-columns"></i>Log Table</h5>

        <!-- Default datatable -->
        <div class="widget">
            <div class="navbar">
                <div class="navbar-inner">
                    <h6>Log datatable</h6>
                </div>
            </div>
            <asp:Repeater ID="rptlog" runat="server">
                  <HeaderTemplate>
            <div class="table-overflow">
                <table class="table table-striped table-bordered" id="data-table">
                    <thead>
                        <tr>
                             
                                        <th>UserLogID</th>
                                        <th>LoginTime</th>
                                        <th>LogoutTime</th>
                                        <th>MacAddress</th>
                                       

                        </tr>
                    </thead>
                     </HeaderTemplate>
                    <ItemTemplate>
                    <tbody>
                        <tr>
                
                            <td><asp:Label ID="lbluserlid" runat="server" Text='<%# Eval("UserLogID") %>' /></td>
                               <td><asp:Label ID="lbllogintime" runat="server" Text='<%# Eval("LoginTime") %>' /></td>
                             <td><asp:Label ID="lbllogouttime" runat="server" Text='<%# Eval("LogoutTime") %>' /></td>
                            <td><asp:Label ID="lblmacadd" runat="server" Text='<%# Eval("MacAddress") %>' /></td>
                                 
                         </tr>
                       </tbody>
                     </ItemTemplate>
                    <FooterTemplate>
                      </table>
                    </FooterTemplate>
                     </asp:Repeater>
        </div>
        <!-- /default datatable -->
          </div>
  
</asp:Content>

