using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc1project.Models;

namespace mvc1project.Controllers
{
    public class applicationController : Controller
    {
        mvcprojectEntities ob = new mvcprojectEntities();
        // GET: application
        public ActionResult application_load(int jid,int cid)
        {
            Session["jobid"] = jid;
            Session["comid"] = cid;
            int uid = Convert.ToInt32(Session["uid"]);
            var getdata = ob.sp_jobview(jid, cid).FirstOrDefault();
            return View(new Jobcs
            {
                title = getdata.title,
                sk = getdata.skills,
                exp = getdata.experience,
                jbstatus = getdata.job_status,
                lstdate = getdata.last_date,
                loc = getdata.location,
                sal= getdata.salary

            });
        }
        public ActionResult Job_Apply_click(Jobcs clsobj, HttpPostedFileBase file)
        {
            int cid = Convert.ToInt32(Session["comid"]);
            int jid = Convert.ToInt32(Session["jobid"]);
            int uid = Convert.ToInt32(Session["uid"]);
            int count = Convert.ToInt32(ob.sp_isapplied(uid, jid).FirstOrDefault());
            if (count == 0)
            {
                if (ModelState.IsValid)
                {
                    if (file.ContentLength > 0)
                    {
                        string fname = Path.GetFileName(file.FileName);
                        var s = Server.MapPath("~/PHS");
                        string pa = Path.Combine(s, fname);
                        file.SaveAs(pa);
                        var fullpath = Path.Combine("~\\PHS", fname);
                        clsobj.photo = fullpath;//set
                    }
                    ob.sp_appinsert(uid, jid, DateTime.Now, clsobj.photo, "Applied");
                    clsobj.msg = "inserted successfully";
                    return View("application_load", clsobj);

                }
            }
            else
            {
                clsobj.msg = "Already applied";
                return View("application_load", clsobj);

            }
            return View("application_load", clsobj);
        }
    }
}