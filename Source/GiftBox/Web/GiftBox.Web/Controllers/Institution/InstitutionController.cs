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

        public InstitutionController(IUsersService users, IHomeService homes)
            : base(users)
        {
            this.homes = homes;
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
    }
}