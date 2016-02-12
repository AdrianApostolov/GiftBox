namespace GiftBox.Services.Data
{
    using System.Linq;
    using GiftBox.Data.Common.Repositories;
    using GiftBox.Data.Models;
    
    using GiftBox.Services.Data.Contracts;

    public class HomeService : IHomeService
    {
        private IDeletableEntityRepository<Home> homes;

        public HomeService(IDeletableEntityRepository<Home> homes)
        {
            this.homes = homes;
        }

        public IQueryable<Home> GetHomeById(int? id)
        {
            var home = this.homes
                        .All()
                        .Where(h => h.Id == id);

            return home;
        }

        public void Add(Home home)
        {
            this.homes.Add(home);
            this.homes.SaveChanges();
        }

        public void Update()
        {
            this.homes.SaveChanges();
        }
    }
}
