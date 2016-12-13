using OnlineElection.BLL.Repository;
using OnlineElection.DAL;
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
        PersonRepository personRepository;
        PollRepository pollRepository;
        FacultyRepository facultyRepository;
        Poll _poll;

        // GET: Polls
        public ActionResult Index()
        {
            return View("~/ViewsAdmin/Polls/Index.cshtml");
        }

        public ActionResult CreatePoll()
        {
            facultyRepository = new FacultyRepository();
            return View("~/ViewsAdmin/Polls/CreatePoll.cshtml", facultyRepository.GetAllFaculty());
        }

        public ActionResult GetCandidates()
        {
            personRepository = new PersonRepository();
            return PartialView("~/ViewsAdmin/Polls/_GetCandidates.cshtml", personRepository.GetAll());
        }

        /**
          * @desc Insert the Poll details admin have created
          * @param PollModel object
          * @return Json - success/Failure
        */
        [HttpPost]
        public JsonResult CreatePoll(PollModel polls)
        {
            bool status;
            pollRepository = new PollRepository();
            status = pollRepository.InsertPolls(polls);

            return Json(status, JsonRequestBehavior.AllowGet);
        }


        /**
          * @desc Give all the Batch details for the relevent Faculty/Faculties
          * @param Faculty ID/IDs
          * @return Json - Batch Details or success/Failure
        */
        public JsonResult GetBatches(Guid[] ids)
        {

            facultyRepository = new FacultyRepository();
            var batches = facultyRepository.GetBatches(ids);

            return Json(batches, JsonRequestBehavior.AllowGet);
        }


        /**
          * @desc Return ViewPolls page
          * @param No param
          * @return View - ViewPolls page
        */
        public ActionResult ViewPolls()
        {
            return View("~/ViewsAdmin/Polls/ViewPolls.cshtml");
        }

        /**
          * @desc Return _TableViewPolls partial view page.This is called by an AJAX function
          * @param No param
          * @return PartialView - _TableViewPolls page
        */
        public ActionResult GetAllPolls()
        {
            pollRepository = new PollRepository();
            return PartialView("~/ViewsAdmin/Polls/_TableViewPolls.cshtml", pollRepository.GetAllPolls());
        }


        /**
          * @desc Return Assigned candidates to the ViewPolls page.This is called by an AJAX function
          * @param - (GUID) poll ID
          * @return Json - AssignedCanidateDomain object
        */
        [HttpGet]
        public JsonResult GetAssignedCandidates(Guid pollID)
        {
            pollRepository = new PollRepository();
            var assignedCandidates=pollRepository.GetAssignedCandidates(pollID);
            return Json(assignedCandidates,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AdminApproveOrIgnore(Poll poll)
        {
            _poll = new Poll();
            pollRepository = new PollRepository();
            _poll.ID = poll.ID;
            _poll.adminApproved = poll.adminApproved;

            bool status = pollRepository.AdminApproveOrIgnore(_poll);

            if (status) return Json(true, JsonRequestBehavior.AllowGet);

            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult DeletePoll(string id)
        {
            pollRepository = new PollRepository();
            Guid pollID = Guid.Parse(id);

            bool status = pollRepository.DeletePoll(pollID);

            if (status) return Json(true, JsonRequestBehavior.AllowGet);

            return Json(false, JsonRequestBehavior.AllowGet);
        }

    }
}