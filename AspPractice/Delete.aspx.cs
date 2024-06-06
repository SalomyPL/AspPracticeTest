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
    public partial class Delete : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=NIMYA\SQLEXPRESS;database=AspPractice;Integrated Security=true");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string delete_query = "DELETE FROM Register_form WHERE Name='" + TextBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(delete_query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                Label1.Text = "Deleted";
            }
        }
    }
}