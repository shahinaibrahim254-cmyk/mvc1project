using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc1project.Models;

namespace mvc1project.Controllers
{
    public class candidateregController : Controller
    {
        mvcprojectEntities ob = new mvcprojectEntities();
        // GET: candidatereg
        public ActionResult Insert_userpageload()
        {
            Candidateinsert user = new Candidateinsert();
            user.MyFavouriteQual = getqualificationdata();
            return View(user);
        }
        public List<checkBoxListHelper> getqualificationdata()
        {
            List<checkBoxListHelper> sts = new List<checkBoxListHelper>()
            {
                new checkBoxListHelper { value = "SSLC", text = "SSLC", ischecked = true },
                new checkBoxListHelper { value = "PLUSTWO", text = "PLUSTWO", ischecked = false },
                new checkBoxListHelper { value = "BCA", text = "BCA", ischecked = false },
                new checkBoxListHelper { value = "MCA", text = "MCA", ischecked = false },
                new checkBoxListHelper { value = "BSC COMPUTERSCIENCE", text = "BSC COMPUTERSCIENCE", ischecked = false },
                new checkBoxListHelper { value = "MSC COMPUTERSCIENCE", text = "MSC COMPUTERSCIENCE", ischecked = false },
            };
            return sts;
        }
        public ActionResult Insert_userclick(Candidateinsert clsobj)
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
                var quid = string.Join(",", clsobj.selectedQual);
                clsobj.qualification = quid;
                clsobj.MyFavouriteQual = getqualificationdata();
                ob.sp_candidatereg(regid, clsobj.name, clsobj.age, clsobj.address, clsobj.phone, clsobj.email, clsobj.gender, clsobj.qualification, clsobj.skills, clsobj.exprience);
                ob.sp_loginsert(regid, clsobj.username, clsobj.pass, "user");
                clsobj.usermsg = "succcessfully inserted";
                return View("Insert_userpageload", clsobj);
            }
            else
            {

                clsobj.MyFavouriteQual = getqualificationdata();

            }
            return View("Insert_userpageload", clsobj);

        }
    }
}