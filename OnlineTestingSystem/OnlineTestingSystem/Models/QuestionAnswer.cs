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

        [Required(ErrorMessage = "DisciplineID is Required")]
        public int DisciplineID { get; set; }

        //[Required(ErrorMessage = "Category is Required")]
        public int Category { get; set; }
        [Required(ErrorMessage = "Answer1 is Required")]
        public string Answer1 { get; set; }
        [Required(ErrorMessage = "Answer2 is Required")]
        public string Answer2 { get; set; }
        [Required(ErrorMessage = "Answer3 is Required")]
        public string Answer3 { get; set; }
        [Required(ErrorMessage = "Answer4 is Required")]
        public string Answer4 { get; set; }
        [Required(ErrorMessage = "Correct Answer is Required")]
        public string CorrectAnswer { get; set; }
        public string selectAnswer { get; set; }
    }
}