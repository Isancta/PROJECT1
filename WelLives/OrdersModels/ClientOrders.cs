
using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace WelLives.WHmodels
{
    public class ClientOrders

    {
        #region properties
        public int customerID { get; set; }
        public DateTime beginDate { get; set; }
        public string customerName { get; set; }
        public string email { get; set; }
        public string phoneN { get; set; }
        public string address { get; set; }

        public int orderID { get; set; }
        public double totalAmount { get; set; }
        public int orderStatusID { get; set; }
        public string status { get; set; }

        public int orderLine_ID { get; set; }
        public int quantity { get; set; }

        #endregion

        #region establish connection to database


        SqlConnection Conn = new SqlConnection(@"server = SANCTA-MARIE\ISPM_TRAINING;database=Warehouse;integrated security=true");

        #endregion

        #region Add a new custome

        
    }

}
