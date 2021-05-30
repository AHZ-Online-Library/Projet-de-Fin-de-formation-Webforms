<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="View Books.aspx.cs" Inherits="AHZ_Online_Library.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
         
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <style>

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
            <div class="row">
                <center>
                        <h3 color: "#FFFFFF" style="color: #FFFFFF">
                        Book Inventory List</h3>
                    </center>
          
                    <br />
                    <div class="row">
                        <div class="card"
                            <div class="card-body">
                                
                                <div class="row">
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AHZ_Online_library_DBConnectionString %>" SelectCommand="SELECT * FROM [Book_info]"></asp:SqlDataSource>
                                    <div class="col">
                                 <asp:GridView class="table table-striped table-bordered nowrap"  ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1" ForeColor="#333333" AllowPaging="True" CellPadding="4" GridLines="None" PageSize="3">
                                     <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                           <Columns>
                              <asp:BoundField DataField="book_id" HeaderText="ID" ReadOnly="True" SortExpression="book_id" >
                                 <ControlStyle Font-Bold="True" />
                                 <ItemStyle Font-Bold="True" />
                              </asp:BoundField>
                              <asp:TemplateField>
                                 <ItemTemplate>
                                    <div class="container-fluid">
                                       <div class="row">
                                          <div class="col-lg-10">
                                             <div class="row">
                                                <div class="col-12">
                                                   <asp:Label ID="Label1" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                </div>
                                             </div>
                                             <div class="row">
                                                <div class="col-12">
                                                   <span>Author - </span>
                                                   <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("author_name") %>'></asp:Label>
                                                   &nbsp;| <span><span>&nbsp;</span>Genre - </span>
                                                   <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("genre") %>'></asp:Label>
                                                   &nbsp;| 
                                                   <span>
                                                      Language -<span>&nbsp;</span>
                                                      <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("language_") %>'></asp:Label>
                                                   </span>
                                                </div>
                                             </div>
                                             <div class="row">
                                                <div class="col-12">
                                                   Publisher -
                                                   <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("publisher_name") %>'></asp:Label>
                                                   &nbsp;| Publish Date -
                                                   <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("publisher_date") %>'></asp:Label>
                                                   &nbsp;| Pages -
                                                   <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("pages") %>'></asp:Label>
                                                   &nbsp;| Edition -
                                                   <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("edition") %>'></asp:Label>
                                                </div>
                                             </div>
                                             
                                             <div class="row">
                                                <div class="col-12">
                                                   Description -
                                                   <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Smaller" Text='<%# Eval("book_description") %>'></asp:Label>
                                                </div>
                                             </div>
                                          </div>
                                          <div class="col-lg-2">
                                             <asp:Image class="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("image_book") %>' />
                                          </div>
                                       </div>
                                    </div>
                                 </ItemTemplate>
                              </asp:TemplateField>
                                <asp:HyperLinkField DataNavigateUrlFields="file_book" Text="Read and Download" />
                           </Columns>
                                     <EditRowStyle BackColor="#999999" />
                                     <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                     <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                     <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                     <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                     <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                     <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                     <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                     <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                     <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
           </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <center>
                    <a href="home.aspx">
                        << Back to Home</a><span class="clearfix"></span>
                           <br />
               <center>
            </div>
        </div>
</asp:Content>

