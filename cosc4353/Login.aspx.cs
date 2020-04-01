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
            string verifyUser = "select count(*) FROM login WHERE username= '" + LoginBox.Text + "'";
            SqlCommand com = new SqlCommand(verifyUser, link);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            link.Close();

            if(temp == 1)    // checks db to see in username exist
            {
                link.Open();
                string verifyPass = "select password FROM login WHERE username= '" + LoginBox.Text + "'";
                SqlCommand passCom = new SqlCommand(verifyPass, link);
                string password = passCom.ExecuteScalar().ToString();
                string conf = resText.Text;

                if(password == PassWordBox.Text)   // if username and password are correct, redirect user to profile page
                {
                    Session["user"] = LoginBox.Text;
                    if(conf.ToUpper() == "N")
                    {
                      Response.Redirect("History.aspx");
                    }
                    else
                    {
                       Response.Redirect("Profile.aspx");
                    }
                    
                }
                else
                {
                    Label6.Text = "Password is incorrect";  //if password doesnt match username in db
                    Label6.Visible = true;
               
                }
                link.Close();

            }
            else
            {
                    Label6.Text = "Invalid Username or Password";   // if username or password is not correct or user doesnt exist in db
                    Label6.Visible = true;

            }


        }

        protected void RegButton_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginPageConnectionString"].ConnectionString);
            con.Open();
            string verifyUser = "select count(*) FROM login WHERE username= '" + TxtBoxNewU.Text + "'";
            SqlCommand com = new SqlCommand(verifyUser, con);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            con.Close();

            if (temp != 1)      
            {
                con.Open();
                string passwordReg = TextBoxNewPass.Text;
                string confirmPass = ConfirmTextBox1.Text;

                if (passwordReg.Length < 8)     // password length verification field
                {
                    Label7.Text = "Pasword length is too short. Please enter a longer password";
                    Label7.Visible = true;

                }

                if(passwordReg != confirmPass)  //ensures user enters password correctly twice
                {
                    Label7.Text = "Passwords do not match.Please try again";
                    Label7.Visible = true;
                }

                else      // adds the username and password into the db
                {
                    string insertQuery = "insert into login (username,password,confirmPassword) values (@user, @password, @cpass)";
                    SqlCommand comm = new SqlCommand(insertQuery, con);
                    comm.Parameters.AddWithValue("@user", TxtBoxNewU.Text);
                    comm.Parameters.AddWithValue("@password", TextBoxNewPass.Text);
                    comm.Parameters.AddWithValue("@cpass", ConfirmTextBox1.Text);
                    comm.ExecuteNonQuery();
                    Label7.Text = "Registraion is Sucessful. Please login now.";
                    Label7.Visible = true;

                }
                
            }

            else   //Username is taken or user is already registered in the db
            {
                Label7.Text= "Username is taken.Please enter a different username.";
                Label7.Visible = true;

            }







        }
    }
}