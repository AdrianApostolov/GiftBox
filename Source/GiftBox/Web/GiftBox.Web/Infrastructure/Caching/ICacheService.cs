namespace GiftBox.Web.Infrastructure.Caching
{
    using System;

    public interface ICacheService
    {
        T Get<T>(string cacheID, Func<T> getItemCallback, int duration); 

        void Clear(string cacheId);
    }
}
