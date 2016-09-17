using OnlineElection.BLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineElection.Controllers
{
    public class CandidateController : Controller
    {
        CandidateRepository repository = new CandidateRepository();
        // GET: Candidate
        public ActionResult Index()
        {
            
            return View(repository.GetAllCandidates());
        }
    }
}