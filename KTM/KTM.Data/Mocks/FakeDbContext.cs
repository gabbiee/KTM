using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTM.Data.Mocks
{
    using System.Data.Entity;
    using Models.EntityModels;
    using Repositories;
   public class FakeDbContext: IKTMContext
    {
       public FakeDbContext()
       {
           this.Motorcycles=new FakeMotorcycleDbSet();
            this.Categories=new FakeCategoryDbSet();
            this.News=new FakeNewsDbSet();
            this.Reviews=new FakeDbSet<Review>();
           this.Ratings=new FakeDbSet<Rating>();

       }

       public DbSet<Motorcycle> Motorcycles { get; set; }
       public DbSet<Category> Categories { get; set; }
       public DbSet<Review> Reviews { get; set; }
       public DbSet<Rating> Ratings { get; set; }
       public DbSet<News> News { get; set; }
       public int SaveChanges()
       {

           return 0;
       }
    }
}
