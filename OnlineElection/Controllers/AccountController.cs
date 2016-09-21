using OnlineElection.BLL;
using OnlineElection.BLL.Repository;
using OnlineElection.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineElection.Controllers
{
    public class AccountController : Controller
    {
        //UserRepository repository = new UserRepository();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Register(user user)
        //{
        //    if (!ModelState.IsValid) return View();
        //    repository.RegisterUser(user);
        //    repository.SaveChanges();
        //    return RedirectToAction("Login");

        //}

        public ActionResult Login()
        {
            return View();
        }
    }
}