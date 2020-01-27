using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineTestingSystem.Models;

namespace OnlineTestingSystem.Interfaces
{
    public interface IDisciplineDetails
    {
        void AddDetail(Users user, Discipline discipline);
        
    }
}
