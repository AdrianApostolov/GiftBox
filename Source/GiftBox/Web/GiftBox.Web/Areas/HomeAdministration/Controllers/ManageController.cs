namespace GiftBox.Web.Areas.HomeAdministration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using GiftBox.Common;
    using GiftBox.Web.Controllers;
    using GiftBox.Services.Data.Contracts;
    using GiftBox.Web.Areas.HomeAdministration.ViewModels.Categories;
    using GiftBox.Web.Areas.HomeAdministration.ViewModels.Children;
    using GiftBox.Web.Areas.HomeAdministration.ViewModels.Gift;
    using GiftBox.Web.Areas.HomeAdministration.ViewModels.Needs;
    using GiftBox.Web.Infrastructure.Caching;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using AutoMapper.QueryableExtensions;

    [Authorize(Roles = GlobalConstants.HomeAdministrator)]
    public class ManageController : BaseController
    {
        private readonly IChildService children;
        private readonly IGiftService gifts;
        private readonly INeedService needs;
        private readonly ICategoryService categories;
        private readonly InMemoryCache cache;

        public ManageController(
            IUsersService users, 
            IChildService children, 
            IGiftService gifts, 
            ICategoryService categories, 
            INeedService needs,
            InMemoryCache cache)
            : base(users)
        {
            this.children = children;
            this.gifts = gifts;
            this.categories = categories;
            this.needs = needs;
            this.cache = cache;
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            if (this.CurrentUser.HomeId == 0)
            {
                return this.RedirectToAction("Create", "Institution");
            }

            this.PopulateDropDowns();
            return this.View();
        }

        public ActionResult ReadChild([DataSourceRequest]DataSourceRequest request)
        {
            var allChildren = this.children
                .GetAll(this.CurrentUser.HomeId).
                ProjectTo<DisplayChildViewModel>();

            return this.Json(allChildren.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ReadGifts([DataSourceRequest]DataSourceRequest request)
        {
            var allGifts = this.gifts
                .GetAllByHomeId(this.CurrentUser.HomeId)
                .ProjectTo<DisplayGiftViewModel>();

            return this.Json(allGifts.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ReadNeed([DataSourceRequest] DataSourceRequest request)
        {
            var allNeeds = this.needs
                .GetAllByHomeId(this.CurrentUser.HomeId)
                .ProjectTo<DisplayNeedViewModel>();

            return this.Json(allNeeds.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        private void PopulateDropDowns()
        {
            var childrenAll = this.children
                .GetAll(this.CurrentUser.HomeId)
                .ProjectTo<DisplayChildViewModel>();

            var eventCategory = this.cache.Get("eventsCategories", () => this.categories
                .GetEventCategories()
                .ProjectTo<DisplayEventCategoryViewModel>(), 60 * 60);

            var needsCategory = this.cache.Get("needsCategories", () => this.categories
                .GetNeedCategories()
                .ProjectTo<DisplayNeedCategoryViewModel>(), 60 * 60);

            this.ViewData["children"] = childrenAll;
            this.ViewData["defaultChild"] = childrenAll.Any() ? childrenAll.First() : null;

            this.ViewData["eventCategories"] = eventCategory;
            this.ViewData["defaultEventCategory"] = eventCategory.First();

            this.ViewData["needCategories"] = needsCategory;
            this.ViewData["defaultNeedCategory"] = needsCategory.First();
        }
    }
}