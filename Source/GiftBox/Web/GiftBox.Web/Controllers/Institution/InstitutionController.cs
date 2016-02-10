using AutoMapper.QueryableExtensions;

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


    public class InstitutionController : BaseController
    {
        private IDeletableEntityRepository<Home> homes;
        private IDeletableEntityRepository<Location> locations; 

        public InstitutionController(IUsersService users, IDeletableEntityRepository<Home> homes, 
                                    IDeletableEntityRepository<Location> locations)
            :base(users)
        {
            this.homes = homes;
            this.locations = locations;
        }

        // GET: Institution
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Details(int? id)
        {
            var home = this.homes
                .All()
                .Where(h => h.Id == id)
                .ProjectTo<DetailsInstitutionViewModel>()
                .FirstOrDefault();

            return View(home);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return this.View();
        }


        [HttpPost]
        [Authorize]
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
                this.homes.SaveChanges();

               return this.RedirectToAction("Details", new {id = home.Id});
            }
            return this.View(model);
        }
    }
}