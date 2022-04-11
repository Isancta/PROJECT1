using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace Depot.MODELS
{
    public class Credentials
    {
        public string Username { get; set; }
        public string Password { get; set; }



        public bool SignIn(string userN, string passW)
        {

            SqlConnection conn = new SqlConnection("server=SANCTA-MARIE\\ISPM_TRAINING;database=DEPOT;integrated security=true");

            SqlCommand command = new SqlCommand("select count(*) from Customer where Username=@userName and Password=@passWord", conn);

            command.Parameters.AddWithValue("@userName", userN);
            command.Parameters.AddWithValue("@passWord", passW);

            try
            {
                conn.Open();
                int record = (int)command.ExecuteScalar();

                if (record > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch (System.Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
