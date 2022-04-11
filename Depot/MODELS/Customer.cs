using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace Depot.MODELS
{
    public class Customer
    {

        #region create account

        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Phone{ get; set; }

        public string  Address1 { get; set; }

        public string Address2 { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        SqlConnection conn = new SqlConnection("server = SANCTA-MARIE\\ISPM_TRAINING;database=DEPOT;integrated security=true");

        public string AddNewCustomer(Customer newCustomer)

        {

            SqlCommand command = new SqlCommand("insert into Customer values(@CustomerID,@Name,@Email,@Phone,@Address1,@Address2,@Username,@Password) ", conn);

            command.Parameters.AddWithValue("@CustomerID", newCustomer.CustomerID);
            command.Parameters.AddWithValue("@Name", newCustomer.CustomerName);
            command.Parameters.AddWithValue("@Email", newCustomer.Email);
            command.Parameters.AddWithValue("@Phone", newCustomer.Phone);
            command.Parameters.AddWithValue("@Address", newCustomer.Address1);
            command.Parameters.AddWithValue("@Address", newCustomer.Address2);
            command.Parameters.AddWithValue("@Username", newCustomer.Username);
            command.Parameters.AddWithValue("@Password", newCustomer.Password);
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
            return " New Customer Added ";

        }
        #endregion

        #region List of customers by Admin

        public List<Customer> GetListOfCustomer()
        {


            List<Customer> listOfCustomer = new List<Customer>();
            SqlDataReader productRead = null;

            // How to define specific column? select (ID,Name)form Product


            SqlCommand command_Read = new SqlCommand("select* from Customer", conn);


            try
            {
                conn.Open();
                productRead = command_Read.ExecuteReader();

                while (productRead.Read())

                {
                    listOfCustomer.Add(new Customer()
                    {
                        CustomerID = Convert.ToInt32(productRead[0]),
                        CustomerName = Convert.ToString(productRead[1]),
                        Email = Convert.ToString(productRead[2]),
                        Phone = Convert.ToString(productRead[3]),
                        Address1 = Convert.ToString(productRead[4]),
                        Address2 = Convert.ToString(productRead[5]),
                        Username = Convert.ToString(productRead[6]),
                        Password = Convert.ToString(productRead[7]),
                        
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
                conn.Close();
            }
            return listOfCustomer;

        }

        #endregion

        #region Search Customer Information by Name

        public Customer FindCustoByName(string CustomName)
        {

            Customer Customer = new Customer();
            SqlDataReader readTable = null;

            SqlCommand cmd_Find = new SqlCommand("select * from Customer where Name = @name", conn);

            cmd_Find.Parameters.AddWithValue("@name", CustomName);

            try
            {
                conn.Open();
                readTable = cmd_Find.ExecuteReader();

                if (readTable.Read())
                {
                    Customer.CustomerID = Convert.ToInt32(readTable[0]);
                    Customer.CustomerName = CustomName;
                    Customer.Email = Convert.ToString(readTable[2]);
                    Customer.Phone = Convert.ToString(readTable[3]);
                    Customer.Address1 = Convert.ToString(readTable[4]);
                    Customer.Address2 = Convert.ToString(readTable[5]);
                    Customer.Username = Convert.ToString(readTable[6]);
                    Customer.Password = Convert.ToString(readTable[7]);

                }

                else
                {
                    throw new Exception(" Customer not found");
                }

            }
            catch (Exception searchEx)
            {
                throw new Exception(searchEx.Message);
            }
            finally
            {

                conn.Close();
            }

            return Customer ;


        }


        #endregion




    }
}
