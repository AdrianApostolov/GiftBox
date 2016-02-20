namespace GiftBox.Services.Data.Contracts
{
    using System.Linq;

    using GiftBox.Data.Models;

    public interface ICommentService
    {
        Comment GetById(int id);

        void Delete(Comment comment);

        void Add(Comment comment);

        IQueryable<Comment> GetHomeComments(int? id);
    }
}
