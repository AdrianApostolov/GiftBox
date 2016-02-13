using AutoMapper.QueryableExtensions;
using GiftBox.Data.Models;
using GiftBox.Web.Areas.HomeAdministration.ViewModels.Children;
using GiftBox.Web.Areas.HomeAdministration.ViewModels.Gift;
using Kendo.Mvc.Extensions;

namespace GiftBox.Web.Areas.HomeAdministration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using GiftBox.Common;
    using GiftBox.Web.Controllers;
    using GiftBox.Services.Data.Contracts;

    using Kendo.Mvc.UI;

    [Authorize(Roles = GlobalConstants.HomeAdministrator)]
    public class ManageController : BaseController
    {
        private readonly IChildService children;
        private readonly IGiftService gifts;

        public ManageController(IUsersService users, IChildService children, IGiftService gifts)
            :base(users)
        {
            this.children = children;
            this.gifts = gifts;
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReadChild([DataSourceRequest]DataSourceRequest request)
        {
            var allChildren = this.children
                .GetAll(this.CurrentUser.HomeId).ProjectTo<DisplayChildViewModel>();

            return this.Json(allChildren.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ReadGifts([DataSourceRequest]DataSourceRequest request)
        {
            var allGifts = this.gifts
                .GetAll().ProjectTo<DisplayGiftViewModel>();

            return this.Json(allGifts.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        //private void PopulateDropDowns()
        //{
        //    var childrenAll = this.children.GetAll(this.CurrentUser.HomeId);
        //    this.ViewData["children"] = childrenAll;
        //}
    }
}