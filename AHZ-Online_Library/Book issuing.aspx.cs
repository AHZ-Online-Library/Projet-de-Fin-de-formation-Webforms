using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AHZ_Online_Library
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        static string con_ahz = ConfigurationManager.ConnectionStrings["ahz_con"].ConnectionString;
        SqlConnection con = new SqlConnection(con_ahz);
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        void delete()
        {
            try
            {
              
                SqlCommand cmd = new SqlCommand("DELETE from  Admin_Login where Admin_Name='" + TextBox1.Text.Trim() + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                div1.Visible = true;

                div3.Visible = false;

                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void update()
        {

            SqlCommand cmd = new SqlCommand("update Admin_Login set Password_=@mode_de_passe WHERE Admin_Name='" + TextBox1.Text.Trim() + "'", con);
            cmd.Parameters.AddWithValue("@Email", TextBox3.Text.Trim());
            cmd.Parameters.AddWithValue("@mode_de_passe", TextBox4.Text.Trim());
            con.Open();
            cmd.ExecuteNonQuery();
            GridView1.DataBind();
            con.Close();


        }

        void add()
        {
            if (TextBox1.Text == "" || TextBox3.Text == "" || TextBox4.Text == "")
            {
                div3.Visible = true;
                div1.Visible = false;
            }
            else
            {
                
                SqlCommand cmd = new SqlCommand("Insert into Admin_Login values ('" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox1.Text + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                GridView1.DataBind();
                con.Close();
                // Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login');</script>");
                // div2.Text = "Sign Up Successful. Go to User Login to Login";
                div1.Visible = true;
                div3.Visible = false;

            }

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Admin_Login where Admin_Name='" + TextBox1.Text.Trim() + "'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    TextBox3.Text = dr.GetValue(0).ToString();


                    TextBox4.Text = dr.GetValue(1).ToString();
                    div1.Visible = true;
                    div3.Visible = false;

                }

            }
            else
            {
                div3.Visible = true;
                div1.Visible = false;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select count(*) from Admin_Login where Admin_Name= '" + TextBox1.Text + "'", con);

            con.Open();
            int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            con.Close();
            if (temp == 1)
            {
                div3.Visible = true;
                div1.Visible = false;
            }
            else
            {
                add();


            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            update();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            delete();
        }
    }
}