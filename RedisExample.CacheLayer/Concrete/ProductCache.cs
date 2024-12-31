using Newtonsoft.Json;
using RedisExample.CacheLayer.Abstract;
using RedisExample.Entity;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisExample.CacheLayer.Concrete
{
    public class ProductCache : IProductCache
    {
        private readonly IDatabase _database;

        public ProductCache(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }
        public async Task<Product> GetFromCacheAsync(int productId)
        {
            var cachedProduct = await _database.StringGetAsync($"product:{productId}");
            if (cachedProduct.IsNullOrEmpty)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<Product>(cachedProduct);
        }

        public async Task<IEnumerable<Product>> GetAllFromCacheAsync()
        {
            var cachedProducts = await _database.StringGetAsync("all_products");
            if (cachedProducts.IsNullOrEmpty)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<List<Product>>(cachedProducts);
        }

        public async Task SetCacheAsync(int productId, Product product)
        {
            await _database.StringSetAsync($"product:{productId}", JsonConvert.SerializeObject(product));
        }

        public async Task SetAllCacheAsync(IEnumerable<Product> products)
        {
            await _database.StringSetAsync("all_products", JsonConvert.SerializeObject(products));
        }
    }
}
