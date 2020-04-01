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
    public partial class Change_Password : System.Web.UI.Page
    {
        
        private string pass;
        string user;
        
        protected void ChangePassClick(object sender, System.EventArgs e)
        {           
            String oldpass = OldPassword.Text;
            String newpass = NewPassword1.Text;
            String confirmpass = NewPassword2.Text;
                        
            if(!(pass == oldpass))
            {
                Correct.Text = "Old Password field is incorrect";
            }
            else if (newpass == confirmpass)
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginPageConnectionString"].ConnectionString);
                connection.Open();
                string changepassquery = "UPDATE login SET password = '" + newpass + "' WHERE username = '" + user + "'";
                SqlCommand command = new SqlCommand(changepassquery, connection);
                command.ExecuteNonQuery();
                connection.Close();

                string redirectScript = " window.location.href = 'Profile.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Password Successfully Saved!');" + redirectScript, true);
            }
            else { Correct.Text = "Passwords do not match"; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            user = (string)Session["user"];
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginPageConnectionString"].ConnectionString);
            connection.Open();
            string PassSearchQuery = "select password FROM login WHERE username= '" + user + "'";
            SqlCommand cmd = new SqlCommand(PassSearchQuery, connection);
            pass = cmd.ExecuteScalar().ToString();
            connection.Close();
        }
        
    }
}