namespace GiftBox.Services.Data
{
    using System.Linq;

    using GiftBox.Data.Models;
    using GiftBox.Services.Data.Contracts;
    using GiftBox.Data.Common.Repositories;

    public class ChildService : IChildService
    {
        private readonly IDeletableEntityRepository<Child> childeren; 

        public ChildService(IDeletableEntityRepository<Child> childeren)
        {
            this.childeren = childeren;
        }

        public IQueryable<Child> GetAll(int homeId)
        {
            var children = this.childeren
                .All()
                .Where(x => x.HomeId == homeId);

            return children;
        }

        public Child GetById(int id)
        {
            var child = this.childeren.GetById(id);

            return child;
        }

        public void Add(Child child)
        {
            this.childeren.Add(child);
            this.childeren.SaveChanges();
        }

        public void Delete(int id)
        {
            this.childeren.Delete(id);
            this.childeren.SaveChanges();
        }

        public void Update(Child child)
        {
            this.childeren.Update(child);
            this.childeren.SaveChanges();
        }
    }
}
