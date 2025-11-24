using System;
using System.Linq;
using System.Web.Mvc;
using mvc1project.Models;

namespace mvc1project.Controllers
{
    public class JobController : Controller
    {
        mvcprojectEntities db = new mvcprojectEntities();

        // GET: Job/AddJob
        public ActionResult AddJob()
        {
            return View();
        }

        // POST: Job/AddJob
        [HttpPost]
        public ActionResult AddJob(Jobcs ob)
        {
            try
            {
                int cid = Convert.ToInt32(Session["uid"]);
                db.sp_job(cid,ob.title, ob.sk, ob.loc, ob.sal, ob.exp, ob.jbstatus, ob.lstdate);
                ViewBag.Message = "Job Added Successfully!";
            }
            catch
            {
                ViewBag.Message = "Error while adding job!";
            }

            return View(ob);
        }


    }
}
