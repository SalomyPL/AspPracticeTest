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
    public partial class Change_Password : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=NIMYA\SQLEXPRESS;database=AspPractice;Integrated Security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string select_query = "SELECT Password from Register_form WHERE Id='" + Session["uid"] + "'";
                SqlCommand cmd = new SqlCommand(select_query, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                
                while (dr.Read())
                {
                    TextBox1.Text = dr["Password"].ToString();
                }
                con.Close();
                

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string update_query = "UPDATE Register_form SET Password=" + TextBox2.Text + " WHERE Id='" + Session["uid"] + "'";
            SqlCommand cmd1 = new SqlCommand(update_query, con);
            con.Open();
            int i = cmd1.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                Label1.Text = "Password changed";
            }


        }
    }
}