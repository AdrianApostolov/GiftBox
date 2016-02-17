namespace GiftBox.Services.Data.Contracts
{
    using System.Linq;
    using GiftBox.Data.Models;

    public interface IGiftService
    {
        IQueryable<Gift> GetAll();

        IQueryable<Gift> GetAllByHomeId(int homeId);

        IQueryable<Gift> GetAllNotClaimed();

        Gift GetById(int id);

        void Add(Gift gift);

        void Delete(int id);

        void Update(Gift gift);
    }
}
