namespace KTM.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using KTM.Models;

    public class KTMContext : IdentityDbContext<User>
    {
        public KTMContext()
            : base("KTMConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Motorcycle> Motorcycles { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<News> News { get; set; } 

        public static KTMContext Create()
        {
            return new KTMContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Motorcycle>()
                .HasMany(g => g.Ratings)
                .WithRequired(r => r.Motorcycle)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Motorcycle>()
                .HasMany(g => g.Reviews)
                .WithRequired(r => r.Motorcycle)
                .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}
