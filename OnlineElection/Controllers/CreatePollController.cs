using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineElection.Controllers
{
    public class CreatePollController : Controller
    {
        // GET: CreatePoll
        public ActionResult Index()
        {
            return View();
        }
    }
}