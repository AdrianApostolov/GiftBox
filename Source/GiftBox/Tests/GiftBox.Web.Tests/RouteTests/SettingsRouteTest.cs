using System.Web.Routing;
namespace GiftBox.Web.Tests.RouteTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GiftBox.Web.Controllers;
    using GiftBox.Web.Controllers.Account;
    using MvcRouteTester;

    [TestClass]
    public class SettingsRouteTest
    {
        [TestMethod]
        public void TestSettingsRouteById()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Settings/UpdateProfile/96887e35-0b24-4c91-b3c2-c3250f9ba94b";

            routeCollection
                .ShouldMap(urlForTest)
                .To<SettingsController>(x => x.UpdateProfile("96887e35-0b24-4c91-b3c2-c3250f9ba94b"));
        }

        [TestMethod]
        public void TestSettingsRouteByIdNull()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Settings/UpdateProfile/96887e35-0b24-4c91-b3c2-c3250f9ba94b";

            routeCollection
                .ShouldMap(urlForTest)
                .To<SettingsController>(x => x.UpdateProfile("96887e35-0b24-4c91-b3c2-c3250f9ba94b"));
        }
    }
}
