namespace GiftBox.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using AutoMapper;

    using GiftBox.Data.Common.Models;
    using GiftBox.Services.Data.Contracts;
    using GiftBox.Web.Areas.Administration.ViewModels.Base;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using System.Web.Mvc;

    public abstract class KendoGridAdministrationController : AdminController
    {
        public KendoGridAdministrationController(IUsersService users, IDataService data)
           : base(users, data)
        {
        }

        protected abstract IEnumerable GetData();

        protected abstract T GetById<T>(object id) where T : class;

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var ads =
                this.GetData()
                .ToDataSourceResult(request);

            return this.Json(ads);
        }

        [NonAction]
        protected virtual T Create<T>(object model) where T : class
        {
            if (model != null && ModelState.IsValid)
            {
                var dbModel = Mapper.Map<T>(model);
                return dbModel;
            }

            return null;
        }

        [NonAction]
        protected virtual void Update<TModel, TViewModel>(TViewModel model, object id)
            where TModel : AuditInfo
            where TViewModel : AdministrationViewModel
        {
            if (model != null && ModelState.IsValid)
            {
                var dbModel = this.GetById<TModel>(id);
                Mapper.Map<TViewModel, TModel>(model, dbModel);
                model.ModifiedOn = dbModel.ModifiedOn;
            }
        }

        protected JsonResult GridOperation<T>(T model, [DataSourceRequest]DataSourceRequest request)
        {
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}