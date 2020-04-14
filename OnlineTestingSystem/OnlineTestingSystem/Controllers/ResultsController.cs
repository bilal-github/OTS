using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTestingSystem;
using OnlineTestingSystem.Interfaces;
using OnlineTestingSystem.Models;

namespace OnlineTestingSystem.Controllers
{
    public class ResultsController : Controller
    {
        private IResults _iresults;
        private Result result = new Result();

        public ResultsController(IResults iresults)
        {
            _iresults = iresults;
        }
        
        [HttpGet]
        public ActionResult Results()
        {
            int UserID = Convert.ToInt32(Session["UserID"]);
            int DisciplineID = Convert.ToInt32(Session["DisciplineID"]);
            int TestID = Convert.ToInt32(Session["TestID"]);

            result = _iresults.GetResult(UserID,DisciplineID);
            _iresults.insertIntoResults(UserID, TestID, result.Score);
            return View(result);
        }
    }
}