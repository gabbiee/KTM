namespace KTM.Services
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using AutoMapper;
    using Data;
    using Data.UnitOfWork;
    using Models.EntityModels;
    using Models.ViewModels;

    public class MotorcycleService : Service
    {
       protected IKTMData data;
      //  private KTMContext Context;

        public MotorcycleService()
        {
           this.data = new KTMData();
        //  this.Context=new KTMContext();
            
        }

        //.All()
        public IEnumerable<Motorcycle> GetAllMotorcycles(int page, int count)
        {
            var motorcycles = this.data.Motorcycles.All()
                .OrderBy(g => g.Title)
                .Skip((page - 1) * count)
                .Take(count);

            return motorcycles;

        }

        public IEnumerable<ConciseMotorcycleViewModel> GetViewModels(IEnumerable<Motorcycle> motorcycles)
        {
            var model = Mapper.Map<IEnumerable<ConciseMotorcycleViewModel>>(motorcycles);

            return model;
        }

  
        public Motorcycle GetMotorcycleById(int id)
        {
            var motorcycle = this.data.Motorcycles.All()
                .Include(g => g.Category)
                .Include(g => g.Reviews)
                .Include(g => g.Ratings)
                .FirstOrDefault(g => g.Id == id);

            return motorcycle;

        }

        public MotorcycleDetailsViewModel GetMotorcycleDetailsViewModel(Motorcycle motorcycle)
        {
            var model = Mapper.Map<MotorcycleDetailsViewModel>(motorcycle);
            return model;
        }

        public MotorcycleDetailsViewModel GetDetails(int id)
        {
            var motorcycle = this.data.Motorcycles.All()
                .Include(g => g.Category)
                .Include(g => g.Reviews)
                .Include(g => g.Ratings)
                .FirstOrDefault(g => g.Id == id);

            if (motorcycle == null)
            {
                return null;
            }

            var vm = Mapper.Map<MotorcycleDetailsViewModel>(motorcycle);
            return vm;

        }
    }
}
