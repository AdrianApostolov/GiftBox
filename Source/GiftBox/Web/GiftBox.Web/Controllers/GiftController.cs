namespace GiftBox.Web.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using GiftBox.Data.Models;
    using GiftBox.Common;
    using GiftBox.Web.ViewModels.Gift;
    using GiftBox.Services.Data.Contracts;
    using GiftBox.Web.Infrastructure.Populators;
    using GiftBox.Web.Views.Categories;

    public class GiftController : BaseController
    {
        private readonly IGiftService gifts;
        private readonly IDropDownListPopulator populator;

        public GiftController(IUsersService users, IGiftService gifts, IDropDownListPopulator populator)
            : base(users)
        {
            this.gifts = gifts;
            this.populator = populator;
        }

        [HttpGet]
        public ActionResult All()
        {
            var allGifts = this.gifts
                .GetAllNotClaimed()
                .ProjectTo<GiftViewModel>();

            return this.View(allGifts);
        }

        [HttpGet]
        public ActionResult DonateGift(int? id)
        {
            var currentGift = this.GetCurrentGift(id);
            var dispalyModel = AutoMapper.Mapper.Map<DetailsGiftViewModel>(currentGift);
            return this.View(dispalyModel);
        }

        [HttpPost]
        public ActionResult DonateGift(int id)
        {
            var currentGift = this.GetCurrentGift(id);

            currentGift.ClaimedById = this.CurrentUser.Id;
            currentGift.Claimed = true;
            this.gifts.Update(currentGift);
            this.TempData["Success"] = GlobalConstants.ClaimSuccessMessage;

            return this.RedirectToAction("DonateGift", new { id = currentGift.Id });
        }

        private Gift GetCurrentGift(int? id)
        {
            var currentGift = this.gifts
                .GetAll()
                .Include(x => x.Child)
                .Include(x => x.Child.Home)
                .Include(x => x.Child.Home.HomeAdministrator)
                .Include(x => x.Child.Home.Location)
                .FirstOrDefault(x => x.Id == id);

            return currentGift;
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetEventCategoriesPartial()
        {
            var viewModel = new ListEventCategoryViewModel
            {
                Categories = this.populator.GetEventCategories(),
            };

            return this.PartialView(GlobalConstants.EventsCategoriesListPartial, viewModel);
        }

        [HttpGet]
        public ActionResult FilterByEventCategory(int categoryId)
        {
            var allGiftsByCategory = this.gifts
               .GetAllNotClaimed()
               .ProjectTo<GiftViewModel>();

            if (categoryId > -1)
            {
                allGiftsByCategory = this.gifts
               .GetAllNotClaimed()
               .Where(x => x.EventCategoryId == categoryId)
               .ProjectTo<GiftViewModel>();
            }

            return this.PartialView(GlobalConstants.ListGiftsPartial, allGiftsByCategory);
        }

        [HttpGet]
        public ActionResult Search(string searchInput)
        {
            var allGifts = this.gifts.GetAllBySearchPattern(searchInput);
              
            if (!allGifts.Any())
            {
                return this.Content(GlobalConstants.NoPagesFound);
            }

            var viewModel = allGifts.ProjectTo<GiftViewModel>();

            return this.PartialView(GlobalConstants.ListGiftsPartial, viewModel);
        }
    }
}