<%@ Page Title="Welcome Admin" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="Log in Admin.aspx.cs" Inherits="AHZ_Online_Library.WebForm4" %>
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
       .container{
height: 100%;

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
    <strong>Success!</strong> You have been logged in
  </div>
         <div id="div2" runat="server" class="alert alert-danger alert-dismissible" visible="false">
    <button type="button" class="close" data-dismiss="alert">×</button>
    <strong>Danger!</strong>The email are wrong
  </div>
         <div id="div4" runat="server" class="alert alert-danger alert-dismissible" visible="false">
    <button type="button" class="close" data-dismiss="alert">×</button>
    <strong>Danger!</strong>The password  are wrong
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
<img src="img/profileadmine.png" width="150px" />
                                </center>

                            </div>

                    </div>
                         <div class="row">
                            <div class="col">
                                <center>
<h3><b>Admin Log In</b></h3>
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
                    </div>
                </div>
            </div>
        </div>
              <a href="Home Page.aspx" id="back_home"><< back to home</a><br /><br />
    </div>
         </div>
        </div>
</asp:Content>
