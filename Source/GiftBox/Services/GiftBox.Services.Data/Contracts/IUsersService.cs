namespace GiftBox.Services.Data.Contracts
{
    using System.Linq;

    using GiftBox.Data.Models;

    public interface IUsersService
    {
        IQueryable<User> All();

        User GetById(object id);

        void Update();
    }
}
