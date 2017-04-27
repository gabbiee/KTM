using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTM.Data
{
    using System.Data.Entity;
    using System.Security.Cryptography.X509Certificates;
    using Models.EntityModels;

    public  interface IKTMContext
    {
        DbSet<Motorcycle> Motorcycles { get; set; }
        DbSet<Category> Categories { get; set; }

        DbSet<Review> Reviews { get; set; }

        DbSet<Rating> Ratings { get; set; }

        DbSet<News> News { get; set; }

        int SaveChanges();
    }
}
