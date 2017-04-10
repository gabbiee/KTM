namespace KTM.Data.UnitOfWork
{
    using Repositories;
    using KTM.Models;

    public interface IKTMData
    {
        IRepository<User> Users { get; }

        IRepository<Motorcycle> Motorcycles { get; }

        IRepository<Category> Categories { get; }

        IRepository<Rating> Ratings { get; }

        IRepository<Review> Reviews { get; }

        IRepository<News> News { get; }

        void SaveChanges();
    }
}
