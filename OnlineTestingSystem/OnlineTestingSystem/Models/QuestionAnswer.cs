using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTestingSystem.Models
{
    public class QuestionAnswer
    {
        //Questions class in Diagram       
        [Required(ErrorMessage = "Question Description is Required")]
        public string QuestionDescription { get; set; }

        //Answers class in diagram
        public int QuestionID { get; set; }
        public int DisciplineID { get; set; }
        public int Category { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public string CorrectAnswer { get; set; }
    }
}