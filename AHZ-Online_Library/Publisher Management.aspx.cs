using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace AHZ_Online_Library
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["ahz_con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        // ADD a Publisher

        protected void Button2_Click(object sender, EventArgs e)
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
                if (checkPublisherExists())
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
                    addNewPublisher();
                }
            }
        }

        //Update a Publisher
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
                if (checkPublisherExists())
                {
                    updatePublisherByID();
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
        //Delete a Publisher
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
                if (checkPublisherExists())
                {
                    deletePublisherByID();
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
        //Go Button
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

                getPublisherByID();
        }
        void getPublisherByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from Publisher_info where Publisher_id='" + TextBox1.Text.Trim() + "';", con);
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

        bool checkPublisherExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from Publisher_info where Publisher_id='" + TextBox1.Text.Trim() + "';", con);
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

        void addNewPublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO Publisher_info(Publisher_id,Publisher_Name) values(@publisher_id,@publisher_name)", con);

                cmd.Parameters.AddWithValue("@publisher_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());


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

        public void updatePublisherByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("update Publisher_info set Publisher_Name=@publisher_name WHERE Publisher_id='" + TextBox1.Text.Trim() + "'", con);
                cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());
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

        public void deletePublisherByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("Delete from Publisher_info WHERE Publisher_id='" + TextBox1.Text.Trim() + "'", con);
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


    }
}