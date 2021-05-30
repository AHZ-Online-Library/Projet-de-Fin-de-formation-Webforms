using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace AHZ_Online_Library
{
    public partial class WebForm2 : System.Web.UI.Page

    {
        static string con_ahz = ConfigurationManager.ConnectionStrings["ahz_con"].ConnectionString; 
        SqlConnection con = new SqlConnection(con_ahz);
        
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Log-in.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select count(*) from Member_Account where Email = '" + txtmail.Text + "'", con);

            con.Open();
            int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            con.Close();
            if (temp == 1)
            {
                div3.Visible = true;
                div2.Visible = false;
                div1.Visible = false;
            }
            else
            {
                signup();
            }
        }
        void signup()
        {


            if (TextBox1.Text == "" || TextBox2.Text == "" || TextBox3.Text == "" || TextBox6.Text == "" || TextBox7.Text == "" || TextBox11.Text == "" || TextBox2.Text != TextBox3.Text)
            {
                //   Response.Write("<script>alert('Make sure that you fill in all the fields and that the password and Confirm Password are the same');</script>");
                //    div.Text = "Make sure that you fill in all the fields and that the password and Confirm Password are the same";
                div2.Visible = true;
                div1.Visible = false;
                div3.Visible = false;
            }
            else
            {

                SqlCommand cmd = new SqlCommand("Insert into Member_Account values ('" + TextBox1.Text + "','" + "pending" + "','" + txtmail.Text + "','" + DropDownList1.SelectedItem.Value + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + TextBox2.Text + "','" + TextBox11.Text + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                // Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login');</script>");
                // div2.Text = "Sign Up Successful. Go to User Login to Login";
                div2.Visible = false;
                div1.Visible = true;
                div3.Visible = false;

            }

        }
    }
}