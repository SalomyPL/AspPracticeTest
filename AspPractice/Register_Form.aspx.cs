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
    public partial class Register_Form : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=NIMYA\SQLEXPRESS;database=AspPractice;Integrated Security=true");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //checking the username exist or not
            string count_query = "SELECT count(Id) FROM Register_form WHERE Username='" + TextBox5.Text + "'";
            SqlCommand cmd = new SqlCommand(count_query, con);
            con.Open();
            string Cid = cmd.ExecuteScalar().ToString();
            con.Close();
            if (Cid =="1")
            {
                Label13.Text = "Username is already exist.";
            }

            // Data's insert into database

            string upload_photo = "~/photos/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(upload_photo));

            string list_item = "";
            for(int i=0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                {
                    list_item = list_item + CheckBoxList1.Items[i].Text + ",";
                }
            }

            string insert_query = "INSERT INTO Register_form VALUES('" + TextBox7.Text + "'," + TextBox8.Text + "," + TextBox3.Text + ",'" + TextBox4.Text + "','" + RadioButtonList1.SelectedItem.Text + "','" + DropDownList1.SelectedItem.Text + "','" + list_item + "','" + upload_photo+ "','" + TextBox5.Text + "','" + TextBox6.Text + "')";
            SqlCommand cmd1 = new SqlCommand(insert_query, con);
            con.Open();
            int i1=cmd1.ExecuteNonQuery();
            con.Close();
            if (i1 == 1)
            {
                Label12.Text = "inserted";
            }

        }
        
        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {
            string count_query = "SELECT count(Id) FROM Register_form WHERE Username='" + TextBox5.Text + "'";
            SqlCommand cmd2 = new SqlCommand(count_query, con);
            con.Open();
            string cid = cmd2.ExecuteScalar().ToString();
            con.Close();
            if (cid == "1")
            {
                Label13.Visible =true;
                Label13.Text = "Username is already existed.please choose another username";
            }
            else
            {
                Label13.Visible = false;

            }
        }
    }
}