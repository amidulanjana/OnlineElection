using OnlineElection.BLL.Repository;
using OnlineElection.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineElection.Controllers.Admin
{
    public class MessegingController : Controller
    {

        BatchRepository _batchRepository = new BatchRepository();
        MessegeRepository _messageRepository = new MessegeRepository();

        // GET: Messeging
        public ActionResult Index()
        {

            ViewBag.FOCbatchDetails = _batchRepository.GetFOCBatchDetails();
            
            ViewBag.FOBbatchDetails = _batchRepository.GetFOBBatchDetails();

            ViewBag.FOEbatchDetails = _batchRepository.GetFOEBatchDetails();

            //get the user ID
            string user = "21781DD9-4A1C-4DFB-933F-21633B94B61B";
            ViewBag.unreadCount = _messageRepository.unreadCount(user);
            return View("~/ViewsAdmin/Messeging/Index.cshtml");
        }

        public ActionResult Messeges()
        {

            
            Session["messID"] = "1";
            if (Session["messID"] == null)
            {
                Session["messID"] = "null";
            }

            string messID = (string)Session["messID"];
            ViewBag.MessegeID = messID;


            //get the user ID
            string user = "21781DD9-4A1C-4DFB-933F-21633B94B61B";
            ViewBag.unreadCount = _messageRepository.unreadCount(user);
            return View("~/ViewsAdmin/Messeging/Messeges.cshtml");
        }

        // POST: Messeging/SendMessege
        [HttpPost]
        public ActionResult SendMessege(FormCollection collection)
        {
            try
            {
                List<BatchDetailsViewModel> batchFOC = new List<BatchDetailsViewModel>();
                List<BatchDetailsViewModel> batchFOB = new List<BatchDetailsViewModel>();
                List<BatchDetailsViewModel> batchFOE = new List<BatchDetailsViewModel>();

                List<string> trueVal = new List<string>();

                string foc = collection["foc"];

                string fob = collection["fob"];

                string foe = collection["foe"];

                batchFOC = _batchRepository.GetFOCBatchDetails().ToList();
                batchFOB = _batchRepository.GetFOBBatchDetails().ToList();
                batchFOE = _batchRepository.GetFOEBatchDetails().ToList();

                if (foc != "on")
                {
                    foreach (var item in batchFOC)
                    {
                        string valB = collection[item.batch_ID];
                        if (valB == "on")
                        {
                            trueVal.Add(item.batch_ID);
                        }
                    }
                }
                else
                {
                    trueVal.Add("foc");
                }

                if (fob != "on")
                {
                    foreach (var item in batchFOB)
                    {
                        string valB = collection[item.batch_ID];
                        if (valB == "on")
                        {
                            trueVal.Add(item.batch_ID);
                        }
                    }
                }
                else
                {
                    trueVal.Add("fob");
                }


                if (foe != "on")
                {
                    foreach (var item in batchFOE)
                    {
                        string valB = collection[item.batch_ID];
                        if (valB == "on")
                        {
                            trueVal.Add(item.batch_ID);
                        }
                    }
                }
                else
                {
                    trueVal.Add("foe");
                }



                string subject = collection["txtSubject"];
                string body = collection["TextAreaInput"];
               
               bool answer = _batchRepository.sendMessege(trueVal,subject,body);



                //These are for the Index Needed
                    ViewBag.FOCbatchDetails = _batchRepository.GetFOCBatchDetails();

                    ViewBag.FOBbatchDetails = _batchRepository.GetFOBBatchDetails();

                    ViewBag.FOEbatchDetails = _batchRepository.GetFOEBatchDetails();

                return View("~/ViewsAdmin/Messeging/Index.cshtml");
            }
            catch(Exception e)
            {
                return View("~/ViewsAdmin/Messeging/Index.cshtml");
            }
        }


        public ActionResult GetMessView()
        {
            string user = "21781DD9-4A1C-4DFB-933F-21633B94B61B";
            return PartialView("~/ViewsAdmin/Shared/_MessgingInterfaceMessegeList.cshtml", _messageRepository.GetAllMessages(user));
        }


        public ActionResult GetMessConvView(int id)
        {
            //int id = 4;
            return PartialView("~/ViewsAdmin/Shared/_MessagesConversations.cshtml", _messageRepository.GetConversation(id));
        }

    }
}
