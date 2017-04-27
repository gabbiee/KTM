namespace KTM.App.Areas.Admin.Models.BindingModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class NewsBindingModel
    {
        public NewsBindingModel()
        {
            this.ImageUrls = new List<string>();
           
        }

        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "Content")]
        public string Content { get; set; }

        [Display(Name = "Images")]
        public IEnumerable<string> ImageUrls { get; set; }
    }
}