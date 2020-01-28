using OnlineTestingSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineTestingSystem.Models
{
    public class TestModel : ITest
    {
        string connectionString = ConfigurationManager.ConnectionStrings["OTSConnection"].ConnectionString;

        public Test AddTest(Test test)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT into Test(DisciplineID,UserID) " +
                        "Values(@DisciplineID,@UserID)";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        command.Parameters.AddWithValue("DisciplineID", test.DisciplineID);
                        command.Parameters.AddWithValue("UserID", test.UserID);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return test;
        }
    }
}