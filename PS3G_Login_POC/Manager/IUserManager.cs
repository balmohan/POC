using PS3G_Login_POC.Models;

namespace PS3G_Login_POC.Manager
{
    interface IUserManager
    {
        bool Login(User user);
        void Register(User user);
        
    }
}
