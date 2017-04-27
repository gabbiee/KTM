namespace KTM.Models.EntityModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class News
    {
        public News()
        {
            this.ImageUrls = new HashSet<ImageUrl>();

        }
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        
        public virtual ICollection<ImageUrl> ImageUrls { get; set; }
    }
}
