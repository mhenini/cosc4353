using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cosc4353
{
    public partial class Form : System.Web.UI.Page
    {
        private string connStr = ConfigurationManager.ConnectionStrings["fuelSite"].ConnectionString;

        // This is temp for testing. The user name should be pullen in from a session var.
        // Ex:  string user = (string)Session["username"];
        // Session var can be set from the login page when user successfully logs in
        string user;

        private double locationFactor;
        private double historyFactor;
        private double gallonsFactor;
        private double companyFactor = 0.1;
        private double rateFactor;
        private static double suggestedPrice;
        private static double totalPrice;

        private static double gallonsRequested;
        private static string deliveryAddress;
        private static string deliveryDate;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (string)Session["user"];
            
            SqlConnection conn = new SqlConnection(connStr);
            // load delivery address from client info table
            conn.Open();
            string query = "select Address1, City, State, Zipcode from ClientInfo where Username = '" + user + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader result = cmd.ExecuteReader();
            result.Read();
            deliveryAddress = result["Address1"].ToString() +", " + result["City"].ToString() + ", " + result["State"].ToString().Trim() + " " + result["Zipcode"].ToString();
            conn.Close();

            address.Value = deliveryAddress;
        }     

        // set location factor
        protected void setLocationFactor() {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string query = "select State from ClientInfo where Username = '" + user + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader result = cmd.ExecuteReader();
            result.Read();
            string st = result["State"].ToString().Trim().ToLower();

            if (st == "tx")
                locationFactor = 0.02;
            else
                locationFactor = 0.04;

            conn.Close();
        }

        // rate history factor
        protected void setHistoryFactor() {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string query = "select count(*) from FuelQuote where Username = '" + user + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            int result = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            
            if (result == 0)
                historyFactor = 0;
            else
                historyFactor = 0.01;

            conn.Close();
        }

        // gallons requested factor
        protected void setGallonsFactor() {
            if (gallonsRequested < 1000)
                gallonsFactor = 0.03;
            else
                gallonsFactor = 0.02;
        }      

        // rate fluctuation
        protected void setRateFactor() {
            int month = Convert.ToInt32(deliveryDate.Substring(0,2));
            if (6 <= month && month <= 8)
                rateFactor = 0.04;
            else
                rateFactor = 0.03;
        }

        // calc/dispay suggested/total price
        protected void calcPrices() {
            setLocationFactor();
            setHistoryFactor();
            setGallonsFactor();
            setRateFactor();

            double currentPrice = 1.50;
            double margin = currentPrice * (locationFactor - historyFactor + gallonsFactor + companyFactor + rateFactor);
            suggestedPrice = Math.Round(currentPrice + margin, 2);
            totalPrice = Math.Round(gallonsRequested * suggestedPrice, 2);
        }

        protected void getPrice_Click(object sender, EventArgs e)
        {
            gallonsRequested = Convert.ToInt32(gallons.Value);
            deliveryDate = date.Value;
            calcPrices();

            price.Value = suggestedPrice.ToString();
            total.Value = totalPrice.ToString();
            getPrice.Attributes.Remove("disabled");
            submitPrice.Attributes.Remove("disabled");
        }

        protected void savePrice_Click(object sender, EventArgs e)
        {            
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string query = "insert into FuelQuote (Username, GallonsRequested, DeliveryAddress, DeliveryDate, SuggestedPrice, TotalAmount) values (@Uname, @GalReq, @Addr, @Date, @SuggPrice, @TotPrice)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Uname", user);
            cmd.Parameters.AddWithValue("@GalReq", gallonsRequested);
            cmd.Parameters.AddWithValue("@Addr", deliveryAddress);
            cmd.Parameters.AddWithValue("@Date", deliveryDate);
            cmd.Parameters.AddWithValue("@SuggPrice", suggestedPrice);
            cmd.Parameters.AddWithValue("@TotPrice", totalPrice);
            cmd.ExecuteNonQuery();

            string redirectScript = " window.location.href = 'History.aspx';";
            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Your Quote was successfully saved. You will be redirected to the History page.');" + redirectScript, true);

            conn.Close();
        }        
    }
}
