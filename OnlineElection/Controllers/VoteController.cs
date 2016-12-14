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


            //ViewBag.candidateList = _candidateRepository.GetAllCandidates();

            return View();
        }

        //Sasindu 
        // GET: Vote

        //please get vote id as a parameter
        //public ActionResult VotingPage(string poll_id)
        public ActionResult VotingPage()
        {
            ViewData["Message"] = "Vote Name";
            ViewData["Description"] = "Vote Description";
            string poll_id = "d9e2a9c5-e2ca-41b9-a811-adab5647a76f";

            Session["pollID"] = poll_id;

            ViewBag.candidateList = _candidateRepository.GetPollSpecificCandidates(poll_id);

            return View();
        }


        //Sasindu
        // POST: Vote/VoteSubmit
        [HttpPost]
        public ActionResult VoteSubmit()
        {
            try
            {
                //get the person ID of logged in student
                string loggedid = "D358BC1A-F92E-4C5B-8F16-EE0C15086BE0";

                //get the poll iD
                //string PollID = "d9e2a9c5-e2ca-41b9-a811-adab5647a76f";
                string PollID = (string)Session["pollID"];
                //get the candidate ID
                string candidateId = Request.Form["selctedCandidate"];
                bool result = _candidateRepository.VoteStubmit(loggedid, PollID, candidateId);



                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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


        //public ActionResult ViewPolls()
        //{
        //    PollRepository poll = new PollRepository();
        //    ViewBag.poll1 = poll.ViewPolls();

        //    return View("ViewPolls");
        //}

        //[HttpGet]

        //public bool CheckPoll(string userID)
        //{
        //    Guid id = new Guid(userID);
        //    PollRepository poll = new PollRepository();
        //    bool status = true;
        //    var check = poll.CheckPoll(id);

        //    if (check != null)
        //    {
        //        status = false;
        //    }
        //    else
        //    {
        //        status = true;
        //    }
        //    return status;
        //}



    }
}
