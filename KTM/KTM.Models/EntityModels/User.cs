namespace KTM.Models.EntityModels
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        public User()
        {
            this.CreatedMotorcycles = new HashSet<Motorcycle>();
            this.Reviews = new HashSet<Review>();
            this.Ratings = new HashSet<Rating>();
        }

        public virtual ICollection<Motorcycle> CreatedMotorcycles { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
