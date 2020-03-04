using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineTestingSystem.Interfaces;

namespace OnlineTestingSystem.Models
{
    public class Discipline_QuestionAnswerModel : IDiscipline_QuestionAnswer
    {
        string connectionString = ConfigurationManager.ConnectionStrings["OTSConnection"].ConnectionString;


        public Discipline_QuestionAnswer AddQuestionAnswer(Discipline_QuestionAnswer discipline_QuestionAnswer)
        {
            int DisciplineID = -1;
            int QuestionID = -1;
            try
            {
                using (SqlConnection connection1 = new SqlConnection(connectionString))
                {
                    string selectQuery = "SELECT DisciplineID FROM Disciplines Where DisciplineName = @DisciplineName";
                    using (SqlCommand command = new SqlCommand(selectQuery, connection1))
                    {
                        connection1.Open();
                        command.Parameters.AddWithValue("DisciplineName", discipline_QuestionAnswer.discipline.DisciplineName);
                        SqlDataReader reader;
                        reader = command.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                        while (reader.Read())
                        {
                            // disciplinesList.Add(new Discipline { DisciplineID = reader.GetInt32(0), DisciplineName = reader.GetString(1) });
                            DisciplineID = (int)reader[0];
                        }
                        reader.Close();
                    }
                }


                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string QuestionQuery = "INSERT INTO Questions(QuestionDescription) " +
                                            "OUTPUT INSERTED.QuestionID " +
                                            "Values(@QuestionDescription)";
                    using (SqlCommand command = new SqlCommand(QuestionQuery, conn))
                    {
                        conn.Open();
                        command.Parameters.AddWithValue("QuestionDescription", discipline_QuestionAnswer.questionAnswer.QuestionDescription);


                        QuestionID = (int)command.ExecuteScalar();
                        //command.ExecuteNonQuery();
                    }

                }

                //set the Discipline ID and Question ID
                discipline_QuestionAnswer.discipline.DisciplineID = DisciplineID;
                discipline_QuestionAnswer.questionAnswer.DisciplineID = DisciplineID;
                discipline_QuestionAnswer.questionAnswer.QuestionID = QuestionID;

                //insert into answers table
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string AnswerQuery = "INSERT INTO Answers(DisciplineID, Category, QuestionID, " +
                                        "Answer1, Answer2, Answer3, Answer4, CorrectAnswer) " +
                                        "Values(@DisciplineID, @Category, @QuestionID, " +
                                        "@Answer1, @Answer2, @Answer3, @Answer4, @CorrectAnswer)";
                    using (SqlCommand AnswerCommand = new SqlCommand(AnswerQuery, connection))
                    {
                        connection.Open();
                        AnswerCommand.Parameters.AddWithValue("DisciplineID", discipline_QuestionAnswer.questionAnswer.DisciplineID);
                        AnswerCommand.Parameters.AddWithValue("Category", discipline_QuestionAnswer.questionAnswer.Category);
                        AnswerCommand.Parameters.AddWithValue("QuestionID", discipline_QuestionAnswer.questionAnswer.QuestionID);
                        AnswerCommand.Parameters.AddWithValue("Answer1", discipline_QuestionAnswer.questionAnswer.Answer1);
                        AnswerCommand.Parameters.AddWithValue("Answer2", discipline_QuestionAnswer.questionAnswer.Answer2);
                        AnswerCommand.Parameters.AddWithValue("Answer3", discipline_QuestionAnswer.questionAnswer.Answer3);
                        AnswerCommand.Parameters.AddWithValue("Answer4", discipline_QuestionAnswer.questionAnswer.Answer4);
                        AnswerCommand.Parameters.AddWithValue("CorrectAnswer", discipline_QuestionAnswer.questionAnswer.CorrectAnswer);
                        AnswerCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return discipline_QuestionAnswer;
        }
    }
}