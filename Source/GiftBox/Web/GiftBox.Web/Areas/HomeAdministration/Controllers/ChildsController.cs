using System.Collections.Generic;
using System.Linq;

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

    public class ChildsController : BaseController
    {
        private readonly IChildService children;

        public ChildsController(IUsersService users, IChildService children)
            : base(users)
        {
            this.children = children;
        }

        public ActionResult CreateChild([DataSourceRequest]DataSourceRequest request, IEnumerable<AddChildViewModel> models)
        {
            var result = new List<AddChildViewModel>();
            if (this.ModelState.IsValid && models != null)
            {
                foreach (var model in models)
                {
                    var dbModel = AutoMapper.Mapper.Map<Child>(model);
                    dbModel.HomeId = this.CurrentUser.HomeId;
                    this.children.Add(dbModel);
                    result.Add(model);
                }

                return this.Json(new[] { result }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }

            return null;
        }
       
        public ActionResult UpdateChild([DataSourceRequest] DataSourceRequest request, IEnumerable<EditChildViewModel> models)
        {
            if (this.ModelState.IsValid && models != null)
            {
                foreach (var model in models)
                {
                    var dbModel = this.children.GetById(model.Id);
                    Mapper.Map(model, dbModel);
                    this.children.Update(dbModel);

                    return this.Json(new[] { model }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
                }
            }

            return null;
        }

        public ActionResult DeleteChild([DataSourceRequest] DataSourceRequest request, IEnumerable<DisplayChildViewModel> models)
        {
            var result = new List<DisplayChildViewModel>();
            if (models != null)
            {
                foreach (var model in models)
                {
                    this.children.Delete(model.Id);
                    result.Add(model);
                }

                return this.Json(new[] { result }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }

            return null;
        }
    }
}