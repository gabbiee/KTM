namespace KTM.Services.Interfaces
{
    using Models.EntityModels;
    using Models.ViewModels;

    public interface IReviewService
    {
        Motorcycle GetMotorcycleById(int id);
        ConciseReviewViewModel GetConciseReviewViewModel(Review review);
        Review AddReview(string content, Motorcycle motorcycle, User currentUser);
    }
}
