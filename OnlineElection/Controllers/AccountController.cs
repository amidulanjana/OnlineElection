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
            _person.password = Crypto.SHA1(person.password);
           
            bool status;
            if (!ModelState.IsValid) return Json(false,JsonRequestBehavior.AllowGet);
            status=repository.registerPerson(_person);

            //if (status) { ViewBag.Status = "Wait until admin approve"; }
            //else { ViewBag.Status = "Dont know what to do"; }

            return Json(status, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Login()
        {
            return View();
        }


        
    }
}