namespace KTM.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.UI.WebControls;
    using AutoMapper;
    using Data.UnitOfWork;
    using Models.ViewModels;

    public class CategoriesController : BaseController
    {
        public CategoriesController(IKTMData data)
            : base(data)
        {
        }

        public ActionResult All()
        {
            var categories = this.Data.Categories.All()
                .Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() });
            return this.PartialView(categories);
        }

        public ActionResult Details(int id)
        {
            var category = this.Data.Categories.Find(id);
            if (category == null)
            {
                return this.HttpNotFound("The requested category was not found in the system.");
            }

            var motorcycles = category.Motorcycles
                .OrderBy(g => g.Title);
            var model = Mapper.Map<IEnumerable<ConciseMotorcycleViewModel>>(motorcycles);
            ViewBag.Category = category.Name;
            return View(model);
        }
    }
}