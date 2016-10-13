﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineElection.DAL;
using OnlineElection.BLL.Repository;
using System.Web.Helpers;

namespace AdminPanel.Controllers
{
    public class UserController : Controller
    {
        PersonRepository repository = new PersonRepository();
        person _person;
        // GET: User
        //public ActionResult Index()
        //{
        //    //return View();
        //}

        public ActionResult AddUser()
        {
            
            return View("~/ViewsAdmin/User/AddUser.cshtml");
        }

        public ActionResult ViewUsers()
        {
            return View("~/ViewsAdmin/User/ViewUsers.cshtml",repository.GetAll());
        }

        [HttpPost]
        public JsonResult IsSIDAvaliable(string SID)
        {
           
            bool isAvailable = repository.IsSIDAvailable(SID);

            if (isAvailable) return Json(new { valid = false }, JsonRequestBehavior.AllowGet);

            return Json(new { valid = true }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult RegisterUser(person person)
        {
            _person = new person();
            _person.SID = person.SID;
            _person.FirstName = person.FirstName;
            _person.password = Crypto.HashPassword(person.password);
            _person.email = person.SID + "@my.sliit.lk";
            _person.AdminApproved = true;

            bool status;
            if (!ModelState.IsValid) return Json(false, JsonRequestBehavior.AllowGet);
            status = repository.registerPerson(_person);

            return Json(status, JsonRequestBehavior.AllowGet);

        }

        //adminApproveOrIgnore
        [HttpPost]
        public JsonResult AdminApproveOrIgnore(person user)
        {
            _person = new person();
            _person.Person_ID = user.Person_ID;
            _person.AdminApproved = user.AdminApproved;

            bool status = repository.AdminApproveOrIgnore(_person);

            if (status) return Json(true,JsonRequestBehavior.AllowGet);

            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}