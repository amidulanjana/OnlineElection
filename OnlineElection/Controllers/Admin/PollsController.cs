using OnlineElection.BLL.Repository;
using OnlineElection.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineElection.Controllers.Admin
{
    public class PollsController : Controller
    {
        PersonRepository personRepository = new PersonRepository();
        PollRepository pollRepository = new PollRepository();
        // GET: Polls
        public ActionResult Index()
        {
            return View("~/ViewsAdmin/Polls/Index.cshtml");
        }

        public ActionResult CreatePoll()
        {
            return View("~/ViewsAdmin/Polls/CreatePoll.cshtml");
        }

        public ActionResult GetCandidates()
        {
            return PartialView("~/ViewsAdmin/Polls/_GetCandidates.cshtml", personRepository.GetAll());
        }


        [HttpPost]
        public JsonResult CreatePoll(PollModel polls)
        {

            pollRepository.InsertPolls(polls);
            return Json(null,null);
        }
    }
}