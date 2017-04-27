namespace KTM.App.Controllers
{
     using System.Collections.Generic;
    using System.Net;
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using Models.ViewModels;
    using Services;

    public class CategoriesController : Controller
    {
        private CategoriesService service;

        public CategoriesController(IKTMData data)
            : base(data)
        {
            this.service=new CategoriesService();
        }

        public ActionResult All()
        {
      
            var vm = this.service.GetAllCategories();
            if (vm == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            Response.StatusCode = 200;
            return this.PartialView(vm);
        }

    
        public ActionResult Details(int id)
        {

       
          var category = this.service.GetCategoryById(id);
           if (category == null)
           {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }


            IEnumerable<ConciseMotorcycleViewModel> vm = this.service.GetDetails(id);
            if (vm == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            ViewBag.Category = category.Name;
            Response.StatusCode = 200;
            return View(vm);
        }
    }
}