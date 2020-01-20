using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineTestingSystem.Models;

namespace OnlineTestingSystem.Interfaces
{
    public interface IAdmin
    {
        Admin AddAdmin(Admin admin);
        Admin EditAdmin(Admin admin);

        Admin AuthenticateAdmin(Admin admin);
    }
}
