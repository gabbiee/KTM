namespace KTM.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Models.EntityModels;
    using Models.ViewModels;

    public interface ICategoriesService
    {
        IQueryable<SelectListItem> GetAllCategories();
        Category GetCategoryById(int id);
        IEnumerable<Motorcycle> GetMotorcyclesFromCategory(Category category);
        IEnumerable<ConciseMotorcycleViewModel> ConciseMotorcycleViewModels(IEnumerable<Motorcycle> motorcycles);
        IEnumerable<ConciseMotorcycleViewModel> GetDetails(int id);
    }
}
