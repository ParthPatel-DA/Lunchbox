<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="ContectUs.aspx.cs" Inherits="ContectUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="bootstrap/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- mail -->
    <div class="mail">
        <div class="container">
            <div class="agileinfo_mail_grids">
                <div class="col-md-6 agileinfo_mail_grid_left">
                    <div class="container">
                        <div class="agileinfo_footer_grids">
                            <div class="col-md-12 agileinfo_footer_grid">
                                <div class="col-md-12 agileinfo_footer_grid">
                                    <br />
                                    <h4 style="font-size: 2em; margin-top: 8px; font-weight: 700; font-family: 'Lobster Two', cursive;">Contact information</h4>
                                    <br />
                                    <ul class="agileinfo_footer_grid_list">
                                        <li style="font-size: 14px; padding: 10px;"><i class="round-icon iconfont-map-marker " style="border: 2px solid #E24425; color: white; background: #E24425;"></i>
                                            <span style="padding: 5px; font-size: 20px;">Bhagyoday Socity,</span><br />
                                            <span style="padding: 40px; font-size: 20px;">Palanpur Patia,</span><br />
                                            <span style="padding: 40px; font-size: 20px;">Rander Road,</span><br />
                                            <span style="padding: 40px; font-size: 20px;">Surat 395009</span></li>
                                        <li style="font-size: 14px; padding: 10px;"><i class="round-icon iconfont-envelope-alt" style="border: 2px solid #E24425; color: white; background: #E24425;"></i><a href="mailto:lunchboxindia2017@gmail.com" style="padding: 10px; font-size: 20px;">lunchboxindia2017@gmial.com</a></li>
                                        <li style="font-size: 14px; padding: 10px;"><i class="round-icon iconfont-phone" style="border: 2px solid #E24425; color: white; background: #E24425;"></i><span style="padding: 10px; font-size: 20px;">+918469520590</span></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="col-md-12 agileinfo_footer_grid">
                        <br />
                        <h4 style="font-size: 2em; margin-top: 8px; font-weight: 700; font-family: 'Lobster Two', cursive;">Contact us</h4>
                        <br />
                    </div>
                    <div class="form_details">

                        <asp:TextBox ID="txtEmail" Class="text" Names="email" runat="server" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$"  oninvalid="setCustomValidity('enter the proper Email ')"	oninput="setCustomValidity('')" Text="Email Address" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Email Address';}" Style="padding: 10px; width: 80%; font-size: 1.2em; margin: 10px 0px; border: 1px solid #8A8888; color: #8A8888; background: none; -webkit-appearance: none; float: left; outline: none; font-weight: 500;"></asp:TextBox>


                        <asp:TextBox ID="txtContactNo" class="text" name="contectNo" Text="ContectNo" pattern="^(7|8|9)[0-9]{9}$" oninvalid="setCustomValidity(' enter only 10 Digits')" oninput="setCustomValidity('')" runat="server" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'ContectNo';}" Style="padding: 10px; width: 80%; font-size: 1.2em; margin: 10px 0px; border: 1px solid #8A8888; color: #8A8888; background: none; -webkit-appearance: none; float: left; outline: none; font-weight: 500;"></asp:TextBox>

                        <asp:TextBox ID="txtDescription" Text="Description" name="Discription" pattern="[A-Za-z]*" oninvalid="setCustomValidity('enter The Description in  Format  ')"	oninput="setCustomValidity('')" TextMode="MultiLine" runat="server" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Message';}" Style="padding: 10px; width: 80%; font-size: 1.2em; margin: 10px 0px; border: 1px solid #8A8888; color: #8A8888; background: none; -webkit-appearance: none; float: left; outline: none; font-weight: 500;"></asp:TextBox>
                        <div class="clearfix"></div>
                        <div class="sub-button wow swing animated" data-wow-delay="0.4s">

                            <asp:Button ID="btnsend" runat="server" Text="Send Message" OnClick="btnsend_Click" />
                        </div>
                    </div>

                </div>
                <div class="clearfix"></div>
            </div>

            <div class="col-md-12 agileinfo_mail_grid_right" style="margin-top: 30px;">
                <div class="col-md-11 agileinfo_footer_grid">
                    <h4 style="font-size: 2em; margin-top: 8px; font-weight: 700; font-family: 'Lobster Two', cursive;">Find Our Address</h4>
                    <br />
                </div>
                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3719.5809207482926!2d72.7934740149357!3d21.20880068590116!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3be04e80b02b6d01%3A0x7e1416caa92cb786!2sRander+Rd%2C+Surat%2C+Gujarat!5e0!3m2!1sen!2sin!4v1490252954636" width="1200" height="500" frameborder="0" style="border: 0" allowfullscreen></iframe>
            </div>
        </div>
    </div>
    <!-- //mail -->
</asp:Content>

