namespace KTM.Services
{
    using Data;
    using Interfaces;

    public abstract class Service:IService
    {
        public Service()
        {
            
            this.Context=new KTMContext();
        }

        public KTMContext Context { get; }
    }
}
