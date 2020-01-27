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
        private List<Discipline> disciplinesList = new List<Discipline>();
        private List<string> disciplineList = new List<string>();
        //public List<Discipline> disciplinesList { get; set; }

        string connectionString = ConfigurationManager.ConnectionStrings["OTSConnection"].ConnectionString;
        public Discipline AddDiscipline(Discipline discipline)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT into Disciplines(DisciplineName) " +
                        "Values(@DisciplineName)";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        command.Parameters.AddWithValue("DisciplineName", discipline.DisciplineName);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return discipline;
        }

        public IEnumerable<Discipline> disciplines()
        {
            LoadDisciplines();
            
            return disciplinesList;
            
        }

        public List<string> LoadDisciplines()
        {            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT DisciplineName from Disciplines";

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        conn.Open();
                      
                        SqlDataReader reader;
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            // disciplinesList.Add(new Discipline { DisciplineID = reader.GetInt32(0), DisciplineName = reader.GetString(1) });
                            disciplineList.Add(reader[0].ToString());
                        }
                        reader.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return disciplineList;
        }

        public Discipline EditDiscipline(Discipline discipline)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Disciplines SET DisciplineName = @DisciplineName " +
                                    "WHERE DisciplineID = @DisciplineID";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        command.Parameters.AddWithValue("DisciplineID", discipline.DisciplineID);
                        command.Parameters.AddWithValue("DisciplineName", discipline.DisciplineName);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return discipline;
        }
    }
}