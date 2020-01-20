using OnlineTestingSystem.Models;
using OnlineTestingSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTestingSystem.Controllers
{
    public class DisciplineController : Controller
    {
        private IDiscipline _idiscipline;
        public DisciplineController(IDiscipline idiscipline)
        {
            _idiscipline = idiscipline;
        }
        [HttpGet]
        public ActionResult AddDiscipline()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDiscipline(Discipline discipline)
        {
            if (ModelState.IsValid)
            {
                Discipline newDiscipline = _idiscipline.AddDiscipline(discipline);
                ViewBag.message = "Discipline Added Successfully";

            }
            return View();
        }

        [HttpGet]
        public ActionResult EditDiscipline()
        {
            var disciplinesList = _idiscipline.disciplines();
            return View(disciplinesList);
        }

        [HttpPost]
        public ActionResult EditDiscipline(Discipline updateDiscipline)
        {
            if (ModelState.IsValid)
            {
                Discipline editDiscipine = _idiscipline.EditDiscipline(updateDiscipline);
                ViewBag.message = "Discipline Updated Successfully";
            }
            return View();
        }
    }
}