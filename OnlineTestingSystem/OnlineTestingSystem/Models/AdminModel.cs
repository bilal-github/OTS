using OnlineTestingSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineTestingSystem.Models
{
    public class AdminModel : IAdmin
    {
        string connectionString = ConfigurationManager.ConnectionStrings["OTSConnection"].ConnectionString;
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

        public Admin EditAdmin(Admin admin)
        {
            throw new NotImplementedException();
        }

      
    }
}