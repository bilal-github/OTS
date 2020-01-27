using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineTestingSystem.Interfaces;

namespace OnlineTestingSystem.Models
{
    public class DisciplineDetailsModel : IDisciplineDetails
    {
        string connectionString = ConfigurationManager.ConnectionStrings["OTSConnection"].ConnectionString;

        public void AddDetail(Users user, Discipline discipline)
        {
            
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO DisciplineDetail(UserID,DisciplineID) " +
                                    "Values(@UserID, @DisciplineID)";

                    using(SqlCommand command = new SqlCommand(query, connection)){

                        command.Parameters.AddWithValue("UserID", user.UserID);
                        command.Parameters.AddWithValue("DisciplineID", discipline.DisciplineID);

                        connection.Open();

                        command.ExecuteNonQuery();
                    }
                }

                
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}