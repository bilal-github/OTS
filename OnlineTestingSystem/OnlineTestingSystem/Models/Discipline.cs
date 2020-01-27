using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTestingSystem.Models
{
    public class Discipline
    {
        public int DisciplineID { get; set; }

        [Required(ErrorMessage = "Discipilne Name is Required")]
        public string DisciplineName { get; set; }
        


    }
}