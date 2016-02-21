using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GiftBox.Data.Models;
using GiftBox.Services.Data.Contracts;
using GiftBox.Web.Controllers;
using GiftBox.Web.Infrastructure.Mapping;
using Moq;
using TestStack.FluentMVCTesting;

namespace GiftBox.Web.Tests.ControllerTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    [TestClass]
    public class InstitutionControllerTests
    {
        [TestMethod]
        [ExpectedException(typeof(HttpException))]
        public void DetailShoudThrowHttpExceptionWhenHomeIdDoesNotExist()
        {
            var autoMapperConfig = new AutoMapperConfig(typeof(GiftController).Assembly);
            autoMapperConfig.Execute();

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
            var autoMapperConfig = new AutoMapperConfig(typeof(GiftController).Assembly);
            autoMapperConfig.Execute();

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
