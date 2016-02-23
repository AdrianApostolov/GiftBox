using System.Data.Entity;
using GiftBox.Web.ViewModels.Gift;

namespace GiftBox.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using GiftBox.Common;
    using GiftBox.Data.Common.Repositories;
    using GiftBox.Data.Models;
    using GiftBox.Services.Data.Contracts;
    using GiftBox.Web.ViewModels.Institution;

    using AutoMapper.QueryableExtensions;

    public class InstitutionController : BaseController
    {
        private readonly IHomeService homes;
        private readonly IGiftService gifts;

        public InstitutionController(IUsersService users, IHomeService homes, IGiftService gifts)
            : base(users)
        {
            this.homes = homes;
            this.gifts = gifts;
        }
        
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
              throw new HttpException(404, "Incorrect route parameters, id cannot be null");
            }

            var home = this.homes
                .GetHomeById(id)
                .ProjectTo<DetailsInstitutionViewModel>()
                .FirstOrDefault();

            if (home == null)
            {
                throw new HttpException(404, "Home does not exist");
            }

            return this.View(home);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetChildrenGifts(int homeId)
        {
            var allGifts = this.gifts
                .GetAll()
                .Include(x => x.Child)
                .Where(x => x.Child.HomeId == homeId)
                .ProjectTo<GiftViewModel>();

            return this.PartialView(GlobalConstants.ListGiftsPartial, allGifts);
        }
    }
}