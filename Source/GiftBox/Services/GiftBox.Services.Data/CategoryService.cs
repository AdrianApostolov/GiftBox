namespace GiftBox.Services.Data
{
    using System.Linq;
    using GiftBox.Data.Common.Repositories;
    using GiftBox.Data.Models;
    using GiftBox.Services.Data.Contracts;

    public class CategoryService : ICategoryService
    {
        private IDeletableEntityRepository<NeedCategory> needCategories;
        private IDeletableEntityRepository<EventCategory> eventCategories;

        public CategoryService(
            IDeletableEntityRepository<NeedCategory> needCategories, 
            IDeletableEntityRepository<EventCategory> eventCategories)
        {
            this.needCategories = needCategories;
            this.eventCategories = eventCategories;
        }

        public IQueryable<NeedCategory> GetNeedCategories()
        {
            return this.needCategories.All();
        }

        public IQueryable<EventCategory> GetEventCategories()
        {
            return this.eventCategories.All();
        }
    }
}
