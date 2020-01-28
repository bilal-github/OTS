using OnlineTestingSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineTestingSystem.Models
{
    public class QuestionAnswerModel : IQuestion
    {
        string connectionString = ConfigurationManager.ConnectionStrings["OTSConnection"].ConnectionString;

        public QuestionAnswer AddQuestionAnswer(QuestionAnswer questionAnswer)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string QuestionQuery = "INSERT INTO Questions(QuestionDescription) " +
                        "Values(@QuestionDescription)";
                    using (SqlCommand command = new SqlCommand(QuestionQuery, conn))
                    {
                        conn.Open();
                        command.Parameters.AddWithValue("QuestionDescription", questionAnswer.QuestionDescription);
                        command.ExecuteNonQuery();
                    }

                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string AnswerQuery = "INSERT INTO Answers(DisciplineID, Category, QuesitonID, " +
                                        "Answer1, Answer2, Answer3, Answer4, CorrectAnswer) " +
                                        "Values(@DisciplineID, @Category, @QuesitonID, " +
                                        "@Answer1, @Answer2, @Answer3, @Answer4, @CorrectAnswer)";
                    using(SqlCommand AnswerCommand = new SqlCommand(AnswerQuery, connection))
                    {
                        connection.Open();
                        AnswerCommand.Parameters.AddWithValue("DisciplineID", questionAnswer.DisciplineID);
                        AnswerCommand.Parameters.AddWithValue("Category", questionAnswer.Category);
                        AnswerCommand.Parameters.AddWithValue("QuestionID", questionAnswer.QuestionID);
                        AnswerCommand.Parameters.AddWithValue("Answer1", questionAnswer.Answer1);
                        AnswerCommand.Parameters.AddWithValue("Answer2", questionAnswer.Answer2);
                        AnswerCommand.Parameters.AddWithValue("Answer3", questionAnswer.Answer3);
                        AnswerCommand.Parameters.AddWithValue("Answer4", questionAnswer.Answer4);
                        AnswerCommand.Parameters.AddWithValue("CorrectAnswer", questionAnswer.CorrectAnswer);
                        AnswerCommand.ExecuteNonQuery();

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return questionAnswer;
        }
    }
}