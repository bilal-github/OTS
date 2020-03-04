using OnlineTestingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Interfaces
{
    public interface IQuestionAnswer
    {
        QuestionAnswer AddQuestionAnswer(QuestionAnswer questionAnswer);
        QuestionAnswer RetrieveQuestion(int QuestionID);
        QuestionAnswer RetrieveAnswer(int QuestionID, int DisciplineID);
        int CountQuestions(int DisciplineID);
        int RetrieveDisciplineID(string DisciplineName);
        List<int> GetQuestionIDs(int disciplineID);
        //QuestionAnswer checkAnswer(int QuestionID, )
    }
}
