using System;

namespace PS3G_Login_POC.Models
{
    public class User:IEquatable<User>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool Equals(User other)
        {
            if (other != null && (this.UserName==other.UserName && this.Password==other.Password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}