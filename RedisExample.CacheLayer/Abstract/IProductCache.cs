using RedisExample.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisExample.CacheLayer.Abstract
{
    public interface IProductCache
    {
        Task<Product> GetFromCacheAsync(int productId);
        Task<IEnumerable<Product>> GetAllFromCacheAsync();
        Task SetCacheAsync(int productId, Product product);
        Task SetAllCacheAsync(IEnumerable<Product> products);
    }
}

