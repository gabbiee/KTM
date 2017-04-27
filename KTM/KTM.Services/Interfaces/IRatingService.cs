namespace KTM.Services.Interfaces
{
    using Models.EntityModels;

    public interface IRatingService
    {
        Motorcycle GetMotorcycleById(int id);
        Rating GetExistingRatings(Motorcycle motorcycle, User currentUser);
    }
}
