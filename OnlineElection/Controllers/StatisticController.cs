using OnlineElection.BLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineElection.Controllers
{
    public class StatisticController : Controller
    {
        PersonRepository repo;
        // GET: Statistic
        public ActionResult Index()
        {
            Guid id = new Guid(Session["userID"].ToString());
            repo = new PersonRepository();
            repo.getUserVoted(id);
            return View(repo.getUserVoted(id));
            
        }


    }
}