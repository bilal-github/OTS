using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTestingSystem.Models
{
    public class Admin
    {

        public int AdminID { get; set; }
               
        [Required(ErrorMessage = "Admin Name is Required")]
        public string AdminName { get; set; }
	    public	int AdminPhone;
		public String Admin_Hobby;
		public int Admin_Salary;


        [Required(ErrorMessage = "Password is Required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string AdminPassword { get; set; }
        
		
		//Start Admin Method
		void AddAdmin(){
			
			
		}


    }
}