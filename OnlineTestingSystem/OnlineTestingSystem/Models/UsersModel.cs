using OnlineTestingSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineTestingSystem.Models
{
    public class UsersModel : IUsers
    {
        string connectionString = ConfigurationManager.ConnectionStrings["OTSConnection"].ConnectionString;
        public Users AddUsers(Users user)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT into Users(UserPassword,UserFirstName,UserLastName,UserEmail) " +
                    "Values(@UserPassword,@UserFirstName,@UserLastName,@UserEmail)";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    command.Parameters.AddWithValue("UserPassword", user.UserPassword);
                    command.Parameters.AddWithValue("UserFirstName", user.UserFirstName);
                    command.Parameters.AddWithValue("UserLastName", user.UserLastName);
                    command.Parameters.AddWithValue("UserEmail", user.UserEmail);
                    command.ExecuteNonQuery();
                }
            }
            return user;
        }

        public Users DeleteUsers(Users user)
        {
            throw new NotImplementedException();
        }

        public Users UpdateUsers(Users user)
        {
            throw new NotImplementedException();
        }
    }
}