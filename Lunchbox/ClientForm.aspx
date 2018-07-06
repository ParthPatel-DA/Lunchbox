<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="ClientForm.aspx.cs" Inherits="ClientForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content" style="margin-top: 14px;">
        <div class="main" style="background: #FFFFFF;">
            <div class="container">
                <div class="register">
                    <h2 style="font-size: 2em; margin-top: 8px; font-weight: 700; font-family: 'Lobster Two', cursive;">Signup<br>
                        <br>
                    </h2>
                    <div class="row">
                        <h3 style="color: red"></h3>
                        <%--<form class="form" role="form" name="myform" action="http://takeurpick.com/login/new_signup" method="post">--%>
                        <div class="col-lg-12">
                            <asp:Panel ID="panel1" runat="server" Visible="true">
                                <div class="register-top-grid col-md-6">
                                    <br>
                                    <h3>PERSONAL INFORMATION</h3>
                                    <div class="wow fadeInLeft" data-wow-delay="0.4s">
                                        <span><%--First Name<label>*</label>--%>
                                            <asp:Label runat="server" Text="First Name"></asp:Label>
                                        </span>
                                        <%--  <input type="text" class="form-control"  name="firstname" required/> --%>
                                        <asp:TextBox ID="txtfnm" runat="server" required="" pattern="[A-Za-z]*" oninvalid="setCustomValidity('enter The First Name in Character Format  ')" oninput="setCustomValidity('')" MaxLength="15" Class="form-control" Names="firstname"></asp:TextBox>
                                    </div>
                                    <div class="wow fadeInRight" data-wow-delay="0.4s">
                                        <span><%--Last Name<label>*</label>--%>
                                            <asp:Label runat="server" Text="Last Name"></asp:Label>
                                        </span>
                                        <asp:TextBox ID="txtlnm" runat="server" required="" pattern="[A-Za-z]*" oninvalid="setCustomValidity('enter The last Name in Character Format ')" oninput="setCustomValidity('')" MaxLength="15" Class="form-control" Names="lastname"></asp:TextBox>
                                        <%-- <input type="text" class="form-control"  name="lastname" required/> --%>
                                    </div>
                                    <div class="wow fadeInRight form-group" data-wow-delay="0.4s">
                                        <span><%--Email Address<label>*</label>--%>
                                            <asp:Label runat="server" Text="Emil Address"></asp:Label>
                                        </span>
                                        <asp:TextBox ID="txtmail" runat="server" required="" TextMode="Email" oninvalid="setCustomValidity('enter the proper Email ')" oninput="setCustomValidity('')" Class="form-control" Names="email" Style="border: 1px solid #EEE; outline-color: #FF5B36; width: 96%; font-size: 1em; padding: 0.5em;"></asp:TextBox>
                                        <%-- <input type="email"  class="form-control" name="email" required style="border: 1px solid #EEE;outline-color: #FF5B36;width: 96%;font-size: 1em;padding: 0.5em;"/> --%>
                                    </div>
                                    <div class="wow fadeInRight" data-wow-delay="0.4s">
                                        <span><%--Telephone<label>*</label>--%>
                                            <asp:Label runat="server" Text="Telephone"></asp:Label>
                                        </span>
                                        <asp:TextBox ID="txtphno" runat="server" required="" class="form-control" name="ContactNo" pattern="^(7|8|9)[0-9]{9}$" oninvalid="setCustomValidity('format does not match')" oninput="setCustomValidity('')" Names="contact"></asp:TextBox>
                                        <%--<input type="text" class="form-control"  name="contact"  required/> 	--%>
                                    </div>

                                    <div class="wow fadeInLeft" data-wow-delay="0.4s">
                                        <span>
                                            <asp:Label runat="server" Text="Image"></asp:Label>
                                        </span>
                                        <asp:FileUpload ID="FileUpload1" runat="server"></asp:FileUpload>
                                    </div>
                                </div>

                                <%--   <div class="col-md-6">
               <div class="clearfix"> </div> --%>
                                <div class="register-bottom-grid col-md-6">

                                    <%--    <div class="wow fadeInLeft" data-wow-delay="0.4s">								
                     <span>
                         <asp:Label runat="server" Text="Company"></asp:Label>
                     </span>								
             
                      <asp:TextBox ID="txtcompnm" runat="server" required="required" pattern="[A-Za-z]*" oninvalid="setCustomValidity('Enter Company in character format')" oninput="setCustomValidity('')" Class="form-control" Names="company"></asp:TextBox>						
                  </div>--%>
                                    <%--     <div class="wow fadeInRight" data-wow-delay="0.4s">
                              <h3>Meal/Menu Type</h3>						
              
                     								
                     <div class="radio">								
                        <label>	<asp:RadioButton ID="radveg" runat="server" />Veg	</label>		
                     </div>
                     <div class="radio" style="margin-top:13px">								  
                        <label><asp:RadioButton ID="radnonveg" runat="server" />Non-Veg	</label>				
                     </div>
                      <div class="radio" style="margin-top:13px">								  
                        <label><asp:RadioButton ID="radboth" runat="server" />Both	</label>								
                     </div>
                  </div>--%>
                                    <br />
                                    <h3>YOUR PASSWORD</h3>
                                    <div class="wow fadeInLeft form-group" data-wow-delay="0.4s">
                                        <%--<span>Password<label>*</label>--%>
                                        <asp:Label runat="server" Text="Password"></asp:Label>


                                        <asp:TextBox ID="txtpass" runat="server" required="required" pattern="^[A-Za-z0-9]+{5,15}$" oninvalid="setCustomValidity('Enter minimum 5 and maximum 15 characters for password')" TextMode="password" oninput="setCustomValidity('')" Class="form-control" Names="password" Style="border: 1px solid #EEE; outline-color: #FF5B36; width: 96%; font-size: 1em; padding: 0.5em;"></asp:TextBox>
                                    </div>
                                    <div class="wow fadeInRight form-group" data-wow-delay="0.4s">
                                        <span>
                                            <asp:Label runat="server" Text="Confirm Password"></asp:Label>
                                        </span>

                                        <asp:TextBox ID="txtconpass" runat="server" required="required" pattern="^[A-Za-z0-9]+{5,15}$" oninvalid="setCustomValidity('Enter minimum 5 and maximum 15 characters for password')" TextMode="password" oninput="setCustomValidity('')" Class="form-control" Names="conpassword" Style="border: 1px solid #EEE; outline-color: #FF5B36; width: 96%; font-size: 1em; padding: 0.5em;"></asp:TextBox>
                                        <asp:Label ID="lblerrorPwd" runat="server" Text="Please Enter Same Password." Style="color: #ff0000; font-weight: bolder;" Visible="false"></asp:Label>
                                    </div>


                                    <asp:Button ID="btnnext" runat="server" Text="Next" Style="margin-top: 1em; color: #fff; font-size: 1.3em; padding: 0.4em 1em; -webkit-appearance: none; height: 45px; display: inline-block -moz-transition: all 0.3s ease-out; -ms-transition: all 0.3s ease-out; -o-transition: all 0.3s ease-out; transition: all 0.3s ease-out; font-weight: 600; border: none; text-transform: uppercase; cursor: pointer; background: #E24426;"
                                        OnClick="btnnext_Click"></asp:Button>
                                </div>
                            </asp:Panel>


                            <div class="clearfix"></div>
                            <asp:Panel ID="panel2" runat="server" Visible="false">
                                <div class="register-bottom-grid">

                                    <h3>YOUR ADDRESS</h3>

                                    <div class="wow fadeInRight form-group" data-wow-delay="0.4s">
                                        <span><%--Address1<label>*</label>--%>
                                            <asp:Label runat="server" Text="Address1"></asp:Label>
                                        </span>

                                        <asp:TextBox ID="txtadd" runat="server" required="required" pattern="[A-Za-z0-9]{5}[A-Za-z]{25}*" oninvalid="setCustomValidity('Enter the address in proper format')" oninput="setCustomValidity('')" MaxLength="30" TextMode="MultiLine" Style="border: 1px solid #EEE; outline-color: #FF5B36; width: 50%; font-size: 1em; padding: 0.5em;" name="address2"></asp:TextBox>
                                    </div>
                                    <div class="wow fadeInRight form-group" data-wow-delay="0.4s">
                                        <span><%--Address2--%>
                                            <asp:Label runat="server" Text="Area"></asp:Label>
                                        </span>
                                        <%--<textarea   class="form-control" name="address2" style="border: 1px solid #EEE;outline-color: #FF5B36;width: 96%;font-size: 1em;padding: 0.5em;"></textarea>							 --%>
                                        <asp:TextBox ID="txtarea" required="required"  oninvalid="setCustomValidity('Enter the area in proper formet')" oninput="setCustomValidity('')"  runat="server" class="form-control" Style="border: 1px solid #EEE; outline-color: #FF5B36; width: 50%; font-size: 1em; padding: 0.5em;" name="address2"></asp:TextBox>
                                    </div>
                                    <div class="wow fadeInRight form-group" data-wow-delay="0.4s">
                                        <span><%--Landmark--%>
                                            <asp:Label runat="server" Text="Laandmark"></asp:Label>
                                        </span>
                                        <%-- <textarea   class="form-control" name="landmark" style="border: 1px solid #EEE;outline-color: #FF5B36;width: 96%;font-size: 1em;padding: 0.5em;"></textarea>							 --%>
                                        <asp:TextBox ID="txtlandmark" runat="server" required="required" pattern="[A-Za-z]{25}*" oninvalid="setCustomValidity('Enter the landmark in proper format')" oninput="setCustomValidity('')"  TextMode="MultiLine" Style="border: 1px solid #EEE; outline-color: #FF5B36; width: 50%; font-size: 1em; padding: 0.5em;" name="Landmark"></asp:TextBox>
                                    </div>
                                    <div class="wow fadeInRight" data-wow-delay="0.4s">
                                        <span><%--Post Code<label>*</label>--%>
                                            <asp:Label runat="server" Text="Post Code"></asp:Label>
                                        </span>
                                        <%--                     <input type="text" class="form-control"  name="postal_code"  required />							--%>
                                        <asp:TextBox ID="txtpinno" runat="server" required="required" pattern="[0-9]{6}*" oninvalid="setCustomValidity('Enter the pincodeNo ')" oninput="setCustomValidity('')"  class="form-control" name="pincodeNo" Style="width: 50%;"></asp:TextBox>
                                    </div>

                                    <asp:UpdatePanel ID="updpanel1" runat="server">
                                        <ContentTemplate>
                                            <div class="wow fadeInRight" data-wow-delay="0.4s">
                                                <span>
                                                    <asp:Label ID="lblselectedtext" runat="server" Text="Country"></asp:Label>
                                                </span>


                                                <asp:DropDownList ID="ddlcountry" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged" Style="width: 105%" TabIndex="9" name="country" data-settings='{"wrapperClass":"flat"}'>
                                                </asp:DropDownList>

                                            </div>
                                            <div class="wow fadeInRight" data-wow-delay="0.4s">
                                                <span>
                                                    <asp:Label ID="lblselectedtext1" runat="server" Text="Region/State"></asp:Label>
                                                </span>
                                                <asp:DropDownList runat="server" ID="ddlstate" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged" Style="width: 105%" TabIndex="9" name="state" data-settings='{"wrapperClass":"flat"}'>
                                                </asp:DropDownList>

                                            </div>
                                            <div class="wow fadeInRight" data-wow-delay="0.4s">
                                                <span>
                                                    <asp:Label ID="lblselectedtext2" runat="server" Text="City"></asp:Label>
                                                </span>
                                                <asp:DropDownList runat="server" ID="ddlcity" class="form-control" Style="width: 105%" TabIndex="9" name="city" data-settings='{"wrapperClass":"flat"}'>
                                                </asp:DropDownList>

                                            </div>
                                            <asp:LinkButton ID="lnkmylink" runat="server"></asp:LinkButton>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="lnkmylink" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <div>
                                        <asp:Button ID="btnsub" runat="server" Text="Submit" Style="margin-top: 1em; color: #fff; font-size: 1.3em; padding: 0.4em 1em; -webkit-appearance: none; height: 45px; display: inline-block; -moz-transition: all 0.3s ease-out; -ms-transition: all 0.3s ease-out; -o-transition: all 0.3s ease-out; transition: all 0.3s ease-out; font-weight: 600; border: none; text-transform: uppercase; cursor: pointer; background: #E24426;"
                                            OnClick="btnsub_Click" />
                                    </div>
                                </div>

                            </asp:Panel>
                            <%--<div class="register-bottom-grid">
                  <h3>NEWSLETTER</h3>
                  <div class="wow fadeInLeft" data-wow-delay="0.4s">
                     <span>Subscribe</span>								
                     <div class="radio">								
                        <label><input type="radio" name="subscriber" value="yes" checked required />Yes</label>							
                     </div>
                     <div class="radio" style="margin-top:13px">								  
                        <label><input type="radio" name="subscriber" value="no" required />No</label>								
                     </div>
                  </div>
               </div>--%>
                            <div class="clearfix"></div>
                            <!--<div class="register-but">
                  <input type="submit" value="Submit">
                  <div class="clearfix"> </div>
               </div>-->
                            <div class="sub-button wow swing animated" data-wow-delay="0.4s">
                                <%--	<input name="submit" type="submit" value="Submit" style="  margin-top: 1em;
  color: #fff;
  font-size: 1.3em;
  padding: 0.4em 1em;
  -webkit-appearance: none;
  height:45px;
  display: inline-block;
 
  -moz-transition: all 0.3s ease-out;
  -ms-transition: all 0.3s ease-out;
  -o-transition: all 0.3s ease-out;
  transition: all 0.3s ease-out;
  font-weight: 600;
  border: none;
  text-transform: uppercase;
 
  cursor: pointer;
  background: #E24426;
}">--%>
                            </div>
                            <%--</form>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

