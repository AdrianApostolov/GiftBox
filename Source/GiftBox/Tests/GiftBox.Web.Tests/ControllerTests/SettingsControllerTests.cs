using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GiftBox.Data.Models;
using GiftBox.Services.Data.Contracts;
using GiftBox.Web.Areas.HomeAdministration.Controllers;
using GiftBox.Web.Controllers;
using GiftBox.Web.Controllers.Account;
using GiftBox.Web.Infrastructure.Mapping;
using Kendo.Mvc.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestStack.FluentMVCTesting;
using ManageController = GiftBox.Web.Areas.HomeAdministration.Controllers.ManageController;

namespace GiftBox.Web.Tests.ControllerTests
{
    [TestClass]
    public class SettingsControllerTests
    {
        [TestMethod]
        [ExpectedException(typeof(HttpException))]
        public void UserDetailShoudThrowHttpExceptionWhenHomeIdDoesNotExist()
        {
            var autoMapperConfig = new AutoMapperConfig(typeof(GiftController).Assembly);
            autoMapperConfig.Execute();

            var userServerce = new Mock<IUsersService>();

            userServerce.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new User());

            var controller = new SettingsController(userServerce.Object);
            controller.WithCallTo(x => x.UpdateProfile("123141241"));
        }

        [TestMethod]
        [ExpectedException(typeof(HttpException))]
        public void UserDetailShoudThrowHttpExceptionWhenUserDoesNotExist()
        {
            var autoMapperConfig = new AutoMapperConfig(typeof(GiftController).Assembly);
            autoMapperConfig.Execute();

            var userServerce = new Mock<IUsersService>();

            userServerce.Setup(x => x.GetById(It.IsAny<string>()))
                .Returns(new User());

            var controller = new SettingsController(userServerce.Object);
            controller.WithCallTo(x => x.UpdateProfile(It.IsAny<string>()));
        }

        [TestMethod]
        public void UserDetailShoudWhenIdIsPassedCorrect()
        {
            var autoMapperConfig = new AutoMapperConfig(typeof(GiftController).Assembly);
            autoMapperConfig.Execute();

            var userServerce = new Mock<IUsersService>();

            userServerce.Setup(x => x.GetById("1"))
                .Returns(new User());

            var controller = new SettingsController(userServerce.Object);
            controller.WithCallTo(x => x.UpdateProfile("1"))
                .ShouldRenderView("UpdateProfile");
        }
    }
}
