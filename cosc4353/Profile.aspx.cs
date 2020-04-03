using System;
using System.Collections.Generic;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace cosc4353
{
    public partial class Profile : System.Web.UI.Page
    {
        private string user;
        private string FullName;
        private string Address1;
        private string Address2;
        private string City;
        private string State;
        private string Zipcode;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = (string)Session["user"];
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HistoryConnection"].ConnectionString);
            connection.Open();
            SqlCommand com = new SqlCommand("SELECT FullName, Address1, Address2, City, State, Zipcode FROM ClientInfo WHERE Username = '" + user + "'", connection);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                FullName = reader.GetString(0);
                Address1 = reader.GetString(1);
                if(reader["Address2"] == DBNull.Value)
                {
                    Address2 = "";
                }
                else
                {
                    Address2 = reader.GetString(2);
                }
                City = reader.GetString(3);
                State = reader.GetString(4);
                Zipcode = reader.GetString(5);
            }
            connection.Close();

            welcome.Text = "Welcome " + FullName + "!";
            Add1.Text = Address1;
            Add2.Text = Address2;
            cit.Text = City;
            ste.Text = State;
            zip.Text = Zipcode;
        }
    }
}