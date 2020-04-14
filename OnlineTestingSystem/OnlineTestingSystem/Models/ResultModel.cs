using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineTestingSystem.Interfaces;

namespace OnlineTestingSystem.Models
{
    public class ResultModel : IResults
    {
        string connectionString = ConfigurationManager.ConnectionStrings["OTSConnection"].ConnectionString;

        public Result GetResult(int UserID, int DisciplineID)
        {
            Result result = new Result();
            result.UserID = UserID;
            result.DisciplineID = DisciplineID;
            string correctQuestionsQuery = "SELECT count(*) from Temp where IsCorrect = 'true' and UserID =@UserID and DisciplineID = @DisciplineID";
            string TotalQuestionsQuery = "select count(QuestionID) from Temp where UserID =@UserID and DisciplineID =@DisciplineID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(correctQuestionsQuery, connection))
                {
                    command.Parameters.AddWithValue("UserID", UserID);
                    command.Parameters.AddWithValue("DisciplineID", DisciplineID);
                    connection.Open();

                    result.CorrectQuestions = (int)command.ExecuteScalar();
                    connection.Close();
                }
                using (SqlCommand command1 = new SqlCommand(TotalQuestionsQuery, connection))
                {
                    command1.Parameters.AddWithValue("UserID", UserID);
                    command1.Parameters.AddWithValue("DisciplineID", DisciplineID);
                    connection.Open();

                    result.TotalQuestions = (int)command1.ExecuteScalar();
                    connection.Close();
                }
                result.WrongQuestions = result.TotalQuestions - result.CorrectQuestions;
                double Score = Convert.ToDouble(result.CorrectQuestions) / Convert.ToDouble(result.TotalQuestions);
                result.Score = Score.ToString("P");
            }
            return result;


        }

        public void insertIntoResults(int UserID, int TestID, string Score)
        {
            string InsertIntoTest = "Insert into Results(UserID,TestID,Score) Values(@UserID,@TestID,@Score)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(InsertIntoTest, connection))
                {
                    command.Parameters.AddWithValue("UserID", UserID);
                    command.Parameters.AddWithValue("Score", Score);
                    command.Parameters.AddWithValue("TestID", TestID);
                    connection.Open();

                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}