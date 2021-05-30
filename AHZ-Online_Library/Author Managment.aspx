<%@ Page Title="Authors Manager" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="Author Managment.aspx.cs" Inherits="AHZ_Online_Library.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .card { background-color:#f2f2f2;
        }
    
        #back_home {
             color: black;
             background-color:white;
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
    <strong>Success!</strong> Author added successfully.</div>

         <div id="div2" runat="server" class="alert alert-success alert-dismissible" visible="false">
    <button type="button" class="close" data-dismiss="alert">×</button>
    <strong>Success!</strong> Author Updated Successfully
  </div>
           <div id="div3" runat="server" class="alert alert-success alert-dismissible" visible="false">
    <button type="button" class="close" data-dismiss="alert">×</button>
    <strong>Success!</strong> Author Deleted Successfully
  </div>
          <div id="div4" runat="server" class="alert alert-danger alert-dismissible" visible="false">
    <button type="button" class="close" data-dismiss="alert">×</button>
    <strong>Failed!</strong> Author with this ID does not exist .
  </div>
         <div id="div5" runat="server" class="alert alert-danger alert-dismissible" visible="false">
    <button type="button" class="close" data-dismiss="alert">×</button>
    <strong>Failed!</strong> Author Already Exist with this ID.
  </div>
         <div id="div6" runat="server" class="alert alert-danger alert-dismissible" visible="false">
    <button type="button" class="close" data-dismiss="alert">×</button>
             <strong>Failed!</strong> Make sure that you write down a Author ID !
  </div>
        <div class="row">
            <div class="col-md-5">
 
                <div class="card">
                    <div class="card-body">
 
                        <div class="row">
                            <div class="col">
                                <center><img src="img/doctor.png"  width="100px;"/>
                                        <h4>Author Details</h4>
                                    </center>
                            </div>
                        </div>
 
 
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
 
                        <div class="row">
                            <div class="col-md-5">
                                <label>Author ID</label>
                                <div class="form-group">
                                  <div class="input-group-btn">
                                       <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ID"></asp:TextBox>
                                      <asp:Button ID="Button1" runat="server" Text="Go" class="btn btn-primary btn-block btn-lg" OnClick="Button1_Click" />
     
    </div>
                                    </div>
                                
                            </div>            
                            <div class="col-md-7">
                                <label>Author Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Author Name"></asp:TextBox>
 
                                </div>
                            </div>
                        </div>
 
                        <div class="row">
                            <div class="col-4">
                                <asp:Button ID="Button2" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="Button2_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button3" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="Button3_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button4" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="Button4_Click" />
                            </div>
                        </div>
 
 
                    </div>
                </div>
 
                <a href="Home Page.aspx" id="back_home"><< Back to Home</a><br>
                <br>
            </div>
 
            <div class="col-md-7">
 
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center><img src="img/clipboard.png" width="100px" />
                                        <h4>Author List</h4>
                                    </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
 
                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AHZ_Online_library_DBConnectionString %>" SelectCommand="SELECT * FROM [Author_info]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Author_id" DataSourceID="SqlDataSource1" ForeColor="White" AllowPaging="True">
                                    <Columns>
                                        <asp:BoundField DataField="Author_id" HeaderText="Author_id" ReadOnly="True" SortExpression="Author_id" />
                                        <asp:BoundField DataField="Author_Name" HeaderText="Author_Name" SortExpression="Author_Name" />
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
