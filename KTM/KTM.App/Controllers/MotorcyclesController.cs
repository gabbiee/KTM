namespace KTM.App.Controllers
{

    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using Services;

    public class MotorcyclesController : Controller
    {
        private MotorcycleService service;
       

        public MotorcyclesController(IKTMData data)
             : base(data)
        {
            this.service=new MotorcycleService();
            
        }

      

        public ActionResult Index(int page = 1, int count = 5)
        {

              var motorcycles = this.service.GetAllMotorcycles(page, count);
         
            ViewBag.MaxPages = (this.Data.Motorcycles.All().Count() + count - 1) / count;
            ViewBag.CurrentPage = page;
            var vm = this.service.GetViewModels(motorcycles);
            if (vm == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            Response.StatusCode = 200;
            return this.View(vm);
        }

        public ActionResult Details(int id)
        {
           
            var vm = this.service.GetDetails(id);
            if (vm == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            Response.StatusCode = 200;
            return this.View(vm);
        }

      
    }
}