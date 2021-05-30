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
    public partial class Hello_User : System.Web.UI.Page
    {
        static string con_ahz = ConfigurationManager.ConnectionStrings["ahz_con"].ConnectionString;
        SqlConnection con = new SqlConnection(con_ahz);
        DataSet d = new DataSet();
        SqlDataAdapter ad = new SqlDataAdapter("select * from Member_Account", con_ahz);

        protected void Page_Load(object sender, EventArgs e)
        {
            ad.Fill(d, "Member_Account");
            try
            {
                if (Session["New"].ToString() == "" || Session["New"] == null)
                {
                    Response.Write("<script>alert('Session Expired Login Again');</script>");
                    Response.Redirect("Log-in.aspx");
                }
                else
                {
                    //getUserBookData();

                    if (!Page.IsPostBack)
                    {
                        try
                        {
                            getpersonelinfo();


                        }
                        catch
                        {

                        }
                        // getUserPersonalDetails();
                    }

                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("Log-in.aspx");
            }
        }
        void getpersonelinfo()
        {
            SqlConnection con = new SqlConnection(con_ahz);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT *  from Member_Account where Email='" + Session["New"].ToString() + "';", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            txtmail.Text = ds.Rows[0]["Email"].ToString();
            TextBox1.Text = ds.Rows[0]["Member_Name"].ToString();
            
            DropDownList1.Text = ds.Rows[0]["country"].ToString().Trim();
            TextBox6.Text = ds.Rows[0]["city"].ToString();
            TextBox7.Text = ds.Rows[0]["Phone_Number"].ToString();
            TextBox8.Text = ds.Rows[0]["Member_id"].ToString();
            TextBox9.Text = ds.Rows[0]["Password_"].ToString();
            Label1.Text = ds.Rows[0]["Account_status"].ToString().Trim();
            TextBox2.Text = ds.Rows[0]["Birth_Date"].ToString();

            if (ds.Rows[0]["Account_status"].ToString().Trim() == "active")
            {
                Label1.Attributes.Add("class", "badge badge-pill badge-success");
            }
            else if (ds.Rows[0]["Account_status"].ToString().Trim() == "pending")
            {
                Label1.Attributes.Add("class", "badge badge-pill badge-warning");
            }
            else if (ds.Rows[0]["Account_status"].ToString().Trim() == "deactive")
            {
                Label1.Attributes.Add("class", "badge badge-pill badge-danger");
            }
            else
            {
                Label1.Attributes.Add("class", "badge badge-pill badge-info");

            }
        }

        void updateUserPersonalDetails()
        {
            //string password = "";
            //if (TextBox10.Text.Trim() == "")
            //{
            //    password = TextBox9.Text.Trim();
            //}
            //else
            //{
            //    password = TextBox10.Text.Trim();
            //}
            try
            {
                SqlConnection con = new SqlConnection(con_ahz);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("update Member_Account set Member_Name=@full_name, Birth_Date=@dob, Email=@email, country=@state, city=@city, Phone_Number=@pincode,Password_=@password WHERE email='" + Session["New"].ToString().Trim() + "'", con);

                cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());

                cmd.Parameters.AddWithValue("@email", txtmail.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim());

                cmd.Parameters.AddWithValue("@password", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@account_status", "pending");

                int result = cmd.ExecuteNonQuery();
                SqlCommandBuilder cb = new SqlCommandBuilder(ad);
                ad.Update(d.Tables["Member_Account"]);
                con.Close();
                if (result > 0)
                {

                    Response.Write("<script>alert('Your Details Updated Successfully');</script>");
                    getpersonelinfo();


                }
                else
                {
                    Response.Write("<script>alert('Invaid entry');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["New"].ToString() == "" || Session["New"] == null)
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("Log-in.aspx");
            }
            else
            {
                updateUserPersonalDetails();

            }
        }
    }
}