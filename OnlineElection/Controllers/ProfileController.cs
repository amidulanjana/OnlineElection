using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineElection.DAL;
using OnlineElection.BLL;
using OnlineElection.BLL.Repository;
using System.Data.Entity;

namespace OnlineElection.Controllers
{
    public class ProfileController : Controller
    {
        PersonRepository repo = new PersonRepository();
        Guid sessionId;
        // GET: Profile
        public ActionResult Index()
        {
            Session["userID"] = "1A1FB01A-E3AC-4AE3-BD7C-5691CDA38AE3";
            sessionId = new Guid(Session["userID"].ToString());
            if (Session["userID"].ToString() == null) return View("Login");

            person person = repo.GetPeronById(sessionId);
            ViewBag.person = person;
            return View();
        }


        public ActionResult Edit()
        {
            sessionId = new Guid(Session["userID"].ToString());
            person person = repo.GetPeronById(sessionId);
            ViewBag.person = person;
            return View();
        }

       [HttpPost]
        public ActionResult Edit([Bind(Include= "FirstName,LastName,Address,Phone,email,password")]person person)
        {
            if (ModelState.IsValid)
            {
                repo.Entry(person.Person_ID, person);
                return RedirectToAction("Index");
            }

            return View(person);   
        }

    }
}