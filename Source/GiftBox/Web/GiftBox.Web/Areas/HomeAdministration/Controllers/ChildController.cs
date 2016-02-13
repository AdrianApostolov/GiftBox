
namespace GiftBox.Web.Areas.HomeAdministration.Controllers
{
    using System.Web.Mvc;

    using GiftBox.Web.Areas.HomeAdministration.ViewModels.Children;
    using GiftBox.Web.Controllers;
    using GiftBox.Data.Models;
    using GiftBox.Services.Data.Contracts;

    using AutoMapper;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    public class ChildController : BaseController
    {
        private readonly IChildService children;

        public ChildController(IUsersService users, IChildService children)
            :base(users)
        {
            this.children = children;
        }

        // GET: HomeAdministration/Child
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult CreateChild([DataSourceRequest]DataSourceRequest request, AddChildViewModel model)
        {
            if (this.ModelState.IsValid && model != null)
            {
                var dbModel = AutoMapper.Mapper.Map<Child>(model);
                dbModel.HomeId = this.CurrentUser.HomeId;
                this.children.Add(dbModel);

                return this.Json(new[] { model }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }

            return null;
        }
       
        public ActionResult UpdateChild([DataSourceRequest] DataSourceRequest request, EditChildViewModel model)
        {
            if (this.ModelState.IsValid && model != null)
            {
                var dbModel = this.children.GetById(model.Id);
                Mapper.Map(model, dbModel);
                this.children.Update(dbModel);

                return this.Json(new[] { model }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }

            return null;
        }

        public ActionResult DeleteChild([DataSourceRequest] DataSourceRequest request, DisplayChildViewModel model)
        {
            if (model != null)
            {
                this.children.Delete(model.Id);
                return this.Json(new[] { model }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }

            return null;
        }
    }
}