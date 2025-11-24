using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc1project.Controllers
{
    public class CHomeController : Controller
    {
        // GET: CHome
        public ActionResult Index()
        {
            return View();
        }
    }
}