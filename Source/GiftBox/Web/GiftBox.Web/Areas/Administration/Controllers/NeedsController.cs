using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GiftBox.Data.Models;
using GiftBox.Services.Data.Contracts;
using GiftBox.Web.Areas.Administration.ViewModels.Needs;
using Kendo.Mvc.UI;

namespace GiftBox.Web.Areas.Administration.Controllers
{
    public class NeedsController : KendoGridAdministrationController
    {
        // GET: Administration/Needs
        public ActionResult Index()
        {
            return View();
        }

        public NeedsController(IUsersService users, IDataService data) : base(users, data)
        {
        }

        protected override IEnumerable GetData()
        {
            return this.data.NeedRepository.All();
        }

        protected override T GetById<T>(object id)
        {
            return this.data.NeedRepository.GetById(id) as T;
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, IEnumerable<AdministrationNeedViewModel> models)
        {
            foreach (var model in models)
            {
                base.Update<Need, AdministrationNeedViewModel>(model, model.Id);
                this.data.EventCategoryRepository.SaveChanges();
            }

            return this.GridOperation(models, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, IEnumerable<AdministrationNeedViewModel> models)
        {
            if (models != null)
            {
                foreach (var model in models)
                {
                    this.data.EventCategoryRepository.Delete(model.Id);
                    this.data.EventCategoryRepository.SaveChanges();
                }
            }

            return this.GridOperation(models, request);
        }
    }
}