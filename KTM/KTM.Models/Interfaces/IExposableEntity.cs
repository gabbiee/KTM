namespace KTM.Models.Interfaces
{
    using System.Collections.Generic;

    public interface IExposableEntity
    {

       ICollection<Review> Reviews { get; set; }
        ICollection<ImageUrl> ImageUrls { get; set; }

    }
}
