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
        public ViewResult LoginUsers(Users user)
        {
            if (ModelState.IsValid)
            {
                Users validUser = _iusers.AuthenticateUsers(user);
                if (user.UserEmail == validUser.UserEmail)
                {
                    //redirect to welcome page 
                    // return RedirectToAction("AdminPanel", "Admin");
                    ViewBag.message = "Valid User";

                }
                else
                {
                    ViewBag.message = "Invalid User";

                }
            }
            return View();
        }





    }
}
