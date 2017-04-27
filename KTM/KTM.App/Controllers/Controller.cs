namespace KTM.App.Controllers
{
  using Data.UnitOfWork;

    public abstract class Controller : System.Web.Mvc.Controller
    {
        protected static IKTMData data;

        protected Controller(IKTMData data)
        {
            this.Data = data;
        }

        protected Controller()
        {
            this.Data = data;
        }

        protected IKTMData Data { get; private set; }
    }
}