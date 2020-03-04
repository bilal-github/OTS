using OnlineTestingSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineTestingSystem.Models
{
    public class QuestionAnswerModel : IQuestionAnswer
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
                                        "Values(@DisciplineID, @Category, " +
                                        "@Answer1, @Answer2, @Answer3, @Answer4, @CorrectAnswer)";
                    using(SqlCommand AnswerCommand = new SqlCommand(AnswerQuery, connection))
                    {
                        connection.Open();
                        AnswerCommand.Parameters.AddWithValue("DisciplineID", questionAnswer.DisciplineID);
                        AnswerCommand.Parameters.AddWithValue("Category", questionAnswer.Category);
                       // AnswerCommand.Parameters.AddWithValue("QuestionID", questionAnswer.QuestionID);
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

        public QuestionAnswer RetrieveQuestion(int QuestionID)
        {
            QuestionAnswer question = new QuestionAnswer();

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                string selectQuestion = "select QuestionID, QuestionDescription from Questions where QuestionID = @QuestionID";

                using(SqlCommand command = new SqlCommand(selectQuestion, connection))
                {
                    command.Parameters.AddWithValue("QuestionID", QuestionID);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        question.QuestionID = (int)reader[0];
                        question.QuestionDescription = reader[1].ToString();
                    }
                }
            }
            return question;
        }

        public QuestionAnswer RetrieveAnswer(int QuestionID, int DisciplineID)
        {
            QuestionAnswer answer = new QuestionAnswer();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string selectAnswers = "select Answer1,Answer2,Answer3, Answer4, CorrectAnswer from Answers where QuestionID = @QuestionID and DisciplineID = @DiscipilneID";

                using(SqlCommand command = new SqlCommand(selectAnswers, connection))
                {
                    command.Parameters.AddWithValue("QuestionID", QuestionID);
                    command.Parameters.AddWithValue("DiscipilneID", DisciplineID);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        answer.Answer1 = reader[0].ToString();
                        answer.Answer2 = reader[1].ToString();
                        answer.Answer3 = reader[2].ToString();
                        answer.Answer4 = reader[3].ToString();
                        answer.CorrectAnswer = reader[4].ToString();
                    }
                }
            }
            return answer;
        }

        public int CountQuestions(int DisciplineID)
        {
            int count = 0;
            string selectQuery = "Select count(QuestionID) from answers where DisciplineID = @DisciplineID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using(SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("DiscipilneID", DisciplineID);
                    connection.Open();
                    count = (int)command.ExecuteScalar();
                }
            }
            return count;
        }

        public int RetrieveDisciplineID(string DisciplineName)
        {
            int id = 0;
            string selectQuery = "Select DisciplineID from Disciplines where DisciplineName = @DisciplineName";
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                using(SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("DisciplineName", DisciplineName);
                    id = (int)command.ExecuteScalar();
                }
            }
            return id;
        }

        public List<int> GetQuestionIDs(int disciplineID)
        {
            List<int> questions = new List<int>();
            string selectQuery = "Select QuestionID from answers where DisciplineID = @DisciplineID";
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                using(SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("DisciplineID", disciplineID);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        questions.Add(Convert.ToInt32(reader[0]));                        
                    }
                }
            }
            return questions;
        }
    }
}