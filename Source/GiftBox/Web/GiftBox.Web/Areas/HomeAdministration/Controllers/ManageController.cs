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

        public ManageController(IUsersService users, IChildService children, IGiftService gifts, ICategoryService categories, INeedService needs)
            : base(users)
        {
            this.children = children;
            this.gifts = gifts;
            this.categories = categories;
            this.needs = needs;
        }
        
        [HttpGet]
        public ActionResult Index()
        {
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
                .GetAll(this.CurrentUser.HomeId)
                .ProjectTo<DisplayNeedViewModel>();

            return this.Json(allNeeds.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        private void PopulateDropDowns()
        {
            var childrenAll = this.children
                .GetAll(this.CurrentUser.HomeId)
                .ProjectTo<DisplayChildViewModel>();

            var eventCategory = this.categories
                .GetEventCategories()
                .ProjectTo<DisplayEventCategoryViewModel>();

            var needsCategory = this.categories
                .GetNeedCategories()
                .ProjectTo<DisplayNeedCategoryViewModel>();

            this.ViewData["children"] = childrenAll;
            this.ViewData["defaultChild"] = childrenAll.Any() ? childrenAll.First() : null;

            this.ViewData["eventCategories"] = eventCategory;
            this.ViewData["defaultEventCategory"] = eventCategory.First();

            this.ViewData["needCategories"] = needsCategory;
            this.ViewData["defaultNeedCategory"] = needsCategory.First();
        }
    }
}