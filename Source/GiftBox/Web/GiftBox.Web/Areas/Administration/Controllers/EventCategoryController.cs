namespace GiftBox.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using GiftBox.Data.Models;
    using GiftBox.Services.Data.Contracts;
    using GiftBox.Web.Areas.Administration.ViewModels.EventCategory;
    using Kendo.Mvc.UI;

    public class EventCategoryController : KendoGridAdministrationController
    {
        // GET: Administration/EventCategory
        public ActionResult Index()
        {
            return View();
        }

        public EventCategoryController(IUsersService users, IDataService data) 
            : base(users, data)
        {
        }

        protected override IEnumerable GetData()
        {
            return this.data.EventCategoryRepository.All();
        }

        protected override T GetById<T>(object id)
        {
            return this.data.EventCategoryRepository.GetById(id) as T;
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, IEnumerable<EventCategoryViewModel> models)
        {
            foreach (var model in models)
            {
                var dbModel = base.Create<EventCategory>(model);
                this.data.EventCategoryRepository.Add(dbModel);
                this.data.EventCategoryRepository.SaveChanges();
            }

            return this.GridOperation(models, request);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, IEnumerable<EventCategoryViewModel> models)
        {
            foreach (var model in models)
            {
                base.Update<EventCategory, EventCategoryViewModel>(model, model.Id);
                this.data.EventCategoryRepository.SaveChanges();
            }

            return this.GridOperation(models, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, IEnumerable<EventCategoryViewModel> models)
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