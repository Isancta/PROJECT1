using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;


namespace Depot.MODELS
{
    public class Order
    {
        #region Submit order

        public int OrderId { get; set; }


        public DateTime OrderTime { get; set; }
        public int CustomerID { get; set; }
        public double TotalAmount { get; set; }
        public string OrderStatus { get; set; }
        public List<OrderLine> OrderLines { get; set; }




        SqlConnection conn = new SqlConnection("server = SANCTA-MARIE\\ISPM_TRAINING;database=DEPOT;integrated security=true");

        public Order AddOrder(Order NewOrder)

        {
            Order insertedOrder = null;
            Products prod = new Products();

            //Get the total amount for this order from products being ordered
            foreach (var line in NewOrder.OrderLines)
            {
                var product = prod.FindPrById(line.Product_ID);
                NewOrder.TotalAmount += product != null ? product.Price * line.Quantity : 0;
            }

            SqlCommand command = new SqlCommand("INSERT INTO [dbo].[ORDERS]( [Orderdate] ,[Customer_ID],[TotalAmount],[OrderStatus])VALUES(@Orderdate,@Customer_ID,@TotalAmount,@OrderStatus ) select SCOPE_IDENTITY()", conn);

            command.Parameters.AddWithValue("@Orderdate", NewOrder.OrderTime);
            command.Parameters.AddWithValue("@Customer_ID", NewOrder.CustomerID);
            command.Parameters.AddWithValue("@TotalAmount", NewOrder.TotalAmount);
            command.Parameters.AddWithValue("@OrderStatus", NewOrder.OrderStatus);

            try
            {
                conn.Open();
                // command.ExecuteNonQuery()
                int InsertedOrderId = int.Parse(command.ExecuteScalar().ToString());
                if (InsertedOrderId > 0)
                {
                    //OrderLine orderLine = new OrderLine();
                    foreach (var line in NewOrder.OrderLines)
                    {
                        line.Order_ID = InsertedOrderId;
                        line.AddOrderLine(line);
                    }
                }

                insertedOrder = NewOrder.GetOrderById(InsertedOrderId);
            }
            catch (SqlException exadd)
            {
                throw new Exception(exadd.Message);
            }
            finally
            {
                conn.Close();
            }
            return insertedOrder;

        }


        #endregion

        #region

        public Order GetOrderById(int orderId)
        {
            OrderLine orderLine = new OrderLine();
            Order DBOrder = null;
            SqlDataReader ReadOrder = null;

            SqlCommand command = new SqlCommand("select * from Orders WHERE Id = @OrderId", conn);

            command.Parameters.AddWithValue("@OrderId", orderId);


            try
            {
                conn.Open();
                ReadOrder = command.ExecuteReader();

                while (ReadOrder.Read())

                {
                    DBOrder = new Order
                    {
                        OrderId = Convert.ToInt32(ReadOrder["Id"]),
                        CustomerID = Convert.ToInt32(ReadOrder["Customer_ID"]),
                        OrderTime = DateTime.Parse(ReadOrder["Orderdate"].ToString()),
                        OrderStatus = Convert.ToString(ReadOrder["OrderStatus"]),
                        TotalAmount = Convert.ToDouble(ReadOrder["TotalAmount"])


                    };

                    DBOrder.OrderLines = orderLine.GetOrderLines(DBOrder.OrderId);
                    //Break because we just need one order f the given ID
                    break;

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
            return DBOrder;

        }

        #endregion

        #region
        //public string EditOrder(Order newOrder)
        //{

        //    string Sql = "update orders set Orderdate = @orderdate,Customer_ID=@CustomerId,TotalAmount=@Amount, OrderStatus = @OrderStatus where Id = @OrderID";
        //    SqlCommand C_Update = new SqlCommand(Sql, conn);

        //    C_Update.Parameters.AddWithValue("@orderdate", newOrder.CustomerID);
        //    C_Update.Parameters.AddWithValue("@CustomerId", newOrder.OrderTime);
        //    C_Update.Parameters.AddWithValue("@Amount", newOrder.TotalAmount);
        //    C_Update.Parameters.AddWithValue("@OrderStatus", newOrder.OrderStatus);

        //    try
        //    {
        //        conn.Open();
        //        C_Update.ExecuteNonQuery();


        //    }
        //    catch (Exception ex)
        //    {

        //       throw new Exception(ex.Message);

        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }


        //}
        //#endregion


    }  

}

#endregion