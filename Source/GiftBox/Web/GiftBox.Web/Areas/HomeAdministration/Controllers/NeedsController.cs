

using AutoMapper;

namespace GiftBox.Web.Areas.HomeAdministration.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using GiftBox.Data.Models;
    using GiftBox.Services.Data.Contracts;
    using GiftBox.Web.Areas.HomeAdministration.ViewModels.Needs;
    using GiftBox.Web.Controllers;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    public class NeedsController : BaseController
    {
        private readonly INeedService needs;

        public NeedsController(IUsersService users,INeedService needs)
            :base(users)
        {
            this.needs = needs;
        }

        // GET: HomeAdministration/Needs
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateNeed([DataSourceRequest]DataSourceRequest request, IEnumerable<AddNeedViewModel> models)
        {
            var result = new List<AddNeedViewModel>();
            if (this.ModelState.IsValid && models != null)
            {
                foreach (var model in models)
                {
                    var dbModel = AutoMapper.Mapper.Map<Need>(model);
                    dbModel.HomeId = this.CurrentUser.HomeId;
                    this.needs.Add(dbModel);
                    result.Add(model);
                }

                return this.Json(new[] { result }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }

            return null;
        }

        public ActionResult UpdateNeed([DataSourceRequest]DataSourceRequest request, IEnumerable<EditNeedViewModel> models)
        {
            if (this.ModelState.IsValid && models != null)
            {
                foreach (var model in models)
                {
                    var dbModel = this.needs.GetById(model.Id);
                    Mapper.Map(model, dbModel);
                    this.needs.Update(dbModel);
                    return this.Json(new[] { model }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
                }
            }

            return null;
        }

        public ActionResult DeleteNeed([DataSourceRequest] DataSourceRequest request, IEnumerable<DisplayNeedViewModel> models)
        {
            var result = new List<DisplayNeedViewModel>();
            if (models != null)
            {
                foreach (var model in models)
                {
                    this.needs.Delete(model.Id);
                    result.Add(model);
                }
                return this.Json(new[] { result }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }

            return null;
        }
    }
}