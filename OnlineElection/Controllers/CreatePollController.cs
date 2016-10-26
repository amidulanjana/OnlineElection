using OnlineElection.BLL.Repository;
using OnlineElection.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineElection.Controllers
{
    public class CreatePollController : Controller
    {
        PollRepository Poll = new PollRepository();
        // GET: CreatePoll
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Admin()
        {
            return View();
        }

        [HttpPost]

        public JsonResult Createpoll(Poll poll)
        {

            Poll _poll = new Poll();
            _poll.Name = poll.Name;
            _poll.Type = poll.Type;
            _poll.max_candidates = poll.max_candidates;
            _poll.poll_date = poll.poll_date;


            bool status;
            if (!ModelState.IsValid) return Json(false, JsonRequestBehavior.AllowGet);
            status = Poll.createPoll(_poll);
            return Json(status, JsonRequestBehavior.AllowGet);
        }

        
    }
}