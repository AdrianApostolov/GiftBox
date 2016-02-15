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

        public IQueryable<Gift> GetAll(int homeId)
        {
            var allGifts = this.gifts
                .All()
                .Where(x => x.Child.HomeId == homeId);

            return allGifts;
        }

        public Gift GetById(int id)
        {
            var gift = this.gifts.GetById(id);

            return gift;
        }

        public void Add(Gift gift)
        {
            this.gifts.Add(gift);
            this.gifts.SaveChanges();
        }

        public void Delete(int id)
        {
            this.gifts.Delete(id);
            this.gifts.SaveChanges();
        }

        public void Update(Gift gift)
        {
            this.gifts.Update(gift);
            this.gifts.SaveChanges();
        }
    }
}
