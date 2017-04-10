namespace KTM.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Interfaces;

    public class News
    {
        public News()
        {
            this.ImageUrls=new HashSet<ImageUrl>();
            //this.Reviews=new HashSet<Review>();
        }
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

      //  public string  ImageUrl {get;set;}

       // public virtual ICollection<Review> Comments { get; set; }
     //public virtual ICollection<Review> Reviews { get; set; }
        public virtual  ICollection<ImageUrl> ImageUrls { get; set; }
    }
}
