namespace KTM.App.Controllers
{

    using System.Linq;
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
            //var motorcycles = this.Data.Motorcycles.All()
            //    .OrderBy(g => g.Title)
            //    .Skip((page - 1) * count)
            //    .Take(count);
            ViewBag.MaxPages = (this.Data.Motorcycles.All().Count() + count - 1) / count;
            ViewBag.CurrentPage = page;
           // var model = Mapper.Map<IEnumerable<ConciseMotorcycleViewModel>>(motorcycles);
             var vm = this.service.GetViewModels(motorcycles);

            return this.View(vm);
        }

        public ActionResult Details(int id)
        {
            //var motorcycle = this.Data.Motorcycles.All()
            //    .Include(g => g.Category)
            //    .Include(g => g.Reviews)
            //    .Include(g => g.Ratings)
            //    .FirstOrDefault(g => g.Id == id);

            //var motorcycle = this.service.GetMotorcycleById(id);
            //if (motorcycle == null)
            //{
            //    return this.HttpNotFound("The requested motorcycle was not found in the system.");
            //}
            //var model = this.service.GetMotorcycleDetailsViewModel(motorcycle);

            // var model = Mapper.Map<MotorcycleDetailsViewModel>(motorcycle);
            var vm = this.service.GetDetails(id);

            return this.View(vm);
        }

        //public ActionResult Add()
        //{
        //    return View();
        //}
    }
}