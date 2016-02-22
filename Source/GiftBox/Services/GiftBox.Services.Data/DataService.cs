using GiftBox.Data.Common.Repositories;
using GiftBox.Data.Models;
using GiftBox.Services.Data.Contracts;
namespace GiftBox.Services.Data
{
    public class DataService : IDataService
    {
        public DataService(
            IDeletableEntityRepository<Comment> commentsRepository,
            IDeletableEntityRepository<Home> homeRepository,
            IDeletableEntityRepository<Child> childrenRepository,
            IDeletableEntityRepository<Need> needRepository,
            IDeletableEntityRepository<Gift> giftRepository,
            IDeletableEntityRepository<EventCategory> eventCategoryRepository,
            IDeletableEntityRepository<NeedCategory> needCategoryRepository)
        {
            this.CommentsRepository = commentsRepository;
            this.HomeRepository = homeRepository;
            this.ChildrenRepository = childrenRepository;
            this.NeedRepository = needRepository;
            this.GiftRepository = giftRepository;
            this.EventCategoryRepository = eventCategoryRepository;
            this.NeedCategoryRepository = needCategoryRepository;
        }

        public IDeletableEntityRepository<Comment> CommentsRepository { get; set; }

        public IDeletableEntityRepository<Home> HomeRepository { get; set; }

        public IDeletableEntityRepository<Child> ChildrenRepository { get; set; }

        public IDeletableEntityRepository<Need> NeedRepository { get; set; }

        public IDeletableEntityRepository<Gift> GiftRepository { get; set; }

        public IDeletableEntityRepository<EventCategory> EventCategoryRepository { get; set; }

        public IDeletableEntityRepository<NeedCategory> NeedCategoryRepository { get; set; }
    }
}