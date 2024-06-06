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
    public partial class DataControls : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=NIMYA\SQLEXPRESS;database=AspPractice;Integrated Security=true");
        //DISCONNECTED MODE
        protected void Page_Load(object sender, EventArgs e)
        {
            string select_query = "SELECT * FROM Register_form";
            SqlDataAdapter da = new SqlDataAdapter(select_query, con);//da=values
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string qry = "";
            if (!string.IsNullOrWhiteSpace(TextBox1.Text))
            {
                qry += " and Name like'%" + TextBox1.Text + "%'";
            }
            if (!string.IsNullOrWhiteSpace(TextBox2.Text))
            {
                qry += " and Age like'%" + TextBox2.Text + "%'";
            }
            display(qry);
        }
        public void display(string qry)
        {
            string s = "select * from Register_form where 1=1" + qry;
            SqlDataAdapter da = new SqlDataAdapter(s, con);//da=values
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}