using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvc1project.Models
{
    public class logindb
    {
        [Required(ErrorMessage = "Enter the username")]
        public string uname { set; get; }
        [Required(ErrorMessage = "Enter the password")]
        public string password { set; get; }
        public string msg { set; get; }
        public string lgtype { set; get; }
    }
}