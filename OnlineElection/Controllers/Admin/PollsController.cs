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
        PersonRepository personRepository;
        PollRepository pollRepository;
        FacultyRepository facultyRepository;

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

        [HttpPost]
        public JsonResult CreatePoll(PollModel polls)
        {
            pollRepository = new PollRepository();
            pollRepository.InsertPolls(polls);
            return Json(null,null);
        }


        /**
          * @desc Give all the Batch details for the relevent Faculty/Faculties
          * @param Faculty ID/IDs
          * @return Json - Batch Details or success/Failure
        */

        public JsonResult GetBatches(Guid[] ids)
        {

            facultyRepository = new FacultyRepository();
            var batches=facultyRepository.GetBatches(ids);

            return Json(batches,JsonRequestBehavior.AllowGet);
        }

    }
}