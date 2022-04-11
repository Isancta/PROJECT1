using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;


namespace Depot.MODELS
{
    public class OrderLine
    {
        #region Submit order

        public int Id { get; set; }
        public int Order_ID { get; set; }
        public int Product_ID{ get; set; }
        public int Quantity { get; set; }
        
        SqlConnection conn = new SqlConnection("server = SANCTA-MARIE\\ISPM_TRAINING;database=DEPOT;integrated security=true");

        public string AddOrderLine(OrderLine orderLine)

        {

            SqlCommand command = new SqlCommand("INSERT INTO [dbo].[ORDERLINE]([Order_ID],[Product_ID],[Quantity])VALUES(@Order_ID,@Product_ID,@Quantity)", conn);

           
            command.Parameters.AddWithValue("@Order_ID", orderLine.Order_ID);
            command.Parameters.AddWithValue("@Product_ID", orderLine.Product_ID);
            command.Parameters.AddWithValue("@Quantity", orderLine.Quantity);
           
            try
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException exadd)
            {
                throw new Exception(exadd.Message);
            }
            finally
            {
                conn.Close();
            }
            return " New Order Added ";

        }


        #endregion

        public List<OrderLine> GetOrderLines(int OrderId)

        {
            List<OrderLine> Lines = new List<OrderLine>();
            SqlDataReader ReadOrdeline = null;

            SqlCommand command = new SqlCommand("select * from OrderLine ol INNER JOIN Orders o on ol.Order_ID = o.Id WHERE o.Id = @OrderId", conn);

            command.Parameters.AddWithValue("@OrderId", OrderId);


            try
            {
                conn.Open();
                ReadOrdeline = command.ExecuteReader();

                while (ReadOrdeline.Read())

                {
                    Lines.Add(new OrderLine()
                    {
                        Id = Convert.ToInt32(ReadOrdeline["Id"]),
                        Order_ID = Convert.ToInt32(ReadOrdeline["Order_ID"]),
                        Product_ID = Convert.ToInt32(ReadOrdeline["Product_ID"]),
                        Quantity = Convert.ToInt32(ReadOrdeline["Quantity"])


                    });

                }
            }
            catch (SqlException exadd)
            {
                throw new Exception(exadd.Message);
            }
            finally
            {
                conn.Close();
            }
            return Lines;

        }
    }
}
