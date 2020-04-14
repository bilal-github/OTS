using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTestingSystem.Models;
using OnlineTestingSystem.Interfaces;

namespace OnlineTestingSystem.Controllers
{
    public class TestController : Controller
    {
        private IQuestionAnswer _iquestionAnswer;
        List<int> QuestionsList = new List<int>();
        int count;
        Random random = new Random();

        public TestController(IQuestionAnswer iquestionAnswer)
        {
            _iquestionAnswer = iquestionAnswer;
        }
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Test()
        {
            ViewBag.Name = Session["UserFirstName"];
            ViewBag.DisciplineName = Session["DisciplineName"];
            int UserID = Convert.ToInt32(Session["UserID"]);
            int DisciplineID = _iquestionAnswer.RetrieveDisciplineID(Session["DisciplineName"].ToString());
            int TestID = _iquestionAnswer.RetrieveTestID(UserID, DisciplineID);
            Session["TestID"] = TestID;
            Session["DisciplineID"] = DisciplineID;
            QuestionsList = _iquestionAnswer.GetQuestionIDs(UserID, DisciplineID); // list of questions in the diciplineID
            if (QuestionsList.Count > 0)
            {

                int randomNumber = random.Next(QuestionsList.Count);
                int QuestionID = (int)QuestionsList[randomNumber];
                _iquestionAnswer.AddQuestionToTemp(UserID, DisciplineID, QuestionID);
                Session["CurrentDisciplineID"] = DisciplineID;
                Session["CurrentQuestion"] = QuestionID;
                var question = _iquestionAnswer.RetrieveQuestion(QuestionID);
                var answer = _iquestionAnswer.RetrieveAnswer(QuestionID, DisciplineID);
                ViewBag.Question = question.QuestionDescription;
                ViewBag.Answer1 = answer.Answer1;
                ViewBag.Answer2 = answer.Answer2;
                ViewBag.Answer3 = answer.Answer3;
                ViewBag.Answer4 = answer.Answer4;
                Session["CorrectAnswer"] = answer.CorrectAnswer;
                return View();
            }
            return RedirectToAction("Results","Results");
        }

        [HttpPost]
        public ActionResult Test(QuestionAnswer questionAnswer)
        {
            int UserID = Convert.ToInt32(Session["UserID"]);
            int DisciplineID = Convert.ToInt32(Session["CurrentDisciplineID"]);
            int QuestionID = Convert.ToInt32(Session["CurrentQuestion"]);

            var correctAnswer = Session["CorrectAnswer"].ToString();
            if (questionAnswer.selectAnswer == correctAnswer)
            {
                _iquestionAnswer.IsCorrect("true",UserID,DisciplineID,QuestionID);
                ViewBag.result = "Correct Answer";
            }
            else
            {
                _iquestionAnswer.IsCorrect("false", UserID, DisciplineID, QuestionID);
                ViewBag.result = "Incorrect Answer";
            }
            
            QuestionsList = _iquestionAnswer.GetQuestionIDs(UserID, DisciplineID);
            //if ther are no more questions do this
            if (QuestionsList.Count > 0)
            {
                int randomNumber = random.Next(QuestionsList.Count);
                QuestionID = (int)QuestionsList[randomNumber];
                _iquestionAnswer.AddQuestionToTemp(UserID, DisciplineID, QuestionID);
                Session["CurrentQuestion"] = QuestionID;
                var question = _iquestionAnswer.RetrieveQuestion(QuestionID);
                var answer = _iquestionAnswer.RetrieveAnswer(QuestionID, DisciplineID);

                ViewBag.Question = question.QuestionDescription;
                ViewBag.Answer1 = answer.Answer1;
                ViewBag.Answer2 = answer.Answer2;
                ViewBag.Answer3 = answer.Answer3;
                ViewBag.Answer4 = answer.Answer4;
                Session["CorrectAnswer"] = answer.CorrectAnswer;
                return View();
            }
            return RedirectToAction("Results","Results");
        }
        [HttpGet]
        public ActionResult Results()
        {

            return View();
        }
    }
}