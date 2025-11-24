using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc1project.Models
{
    public class jobsearch
    {
        public jobsearch()
        {
            selectjob = new List<jobList>();
            insertse = new jobList();
        }
        public jobList insertse { get; set; }
        public List<jobList> selectjob { get; set; }

    }
}
public class Jobsearch
{
    public Jobsearch()
    {
        selectjob = new List<jobList>();
        insertse = new jobList();
    }

    public jobList insertse { get; set; }
    public List<jobList> selectjob { get; set; }
}
public class jobList
{
    public int Job_id { get; set; }
    public int Company_id { get; set; }
    public string Job_Tittle { get; set; }
    public string Job_description { get; set; }
    public string Job_Experience { get; set; }
    public string Job_Skills { get; set; }
    public string Job_Salary { get; set; }
    public System.DateTime Job_enddate { get; set; }
    public string Job_Location { get; set; }
    public string Job_Status { get; set; }
   
    public string jobtype_name { get; set; }
}

