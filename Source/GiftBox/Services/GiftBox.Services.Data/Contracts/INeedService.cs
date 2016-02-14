namespace GiftBox.Services.Data.Contracts
{
    using System.Linq;
    using GiftBox.Data.Models;

    public interface INeedService
    {
        IQueryable<Need> GetAll();

        Need GetById(int id);

        void Add(Need need);

        void Delete(int id);

        void Update(Need need);
    }
}
