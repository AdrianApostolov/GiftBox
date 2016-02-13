using System.Linq;
using GiftBox.Data.Models;

namespace GiftBox.Services.Data.Contracts
{
    public interface IChildService
    {
        IQueryable<Child> GetAll(int homeId);

        Child GetById(int id);

        void Add(Child child);

        void Delete(int id);

        void Update(Child child);
    }
}
