using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc1project.Models;

namespace mvc1project.Controllers
{
    public class logincController : Controller
    {
        mvcprojectEntities ob = new mvcprojectEntities();
        // GET: loginc
        public ActionResult LoginPageLoad()
        {
            return View();
        }
        public ActionResult User_Home()
        {
            return View();
        }
        public ActionResult Company_Home()
        {
            return View();
        }
        public ActionResult Login_click(logindb clsobj)
        {
            if (ModelState.IsValid)
            {
                var val = ob.sp_logincountid(clsobj.uname, clsobj.password).First();
                if (val == 1)
                {
                    var uid = ob.sp_loginreg(clsobj.uname, clsobj.password).FirstOrDefault();
                    Session["uid"] = uid;

                    var lt = ob.sp_logtype(clsobj.uname, clsobj.password).FirstOrDefault();

                    if (lt == "user")
                    {
                        // Redirect to JobController User_Home, which shows jobs
                        return RedirectToAction("User_Home");
                    }
                    else if (lt == "company")
                    {
                        return RedirectToAction("Company_Home");
                    }
                }
                else
                {
                    ModelState.Clear();
                    clsobj.msg = "Invalid username or password";
                    return View("LoginPageLoad", clsobj);
                }
            }

            // If ModelState is invalid
            ModelState.Clear();
            return View("LoginPageLoad", clsobj);
        }

    }
}
