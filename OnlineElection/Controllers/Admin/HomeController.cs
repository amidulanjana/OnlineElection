using System.Web.Mvc;
using OnlineElection.BLL.Repository;

namespace OnlineElection.Controllers.Admin
{
    public class HomeController : Controller
    {
        MessegeRepository _messageRepository = new MessegeRepository();
        PollRepository _pollRepository = new PollRepository();

        // GET: Home
        public ActionResult Index()
        {
            //take the current user ID
            string user = "21781DD9-4A1C-4DFB-933F-21633B94B61B";

            ViewBag.unreadCount = _messageRepository.unreadCount(user);
            return View("~/ViewsAdmin/Home/Index.cshtml");
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

        public ActionResult PollResults()
        {
            ViewBag.CompletedPollsList = _pollRepository.GetCompletedPolls();
            ViewBag.NotStartedPollsList = _pollRepository.GetNotStartedPolls();
            ViewBag.RunningPollsList = _pollRepository.GetRunningPolls();

            return View("~/ViewsAdmin/Home/PollResults.cshtml");
        }

    }
}