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

        [HttpPost]

        public JsonResult Createpoll(Poll poll)
        {

            Poll _poll = new Poll();
            _poll.candidates = poll.candidates;


            bool status;
            if (!ModelState.IsValid) return Json(false, JsonRequestBehavior.AllowGet);
            status = Poll.createPoll(_poll);
            return Json(status, JsonRequestBehavior.AllowGet);
        }
    }
}