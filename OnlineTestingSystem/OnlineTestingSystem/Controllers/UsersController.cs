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



        
    }
}
