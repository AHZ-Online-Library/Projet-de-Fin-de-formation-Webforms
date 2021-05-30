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
    public partial class WebForm5 : System.Web.UI.Page
    {
        static string con_ahz = ConfigurationManager.ConnectionStrings["ahz_con"].ConnectionString;
        SqlConnection con = new SqlConnection(con_ahz);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        bool checkIfMemberExists()
        {
            try
            {
                
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from Member_Account where Member_id='" + TextBox1.Text.Trim() + "';", con);
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

        void updateMemberStatusByID(string status)
        {
            if (checkIfMemberExists())
            {
                try
                {
                   
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                    }
                    SqlCommand cmd = new SqlCommand("UPDATE Member_Account SET account_status='" + status + "' WHERE member_id='" + TextBox1.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    div3.Visible = true;
                    div2.Visible = false;
                    div1.Visible = false;

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                div2.Visible = true;
                div1.Visible = false;
                div3.Visible = false;
            }

        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {

            try
            {

                SqlCommand cmd = new SqlCommand("select * from Member_Account where Member_id='" + TextBox1.Text.Trim() + "'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TextBox4.Text = dr.GetValue(1).ToString();
                        TextBox5.Text = dr.GetValue(2).ToString();
                        txtmail.Text = dr.GetValue(3).ToString();
                        TextBox2.Text = dr.GetValue(4).ToString();
                        TextBox6.Text = dr.GetValue(5).ToString();


                    }

                }
                else
                {
                    div2.Visible = true;
                    div1.Visible = false;
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkIfMemberExists())
            {
                try
                {
                   
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE from  Member_Account where Member_id='" + TextBox1.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    div1.Visible = true;
                    div2.Visible = false;
                    div3.Visible = false;

                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            }
            else
            {
                div2.Visible = true;
                div1.Visible = false;
                div3.Visible = false;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("active");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("pause");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("desactive");
        }
    }
}