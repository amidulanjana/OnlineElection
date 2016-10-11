using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineElection.DAL;
using OnlineElection.BLL.Repository;

namespace AdminPanel.Controllers
{
    public class UserController : Controller
    {
        PersonRepository repository = new PersonRepository();
        // GET: User
        //public ActionResult Index()
        //{
        //    //return View();
        //}

        public ActionResult AddUser()
        {
            person person = new person();
            return View("~/Views/AdminViews/User/AddUser.cshtml");
        }

        public ActionResult ViewUsers()
        {
            return View("~/Views/AdminViews/User/ViewUsers.cshtml");
        }
    }
}