using OnlineElection.BLL.Repository;
using OnlineElection.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineElection.Controllers
{
    public class PollController : Controller
    {
        PersonRepository personRepository;
        PollRepository pollRepository;
        // GET: Poll
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreatePoll()
        {
            return View();
        }

        public ActionResult GetCandidates()
        {
            personRepository = new PersonRepository();
            return PartialView("~/Views/Poll/_GetCandidates.cshtml", personRepository.GetAll());
        }

        [HttpPost]
        public JsonResult CreatePoll(PollModel polls)
        {
            bool status;
            pollRepository = new PollRepository();
            status = pollRepository.InsertPolls(polls);

            return Json(status, JsonRequestBehavior.AllowGet);
        }
    }
}