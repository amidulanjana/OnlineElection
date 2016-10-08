using OnlineElection.BLL;
using OnlineElection.BLL.Repository;
using OnlineElection.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace OnlineElection.Controllers
{

    public class AccountController : Controller
    {
        PersonRepository repository = new PersonRepository();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Register(person person)
        {
            person _person = new person();
            _person.SID = person.SID;
            _person.email = person.email;
            _person.password = Crypto.HashPassword(person.password);
            _person.AdminApproved = false;

            bool status;
            if (!ModelState.IsValid) return Json(false, JsonRequestBehavior.AllowGet);
            status = repository.registerPerson(_person);

            return Json(status, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(person LoggedUser)
        {
            bool verify = false;
            bool _adminApprove = false;

            if (!ModelState.IsValid) return Json(false, JsonRequestBehavior.AllowGet);
            person _person = repository.LoggedUser(LoggedUser);

            if (_person != null)
            {
                verify = Crypto.VerifyHashedPassword(_person.password, LoggedUser.password);
            }

            if (_person.AdminApproved != false)
            {
                _adminApprove = true;
            }

            if (verify == true && _adminApprove == true)
            {
              
                Session["userID"] = _person.Person_ID.ToString();
                Session["SID"] = _person.SID.ToString();
                
            }

            var data = new
            {
                passwordVerify = verify,
                adminApprove = _adminApprove

            };

            return Json(data, JsonRequestBehavior.AllowGet);

        }

        public ActionResult LoggedIn()
        {
            if (Session["userID"].ToString() == null) return View("Login");
            
            return RedirectToAction("Index","Home");
            
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return View("Login");
        }


    }
}