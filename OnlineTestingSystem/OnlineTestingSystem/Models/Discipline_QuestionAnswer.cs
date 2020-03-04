using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTestingSystem.Models
{
    /// <summary>
    /// Joined Objects Class
    /// </summary>
    public class Discipline_QuestionAnswer
    {
        
        public Discipline discipline { get; set; }
        public QuestionAnswer questionAnswer { get; set; }
    }
}