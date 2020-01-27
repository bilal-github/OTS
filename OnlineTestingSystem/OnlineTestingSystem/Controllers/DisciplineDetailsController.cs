using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTestingSystem.Interfaces;

namespace OnlineTestingSystem.Controllers
{
    public class DisciplineDetailsController : Controller
    {
        private IDisciplineDetails _idisciplineDetails;
        public DisciplineDetailsController(IDisciplineDetails idisciplineDetails)
        {
            _idisciplineDetails = idisciplineDetails;
        }
        // GET: DisciplineDetails
        [HttpGet]
        public ActionResult AddDetail()
        {
            return View();
        }
    }
}