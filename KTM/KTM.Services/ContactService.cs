namespace KTM.Services
{
    using Data;
    using Data.UnitOfWork;
    using Interfaces;
    using Models.ViewModels;

    public class ContactService:Service,IContactService
    {
        protected IKTMData data;

        public ContactService()
        {
            this.data = new KTMData();
        }

        public ContactPageViewModel GetContactPageVm()
        {
            var model = new ContactPageViewModel()
            {
                Address = "KTM Sportmotorcycle GmbH" +"<br/>"+
                    "Betriebsgebiet Süd" + "<br/>" +
                    "Stallhofnerstraße 3" + "<br/>" +
                    "A - 5230 Mattighofen",
                Phone = "031 035 0090",
                Email = "info@ktm.com"
            };

            return model;
        }

    
    }
}
