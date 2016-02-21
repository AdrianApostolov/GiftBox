using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GiftBox.Common;
using GiftBox.Data.Models;
namespace GiftBox.Web.Controllers.Comments
{
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using GiftBox.Services.Data.Contracts;
    using GiftBox.Web.ViewModels.Comments;

    public class CommentsController : BaseController
    {
        private ICommentService comments;
        private IHomeService homes;
        private INeedService needs;

        public CommentsController(IUsersService users, ICommentService comments, IHomeService homes, INeedService needs)
            : base(users)
        {
            this.comments = comments;
            this.homes = homes;
            this.needs = needs;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(AddCommentViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var comment = Mapper.Map<Comment>(model);
                comment.UserId = this.CurrentUser.Id;

                if (model.HomeId != null)
                {
                    var home = this.homes
                    .GetHomeById(model.HomeId)
                    .FirstOrDefault();

                    if (home == null)
                    {
                        throw new HttpException(404, GlobalConstants.PageNotFound);
                    }

                    home.Comments.Add(comment);
                    this.homes.Update();
                }

                if (model.NeedId != null)
                {
                    var need = this.needs.GetById(model.NeedId);

                    if (need == null)
                    {
                        throw new HttpException(404, GlobalConstants.PageNotFound);
                    }

                    need.Comments.Add(comment);
                    this.needs.Update(need);
                }

                var viewModel = Mapper.Map<CommentViewModel>(comment);

                return this.PartialView(GlobalConstants.SingleCommentPartial, viewModel);
            }

            throw new HttpException(400, GlobalConstants.InvalidComment);
        }

        public ActionResult Delete(int id, string userName)
        {
            var comment = this.comments.GetById(id);

            if (comment != null && comment.UserId == this.CurrentUser.Id)
            {
                this.comments.Delete(comment);
            }

            var comments = this.comments
                .GetHomeComments(comment.HomeId)
                .ProjectTo<CommentViewModel>();

            return this.PartialView(GlobalConstants.PageCommentsPartial, comments);
        }

        public ActionResult GetPageCommentsPartial(int entityId, bool isNeed = false)
        {
            IQueryable<CommentViewModel> comments;
            if (isNeed)
            {
                comments = this.comments
                    .GetNeedComments(entityId)
                    .ProjectTo<CommentViewModel>();
            }
            else
            {
                comments = this.comments
                    .GetHomeComments(entityId)
                    .ProjectTo<CommentViewModel>();
            }

            return this.PartialView(GlobalConstants.PageCommentsPartial, comments);
        }
    }
}