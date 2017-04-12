namespace KTM.Models.ViewModels
{
    using System;

    public class ReviewViewModel
    {
        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime CreationTime { get; set; }

        public int MotorcycleId { get; set; }

        public string MotorcycleTitle { get; set; }
    }
}