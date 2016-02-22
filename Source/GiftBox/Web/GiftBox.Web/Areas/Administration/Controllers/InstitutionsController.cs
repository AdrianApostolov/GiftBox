using System.Collections.Generic;
using GiftBox.Data.Models;

namespace GiftBox.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Web.Mvc;
    using GiftBox.Services.Data.Contracts;
    using Kendo.Mvc.UI;
    using GiftBox.Web.Areas.Administration.ViewModels.Institution;

    public class InstitutionsController : KendoGridAdministrationController
    {
        public InstitutionsController(IUsersService users, IDataService data)
            : base(users, data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }

        protected override IEnumerable GetData()
        {
            return this.data.HomeRepository.All();
        }

        protected override T GetById<T>(object id)
        {
            return this.data.HomeRepository.GetById(id) as T;
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, IEnumerable<AdministrationInstitutionViewModel> models)
        {
            foreach (var model in models)
            {
                base.Update<Home, AdministrationInstitutionViewModel>(model, model.Id);
                this.data.HomeRepository.SaveChanges();
            }

            return this.GridOperation(models, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, IEnumerable<AdministrationInstitutionViewModel> models)
        {
            if (models != null)
            {
                foreach (var model in models)
                {
                    this.data.HomeRepository.Delete(model.Id);
                    this.data.HomeRepository.SaveChanges();
                }
            }

            return this.GridOperation(models, request);
        }
    }
}