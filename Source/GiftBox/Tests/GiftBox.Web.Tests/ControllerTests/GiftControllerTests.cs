using GiftBox.Common;
using GiftBox.Web.Infrastructure.Populators;

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
        private AutoMapperConfig autoMapperConfig;

        public GiftControllerTests()
        {
            this.autoMapperConfig = new AutoMapperConfig(typeof(GiftController).Assembly);
            this.autoMapperConfig.Execute();
        }

        [TestMethod]
        public void ActionAllShoudWorkCorrectly()
        {
            var userServerce = new Mock<IUsersService>();
            var giftService = new Mock<IGiftService>();
            var dropDownPopupator = new Mock<IDropDownListPopulator>();

            giftService.Setup(x => x.GetAll())
                .Returns(new List<Gift>().AsQueryable());

            var controller = new GiftController(userServerce.Object, giftService.Object, dropDownPopupator.Object);
            controller.WithCallTo(x => x.All())
                .ShouldRenderView("All");
        }

        [TestMethod]
        public void ActionAllShoudRenderViewWithCorrectModelAndNoModelErrors()
        {
            var userServerce = new Mock<IUsersService>();
            var giftService = new Mock<IGiftService>();
            var dropDownPopupator = new Mock<IDropDownListPopulator>();

            giftService.Setup(x => x.GetAll())
                .Returns(new List<Gift>().AsQueryable());

            var controller = new GiftController(userServerce.Object, giftService.Object, dropDownPopupator.Object);
            controller.WithCallTo(x => x.All())
                .ShouldRenderView("All")
                .WithModel<IEnumerable<GiftViewModel>>()
                .AndNoModelErrors();
        }

        [TestMethod]
        public void ActionFilterByEventCategoryShoudReturnCorrectlyPartialView()
        {
            var userServerce = new Mock<IUsersService>();
            var giftService = new Mock<IGiftService>();
            var dropDownPopupator = new Mock<IDropDownListPopulator>();

            giftService.Setup(x => x.GetAllNotClaimed())
                .Returns(new List<Gift>().AsQueryable());

            var controller = new GiftController(userServerce.Object, giftService.Object, dropDownPopupator.Object);
            controller.WithCallTo(x => x.FilterByEventCategory(It.IsAny<int>()))
                .ShouldRenderPartialView(GlobalConstants.ListGiftsPartial);
        }

        [TestMethod]
        public void ActionFilterByEventCategoryRenderPartialViewWithCorrectModelAndNoModelErrors()
        {
            var userServerce = new Mock<IUsersService>();
            var giftService = new Mock<IGiftService>();
            var dropDownPopupator = new Mock<IDropDownListPopulator>();

            giftService.Setup(x => x.GetAllNotClaimed())
                .Returns(new List<Gift>().AsQueryable());

            var controller = new GiftController(userServerce.Object, giftService.Object, dropDownPopupator.Object);
            controller.WithCallTo(x => x.FilterByEventCategory(It.IsAny<int>()))
                .ShouldRenderPartialView(GlobalConstants.ListGiftsPartial)
                .WithModel<IEnumerable<GiftViewModel>>()
                .AndNoModelErrors();
        }
    }
}