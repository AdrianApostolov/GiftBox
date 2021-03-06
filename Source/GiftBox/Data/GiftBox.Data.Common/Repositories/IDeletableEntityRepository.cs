﻿namespace GiftBox.Data.Common.Repositories
{
    using System.Linq;

    public interface IDeletableEntityRepository<T> : IRepository<T> 
        where T : class
    {
        IQueryable<T> AllWithDeleted();
    }
}
