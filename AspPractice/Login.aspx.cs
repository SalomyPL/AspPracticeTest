using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace AspPractice
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=NIMYA\SQLEXPRESS;database=AspPractice;Integrated Security=true");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string count_query = "SELECT count(Id) FROM Register_form WHERE Username='" + TextBox1.Text + "'and Password='"+TextBox2.Text+"'";
            SqlCommand cmd = new SqlCommand(count_query, con);
            con.Open();
            string cid = cmd.ExecuteScalar().ToString();
            con.Close();
            if (cid == "1")
            {
                string id_query = "SELECT Id FROM Register_form WHERE Username='" + TextBox1.Text + "'and Password='" + TextBox2.Text + "'";
                SqlCommand cmd1 = new SqlCommand(id_query, con);
                con.Open();
                // string id = cmd1.ExecuteScalar().ToString();
                SqlDataReader dr = cmd1.ExecuteReader();
                int getid = 0;
                while (dr.Read())
                {
                    getid = Convert.ToInt32(dr["Id"].ToString());
                }
                con.Close();
                Session["uid"] = getid;
                Response.Redirect("ViewUserProfile.aspx");
               
            }
            else
            {
                Label1.Text = "Invalid username and password";
            }
                    
        }
    }
}