using System;

namespace PS3G_Login_POC.Models
{
    public class User:IEquatable<User>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool Equals(User other) => other != null && (UserName == other.UserName && Password == other.Password);
    }
}