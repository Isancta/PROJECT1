using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace WelLife.Plan
{
    public class ProducInfo
    {
        #region fields
        public int productID  { get; set; }
        public string pName { get; set; }
        public double pPrice { get; set; }
        public bool  pIsInStock { get; set; }
        public int pAvailableQty  { get; set; }

        #endregion

        #region establish connection to database

        
        SqlConnection Conn = new SqlConnection(@"server = SANCTA-MARIE\ISPM_TRAINING; database=Warehouse; integrated security=true");
        #endregion

        public List<ProducInfo> GetAllProducts()
        {
            
            
            SqlCommand command;
            SqlDataReader productRead = null;
            string sql = "select * from Product";
            
            List<ProducInfo> listOfProducts = new List<ProducInfo>();
            command = new SqlCommand(sql, Conn);
            

            try
            {
                Conn.Open();
                productRead = command.ExecuteReader();
                while(productRead.Read())

                {
                    listOfProducts.Add(new ProducInfo()
                    {
                        productID = Convert.ToInt32(productRead[0]),
                        pName = Convert.ToString(productRead[1]),
                        pPrice = Convert.ToDouble(productRead[2]),
                        pIsInStock = Convert.ToBoolean(productRead[3]),
                        pAvailableQty = Convert.ToInt32(productRead[4])
                    });
                             
                }

            }

            catch (SqlException e)

            {

                throw new Exception(e.Message);
            }
            finally
            {
                productRead.Close();
                Conn.Close();
            }
            return listOfProducts;











        }







    }
    
}
