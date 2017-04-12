namespace KTM.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using Data.UnitOfWork;
    using Models.EntityModels;
    using Models.ViewModels;

    public class CategoriesService:Service
    {
        protected IKTMData data;

        public CategoriesService()
        {
            this.data = new KTMData();
        }


        public IQueryable<SelectListItem> GetAllCategories()
        {
            var categories = this.data.Categories.All()
                .Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() });

            return categories;
        }

        public Category GetCategoryById(int id)
        {
            var category = this.data.Categories.Find(id);

            return category;
        }

        public IEnumerable<Motorcycle> GetMotorcyclesFromCategory(Category category)
        {
            var motorcycles = category.Motorcycles
                .OrderBy(g => g.Title);

            return motorcycles;
        }

        public IEnumerable<ConciseMotorcycleViewModel> ConciseMotorcycleViewModels(IEnumerable<Motorcycle> motorcycles)
        {
            var model = Mapper.Map<IEnumerable<ConciseMotorcycleViewModel>>(motorcycles);
            return model;
        }

        public IEnumerable<ConciseMotorcycleViewModel> GetDetails(int id)
        {
            var category = this.data.Categories.Find(id);
            //   var category = this.service.GetCategoryById(id);
            if (category == null)
            {
                return null;
            }

            var motorcycles = category.Motorcycles
                            .OrderBy(g => g.Title);


            var model = Mapper.Map<IEnumerable<ConciseMotorcycleViewModel>>(motorcycles);
            return model;
            //ViewBag.Category = category.Name;
        }
    }
}
