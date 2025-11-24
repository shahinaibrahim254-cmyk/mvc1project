using System.Linq;
using System.Web.Mvc;
using mvc1project.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System;

namespace mvc1project.Controllers
{
    public class ViewjobController : Controller
    {
        mvcprojectEntities db = new mvcprojectEntities();

        private jobsearch getdata(jobsearch clsobj, string qry)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["importdataconnection"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_jobsearches", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qry", qry);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                var joblist = new jobsearch();
                while (dr.Read())
                {
                    var jobcls = new jobList();

                    jobcls.Job_id = Convert.ToInt32(dr["job_id"].ToString());
                    jobcls.Company_id = Convert.ToInt32(dr["company_id"].ToString());
                    jobcls.Job_Tittle = dr["title"].ToString();
                    //jobcls.Job_description = dr["Job_description"].ToString();
                    jobcls.Job_Experience = dr["experience"].ToString();
                    jobcls.Job_Skills = dr["skills"].ToString();
                    jobcls.Job_Salary = dr["salary"].ToString();
                    jobcls.Job_enddate = Convert.ToDateTime(dr["last_date"].ToString());
                    jobcls.Job_Location = dr["location"].ToString();

                    joblist.selectjob.Add(jobcls);
                }

                con.Close();
                return joblist;
            }
        }

        

            // GET: Viewjob/Viewjob_pageload
            public ActionResult Viewjob_pageload()
        {
            jobsearch obj = new jobsearch();  //It automatically initializes
                                              //insertse = new jobList()(for search fields)
                                              //selectjob = new List<jobList>()(empty list to fill with job data)

            obj.selectjob = db.jobs//selectjob is list to fill job data
                .Select(x => new jobList//x represents each row in the Jobs database table.
                                        //select selects each row
                {
                    Job_id = x.job_id,
                    Company_id = x.company_id,
                    Job_Tittle = x.title,
                    Job_Skills = x.skills,
                    Job_Experience = x.experience,
                    Job_Status = x.job_status,
                    Job_enddate = x.last_date,
                    Job_Location = x.location,
                    Job_Salary = x.salary
                }).ToList();//This is called Projection — converting database rows into model objects.

            // insertse already gets new jobList() from constructor → no need to set again

            return View(obj);
        }
        public ActionResult searchjob_click(jobsearch clsobj)
        {
            string qry = "";

            if (!string.IsNullOrWhiteSpace(clsobj.insertse.Job_Experience))
            {
                qry += " and experience like '%" + clsobj.insertse.Job_Experience + "%'";
            }

            if (!string.IsNullOrWhiteSpace(clsobj.insertse.Job_Skills))
            {
                qry += " and skills like '%" + clsobj.insertse.Job_Skills + "%'";
            }

            if (!string.IsNullOrWhiteSpace(clsobj.insertse.Job_Location))
            {
                qry += " and location like '%" + clsobj.insertse.Job_Location + "%'";
            }

            return View("Viewjob_pageload", getdata(clsobj, qry));
        }
    }
}
