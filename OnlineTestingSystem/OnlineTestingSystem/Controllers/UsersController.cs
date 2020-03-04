using OnlineTestingSystem.Interfaces;
using OnlineTestingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTestingSystem.Controllers
{
    public class UsersController : Controller
    {
        private IUsers _iusers;
        public UsersController(IUsers iusers)
        {
            _iusers = iusers;
        }

        [HttpGet]
        public ViewResult AddUsers()
        {
            return View();
        }
        [HttpPost]
        public ViewResult AddUsers(Users user)
        {
            if (ModelState.IsValid)
            {
                Users newUser = _iusers.AddUsers(user);
                ViewBag.firstName = newUser.UserFirstName;
            }
            return View();
        }

        [HttpGet]
        public ViewResult LoginUsers()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUsers(Users user)
        {

            Users validUser = _iusers.AuthenticateUsers(user);
            if (user.UserEmail == validUser.UserEmail)
            {
                //redirect to welcome page 
                Session["UserFirstName"] = user.UserFirstName;
                Session["UserID"] = user.UserID;

                return RedirectToAction("UserPanel", "Users");
                //ViewBag.message = "Valid User";

            }
            else
            {
                ViewBag.message = "Invalid User";
            }
            return View();
        }

        [HttpGet]
        public ActionResult UserPanel()
        {
            int userID = (int)Session["UserID"];
            if (_iusers.HasRegistrations(userID))//disciplines found
            {
                var DisciplinesByID = _iusers.LoadDisciplinesByID(userID);
                ViewBag.disciplinesList = DisciplinesByID;
            }
            else
            {

            }
            ViewBag.session = Session["UserFirstName"];
            return View();
        }

        [HttpPost]
        public ActionResult UserPanel(User_Discipline user_Discipline)
        {
            if (ModelState.IsValid)
            {
                int userID = (int)Session["UserID"];
                var DisciplinesByID = _iusers.LoadDisciplinesByID(userID);
                ViewBag.disciplinesList = DisciplinesByID;

                ViewBag.DisciplineID = user_Discipline.discipline.DisciplineName;
                var DisciplineName = (from d in DisciplinesByID where d.DisciplineID == Convert.ToInt32(user_Discipline.discipline.DisciplineName) select d.DisciplineName).ToList();
                foreach(string disciplineName in DisciplineName)
                {
                    Session["DisciplineName"] = disciplineName;
                }
                //ViewBag.session = Session["UserFirstName"];
                return RedirectToAction("Test", "Test");
            }

            return View();
        }

        //[HttpGet]
        //public ActionResult Test()
        //{
        //    ViewBag.Name = Session["UserFirstName"];
        //    ViewBag.DisciplineName = Session["DisciplineName"];
        //    return View();
        //}
    }
}
