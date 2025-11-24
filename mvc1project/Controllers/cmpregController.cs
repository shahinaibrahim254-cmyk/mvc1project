using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc1project.Models;

namespace mvc1project.Controllers
{
    public class cmpregController : Controller
    {
        mvcprojectEntities ob = new mvcprojectEntities();
        // GET: cmpreg
        public ActionResult Insert_cmpnypageload()
        {
            return View();
        }
        public ActionResult Insert_cmpnyclick(cmpinsert clsobj)
        {
            if (ModelState.IsValid)
            {

                var getmaxid = ob.sp_maxidlogin().FirstOrDefault();
                int mid = Convert.ToInt32(getmaxid);
                int regid = 0;
                if (mid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }
                ob.sp_cmpnyreg(regid, clsobj.name, clsobj.address, clsobj.phone, clsobj.website, clsobj.description);
                ob.sp_loginsert(regid, clsobj.username, clsobj.pass, "company");
                clsobj.cmpmsg = "succcessfully inserted";
                return View("Insert_cmpnypageload", clsobj);
            }

            return View("Insert_cmpnypageload", clsobj);
        }
    }
}