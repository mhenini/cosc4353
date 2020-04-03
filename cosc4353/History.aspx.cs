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
    public partial class History : System.Web.UI.Page
    {

        public string user;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = (string)Session["user"];
            DataSet HistoryData = GetData();
            HistoryGrid.DataSource = HistoryData;
            HistoryGrid.DataBind();
            
        }

        private DataSet GetData()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HistoryConnection"].ConnectionString);
            using (connection)
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT DeliveryDate, DeliveryAddress, GallonsRequested, SuggestedPrice, TotalAmount FROM FuelQuote WHERE Username = '" + user + "' ORDER BY CAST(DeliveryDate AS DATE) desc", connection);
                command.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                DataSet ds = new DataSet();
                da.Fill(ds);
                connection.Close();
                return ds;
            }
        }
    }
}