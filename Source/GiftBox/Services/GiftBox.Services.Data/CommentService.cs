namespace GiftBox.Services.Data
{
    using System.Linq;

    using GiftBox.Services.Data.Contracts;
    using GiftBox.Data.Common.Repositories;
    using GiftBox.Data.Models;

    public class CommentService : ICommentService
    {
        private readonly IDeletableEntityRepository<Comment> comments;

        public CommentService(IDeletableEntityRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public Comment GetById(int id)
        {
            var comment = this.comments.GetById(id);

            return comment;
        }

        public void Delete(Comment comment)
        {
            this.comments.Delete(comment);
            this.comments.SaveChanges();
        }

        public void Add(Comment comment)
        {
            this.comments.Add(comment);
            this.comments.SaveChanges();
        }

        public IQueryable<Comment> GetHomeComments(int? id)
        {
            var comments = this.comments
                .All()
                .Where(c => c.HomeId == id && !c.IsDeleted)
                .OrderByDescending(c => c.CreatedOn);

            return comments;
        }
    }
}
