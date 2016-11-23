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
        //Guid sessionId;
        person person1;
        // GET: Profile
        public ActionResult Index()
        {
            Session["userID"] = "IT14111884";
            string sessionValue = Session["userID"].ToString();
            if (Session["userID"].ToString() == null) return View("Login");

            person1 = repo.GetPeronById(sessionValue);
            var model = person1;
            return View(model);
        }


        public ActionResult Edit(string id)
        {
            //sessionId = new Guid(Session["userID"].ToString());
            //person person = repo.GetPeronById(sessionId);
            //ViewBag.person = person;
            //string sessionValue = Session["userID"].ToString();
            person1 = repo.GetPeronById(id);

            var model = person1;
            return View(model);
        }

       [HttpPost]
        public ActionResult Edit(person person1)
        {
            //[Bind(Include = "FirstName,LastName,Address,Phone,email,password")]
            if (ModelState.IsValid)
            {
                string sessionValue = Session["userID"].ToString();
                repo.Entry(sessionValue, person1); /*new Guid(Session["userID"].ToString()),*/
                return RedirectToAction("Index");
            }

            return View(person1);   
        }

    }
}