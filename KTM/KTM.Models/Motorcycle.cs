namespace KTM.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Interfaces;

    public class Motorcycle
    {
        public Motorcycle()
        {
            this.ImageUrls = new HashSet<ImageUrl>();
            this.Ratings = new HashSet<Rating>();
            this.Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Engine { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public virtual User Author { get; set; }

        public virtual ICollection<ImageUrl> ImageUrls { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
