namespace KTM.Services.Interfaces
{
    using System.Collections.Generic;
    using Models.EntityModels;
    using Models.ViewModels;

    public interface IMotorcycleService
   {
       IEnumerable<Motorcycle> GetAllMotorcycles(int page, int count);
        IEnumerable<ConciseMotorcycleViewModel> GetViewModels(IEnumerable<Motorcycle> motorcycles);
        Motorcycle GetMotorcycleById(int id);
        MotorcycleDetailsViewModel GetMotorcycleDetailsViewModel(Motorcycle motorcycle);
        MotorcycleDetailsViewModel GetDetails(int id);
   }
}
