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
        public Users AuthenticateUsers(Users user)
        {
            int count = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT UserID, UserFirstName,UserLastName, UserEmail,UserPassword from Users " +
                    "WHERE UserEmail = @UserEmail AND UserPassword = @UserPassword";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    command.Parameters.AddWithValue("UserEmail", user.UserEmail);
                    command.Parameters.AddWithValue("userPassword", user.UserPassword);

                    SqlDataReader reader;

                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        count++;
                        user.UserID = (int)reader[0];
                        user.UserFirstName = (string)reader[1];
                        //user.UserLastName = (string)reader[2];
                        //user.UserEmail = (string)reader[3];
                        //string userFirstName = (string)reader[0];
                    }
                    reader.Close();
                }
            }
            if (count == 0) // for comparison in the controller
            {
                return new Users { UserEmail = "", UserPassword = "" };
            }
            return user;
        }
        /*
        public Users ReturnUser(Users user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT UserFirstName from Users " +
                    "WHERE UserEmail = @UserEmail AND UserPassword = @UserPassword";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    command.Parameters.AddWithValue("UserEmail", user.UserEmail);
                    command.Parameters.AddWithValue("userPassword", user.UserPassword);

                    SqlDataReader reader;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        count++;
                    }
                    reader.Close();
                }
            }
            if (count == 0) // for comparison in the controller
            {
                return new Users { UserEmail = "", UserPassword = "" };
            }
            return user;
        }
      */

        public Users DeleteUsers(Users user)
        {
            throw new NotImplementedException();
        }

        public bool HasRegistrations(int UserID)
        {
            int count = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "select Users.UserID from Users inner join Test on Users.UserID = Test.UserID " +
                                "WHERE Users.UserID = @UserID";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    command.Parameters.AddWithValue("UserID", UserID);

                    SqlDataReader reader;

                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        count++;
                    }
                    reader.Close();
                }
            }
            if (count == 0) // for comparison in the controller
            {
                return false;
            }
            return true;
        }

        public List<Discipline> LoadDisciplinesByID(int UserID)
        {
            List<Discipline> disciplineList = new List<Discipline>();
            Discipline discipline;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "select D.DisciplineID, D.DisciplineName from Disciplines D " +
                                    "inner join Test on D.DisciplineID = Test.DisciplineID " +
                                    "inner join Users on Users.UserID = Test.UserID " +
                                    "WHERE users.UserID = @UserID";

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        command.Parameters.AddWithValue("UserID", UserID);
                        SqlDataReader reader;
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            discipline= new Discipline();
                            // disciplinesList.Add(new Discipline { DisciplineID = reader.GetInt32(0), DisciplineName = reader.GetString(1) });
                            discipline.DisciplineID = (int)reader[0];
                            discipline.DisciplineName = reader[1].ToString();

                            disciplineList.Add(discipline);
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return disciplineList;

        }

        public Users UpdateUsers(Users user)
        {
            throw new NotImplementedException();
        }


    }
}