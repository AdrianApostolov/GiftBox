namespace GiftBox.Web.Tests.ControllerTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using GiftBox.Data.Models;
    using GiftBox.Services.Data.Contracts;
    using GiftBox.Web.Controllers;
    using GiftBox.Web.Infrastructure.Mapping;
    using GiftBox.Web.ViewModels.Need;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using TestStack.FluentMVCTesting;

    [TestClass]
    public class NeedControllerTests
    {
        private AutoMapperConfig autoMapperConfig;

        public NeedControllerTests()
        {
            this.autoMapperConfig = new AutoMapperConfig(typeof(GiftController).Assembly);
            this.autoMapperConfig.Execute();
        }

        [TestMethod]
        public void ActionAllShoudWorkCorrectlyWithoutParameters()
        {
            var usersService = new Mock<IUsersService>();
            var needsService = new Mock<INeedService>();

            needsService.Setup(x => x.GetAll())
                .Returns(new List<Need>().AsQueryable());

            var controller = new NeedController(usersService.Object, needsService.Object);
            controller.WithCallTo(x => x.All())
                .ShouldRenderView("All");
        }

        [TestMethod]
        public void NeedDetailsShoudWorkCorrectlyWithCorrenctIdParameter()
        {
            var usersService = new Mock<IUsersService>();
            var needsService = new Mock<INeedService>();

            needsService.Setup(x => x.GetAll())
                .Returns(new List<Need>() { new Need() { Id = 1 } }.AsQueryable());

            var controller = new NeedController(usersService.Object, needsService.Object);
            controller.WithCallTo(x => x.Details(1))
                .ShouldRenderView("Details");
        }

        [TestMethod]
        public void NeedDetailsShoudMapViewModelCorrectly()
        {
            var usersService = new Mock<IUsersService>();
            var needsService = new Mock<INeedService>();

            needsService.Setup(x => x.GetAll())
                .Returns(new List<Need>() { new Need() { Id = 1, Description = "Some description"} }.AsQueryable());

            var controller = new NeedController(usersService.Object, needsService.Object);
            controller.WithCallTo(x => x.Details(1))
                .ShouldRenderView("Details")
                .WithModel<NeedViewModel>(viewModel =>
                {
                    Assert.AreEqual(viewModel.Description, "Some description");
                });
        }

        [TestMethod]
        [ExpectedException(typeof(HttpException))]
        public void DetailShoudThrowHttpExceptionWhenNeedIdDoesNotExist()
        {
            var usersService = new Mock<IUsersService>();
            var needsService = new Mock<INeedService>();

            needsService.Setup(x => x.GetAll())
                .Returns(new List<Need>().AsQueryable());

            var controller = new NeedController(usersService.Object, needsService.Object);
            controller.WithCallTo(x => x.Details(It.IsAny<int>()))
                .ShouldRenderView("Details");
        }

        [TestMethod]
        [ExpectedException(typeof(HttpException))]
        public void DetailShoudThrowHttpExceptionWhenIdIsNull()
        {
            var usersService = new Mock<IUsersService>();
            var needsService = new Mock<INeedService>();

            needsService.Setup(x => x.GetAll())
                .Returns(new List<Need>().AsQueryable());

            var controller = new NeedController(usersService.Object, needsService.Object);
            controller.WithCallTo(x => x.Details(null))
                .ShouldRenderView("Details");
        }
    }
}
