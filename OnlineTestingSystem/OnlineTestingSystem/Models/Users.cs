using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTestingSystem.Models
{
    public class Users
    {
        public int UserID { get; set; }
        [Required(ErrorMessage ="First Name is Required")]
        public string UserFirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public string UserLastName { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$",
        ErrorMessage = "Please enter correct email address")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage ="Password is Required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
       
    }
}