<%@ Page Title="Manage a Member" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="Member Manager.aspx.cs" Inherits="AHZ_Online_Library.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <style>
        .card {  background-color:#f2f2f2;
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
    <script>
        $(document).ready(function () {
            $("button").click(function () {
                $("#div3").hide(1000);
            });
            $("button").click(function () {
                $("#div2").hide(1000);
            })
            $("button").click(function () {
                $("#div1").hide(1000);
            })
        });

    </script>
    <section>
    <div class="container-fluid">
          <div id="div1" runat="server" class="alert alert-success alert-dismissible" visible="false">
    <button type="button" class="close" data-dismiss="alert">×</button>
    <strong>Success!</strong> Member Deleted Successfully
  </div>
           <div id="div3" runat="server" class="alert alert-success alert-dismissible" visible="false">
    <button type="button" class="close" data-dismiss="alert">×</button>
    <strong>Success!</strong> Member Status Updated
  </div>
         <div id="div2" runat="server" class="alert alert-danger alert-dismissible" visible="false">
    <button type="button" class="close" data-dismiss="alert">×</button>
    <strong>Danger!</strong> Invalid Member ID
  </div>
    <div class="row">
            <div class="col-md-5">
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
<h3><b>Member delail</b></h3>
                                  
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
                     <div class="col-md-3">
                        <label>Member ID</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Member ID"></asp:TextBox>
                              <asp:LinkButton class="btn btn-primary  " ID="LinkButton4" runat="server" OnClick="LinkButton4_Click"><i class="fas fa-check-circle"></i></asp:LinkButton>
                           </div>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Full Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Full Name" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-5">
                        <label>Account Status</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control mr-1" ID="TextBox5" runat="server" placeholder="Account Status" ReadOnly="True"></asp:TextBox>
                              <asp:LinkButton class="btn btn-success mr-1" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"><i class="fas fa-check-circle"></i></asp:LinkButton>
                              <asp:LinkButton class="btn btn-warning mr-1" ID="LinkButton2" runat="server" OnClick="LinkButton2_Click"><i class="far fa-pause-circle"></i></asp:LinkButton>
                              <asp:LinkButton class="btn btn-danger mr-1" ID="LinkButton3" runat="server" OnClick="LinkButton3_Click"><i class="fas fa-times-circle"></i></asp:LinkButton>
                           </div>
                        </div>
                     </div>
                  </div>
                         <div class="row">
                     <div class="col">
                        <label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Email</label>
                    
                         <div class="form-group">
                              <center>
                          <asp:TextBox CssClass="form-control"  id="txtmail" runat="server" placeholder="Email"  ReadOnly="True"></asp:TextBox >
                                  </center>
                        </div>
                         
                     </div>

                  </div>
                     
                            <div class="row">
                     <div class="col-md-4">
                        <label>Country</label>
                        <div class="form-group">
                          <asp:TextBox class="form-control" ID="TextBox2" runat="server" placeholder="City" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>City</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox6" runat="server" placeholder="City" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Numero</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox7" runat="server" placeholder="Numero" ReadOnly="True" ></asp:TextBox>
                        </div>
                     </div>
                  </div>

                        <div class="row">
                            <div class="col">
                             
                                
                                 <div class="form-group">
                         <center>
                                     <asp:Button ID="Button1" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete user" OnClick="Button1_Click" />
</center>
                            </div>
                                 

                    </div>

                </div>

            </div>


        </div>
                <a href="homepage.aspx"><< back to home</a><br /><br />

    </div>
         <div class="col-md-7">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                            <img src="img/clipboard.png" width="100px;" />
                            <center>
<h3><b>Member list</b></h3>
                                    

                                </center>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AHZ_Online_library_DBConnectionString %>" SelectCommand="SELECT [Member_id], [Member_Name], [Account_Status], [Email], [Country], [City] FROM [Member_Account]"></asp:SqlDataSource>
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Email" DataSourceID="SqlDataSource1" ForeColor="White" AllowPaging="True">
                            <Columns>
                                <asp:BoundField DataField="Member_id" HeaderText="Member_id" InsertVisible="False" ReadOnly="True" SortExpression="Member_id" />
                                <asp:BoundField DataField="Member_Name" HeaderText="Member_Name" SortExpression="Member_Name" />
                                <asp:BoundField DataField="Account_Status" HeaderText="Account_Status" SortExpression="Account_Status" />
                                <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="True" SortExpression="Email" />
                                <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                            </Columns>
                         </asp:GridView>
                     </div>
                  </div>
               </div>
            </div>
         </div>
         </div>
        </div>
     </section>
</asp:Content>
