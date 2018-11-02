using PS3G_Login_POC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS3G_Login_POC.Manager
{
    interface IUserManager
    {
        bool Login(User user);
        void Register(User user);
        
    }
}
