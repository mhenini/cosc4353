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

        protected void loginButton_Click(object sender, EventArgs e)
        {
            SqlConnection link = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginPageConnectionString"].ConnectionString);
            link.Open();
            string verifyUser = "select count(*) FROM UserLog WHERE username= '" + LoginBox.Text + "'";
            SqlCommand com = new SqlCommand(verifyUser, link);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            link.Close();

            if(temp == 1)
            {
                link.Open();
                string verifyPass = "select password FROM UserLog WHERE username= '" + LoginBox.Text + "'";
                SqlCommand passCom = new SqlCommand(verifyPass, link);
                string password = passCom.ExecuteScalar().ToString();

                if(password == PassWordBox.Text)
                {
                    Response.Redirect("Profile.aspx");
                }
                else
                {
                    Label6.Text = "Password is incorrect";
                    Label6.Visible = true;
               
                }
                link.Close();

            }
            else
            {
                    Label6.Text = "Invalid Username or Password";
                    Label6.Visible = true;

            }


        }

        protected void RegButton_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginPageConnectionString"].ConnectionString);
            con.Open();
            string verifyUser = "select count(*) FROM UserLog WHERE username= '" + TxtBoxNewU.Text + "'";
            SqlCommand com = new SqlCommand(verifyUser, con);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            con.Close();

            if (temp != 1)
            {
                //Label7.Text= "Username is either taken or you are already registered.";
                //Label7.Visible = true;
                
                con.Open();
                string pass = "select count(*) FROM UserLog WHERE password= '" + TextBoxNewPass.Text + "'";
                SqlCommand passComm = new SqlCommand(pass, con);
                string passwordReg = passComm.ExecuteScalar().ToString();
                string confPass = ConfirmTextBox1.ToString();

                if(passwordReg.Equals(confPass))
                {
                    string insertQuery = "insert into UserLog (username,password,confirmPassword) values (@user, @password, @cpass)";
                    SqlCommand comm = new SqlCommand(insertQuery, con);
                    comm.Parameters.AddWithValue("@user", TxtBoxNewU.Text);
                    comm.Parameters.AddWithValue("@password", TextBoxNewPass.Text);
                    comm.Parameters.AddWithValue("@cpass", ConfirmTextBox1.Text);

                    comm.ExecuteNonQuery();
                    Label7.Text = "Registraion is Sucessful. Please login now.";
                    Label7.Visible = true;

                }
                else
                {
                    Label7.Text = "Paswords do not match.";
                    Label7.Visible = true;

                }

            }

            else
            {
               /* 
                string insertQuery = "insert into UserLog (username,password,confirmPassword) values (@user, @password, @cpass)";
                SqlCommand comm = new SqlCommand(insertQuery, con);
                comm.Parameters.AddWithValue("@user", TxtBoxNewU.Text);
                comm.Parameters.AddWithValue("@password", TextBoxNewPass.Text);
                comm.Parameters.AddWithValue("@cpass", ConfirmTextBox1.Text);

                comm.ExecuteNonQuery();
                Label7.Text = "Registraion is Sucessful. Please login now.";
                Label7.Visible = true;
                */

                Label7.Text= "Username is taken.Please enter a different username.";
                Label7.Visible = true;

            }







        }
    }
}