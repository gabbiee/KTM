namespace KTM.Services
{
    using Data;

    public abstract class Service
    {
        public Service()
        {
            
            this.Context=new KTMContext();
        }

        protected KTMContext Context { get; }
    }
}
