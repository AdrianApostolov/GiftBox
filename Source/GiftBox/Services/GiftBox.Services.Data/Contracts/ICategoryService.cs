using System.Linq;
using GiftBox.Data.Models;

namespace GiftBox.Services.Data.Contracts
{
    public interface ICategoryService
    {
        IQueryable<NeedCategory> GetNeedCategories();

        IQueryable<EventCategory> GetEventCategories();
    }
}
