namespace GiftBox.Web.Tests.RouteTests
{
    using System.Web.Routing;
    using GiftBox.Web.Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MvcRouteTester;

    [TestClass]
    public class NeedRouteTests
    {
        [TestMethod]
        public void TestNeedDetailsByIdWithValue()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Need/Details/1";

            routeCollection
                .ShouldMap(urlForTest)
                .To<NeedController>(x => x.Details(1));
        }

        [TestMethod]
        public void TestNeedDetailsByIdWithNull()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Need/Details/";

            routeCollection
                .ShouldMap(urlForTest)
                .To<NeedController>(x => x.Details(null));
        }
    }
}
