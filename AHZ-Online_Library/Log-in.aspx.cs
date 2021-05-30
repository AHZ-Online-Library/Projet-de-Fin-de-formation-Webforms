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
    public partial class WebForm1 : System.Web.UI.Page
    {
        static string con_ahz = ConfigurationManager.ConnectionStrings["ahz_con"].ConnectionString;
        SqlConnection con = new SqlConnection(con_ahz);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "" || TextBox2.Text == "")
            {

                div4.Visible = false;
                div2.Visible = false;
                div1.Visible = false;
                div3.Visible = true;
            }
            else
            {

                SqlCommand cmd = new SqlCommand("select count(*) from Member_Account  where email= '" + TextBox1.Text + "'", con);
                SqlCommand commend = new SqlCommand("select * from Mamber_Account ", con);

                con.Open();

                int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                con.Close();

                if (temp == 1)
                {
                    con.Open();
                    SqlCommand passcmd = new SqlCommand(" select Password_ from Member_Account where email= '" + TextBox1.Text + "'", con);
                    string password = passcmd.ExecuteScalar().ToString();

                    if (password == TextBox2.Text)
                    {

                        Session["New"] = TextBox1.Text;
                        //  Response.Write("<script>alert('shih')</script>");
                        div1.Visible = true;
                        div3.Visible = false;
                        div4.Visible = false;
                        div2.Visible = false;


                        Session["role"] = "user";
                        Response.Redirect("Home Page.aspx");
                    }
                    else
                    {

                        // Response.Write("<script>alert('msshihx')</script>");
                        div3.Visible = false;
                        div2.Visible = false;
                        div1.Visible = false;
                        div4.Visible = true;

                    }

                }
                else
                {

                    div2.Visible = true;
                    div3.Visible = false;
                    div1.Visible = false;
                    div4.Visible = false;

                }

            }

        }
        
    }
}