using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineTestingSystem.Models;

namespace OnlineTestingSystem.Interfaces
{
    public interface IDiscipline
    {
        Discipline AddDiscipline(Discipline discipline);
        Discipline EditDiscipline(Discipline discipline);
        List<string> LoadDisciplines();
        List<int> LoadDisciplineIDs();

        IEnumerable<Discipline> disciplines();

    }
}
