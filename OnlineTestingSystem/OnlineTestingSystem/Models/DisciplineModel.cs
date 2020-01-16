using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineTestingSystem.Interfaces;

namespace OnlineTestingSystem.Models
{
    public class DisciplineModel : IDiscipline
    {

        string connectionString = ConfigurationManager.ConnectionStrings["OTSConnection"].ConnectionString;
        public Discipline AddDiscipline(Discipline discipline)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT into Discipline(DisciplineName) " +
                    "Values(@DisciplineName)";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    command.Parameters.AddWithValue("DisciplineName", discipline.DisciplineName);
                    command.ExecuteNonQuery();
                }
            }
            return discipline;
        }


        public Discipline EditDiscipline(Discipline discipline)
        {
            return discipline;
        }
    }
}