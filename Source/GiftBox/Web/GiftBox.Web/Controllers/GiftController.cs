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

    public class GiftController : BaseController
    {
        private readonly IGiftService gifts;

        public GiftController(IUsersService users, IGiftService gifts)
            : base(users)
        {
            this.gifts = gifts;
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
    }
}