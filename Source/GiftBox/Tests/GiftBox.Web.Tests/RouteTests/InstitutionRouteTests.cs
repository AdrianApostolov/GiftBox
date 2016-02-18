namespace GiftBox.Web.Tests.RouteTests
{
    using System;
    using System.Web;
    using System.Web.Routing;
    using GiftBox.Web.Controllers;
    using MvcRouteTester;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class InstitutionRouteTests
    {
        [TestMethod]
        public void TestRouteById()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Institution/Details/1";

            routeCollection
                .ShouldMap(urlForTest)
                .To<InstitutionController>(x => x.Details(1));
        }

        [TestMethod]
        public void TestRouteByIdNull()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Institution/Details/";

            routeCollection
                .ShouldMap(urlForTest)
                .To<InstitutionController>(x => x.Details(null));
        }
    }
}
