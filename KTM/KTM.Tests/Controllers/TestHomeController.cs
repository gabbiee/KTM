namespace KTM.Tests.Controllers
{
    using System.Web.Mvc;
    using App.Controllers;
   
    using Data.UnitOfWork;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TestStack.FluentMVCTesting;

    [TestClass]
    public class TestHomeController
    {
        //private IKTMData data;
        //private HomeController controller;

        //private data = new KTMData();
        //private controller = new HomeController(data);

        //[TestInitialize]
        //public void Initialize()
        //{
        //    this.ConfigureMapper();
        //    this.controller = new HomeController(data);

        //}

        //private void ConfigureMapper()
        //{
        //    Mapper.Initialize(exp =>
        //    {
        //        exp.CreateMap<>()
        //    });
        //}


        [TestMethod]
        public void Index_ShouldPass()
        {
            var data = new KTMData();
            var controller = new HomeController(data);

            controller.WithCallTo(c => c.Index()).ShouldRenderDefaultView();
        }
    }
}
