using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace AHZ_Online_Library
{
    public partial class Book_Management : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["ahz_con"].ConnectionString;
        static string global_filepath, global_PDFpath;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillAuthorPublisherValues();
            }

            GridView1.DataBind();
        }

        void fillAuthorPublisherValues()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT Author_Name from Author_Info;", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource = dt;
                DropDownList3.DataValueField = "Author_Name";
                DropDownList3.DataBind();

                cmd = new SqlCommand("SELECT Publisher_Name from Publisher_Info;", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "Publisher_Name";
                DropDownList2.DataBind();

            }
            catch (Exception ex)
            {

            }
        }

        bool checkIfBookExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from Book_Info where Book_Id='" + TextBox1.Text.Trim() + "' OR Book_Name='" + TextBox2.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        void getBookByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from Book_Info WHERE Book_Id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0]["book_name"].ToString();
                 //  TextBox3.Text= dt.Rows[0]["publisher_date"].ToString();
                    TextBox9.Text = dt.Rows[0]["edition"].ToString();
                    TextBox11.Text = dt.Rows[0]["pages"].ToString().Trim();
                    //TextBox6.Text = dt.Rows[0]["description"].ToString();
                    DropDownList1.SelectedValue = dt.Rows[0]["language"].ToString().Trim();
                    DropDownList2.SelectedValue = dt.Rows[0]["publisher_name"].ToString().Trim();
                    DropDownList3.SelectedValue = dt.Rows[0]["author_name"].ToString().Trim();
                    //ListBox1.SelectedValue = dt.Rows[0]["Genre"].ToString();
                    

                    ListBox1.ClearSelection();
                    string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(',');
                    for (int i = 0; i < genre.Length; i++)
                    {
                        for (int j = 0; j < ListBox1.Items.Count; j++)
                        {
                            if (ListBox1.Items[j].ToString() == genre[i])
                            {
                                ListBox1.Items[j].Selected = true;

                            }
                        }
                    }

                    global_filepath = dt.Rows[0]["Image_Book"].ToString();
                    global_PDFpath = dt.Rows[0]["file_book"].ToString();

                }
                //else
                //{
                //    div1.Visible = false;
                //    div2.Visible = false;
                //    div3.Visible = false;
                //    div6.Visible = false;
                //    div5.Visible = false;
                //    div4.Visible = true;

                //    //Response.Write("<script>alert('Invalid Book ID');</script>");
                //}

            }
            catch (Exception ex)
            {

            }
        }

        void addNewBook()
        {
            try
            {
                string genres = "";
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    genres = genres + ListBox1.Items[i] + ",";
                }
                // genres = Adventure,Self Help,
                genres = genres.Remove(genres.Length - 1);

                string filepath = "~/Book_Covers/ebook.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("Book_Covers/" + filename));
                filepath = "~/Book_Covers/" + filename;

            string PDFpath = "~/Books_PDF/";
            string PDFname = Path.GetFileName(FileUpload2.PostedFile.FileName);
            FileUpload2.SaveAs(Server.MapPath("Books_PDF/" + PDFname));
            PDFpath = "~/Books_PDF/" + PDFname;


            SqlConnection con = new SqlConnection(strcon);
                

                SqlCommand cmd = new SqlCommand("INSERT INTO Book_Info (Book_Id,book_name,genre,author_name,publisher_name,publisher_date,language_,edition,pages,book_description,image_book,file_book) values(@book_id,@book_name,@genre,@author_name,@publisher_name,@publish_date,@language,@edition,@pages,@book_description,@book_img_link,@book_pdf_link)", con);

                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);
                cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@pages", TextBox11.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@book_img_link", filepath);
            cmd.Parameters.AddWithValue("@book_pdf_link", PDFpath);

            if (con.State == ConnectionState.Closed)
                {
                con.Open();
            }
                cmd.ExecuteNonQuery();
                con.Close();
                //div1.Visible = true;
                //div2.Visible = false;
                //div3.Visible = false;
                //div4.Visible = false;
                //div5.Visible = false;
                //div6.Visible = false;
              Response.Write("<script>alert('Book added successfully.');</script>");
                GridView1.DataBind();

        }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
}

        void deleteBookByID()
        {
            if (checkIfBookExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE from Book_Info WHERE book_id='" + TextBox1.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();

                    //div6.Visible = false;
                    //div1.Visible = false;
                    //div2.Visible = false;
                    //div4.Visible = false;
                    //div5.Visible = false;
                    //div3.Visible = true;

                    Response.Write("<script>alert('Book Deleted Successfully');</script>");

                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            }
            else
            {
                //div1.Visible = false;
                //div2.Visible = false;
                //div3.Visible = false;
                //div5.Visible = false;
                //div6.Visible = false;
                //div4.Visible = true;

                Response.Write("<script>alert('Invalid Member ID');</script>");
            }
        }

        void updateBookByID()
        {

            if (checkIfBookExists())
            {
                try
                {

                string genres = "";
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    genres = genres + ListBox1.Items[i] + ",";
                }
                // genres = Adventure,Self Help,
               // genres = genres.Remove(genres.Length - 1);

                    //string filepath = "~/Book_Covers/ebook";
                    //string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    //if (filename == "" || filename == null)
                    //{
                    //    filepath = global_filepath;

                    //}
                    //else
                    //{
                    //    FileUpload1.SaveAs(Server.MapPath("Book_Covers/" + filename));
                    //    filepath = "~/Book_Covers/" + filename;
                    //}

                    //string PDFpath = "~/Books_PDF/";
                    //string PDFname = Path.GetFileName(FileUpload2.PostedFile.FileName);
                    //if (PDFname == "" || PDFname == null)
                    //{
                    //    PDFpath = global_PDFpath;

                    //}
                    //else
                    //{
                    //    FileUpload2.SaveAs(Server.MapPath("Books_PDF/" + PDFname));
                    //    PDFpath = "~/Books_PDF/" + PDFname;
                    //}

                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE Book_Info set Book_Name=@book_name, author_name=@author_name, publisher_name=@publisher_name, language_=@language, edition=@edition,pages=@pages where book_id='" + TextBox1.Text.Trim() + "'", con);
                    //,file_book = @book_pdf_link , Image_Book=@book_img_link , publisher_date=@publish_date, book_description=@book_description, Genre=@genre


                    cmd.Parameters.AddWithValue("@book_name", TextBox2.Text);
                   // cmd.Parameters.AddWithValue("@genre", genres);
                    cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                    //cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text);
                    cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@edition", TextBox9.Text);         
                    cmd.Parameters.AddWithValue("@pages", TextBox11.Text);
                    //cmd.Parameters.AddWithValue("@book_description", TextBox6.Text);
                    //cmd.Parameters.AddWithValue("@book_img_link", filepath);
                    //cmd.Parameters.AddWithValue("@book_pdf_link", PDFpath);

                    cmd.ExecuteNonQuery();
                    con.Close();

                    //div1.Visible = false;
                    //div4.Visible = false;
                    //div3.Visible = false;
                    //div5.Visible = false;
                    //div6.Visible = false;
                    //div2.Visible = true;

                  Response.Write("<script>alert('Book Updated Successfully');</script>");
                    GridView1.DataBind();

            }
                catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
            else
            {
                //div6.Visible = true;
                //div1.Visible = false;
                //div2.Visible = false;
                //div3.Visible = false;
                //div4.Visible = false;
                //div5.Visible = false;
               Response.Write("<script>alert('Invalid Book ID');</script>");
            }
        }
        //Add book
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkIfBookExists())
            {
                //div1.Visible = false;
                //div2.Visible = false;
                //div3.Visible = false;
                //div4.Visible = false;
                //div5.Visible = true;
                //div6.Visible = false;

               Response.Write("<script>alert('Book Already Exists, try some other Book ID');</script>");
            }
            else
            {
                addNewBook();
            }
        }
        //Go button
        protected void Button4_Click(object sender, EventArgs e)
        {
            getBookByID();
        }
        //update button
        protected void Button3_Click(object sender, EventArgs e)
        {
            updateBookByID();
        }
        //delete button
        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteBookByID();
        }
    }
}