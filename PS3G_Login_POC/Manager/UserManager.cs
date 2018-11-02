namespace PS3G_Login_POC.Manager
{
    using PS3G_Login_POC.Models;
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
            if (_users.Select(u => u.UserName).Contains(user.UserName) && _users.Select(p => p.Password).Contains(user.Password))
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
        public void Register(User user)
        {
            try
            {
                _users.Add(user);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to Create new user " + ex.Message);
            }
        }
    }
}
