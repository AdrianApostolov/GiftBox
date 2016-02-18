namespace GiftBox.Web.Tests.ControllerTests
{
    using System.Collections.Generic;
    using System.Linq;
    
    using Moq;

    using PagedList;

    using TestStack.FluentMVCTesting;

    using GiftBox.Web.Controllers;
    using GiftBox.Web.Infrastructure.Mapping;
    using GiftBox.Data.Models;
    using GiftBox.Services.Data.Contracts;
    using GiftBox.Web.ViewModels.Institution;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HomeControllerTests
    {
        private AutoMapperConfig autoMapperConfig;

        public HomeControllerTests()
        {
            this.autoMapperConfig = new AutoMapperConfig(typeof(GiftController).Assembly);
            this.autoMapperConfig.Execute();
        }

        [TestMethod]
        public void IndexShoudWorkCorrectlyWithoutParameters()
        {
            var homeService = new Mock<IHomeService>();

            homeService.Setup(x => x.GetAll())
                .Returns(new List<Home>().AsQueryable());

            var controller = new HomeController(homeService.Object);
            controller.WithCallTo(x => x.Index(null,null,null))
                .ShouldRenderView("Index");
        }

        [TestMethod]
        public void IndexShoudWorkCorrectlyOnlyWithSearchParameter()
        {
            var homeService = new Mock<IHomeService>();

            homeService.Setup(x => x.GetAll())
                .Returns(new List<Home>().AsQueryable());

            var controller = new HomeController(homeService.Object);
            controller.WithCallTo(x => x.Index("someSearchInput", null, null))
                .ShouldRenderView("Index");
        }

        [TestMethod]
        public void IndexShoudWorkCorrectlyOnlyWithCurrentFilterParameter()
        {
            var homeService = new Mock<IHomeService>();

            homeService.Setup(x => x.GetAll())
                .Returns(new List<Home>().AsQueryable());

            var controller = new HomeController(homeService.Object);
            controller.WithCallTo(x => x.Index(null, "someFilter", null))
                .ShouldRenderView("Index");
        }

        [TestMethod]
        public void IndexShoudWorkCorrectlyOnlyWithPageParameter()
        {
            var homeService = new Mock<IHomeService>();

            homeService.Setup(x => x.GetAll())
                .Returns(new List<Home>().AsQueryable());

            var controller = new HomeController(homeService.Object);
            controller.WithCallTo(x => x.Index(null,null, 5))
                .ShouldRenderView("Index");
        }

        [TestMethod]
        public void IndexShoudWorkCorrectlyWithAllParameters()
        {
            var homeService = new Mock<IHomeService>();

            homeService.Setup(x => x.GetAll())
                .Returns(new List<Home>().AsQueryable());

            var controller = new HomeController(homeService.Object);
            controller.WithCallTo(x => x.Index("someInputSearch", "someFilter", 5))
                .ShouldRenderView("Index");
        }

        [TestMethod]
        public void IndexShoudRenderViewWithCorrectModelAndNoModelErrors()
        {
            var homeService = new Mock<IHomeService>();

            homeService.Setup(x => x.GetAll())
                .Returns(new List<Home>().AsQueryable());

            var controller = new HomeController(homeService.Object);
            controller.WithCallTo(x => x.Index("someInputSearch", "someFilter", 5))
                .ShouldRenderView("Index")
                .WithModel<IPagedList<DetailsInstitutionViewModel>>()
                .AndNoModelErrors();
        }

        [TestMethod]
        public void SearchShoudReturnNoPagesFoundContentIfThereAreNoHomes()
        {
            var homeService = new Mock<IHomeService>();

            homeService.Setup(x => x.GetAll())
                .Returns(new List<Home>().AsQueryable());

            var controller = new HomeController(homeService.Object);
            controller.WithCallTo(x => x.Search("someSearchInput"))
                .ShouldReturnContent("No pages found!");
        }
    }
}
