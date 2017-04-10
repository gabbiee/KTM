namespace KTM.App.Areas.Admin.Models.BindingModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class MotorcycleBindingModel
    {
        public MotorcycleBindingModel()
        {
            this.ImageUrls = new List<string>();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        [Display(Name = "System requirements")]
        public string SystemRequirements { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Images")]
        public IEnumerable<string> ImageUrls { get; set; }
    }
}