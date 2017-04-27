namespace KTM.Services.Interfaces
{
    using Data;

    public interface IService
    {
        KTMContext Context { get; }
    }
}
