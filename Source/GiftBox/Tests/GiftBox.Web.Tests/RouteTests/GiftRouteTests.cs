using System.Web.Routing;
using GiftBox.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcRouteTester;

namespace GiftBox.Web.Tests.RouteTests
{
    [TestClass]
    public class GiftRouteTests
    {
        [TestMethod]
        public void TestGiftDonateGiftByIdWithValue()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Gift/DonateGift/1";

            routeCollection
                .ShouldMap(urlForTest)
                .To<GiftController>(x => x.DonateGift(1));
        }

        [TestMethod]
        public void TestGiftDonateGiftByIdWithNull()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Gift/DonateGift/1";

            routeCollection
                .ShouldMap(urlForTest)
                .To<GiftController>(x => x.DonateGift(null));
        }
    }
}
