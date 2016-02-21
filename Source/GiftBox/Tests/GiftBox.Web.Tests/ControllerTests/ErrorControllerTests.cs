namespace GiftBox.Web.Tests.ControllerTests
{
    using System.Web;
    using System.Web.Mvc;
    using GiftBox.Web.Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using TestStack.FluentMVCTesting;

    [TestClass]
    public class ErrorControllerTests
    {
        [TestMethod]
        public void ActionNotFoundShoudReturnPageNotFoundView()
        {
            var mockHttpContext = new Mock<HttpContextBase>();
            var response = new Mock<HttpResponseBase>();
            mockHttpContext.SetupGet(x => x.Response).Returns(response.Object);

            var controller = new ErrorController()
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = mockHttpContext.Object
                }
            };

            controller.WithCallTo(x => x.NotFound())
                .ShouldRenderView("NotFound");
        }
    }
}
