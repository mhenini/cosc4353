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
    public partial class ProfileForm : System.Web.UI.Page
    {
        string user;
        protected void Button_Submit(object sender, EventArgs e)
        {
            string fullname = String.Format("{0}", Request.Form["fname"]);
            string Address1 = String.Format("{0}", Request.Form["Addy1"]);
            string Address2 = String.Format("{0}", Request.Form["Addy2"]);
            string City = String.Format("{0}", Request.Form["city"]);
            string State = String.Format("{0}", Request.Form["state"]);
            string Zip = String.Format("{0}", Request.Form["zip"]);

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HistoryConnection"].ConnectionString);
            con.Open();
            string query = "insert into ClientInfo (Username, Fullname, Address1, Address2, City, State, Zipcode) values (@User, @Fname, @Add1, @Add2, @City, @State, @Zip)";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@User", user);
            cmd.Parameters.AddWithValue("@Fname", fullname);
            cmd.Parameters.AddWithValue("@Add1", Address1);
            cmd.Parameters.AddWithValue("@Add2", Address2);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@State", State);
            cmd.Parameters.AddWithValue("@Zip", Zip);
            
            cmd.ExecuteNonQuery();

            con.Close();
            Response.Redirect("Profile.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            user = (string)Session["user"];
        }
    }
}