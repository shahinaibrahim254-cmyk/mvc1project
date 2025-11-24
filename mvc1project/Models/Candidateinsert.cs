using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvc1project.Models
{
    public class checkBoxListHelper
    {
        public string value { set; get; }
        public string text { set; get; }
        public bool ischecked { set; get; }
    }
    public class Candidateinsert
    {
        public List<checkBoxListHelper> MyFavouriteQual { set; get; }
        public string[] selectedQual { set; get; }
        [Required(ErrorMessage = "Enter Name")]
        public string name { set; get; }
        [Range(18, 90, ErrorMessage = "Enter the age")]
        public int age { set; get; }
        [Required(ErrorMessage = "Enter the Address")]
        public string address { set; get; }

        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter valid Number")]

        public string phone { set; get; }
        [EmailAddress(ErrorMessage = "Enter valid email id")]
        public string email { set; get; }
        public string gender { set; get; }
        public string qualification { set; get; }

        public string skills { set; get; }
        public int exprience { set; get; }
        public string username { set; get; }
        public string pass { set; get; }
        [Compare("pass", ErrorMessage = "password mismatch")]
        public string cpassword { get; set; }
        public string usermsg { get; set; }
    }
}