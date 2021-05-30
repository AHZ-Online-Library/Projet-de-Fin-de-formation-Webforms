<%@ Page Title="Sign Up Page" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="Sign Up.aspx.cs" Inherits="AHZ_Online_Library.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
       
        #back_home {
             color: black;
             background-color:white;
         }
      
     

.card{

    color:white; 
background-color: rgba(0,0,0,0.5) !important;
}
          .form-control {
              background-color: rgba(0,0,0,0.5) !important;
              color:white;
          }
    </style>
    <div class="container">
       <div id="div1" runat="server" class="alert alert-success alert-dismissible" visible="false">
    <button type="button" class="close" data-dismiss="alert">×</button>
    <strong>Success!</strong> Sign Up Successful. Go to User Login to Login
  </div>
         <div id="div2" runat="server" class="alert alert-danger alert-dismissible" visible="false">
    <button type="button" class="close" data-dismiss="alert">×</button>
    <strong>Danger!</strong> Make sure that you fill in all the fields and that the password and Confirm Password are the same
  </div>
           <div id="div3" runat="server" class="alert alert-danger alert-dismissible" visible="false">
    <button type="button" class="close" data-dismiss="alert">×</button>
    <strong>Danger!</strong> This email already exist!
  </div>
    <div class="row" >
      
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
<img src="img/profile.png" width="150px" />
                                </center>

                            </div>

                    </div>
                         <div class="row">
                            <div class="col">
                                <center>
<h3><b>Sign In</b></h3>
                                   
                                        
                                </center>

                            </div>

                    </div>
                         <div class="row">
                            <div class="col">
                                <center>
<hr />
                                </center>

                            </div>

                    </div>
                         <div class="row">
                     <div class="col-md-6">
                        <label>Full Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="full name"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Date of birth</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder="jj/mm/yyyy"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                         <div class="row">
                     <div class="col">
                        <label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Email</label>
                     <center>
                         <div class="form-group">
                          <asp:TextBox CssClass="form-control"  id="txtmail" runat="server" placeholder="Email"  ></asp:TextBox >
                        </div>
                         </center>
                     </div>

                  </div>
                         <div class="row">
                     <div class="col-md-6">
                        <label>Password</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="password" TextMode="Password"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Confirm password</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Confirm password" TextMode="Password"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                            <div class="row">
                     <div class="col-md-4">
                        <label>Country</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                              <asp:ListItem Text="Select" Value="select" />
                              <asp:ListItem Text="Afrique du Sud" Value="Afrique du Sud" />
                              <asp:ListItem Text="Afghanistan" Value="Afghanistan" />
                              <asp:ListItem Text="Albanie" Value="Albanie" />
                              <asp:ListItem Text="Algérie" Value="Algérie" />
                              <asp:ListItem Text="Angola" Value="Angola" />
                              <asp:ListItem Text="Arabie Saoudite" Value="Arabie Saoudite" />
                              <asp:ListItem Text="Argentine" Value="Argentine" />
                              <asp:ListItem Text="Australie" Value="Australie" />
                              <asp:ListItem Text="Bahreïn" Value="Bahreïn" />
                              <asp:ListItem Text="Belgique" Value="Belgique" />
                              <asp:ListItem Text="Bénin" Value="Bénin" />
                              <asp:ListItem Text="Jharkhand" Value="Jharkhand" />
                              <asp:ListItem Text="Karnataka" Value="Karnataka" />
                              <asp:ListItem Text="Kerala" Value="Kerala" />
                              <asp:ListItem Text="Madhya Pradesh" Value="Madhya Pradesh" />
                              <asp:ListItem Text="Maharashtra" Value="Maharashtra" />
                              <asp:ListItem Text="Manipur" Value="Manipur" />
                              <asp:ListItem Text="Meghalaya" Value="Meghalaya" />
                              <asp:ListItem Text="Mizoram" Value="Mizoram" />
                              <asp:ListItem Text="Nagaland" Value="Nagaland" />
                              <asp:ListItem Text="Odisha" Value="Odisha" />
                              <asp:ListItem Text="Punjab" Value="Punjab" />
                              <asp:ListItem Text="Rajasthan" Value="Rajasthan" />
                              <asp:ListItem Text="Sikkim" Value="Sikkim" />
                              <asp:ListItem Text="Tamil Nadu" Value="Tamil Nadu" />
                              <asp:ListItem Text="Telangana" Value="Telangana" />
                              <asp:ListItem Text="Tripura" Value="Tripura" />
                              <asp:ListItem Text="Uttar Pradesh" Value="Uttar Pradesh" />
                              <asp:ListItem Text="Uttarakhand" Value="Uttarakhand" />
                              <asp:ListItem Text="West Bengal" Value="West Bengal" />
                           </asp:DropDownList>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>City</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox6" runat="server" placeholder="City"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Numero</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox7" runat="server" placeholder="Numero" ></asp:TextBox>
                        </div>
                     </div>
                  </div>

                        <div class="row">
                            <div class="col">
                             
                                
                                 <div class="form-group">
                         
                                     <asp:Button ID="Button1" class="btn btn-info btn-block btn-lg" runat="server" Text="Sign UP" OnClick="Button1_Click"/>
                                     <asp:Button ID="Button2" class="btn btn-success btn-block btn-lg" runat="server" Text="Log in" OnClick="Button2_Click"/> 
                            </div>
                    </div>

                </div>

            </div>


        </div>
                <a href="Home Page.aspx" id="back_home"><< back to home</a><br /><br />

    </div>
         </div>
        </div>
</asp:Content>
