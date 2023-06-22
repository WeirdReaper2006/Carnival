using System.Linq;
using System.Web.Mvc;
using Carnival.Models;
using System.Web.Security;

namespace Carnival.Controllers
{
    public class LoginsController : Controller
    {
        // GET: Logins
        public ActionResult Login()
        {
            return View();
        }

        // POST: Logins
        [HttpPost]
        public ActionResult Login(Models.Login login)
        {
            using (var context = new CarnivalContext())
            {
                bool isValid = context.Logins.Any(x=>x.Username==login.Username &&x.Password==login.Password);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(login.Username,false);
                    return RedirectToAction("FoodPics", "Randoms");
                }

                ModelState.AddModelError("","Invalid Username or Password");
                return View();
            }
        }

        // GET: Signups
        public ActionResult Signup()
        {
            return View();
        }

        // POST: Signups
        [HttpPost]
        public ActionResult Signup(Login login)
        {
            using (var context= new CarnivalContext())
            {
                context.Logins.Add(login);
                context.SaveChanges();
            }
            return RedirectToAction("login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}