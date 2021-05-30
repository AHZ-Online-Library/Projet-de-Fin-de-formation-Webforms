using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AHZ_Online_Library
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();

        }
        static string con_ahz = ConfigurationManager.ConnectionStrings["ahz_con"].ConnectionString;
        SqlConnection con = new SqlConnection(con_ahz);
        public bool checkIfAuthorExists()
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from Author_info where Author_id='" + TextBox1.Text.Trim() + "';", con);
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
        public void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
        public void addNewAuteur()
        {
            try
            {
                SqlConnection con = new SqlConnection(con_ahz);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO Author_info(Author_id,Author_Name) values(@Author_id,@Author_Name)", con);

                cmd.Parameters.AddWithValue("@Author_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@Author_Name", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                // Response.Redirect("Publisher Management.aspx");
                //  Response.Write("<script>alert('Publisher added successfully.');</script>");
                div1.Visible = true;
                div4.Visible = false;
                div2.Visible = false;
                div3.Visible = false;
                div5.Visible = false;
                div6.Visible = false;
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        public void updateAuteur()
        {
            try
            {
                SqlConnection con = new SqlConnection(con_ahz);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE Author_info SET Author_Name=@Author_Name WHERE Author_id='" + TextBox1.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@Author_Name", TextBox2.Text.Trim());

                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {

                    div1.Visible = false;
                    div4.Visible = false;
                    div3.Visible = false;
                    div5.Visible = false;
                    div6.Visible = false;
                    div2.Visible = true;

                    // Response.Write("<script>alert('Publisher Updated Successfully');</script>");
                    GridView1.DataBind();
                }
                else
                {

                    div1.Visible = false;
                    div2.Visible = false;
                    div3.Visible = false;
                    div5.Visible = false;
                    div6.Visible = false;
                    div4.Visible = true;
                    // Response.Write("<script>alert('Publisher ID does not Exist');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        public void deleteAuteur()
        {
            try
            {
                SqlConnection con = new SqlConnection(con_ahz);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE from Author_info WHERE Author_id='" + TextBox1.Text.Trim() + "'", con);
                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {
                    div6.Visible = false;
                    div1.Visible = false;
                    div2.Visible = false;
                    div4.Visible = false;
                    div5.Visible = false;
                    div3.Visible = true;


                    //Response.Write("<script>alert('Publisher Deleted Successfully');</script>");
                    GridView1.DataBind();
                }
                else
                {
                    div1.Visible = false;
                    div2.Visible = false;
                    div3.Visible = false;
                    div5.Visible = false;
                    div6.Visible = false;
                    div4.Visible = true;
                    //Response.Write("<script>alert('Publisher ID does not Exist');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
       public void getAuteurID()
        {
            try
            {
                SqlConnection con = new SqlConnection(con_ahz);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from Author_info where Author_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                    div6.Visible = false;
                    div1.Visible = false;
                    div2.Visible = false;
                    div3.Visible = false;
                    div5.Visible = false;
                    div4.Visible = false;
                }
                else
                {
                    div6.Visible = false;
                    div1.Visible = false;
                    div2.Visible = false;
                    div3.Visible = false;
                    div5.Visible = false;
                    div4.Visible = true;
                    // Response.Write("<script>alert('Publisher with this ID does not exist.');</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "" || TextBox2.Text == "")
            {
                div6.Visible = true;
                div1.Visible = false;
                div2.Visible = false;
                div3.Visible = false;
                div4.Visible = false;
                div5.Visible = false;
            }
            else
            {
                if (checkIfAuthorExists())
                {
                    div1.Visible = false;
                    div2.Visible = false;
                    div3.Visible = false;
                    div4.Visible = false;
                    div5.Visible = true;
                    div6.Visible = false;
                    // Response.Write("<script>alert('Publisher Already Exist with this ID.');</script>");
                }
                else
                {
                    addNewAuteur();
                }

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            if (TextBox1.Text == "")
            {
                div6.Visible = true;
                div1.Visible = false;
                div2.Visible = false;
                div3.Visible = false;
                div4.Visible = false;
                div5.Visible = false;
                div6.Visible = false;
            }
            else
            {
                if (checkIfAuthorExists())
                {
                    updateAuteur();
                }
                else
                {
                    div6.Visible = false;
                    div1.Visible = false;
                    div2.Visible = false;
                    div3.Visible = false;
                    div4.Visible = true;
                    div5.Visible = false;
                    //Response.Write("<script>alert('Publisher with this ID does not exist');</script>");
                }


            }



        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            if (TextBox1.Text == "")
            {
                div6.Visible = true;
                div1.Visible = false;
                div2.Visible = false;
                div3.Visible = false;
                div4.Visible = false;
                div5.Visible = false;
            }
            else
            {
                if (checkIfAuthorExists())
                {
                    deleteAuteur();
                }
                else
                {
                    div6.Visible = false;
                    div1.Visible = false;
                    div2.Visible = false;
                    div3.Visible = false;
                    div4.Visible = true;
                    div5.Visible = false;
                    //  Response.Write("<script>alert('Publisher with this ID does not exist');</script>");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (TextBox1.Text == "")
            {

                div6.Visible = true;
                div1.Visible = false;
                div2.Visible = false;
                div3.Visible = false;
                div4.Visible = false;
                div5.Visible = false;
            }
            else
                getAuteurID();
        }
    } 
}