using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvc1project.Models
{
    public class cmpinsert
    {

        [Required(ErrorMessage = "Enter Name")]
        public string name { set; get; }

        [Required(ErrorMessage = "Enter the Address")]
        public string address { set; get; }

        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter valid Number")]
        public string phone { set; get; }

        public string website { set; get; }
        public string description { set; get; }
        public string username { set; get; }
        public string pass { set; get; }
        [Compare("pass", ErrorMessage = "password mismatch")]
        public string cpassword { get; set; }
        public string cmpmsg { get; set; }
    }
}