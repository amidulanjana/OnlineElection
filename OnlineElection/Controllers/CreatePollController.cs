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
            bool status;

            return Json(status, JsonRequestBehavior.AllowGet);
        }
    }
}