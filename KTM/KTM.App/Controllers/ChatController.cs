namespace KTM.App.Controllers
{
    using System.Net;
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using Models.ViewModels;
    using Services;

    public class ChatController : Controller
    {
       

        private ChatService service;

        public ChatController(IKTMData data)
            :base(data)
        {
            this.service=new ChatService();
        }

        public ActionResult Index()
        {
         //   var currentUser = this.Data.Users.Find(this.User.Identity.GetUserId()).UserName;
            ChatViewModel vm = this.service.GetChatPage();
            if (vm == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            Response.StatusCode = 200;
            return View(vm);
        }
    }
}