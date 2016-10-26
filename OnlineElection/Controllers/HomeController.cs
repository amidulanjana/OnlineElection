using OnlineElection.BLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineElection.Controllers
{
    public class HomeController : Controller
    {
        MessegeRepository _messageRepository = new MessegeRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }




        public ActionResult GetMessages()
        {
            string user = "21781DD9-4A1C-4DFB-933F-21633B94B61B";

            return PartialView("~/ViewsAdmin/Shared/_MessagesList.cshtml", _messageRepository.GetAllMessages(user));
        }

        public ActionResult GetNotifications()
        {
            string user = "21781DD9-4A1C-4DFB-933F-21633B94B61B";

            return PartialView("~/ViewsAdmin/Shared/_MessagesListNotifications.cshtml", _messageRepository.GetAllMessagesNew(user));
        }

    }
}