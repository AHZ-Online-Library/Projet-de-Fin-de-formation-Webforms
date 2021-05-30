<%@ Page Title="Log in Page" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="Log-in.aspx.cs" Inherits="AHZ_Online_Library.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
     <style>
         #back_home {
             color: black;
             background-color:white;
         }
        .card { background-color:#f2f2f2;
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
    <div id="div1" runat="server" class="alert alert-success alert-dismissible" visible="false">
    <button type="button" class="close" data-dismiss="alert">×</button>
    <strong>Success!</strong> You have been logged in succesfully
  </div>
         <div id="div2" runat="server" class="alert alert-danger alert-dismissible" visible="false">
    <button type="button" class="close" data-dismiss="alert">×</button>
    <strong>Danger!</strong>The email is wrong
  </div>
         <div id="div4" runat="server" class="alert alert-danger alert-dismissible" visible="false">
    <button type="button" class="close" data-dismiss="alert">×</button>
    <strong>Danger!</strong>The password  is wrong
  </div>
         <div id="div3" runat="server" class="alert alert-danger alert-dismissible" visible="false">
    <button type="button" class="close" data-dismiss="alert">×</button>
    <strong>Danger!</strong>Make sure to fill in the email and password field
  </div>
    <div class="row">
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
<h3><b>Log In</b></h3>
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
                            <div class="col">
                                 <label>Email</label>
                      <div class="form-group">
                         
                          <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="Email" runat="server"></asp:TextBox>
                      </div>
                                <label>Password</label>
                      <div class="form-group">
                         
                          <asp:TextBox ID="TextBox2" CssClass="form-control" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                      </div>
                                 <div class="form-group">
                         
                                     <asp:Button ID="Button1" class="btn btn-success btn-block btn-lg" runat="server" Text="Log In" OnClick="Button1_Click" />

                            </div>
                                 <div class="form-group">
                         
                                     <a href="Sign Up.aspx"><input id="Button2" class="btn btn-info btn-block btn-lg" type="button" value="Sign In" /></a>

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
