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

        public CommentsController(IUsersService users, ICommentService comments, IHomeService homes)
            : base(users)
        {
            this.comments = comments;
            this.homes = homes;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(AddCommentViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var comment = Mapper.Map<Comment>(model);
                comment.UserId = this.CurrentUser.Id;

                var home = this.homes
                    .GetHomeById(model.HomeId)
                    .FirstOrDefault();

                if (home == null)
                {
                    throw new HttpException(404, GlobalConstants.PageNotFound);
                }

                home.Comments.Add(comment);
                this.homes.Update();

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

        public ActionResult GetPageCommentsPartial(int homeId)
        {
            var comments = this.comments
                .GetHomeComments(homeId)
                .ProjectTo<CommentViewModel>();

            return this.PartialView(GlobalConstants.PageCommentsPartial, comments);
        }
    }
}