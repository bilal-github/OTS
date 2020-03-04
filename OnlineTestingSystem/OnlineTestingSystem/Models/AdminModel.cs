using OnlineTestingSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace OnlineTestingSystem.Models
{
    public class AdminModel : IAdmin
    {
        string connectionString = ConfigurationManager.ConnectionStrings["OTSConnection"].ConnectionString;
        
        /// <summary>
        /// Add an Admin
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public Admin AddAdmin(Admin admin)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT into Admin(AdminName,AdminPassword) " +
                    "Values(@AdminName,@AdminPassword)";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    command.Parameters.AddWithValue("AdminName", admin.AdminName);
                    command.Parameters.AddWithValue("AdminPassword", admin.AdminPassword);
                    command.ExecuteNonQuery();
                }
            }
            return admin;
        }

        public Admin AuthenticateAdmin(Admin admin)
        {
            int count = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT AdminName,AdminPassword from Admin " +
                    "WHERE AdminName = @AdminName AND AdminPassword = @AdminPassword";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    command.Parameters.AddWithValue("AdminName", admin.AdminName);
                    command.Parameters.AddWithValue("AdminPassword", admin.AdminPassword);
                    
                    SqlDataReader reader;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        count++;
                    }
                    reader.Close();
                }
            }
            if (count==0)
            {
                return new Admin { AdminName = "", AdminPassword = "" };
            }
            return admin;
        }

        public Admin EditAdmin(Admin admin)
        {
            throw new NotImplementedException();
        }


    }
}