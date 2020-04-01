using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace cosc4353
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginPageConnectionString"].ConnectionString);
            con.Open();
            string user = "select count(*) FROM login WHERE username= '" + LoginBox.Text + "'";
            SqlCommand com = new SqlCommand(user, con);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            con.Close();

            if(temp == 1)
            {
                con.Open();
                string pass = "select password FROM login WHERE username= '" + LoginBox.Text + "'";
                SqlCommand passCom = new SqlCommand(pass, con);
                string password = passCom.ExecuteScalar().ToString();

                if(password == PassWordBox.Text)
                {
                    Session["user"] = LoginBox.Text;
                    Response.Redirect("Profile.aspx");
                }
                else
                {
                    Label6.Text = "Password is incorrect";
                    Label6.Visible = true;
               
                }

            }
            else
            {
                    Label6.Text = "Invalid Username or Password";
                    Label6.Visible = true;

            }


        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginPageConnectionString"].ConnectionString);
            con.Open();
            string insertQuery = "insert into login (username,password,confirmPassword) values (@user, @password, @cpass)";
            SqlCommand com = new SqlCommand(insertQuery, con);
            com.Parameters.AddWithValue("@user", TxtBoxNewU.Text);
            com.Parameters.AddWithValue("@password", TextBoxNewPass.Text);
            com.Parameters.AddWithValue("@cpass", ConfirmTextBox1.Text);

            com.ExecuteNonQuery();
            Session["user"] = TxtBoxNewU.Text;
            Response.Redirect("ProfileForm.aspx");



        }
    }
}
