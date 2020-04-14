using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineTestingSystem.Models;

namespace OnlineTestingSystem.Interfaces
{
    public interface IResults
    {
        Result GetResult(int UserID, int DisciplineID);
        void insertIntoResults(int UserID, int TestID, string Score);
        
    }
}
