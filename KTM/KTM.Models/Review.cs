namespace KTM.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Interfaces;

    public class Review
    {
        public int Id { get; set; }

        [Required]
        public DateTime CreationTime { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public virtual User Author { get; set; }

        [Required]
        public virtual Motorcycle Motorcycle { get; set; }
    }
}