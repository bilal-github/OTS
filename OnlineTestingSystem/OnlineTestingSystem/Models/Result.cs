using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTestingSystem.Models
{
    public class Result
    {
        public int TestID { get; set; }
        public int DisciplineID { get; set; }
        public int UserID { get; set; }
        public int TotalQuestions { get; set; }
        public int CorrectQuestions { get; set; }
        public int WrongQuestions { get; set; }

        public string Score { get; set; }
    }
}