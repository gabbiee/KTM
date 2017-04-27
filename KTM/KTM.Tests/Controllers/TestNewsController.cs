namespace KTM.Tests.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Results;
    using App.Areas.Admin.Models.BindingModels;
    using App.Controllers;
    using AutoMapper;
    using Data;
    using Data.Mocks;
    using Data.UnitOfWork;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.EntityModels;
    using Models.ViewModels;
    using Services;
    using Services.Interfaces;
    using TestStack.FluentMVCTesting;

    [TestClass]
    public class TestNewsController
    {
        private NewsController _controller;
        private INewsService _service;
        private IKTMContext _context;
        private IKTMData _data;
        private List<News> news;

        private void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<News, NewsDetailsViewModel>();
                expression.CreateMap<NewsBindingModel, News>();
            });
        }


        [TestInitialize]
        public void Initialize()
        {
            this.ConfigureMapper();
            this.news = new List<News>()
            {
                new News()
                {
                    Id = 1,
                    Title = "New Race",
                    Content = "More info soon",
                       ImageUrls = new[] {
                            new ImageUrl()
                            {
                                Url = "https://drive.google.com/uc?id=0ByuTp8DIw-KvaUtrdl9JT3BYRFk"
                            }}

                },  new News()
                {
                    Id = 1,
                    Title = "New Equipment",
                    Content = "More info soon",
                       ImageUrls = new[] {
                            new ImageUrl()
                            {
                                Url = "https://drive.google.com/uc?id=0ByuTp8DIw-KvaUtrdl9JT3BYRFk"
                            }}

                }

            };

            this._context = new FakeDbContext();
            foreach (var n in news)
            {
                this._context.News.Add(n);
            }

            HttpConfiguration config = new HttpConfiguration();
            this._service = new NewsService();
            this._controller = new NewsController(_data);
            this._controller.Configuration = config;
        }
        //[TestMethod]
        //public void GetValidNewsById_ShouldReturnGivenNews()
        //{
        //    var data = this._controller.Details(1) as OkNegotiatedContentResult<NewsDetailsViewModel>;
        //    Assert.AreEqual(20, data.Content.Price);
        //    Assert.AreEqual("Volga", data.Content.Name);
        //}

        //[TestMethod]
        //public void Details_NullParameter_BadRequest()
        //{

        //    //controller.WithCallTo(c => c.Details(null))
        //    //    .ShouldGiveHttpStatus(HttpStatusCode.NotFound);
        //}
    }
}
