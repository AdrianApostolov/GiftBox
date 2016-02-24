namespace GiftBox.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using GiftBox.Services.Data.Contracts;
    using GiftBox.Web.Areas.Administration.ViewModels.Comments;

    using Kendo.Mvc.UI;

    public class CommentController : KendoGridAdministrationController
    {
        public CommentController(IUsersService users, IDataService data)
            : base(users, data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }

        protected override IEnumerable GetData()
        {
            return this.data.CommentsRepository.All();
        }

        protected override T GetById<T>(object id)
        {
            return this.data.CommentsRepository.GetById(id) as T;
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, IEnumerable<AdministrationCommentViewModel> models)
        {
            if (models != null)
            {
                foreach (var model in models)
                {
                    this.data.CommentsRepository.Delete(model.Id);
                    this.data.CommentsRepository.SaveChanges();
                }
            }

            return this.GridOperation(models, request);
        }
    }
}