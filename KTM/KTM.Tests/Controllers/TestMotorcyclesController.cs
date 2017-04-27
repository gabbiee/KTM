//namespace KTM.Tests.Controllers
//{
//    using System.Collections.Generic;
//    using System.Linq;
//    using System.Runtime.CompilerServices;
//    using System.Web.Http;
//    using System.Web.Http.Results;
//    using System.Web.Mvc;
//    using App.Areas.Admin.Models.BindingModels;
//    using App.Controllers;
//    using AutoMapper;
//    using Data.UnitOfWork;
//    using Microsoft.VisualStudio.TestTools.UnitTesting;
//    using Models.EntityModels;
//    using Models.ViewModels;
//    using Services;
//    using Services.Interfaces;

//    [TestClass]
//    public class TestMotorcyclesController
//    {
//        private MotorcyclesController controller;
//        private  IKTMData data;
//       private IMotorcycleService service;
//        private List<Motorcycle> motors; 

//        private void ConfigureMapper()
//        {
//            Mapper.Initialize(exp =>
//            {
//                exp.CreateMap<Motorcycle, MotorcycleDetailsViewModel>();
//                exp.CreateMap<MotorcycleBindingModel, Motorcycle>();
//            });
//        }

//        [TestInitialize]
//        public void Initialize()
//        {
//            this.ConfigureMapper();

//            this.service = new MotorcycleService();
//            this.controller = new MotorcyclesController(this.data);
         

//        }

    

//        [TestMethod]
//        public void GetCarDetails()
//        {
//            var result = this.controller.Details()
//        }


//        [TestMethod]
//        public void GetValidCarById_ShouldReturnOk()
//        {
//            int id = 1;
//            //this.controller.Details(id);


//            var result = this.controller.Details(id) as OkNegotiatedContentResult<MotorcycleDetailsViewModel>;
//            Assert.IsNotNull(result);
//            //Ass
//        }

//    }
//}