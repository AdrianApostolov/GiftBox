namespace GiftBox.Services.Data.Contracts
{
    using System.Linq;
    using GiftBox.Data.Models;

    public interface IGiftService
    {
        IQueryable<Gift> GetAll();
    }
}
