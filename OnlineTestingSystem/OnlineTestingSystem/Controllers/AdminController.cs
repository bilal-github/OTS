using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTestingSystem.Interfaces;
using OnlineTestingSystem.Models;

namespace OnlineTestingSystem.Controllers
{
    public class AdminController : Controller
    {
        private IAdmin _iadmin;
        public AdminController(IAdmin iadmin)
        {
            _iadmin = iadmin;
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            if (ModelState.IsValid)
            {
                Admin newAdmin = _iadmin.AddAdmin(admin);
                
            }
            return View();
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            //Admin newAdmin = admin;
            if (ModelState.IsValid)
            {
                Admin validAdmin = _iadmin.AuthenticateAdmin(admin);
                if(admin.AdminName == validAdmin.AdminName)
                {
                    return RedirectToAction("AdminPanel", "Admin");

                }
                else
                {
                    ViewBag.message = "Invalid User";
                    
                }
            }
            return View();

        }

        [HttpGet]
        public ActionResult AdminPanel()
        {
            return View();
        }
    }
}