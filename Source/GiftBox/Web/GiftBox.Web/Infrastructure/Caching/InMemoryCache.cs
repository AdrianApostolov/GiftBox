namespace GiftBox.Web.Infrastructure.Caching
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Caching;


    public class InMemoryCache : ICacheService
    {
        private static readonly object LockObject = new object();

        public T Get<T>(string itemName, Func<T> getDataFunc, int durationInSeconds)
        {
            if (HttpRuntime.Cache[itemName] == null)
            {
                lock (LockObject)
                {
                    if (HttpRuntime.Cache[itemName] == null)
                    {
                        var data = getDataFunc();
                        HttpRuntime.Cache.Insert(
                            itemName,
                            data,
                            null,
                            DateTime.Now.AddSeconds(durationInSeconds),
                            Cache.NoSlidingExpiration);
                    }
                }
            }

            return (T)HttpRuntime.Cache[itemName];
        }

        public void Clear(string cacheId)
        {
            HttpRuntime.Cache.Remove(cacheId);
        }
    }
}