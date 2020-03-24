using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cosc4353
{
    public partial class Change_Password : System.Web.UI.Page
    {
        protected void ChangePassClick(object sender, System.EventArgs e)
        {
            String oldpass = OldPassword.Text;
            String newpass = NewPassword1.Text;
            String confirmpass = NewPassword2.Text;

            if (newpass == confirmpass)
            {
                Correct.Text = "Password Changed Successfully";
            }
            else { Correct.Text = "Passwords do not match"; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}