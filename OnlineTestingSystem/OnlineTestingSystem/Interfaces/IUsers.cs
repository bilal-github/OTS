using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineTestingSystem.Models;

namespace OnlineTestingSystem.Interfaces
{
    public interface IUsers
    {
        Users AddUsers(Users user);
        Users UpdateUsers(Users user);
        Users DeleteUsers(Users user);
    }
}
