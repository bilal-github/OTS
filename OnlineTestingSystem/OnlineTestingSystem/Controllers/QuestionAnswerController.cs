using OnlineTestingSystem.Interfaces;
using OnlineTestingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTestingSystem.Controllers
{
    public class QuestionAnswerController : Controller
    {
        // GET: Question
        private IDiscipline_QuestionAnswer _idiscipline_QuestionAnswer;
        private IDiscipline _idiscipline;
       
        public QuestionAnswerController(IDiscipline_QuestionAnswer idiscipline_QuestionAnswer, IDiscipline idiscipline)
        {
            _idiscipline_QuestionAnswer = idiscipline_QuestionAnswer;
            _idiscipline = idiscipline;
        }

        [HttpGet]
        public ActionResult AddQuestion()
        {
            var disciplinesList = _idiscipline.LoadDisciplines(); // string list
            ViewBag.listOfDisciplines = disciplinesList;

            var disciplineIDList = _idiscipline.LoadDisciplineIDs(); // int list
            ViewBag.listOfDisciplineIDs = disciplineIDList;

            return View();
        }

        [HttpPost]
        public ActionResult AddQuestion(Discipline_QuestionAnswer discipline_QuestionAnswer)
        {
            //if (ModelState.IsValid)
            //{                
               discipline_QuestionAnswer = _idiscipline_QuestionAnswer.AddQuestionAnswer(discipline_QuestionAnswer);
                var disciplinesList = _idiscipline.LoadDisciplines(); // string list
                ViewBag.listOfDisciplines = disciplinesList;

                ViewBag.message = "Question Added Successfully";
            //}
            return View();
        }
    }
}