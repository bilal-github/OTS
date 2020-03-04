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

            int DisciplineID = _iquestionAnswer.RetrieveDisciplineID(Session["DisciplineName"].ToString());
            QuestionsList = _iquestionAnswer.GetQuestionIDs(DisciplineID); // [1,15]
            int randomNumber = random.Next(QuestionsList.Count);
            int QuestionID = (int)QuestionsList[randomNumber];
            Session["CurrentQuestion"] = QuestionID;
           // QuestionsList.Remove(QuestionID);
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

        [HttpPost]
        public ActionResult Test(QuestionAnswer questionAnswer)
        {
            //if (Request.HttpMethod == "POST")
            //{
            var correctAnswer = Session["CorrectAnswer"].ToString();
            if (questionAnswer.selectAnswer == correctAnswer)
            {
                ViewBag.result = "Correct Answer";
            }
            else
            {
                ViewBag.result = "Incorrect Answer";
            }
            int DisciplineID = _iquestionAnswer.RetrieveDisciplineID(Session["DisciplineName"].ToString());
            QuestionsList = _iquestionAnswer.GetQuestionIDs(DisciplineID); // [2,5,6,7,5,2]
            QuestionsList.Remove(Convert.ToInt32(Session["CurrentQuestion"]));
            int randomNumber = random.Next(QuestionsList.Count);
            int QuestionID = (int)QuestionsList[randomNumber];
            Session["CurrentQuestion"] = QuestionID;
            //Create temp table store question IDs already seen and then remove at session end.

            QuestionsList.Remove(QuestionID);
            var question = _iquestionAnswer.RetrieveQuestion(QuestionID);
            var answer = _iquestionAnswer.RetrieveAnswer(QuestionID, DisciplineID);

            ViewBag.Question = question.QuestionDescription;
            ViewBag.Answer1 = answer.Answer1;
            ViewBag.Answer2 = answer.Answer2;
            ViewBag.Answer3 = answer.Answer3;
            ViewBag.Answer4 = answer.Answer4;
            Session["CorrectAnswer"] = answer.CorrectAnswer;

            //}
            return View();
        }
    }
}