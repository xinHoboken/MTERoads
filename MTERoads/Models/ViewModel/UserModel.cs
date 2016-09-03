using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MTERoads.Models.ViewModel
{
   
    public class UserLoginModel
    {
        [Key]
        [Required]
        //[Display(Name = "Login ID")]
        public string LoginName { get; set; }
        [Required]
        //[Display(Name = "Password")]
        public string Password { get; set; }
    }
}