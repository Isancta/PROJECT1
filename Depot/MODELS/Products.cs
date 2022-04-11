using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace Depot.MODELS
{
    public class Products
    {
        #region fields
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        
        public int QuantityInStock { get; set; }
       
        #endregion

        #region establish connection to database


        SqlConnection Conn = new SqlConnection(@"server = SANCTA-MARIE\ISPM_TRAINING;database=DEPOT;integrated security=true");

        #endregion

        #region List of products
        public List<Products> GetAllProducts()
        {


            List<Products> listOfProducts = new List<Products>();
            SqlDataReader productRead = null;

            // How to define specific column? select (ID,Name)form Product

           
            SqlCommand command_Read = new SqlCommand("select* from product", Conn);


            try
            {
                Conn.Open();
                productRead = command_Read.ExecuteReader();

                while (productRead.Read())

                {
                    listOfProducts.Add(new Products()
                    {
                        ProductID = Convert.ToInt32(productRead["Id"]),
                        ProductName = Convert.ToString(productRead["ProductName"]),
                        ProductDescription = Convert.ToString(productRead["ProductDescpr"]),
                        Category = Convert.ToString(productRead["Category"]),
                        Price = Convert.ToDouble(productRead["Price"]),
                        QuantityInStock = Convert.ToInt32(productRead["QuantityInStock"]),

                       
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

        #region

        public Products FindPrByName(string prName)
        {

            Products yourProduct = new Products();
            SqlDataReader readTable = null;

            SqlCommand cmd_Find = new SqlCommand("select * from Product where ProductName = @name", Conn);

            cmd_Find.Parameters.AddWithValue("@name", prName);

            try
            {
                Conn.Open();
                readTable = cmd_Find.ExecuteReader();

                if (readTable.Read())
                {
                    yourProduct.ProductID = Convert.ToInt32(readTable["Id"]);
                    yourProduct.ProductName = Convert.ToString(readTable["ProductName"]);
                    yourProduct.ProductDescription = Convert.ToString(readTable["ProductDescpr"]);
                    yourProduct.Category = Convert.ToString(readTable["Category"]);
                    yourProduct.Price = Convert.ToDouble(readTable["Price"]);
                    yourProduct.QuantityInStock = Convert.ToInt32(readTable["QuantityInStock"]);
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

        public Products FindPrById(int productId)
        {

            Products yourProduct = new Products();
            SqlDataReader readTable = null;

            SqlCommand cmd_Find = new SqlCommand("select * from Product where Id = @ProdId", Conn);

            cmd_Find.Parameters.AddWithValue("@ProdId", productId);

            try
            {
                Conn.Open();
                readTable = cmd_Find.ExecuteReader();

                if (readTable.Read())
                {
                    yourProduct.ProductID = Convert.ToInt32(readTable["Id"]);
                    yourProduct.ProductName = Convert.ToString(readTable["ProductName"]);
                    yourProduct.ProductDescription = Convert.ToString(readTable["ProductDescpr"]);
                    yourProduct.Category = Convert.ToString(readTable["Category"]);
                    yourProduct.Price = Convert.ToDouble(readTable["Price"]);
                    yourProduct.QuantityInStock = Convert.ToInt32(readTable["QuantityInStock"]);
                }

                else
                {
                    //throw new Exception(" Sorry, Product not found; try again soon, we are replenishing");
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

        public string DeleteProduct(int Pid)
        {
            SqlCommand command = new SqlCommand("delete from Product where Id =@PrId", Conn);
            command.Parameters.AddWithValue("@PrId",Pid );

            try
            {
                Conn.Open();
                command.ExecuteNonQuery();
                
            }
            catch (Exception delex)
            {

               throw new Exception (delex.Message);
            }
            finally
            {
                Conn.Close();
            }

            return "deleted successful";

        }


    }
}
