namespace GiftBox.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using GiftBox.Data.Models;
    using GiftBox.Services.Data.Contracts;
    using GiftBox.Web.Areas.Administration.ViewModels.Categories;
    using Kendo.Mvc.UI;

    public class NeedCategoryController : KendoGridAdministrationController
    {
        // GET: Administration/EventCategory
        public ActionResult Index()
        {
            return View();
        }

        public NeedCategoryController(IUsersService users, IDataService data)
            : base(users, data)
        {
        }

        protected override IEnumerable GetData()
        {
            return this.data.NeedCategoryRepository.All();
        }

        protected override T GetById<T>(object id)
        {
            return this.data.NeedCategoryRepository.GetById(id) as T;
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, IEnumerable<NeedCategoryViewModel> models)
        {
            foreach (var model in models)
            {
                var dbModel = base.Create<NeedCategory>(model);
                this.data.NeedCategoryRepository.Add(dbModel);
                this.data.NeedCategoryRepository.SaveChanges();
            }

            return this.GridOperation(models, request);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, IEnumerable<NeedCategoryViewModel> models)
        {
            foreach (var model in models)
            {
                base.Update<NeedCategory, NeedCategoryViewModel>(model, model.Id);
                this.data.NeedCategoryRepository.SaveChanges();
            }

            return this.GridOperation(models, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, IEnumerable<NeedCategoryViewModel> models)
        {
            if (models != null)
            {
                foreach (var model in models)
                {
                    this.data.NeedCategoryRepository.Delete(model.Id);
                    this.data.NeedCategoryRepository.SaveChanges();
                }
            }

            return this.GridOperation(models, request);
        }
    }
}