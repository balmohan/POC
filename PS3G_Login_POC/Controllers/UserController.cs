namespace PS3G_Login_POC.Controllers
{
    using PS3G_Login_POC.Manager;
    using PS3G_Login_POC.Models;
    using System.Web.Mvc;

    /// <summary>
    /// User Management controller
    /// </summary>
    public class UserController : Controller
    {
        /// <summary>
        /// Defines the _userManager for UserManager Class
        /// </summary>
        private IUserManager _userManager;

        /// <summary>
        /// Initializes a new instance of the UserMananger class.
        /// </summary>
        public UserController()
        {
            _userManager = new UserManager();
        }

        /// <summary>
        /// The Index
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult Index()
        {
            return RedirectToAction("Register");
        }

        /// <summary>
        /// The Register
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        [HttpGet]
        public ActionResult Register()
        {
            if (this.Session["UserName"] != null)
            {
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// The Register
        /// </summary>
        /// <param name="user">The user<see cref="User"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _userManager.Register(user);
                    TempData["message"] = "Registration has been successful,Please login";
                    return RedirectToAction("login");
                }
                catch ()
                {
                    return View("error");
                }
            }
            return RedirectToAction("Login");
        }

        /// <summary>
        /// The Login
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        [HttpGet]
        public ActionResult Login()
        {
            if (this.Session["UserName"] != null)
            {
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// The Login
        /// </summary>
        /// <param name="user">The user<see cref="User"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        [HttpPost]
        public ActionResult Login(User user)
        {
            if (_userManager.Login(user))
            {
                this.Session["UserName"] = user.UserName;
                this.Session["Password"] = user.Password;
                return RedirectToAction("Dashboard");
            }
            else
            {
                ModelState.AddModelError("error", "Invalid Usrname or Password");
                return View("Login");
            }
        }

        /// <summary>
        /// The Dashboard
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        [HttpGet]
        public ActionResult Dashboard()
        {
            if (this.Session["Username"] == null)
            {
                return RedirectToAction("login");
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// The Logout
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult Logout()
        {
            this.Session.Clear();
            return View("Login");
        }
    }
}
