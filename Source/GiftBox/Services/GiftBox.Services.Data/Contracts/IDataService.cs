using GiftBox.Data.Common.Repositories;
using GiftBox.Data.Models;

namespace GiftBox.Services.Data.Contracts
{
    public interface IDataService
    {
        IDeletableEntityRepository<Comment> CommentsRepository { get; set; }

        IDeletableEntityRepository<Home> HomeRepository { get; set; }

        IDeletableEntityRepository<Child> ChildrenRepository { get; set; }

        IDeletableEntityRepository<Need> NeedRepository { get; set; }

        IDeletableEntityRepository<Gift> GiftRepository { get; set; }

        IDeletableEntityRepository<EventCategory> EventCategoryRepository { get; set; }

        IDeletableEntityRepository<NeedCategory> NeedCategoryRepository { get; set; }
    }
}
