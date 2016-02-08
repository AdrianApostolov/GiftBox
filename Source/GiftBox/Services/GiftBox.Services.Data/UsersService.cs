using GiftBox.Data.Common.Repositories;

namespace GiftBox.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using GiftBox.Data.Models;
    using GiftBox.Services.Data.Contracts;

    public class UsersService : IUsersService
    {
        private IDeletableEntityRepository<User> users;

        public UsersService(IDeletableEntityRepository<User> users)
        {
            this.users = users;
        }

        public IQueryable<User> All()
        {
            return this.users.All();
        }

        public User GetById(object id)
        {
            return this.users.GetById(id);
        }

        public void Update()
        {
            this.users.SaveChanges();
        }
    }
}
