using OnlineTestingSystem.Interfaces;
using OnlineTestingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTestingSystem.Controllers
{
    public class QuestionController : Controller
    {
        // GET: Question
        private IQuestion _iquesiton;
        public QuestionController(IQuestion iquestion)
        {
            _iquesiton = iquestion;
        }

        [HttpGet]
        public ActionResult AddQuestion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddQuestion(QuestionAnswer question)
        {
            if (ModelState.IsValid)
            {
                QuestionAnswer newQuestion = _iquesiton.AddQuestionAnswer(question);
                ViewBag.message = "Question Added Successfully";
            }
            return View();
        }
    }
}