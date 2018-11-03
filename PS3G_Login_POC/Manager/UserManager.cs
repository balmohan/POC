namespace PS3G_Login_POC.Manager
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="UserManager" />
    /// </summary>
    public class UserManager : IUserManager
    {
        /// <summary>
        /// Defines the _users
        /// </summary>
        private static IList<User> _users;

        /// <summary>
        /// Initializes static members of the <see cref="UserManager"/> class.
        /// </summary>
        static UserManager()
        {
            _users = new List<User>();
        }

        /// <summary>
        /// The Login
        /// </summary>
        /// <param name="user">The user<see cref="User"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public bool Login(User user)
        {
            var res = _users.Select(u => u)
                .FirstOrDefault(us => us.UserName == user.UserName && us.Password == user.Password);
            if (res!=null && res.Equals(user))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// The Register
        /// </summary>
        /// <param name="user">The user<see cref="User"/></param>
        public User Register(User user)
        {
            try
            {
                if (_users != null && !_users.Select(u=>u.UserName).Contains(user.UserName))
                {
                    _users.Add(user);
                    return user;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Unable to Create new user " + ex.Message);
            }
        }
    }
}
