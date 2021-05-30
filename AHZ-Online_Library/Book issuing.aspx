<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="Book issuing.aspx.cs" Inherits="AHZ_Online_Library.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>

        .card {background-color:#f2f2f2;
        }
        
           a { text-decoration:none; color :white;
        }
      
       .container-fluid{
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
    <div class="container-fluid">
        <div id="div1" runat="server" class="alert alert-success alert-dismissible" visible="false">
    <button type="button" class="close" data-dismiss="alert">×</button>
    <strong>Success!</strong> operation accomplished successfully
  </div>
           <div id="div3" runat="server" class="alert alert-danger alert-dismissible" visible="false">
    <button type="button" class="close" data-dismiss="alert">×</button>
    <strong>Success!</strong> The operation did not complete
  </div>
        
      <div class="row">
         <div class="col-md-5">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Book Issuing</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center><img src="img/profileadmine.png" width="100px"  />
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-12">
                        <label>Name</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Name"></asp:TextBox>
                              <asp:Button class="btn btn-primary btn-block " ID="Button1" runat="server" Text="Go" OnClick="Button1_Click1" />
                           </div>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>email</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Email"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>password</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Password" ></asp:TextBox>
                        </div>
                     </div>
                  </div>
             
                  <div class="row">
                     <div class="col-4">
                        <asp:Button ID="Button2" class="btn btn-lg btn-block btn-primary" runat="server" Text="Add" OnClick="Button2_Click" />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="Button4" class="btn btn-lg btn-block btn-success" runat="server" Text="Update" OnClick="Button4_Click" />
                     </div>
                      <div class="col-4">
                        <asp:Button ID="Button3" class="btn btn-lg btn-block btn-danger" runat="server" Text="delete" OnClick="Button3_Click"  />
                     </div>
                  </div>
               </div>
            </div>
            <a href="homepage.aspx"><< Back to Home</a><br>
            <br>
         </div>
         <div class="col-md-7">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center><img src="img/clipboard.png"  width="100px"/>
                           <h4>Admine List</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AHZ_Online_library_DBConnectionString %>" SelectCommand="SELECT * FROM [Admin_Login]"></asp:SqlDataSource>
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Email" DataSourceID="SqlDataSource1" ForeColor="White">
                            <Columns>
                                <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="True" SortExpression="Email" />
                                <asp:BoundField DataField="Password_" HeaderText="Password_" SortExpression="Password_" />
                                <asp:BoundField DataField="Admin_Name" HeaderText="Admin_Name" SortExpression="Admin_Name" />
                            </Columns>
                         </asp:GridView>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div>
   </div>
</asp:Content>
