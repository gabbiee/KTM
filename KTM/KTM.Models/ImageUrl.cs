namespace KTM.Models
{
    public class ImageUrl
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public virtual Motorcycle Motorcycle { get; set; }
    }
}