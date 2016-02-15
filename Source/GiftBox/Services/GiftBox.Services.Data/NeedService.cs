using System.Linq;
using GiftBox.Data.Common.Repositories;
using GiftBox.Data.Models;

namespace GiftBox.Services.Data
{
    using GiftBox.Services.Data.Contracts;

    public class NeedService : INeedService
    {
        private readonly IDeletableEntityRepository<Need> needs;

        public NeedService(IDeletableEntityRepository<Need> needs)
        {
            this.needs = needs;
        } 

        public IQueryable<Need> GetAll(int homeId)
        {
            var allNeeds = this.needs
                .All()
                .Where(x => x.HomeId == homeId);

            return allNeeds;
        }

        public Need GetById(int id)
        {
            var need = this.needs.GetById(id);

            return need;
        }

        public void Add(Need need)
        {
            this.needs.Add(need);
            this.needs.SaveChanges();
        }

        public void Delete(int id)
        {
            this.needs.Delete(id);
            this.needs.SaveChanges();
        }

        public void Update(Need need)
        {
            this.needs.Update(need);
            this.needs.SaveChanges();
        }
    }
}
