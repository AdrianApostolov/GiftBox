namespace GiftBox.Web.Tests.ControllerTests
{
    using System.Collections.Generic;
    using System.Linq;

    using GiftBox.Data.Models;
    using GiftBox.Services.Data.Contracts;
    using GiftBox.Web.Controllers;
    using GiftBox.Web.Infrastructure.Mapping;
    using GiftBox.Web.ViewModels.Gift;

    using Moq;

    using TestStack.FluentMVCTesting;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GiftControllerTests
    {
        [TestMethod]
        public void ActionAllShoudWorkCorrectly()
        {
            var autoMapperConfig = new AutoMapperConfig(typeof(GiftController).Assembly);
            autoMapperConfig.Execute();

            var userServerce = new Mock<IUsersService>();
            var giftService = new Mock<IGiftService>();

            giftService.Setup(x => x.GetAll())
                .Returns(new List<Gift>().AsQueryable());

            var controller = new GiftController(userServerce.Object, giftService.Object);
            controller.WithCallTo(x => x.All())
                .ShouldRenderView("All");
        }

        [TestMethod]
        public void ActionAllShoudRenderViewWithCorrectModelAndNoModelErrors()
        {
            var autoMapperConfig = new AutoMapperConfig(typeof(GiftController).Assembly);
            autoMapperConfig.Execute();

            var userServerce = new Mock<IUsersService>();
            var giftService = new Mock<IGiftService>();

            giftService.Setup(x => x.GetAll())
                .Returns(new List<Gift>().AsQueryable());

            var controller = new GiftController(userServerce.Object, giftService.Object);
            controller.WithCallTo(x => x.All())
                .ShouldRenderView("All")
                .WithModel<IEnumerable<GiftViewModel>>()
                .AndNoModelErrors();
        }
    }
}
