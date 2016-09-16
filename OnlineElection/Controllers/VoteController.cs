using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineElection.BLL.Repository;

namespace OnlineElection.Controllers
{
    
    public class VoteController : Controller
    {
        CandidateRepository _candidateRepository = new CandidateRepository();

        // GET: Vote
        public ActionResult Index()
        {
            //ViewData["Message"] = "Vote Name";
            //ViewData["Description"] = "Vote Description";

            ////retreve data from database
            //var candidates = new List<string>
            //{
            //    "Candidate 1",
            //    "Candidate 2",
            //    "Candidate 3",
            //    "Candidate 4",
            //    "Candidate 5",
            //    "Candidate 6",
            //    "Candidate 7",
            //    "Candidate 8"
            //};
            //ViewBag.Candidates = candidates;

            ViewBag.candidateList = _candidateRepository.GetAllCandidates();
            
            return View();
        }

        
        // GET: Vote/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Vote/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vote/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vote/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Vote/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
               // var query=from m in d
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vote/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Vote/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
     
    }
}
