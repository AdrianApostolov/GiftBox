namespace GiftBox.Web.Tests.ControllerTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using GiftBox.Data.Models;
    using GiftBox.Services.Data.Contracts;
    using GiftBox.Web.Controllers;
    using GiftBox.Web.Infrastructure.Mapping;
    using GiftBox.Web.ViewModels.Institution;
    using Moq;
    using TestStack.FluentMVCTesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class InstitutionControllerTests
    {
        private AutoMapperConfig autoMapperConfig;

        public InstitutionControllerTests()
        {
            this.autoMapperConfig = new AutoMapperConfig(typeof(GiftController).Assembly);
            this.autoMapperConfig.Execute();
        }

        [TestMethod]
        public void HomeDetailsShoudWorkCorrectlyWithCorrenctIdParameter()
        {
            var userServerce = new Mock<IUsersService>();
            var homeService = new Mock<IHomeService>();
            var giftService = new Mock<IGiftService>();

            homeService.Setup(x => x.GetHomeById(1))
                .Returns(new List<Home>() {new Home()
                {
                    Id = 1,
                    Location = new Location(),
                    HomeAdministrator = new User(),
                    Children = new List<Child>()
                } }.AsQueryable());

            var controller = new InstitutionController(userServerce.Object, homeService.Object, giftService.Object);
            controller.WithCallTo(x => x.Details(1))
                .ShouldRenderView("Details");
        }

        [TestMethod]
        public void HomeDetailsShoudMapViewModelCorrectly()
        {
            var userServerce = new Mock<IUsersService>();
            var homeService = new Mock<IHomeService>();
            var giftService = new Mock<IGiftService>();

            homeService.Setup(x => x.GetHomeById(1))
                .Returns(new List<Home>() {new Home()
                {
                    Id = 1,
                    Name = "THEHOME",
                    Location = new Location(),
                    HomeAdministrator = new User(),
                    Children = new List<Child>()
                } }.AsQueryable());

            var controller = new InstitutionController(userServerce.Object, homeService.Object, giftService.Object);
            controller.WithCallTo(x => x.Details(1))
                .ShouldRenderView("Details")
                .WithModel<DetailsInstitutionViewModel>(viewModel =>
                {
                    Assert.AreEqual(viewModel.Name, "THEHOME");
                });
        }


        [TestMethod]
        [ExpectedException(typeof(HttpException))]
        public void DetailShoudThrowHttpExceptionWhenHomeIdDoesNotExist()
        {
            var userServerce = new Mock<IUsersService>();
            var homeService = new Mock<IHomeService>();
            var giftService = new Mock<IGiftService>();

            homeService.Setup(x => x.GetHomeById(It.IsAny<int>()))
                .Returns(new List<Home>().AsQueryable());

            var controller = new InstitutionController(userServerce.Object, homeService.Object, giftService.Object);
            controller.WithCallTo(x => x.Details(It.IsAny<int>()))
                .ShouldRenderView("Details");
        }

        [TestMethod]
        [ExpectedException(typeof(HttpException))]
        public void DetailShoudThrowHttpExceptionWhenIdIsNull()
        {
            var userServerce = new Mock<IUsersService>();
            var homeService = new Mock<IHomeService>();
            var giftService = new Mock<IGiftService>();

            homeService.Setup(x => x.GetHomeById(null))
                .Returns(new List<Home>().AsQueryable());

            var controller = new InstitutionController(userServerce.Object, homeService.Object, giftService.Object);
            controller.WithCallTo(x => x.Details(null))
                .ShouldRenderView("Details");
        }
    }
}
