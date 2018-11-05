using System.Net;
using System.Web.Mvc;
using PS3G_Login_POC.Manager;
using PS3G_Login_POC.Models;

namespace PS3G_Login_POC.Controllers
{
    /// <summary>
    /// User Management controller
    /// </summary>
    public class UserController : Controller
    {
        /// <summary>
        /// Defines the _userManager for UserManager Class
        /// </summary>
        private readonly IUserManager _userManager;

        /// <summary>
        /// Initializes a new instance of the UserManager class.
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
            return View();
            //return RedirectToAction("Register");
        }

        /// <summary>
        /// The Register
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        [HttpGet]
        public ActionResult Register()
        {
            if (Session["UserName"] != null)
            {
                return RedirectToAction("Dashboard");
            }

            return PartialView();
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
                    if (_userManager.Register(user) !=null)
                    {
                        return PartialView("Login");

                    }
                    else
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.Conflict, "User Already Exist,Please login");

                    }

                }
                catch
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
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
            if (Session["UserName"] != null)
            {
                return PartialView("Dashboard");
            }

            return PartialView();
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
                Session["UserName"] = user.UserName;
                Session["Password"] = user.Password;
                return RedirectToAction("Dashboard");
            }
            return new HttpStatusCodeResult(HttpStatusCode.Forbidden,"Login Failed");
        }

        /// <summary>
        /// The Dashboard
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        [HttpGet]
        public ActionResult Dashboard()
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("login");
            }

            return View();
        }

        /// <summary>
        /// The Logout
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult Logout()
        {
            Session.Clear();
            return PartialView("Index");
        }
    }
}
