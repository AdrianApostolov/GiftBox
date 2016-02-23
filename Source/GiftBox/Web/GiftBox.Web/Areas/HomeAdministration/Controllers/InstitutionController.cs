namespace GiftBox.Web.Areas.HomeAdministration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using GiftBox.Common;
    using GiftBox.Data.Models;
    using GiftBox.Services.Data.Contracts;
    using GiftBox.Web.Controllers;
    using GiftBox.Web.ViewModels.Institution;
    using AutoMapper.QueryableExtensions;

    [Authorize(Roles = GlobalConstants.HomeAdministrator)]
    public class InstitutionController : BaseController
    {
        private IHomeService homes;
        private ILocationService locations;

        public InstitutionController(IUsersService users, IHomeService homes, ILocationService locations)
            : base(users)
        {
            this.homes = homes;
            this.locations = locations;
        }

        [HttpGet]
        public ActionResult Details()
        {

            if (this.CurrentUser.HomeId == 0)
            {
                return this.RedirectToAction("Create");
            }

            var home = this.homes
                .GetHomeById(this.CurrentUser.HomeId)
                .ProjectTo<DetailsInstitutionViewModel>()
                .FirstOrDefault();

            return this.View(home);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddInstitutionViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var home = AutoMapper.Mapper.Map<Home>(model);
                home.HomeAdministratorId = this.CurrentUser.Id;
                home.ImageUrl = GlobalConstants.DefaultHomeCoverPage;
                home.Location = new Location()
                {
                    Country = model.Location.Country,
                    City = model.Location.City,
                    Address = model.Location.Address,
                    PostCode = model.Location.PostCode
                };

                this.locations.Add(home.Location);
                this.homes.Add(home);
                this.CurrentUser.HomeId = home.Id;
                this.users.Update();
                this.TempData["Success"] = GlobalConstants.CreateHomeMessage;
                return this.RedirectToAction("Details", new { id = home.Id, area = string.Empty });
            }

            return this.View(model);
        }
    }
}