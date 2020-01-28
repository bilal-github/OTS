using OnlineTestingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Interfaces
{
    public interface IQuestion
    {
        QuestionAnswer AddQuestionAnswer(QuestionAnswer questionAnswer);
    }
}
