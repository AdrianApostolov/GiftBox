namespace GiftBox.Services.Data
{
    using System.Linq;

    using GiftBox.Data.Models;
    using GiftBox.Services.Data.Contracts;
    using GiftBox.Data.Common.Repositories;

    public class GiftService : IGiftService
    {
        private readonly IDeletableEntityRepository<Gift> gifts;

        public GiftService(IDeletableEntityRepository<Gift> gifts)
        {
            this.gifts = gifts;
        }

        public IQueryable<Gift> GetAll()
        {
            var allGifts = this.gifts.All();

            return allGifts;
        }
    }
}
