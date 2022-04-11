using System;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace WelLives.WHmodels
{
    public class ProductsInfo
    {
        #region fields
        public int productID { get; set; }
        public string pName { get; set; }
        public double pPrice { get; set; }
        public bool pIsInStock { get; set; }
        public int pAvailableQty { get; set; }

        #endregion

        #region establish connection to database


        SqlConnection Conn = new SqlConnection(@"server = SANCTA-MARIE\ISPM_TRAINING;database=Warehouse;integrated security=true");

        #endregion

        #region List of products
       public List<ProductsInfo> GetAllProducts()
        {


            List<ProductsInfo> listOfProducts = new List<ProductsInfo>();
            SqlDataReader productRead = null;

            // How to define specific column? select (ID,Name)form Product
            // 
            SqlCommand command_Read = new SqlCommand("select * from Product", Conn);


            try
            {
                Conn.Open();
                productRead = command_Read.ExecuteReader();

                while (productRead.Read())

                {
                    listOfProducts.Add(new ProductsInfo()
                    {
                        productID = Convert.ToInt32(productRead[0]),
                        pName = Convert.ToString(productRead[1]),
                        pPrice = Convert.ToDouble(productRead[2]),
                        pIsInStock = Convert.ToBoolean(productRead[3]),
                        pAvailableQty = Convert.ToInt32(productRead[4])
                    });

                }

            }

            catch (SqlException readEx)

            {

                throw new Exception(readEx.Message);
            }
            finally
            {
                productRead.Close();
                Conn.Close();
            }
            return listOfProducts;

        }
        #endregion

        #region search product by Name

        public ProductsInfo FindPrByName(string prName)
        {

            ProductsInfo yourProduct = new ProductsInfo();
            SqlDataReader readTable = null;
            
            SqlCommand cmd_Find = new SqlCommand("select * from Product where name = @Name", Conn);

            cmd_Find.Parameters.AddWithValue("@Name", prName);
            
            try
            {
                Conn.Open();
                readTable = cmd_Find.ExecuteReader();

                if (readTable.Read())
                {
                    yourProduct.productID = Convert.ToInt32(readTable[0]);
                    yourProduct.pName = prName;
                    yourProduct.pPrice = Convert.ToDouble(readTable[2]);
                    yourProduct.pIsInStock = Convert.ToBoolean(readTable[3]);
                    yourProduct.pAvailableQty = Convert.ToInt32(readTable[4]);

                }
                
                else
                {
                    throw new Exception(" Sorry, Product not found; try again soon, we are replenishing");
                }

            }
            catch (Exception searchEx)
            {
                throw new Exception(searchEx.Message);
            }
            finally
            {

                Conn.Close();
            }

            return yourProduct;

            
        }

        #endregion

        #region
        public string AddNewCustomer(ClientOrders newCustomer)

        {

            SqlCommand command = new SqlCommand("insert into Customer values(@customerID,@begin_date,@name,@email,@phone,@address) ", con);

            command.Parameters.AddWithValue("@customerID", newCustomer.customerID);
            command.Parameters.AddWithValue("@begin_date", newCustomer.beginDate);
            command.Parameters.AddWithValue("@name", newCustomer.customerName);
            command.Parameters.AddWithValue("@email", newCustomer.email);
            command.Parameters.AddWithValue("@phone", newCustomer.phoneN);
            command.Parameters.AddWithValue("@address", newCustomer.address);

            try
            {
                Conn.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException exadd)
            {
                throw new Exception(exadd.Message);
            }
            finally
            {
                Conn.Close();
            }
            return " New Customer Added ";


        }
         #endregion


    }

}