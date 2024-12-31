using RedisExample.BusinessLogicLayer.Abstract;
using RedisExample.CacheLayer.Abstract;
using RedisExample.DataAccessLayer.Abstract;
using RedisExample.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisExample.BusinessLogicLayer.Concrate
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCache _productCache;

        public ProductService(IProductRepository productRepository, IProductCache productCache)
        {
            _productRepository = productRepository;
            _productCache = productCache;
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            // Önce cache'den bakıyoruz.
            var cachedProduct = await _productCache.GetFromCacheAsync(productId);
            if (cachedProduct != null)
            {
                return cachedProduct; // Cache'den veriyi döndür.
            }

            // Cache'de bulamazsak veritabanından çekiyoruz.
            var product = await _productRepository.GetByIdAsync(productId);
            if (product != null)
            {
                // Veritabanından aldığımız ürünü cache'liyoruz.
                await _productCache.SetCacheAsync(productId, product);
            }
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            // Cache'den tüm ürünleri alıyoruz.
            var cachedProducts = await _productCache.GetAllFromCacheAsync();
            if (cachedProducts != null)
            {
                return cachedProducts; // Cache'den veriyi döndür.
            }

            // Cache'de bulamazsak veritabanından çekiyoruz.
            var products = await _productRepository.GetAllAsync();
            if (products != null)
            {
                // Veritabanından aldığımız tüm ürünleri cache'liyoruz.
                await _productCache.SetAllCacheAsync(products);
            }
            return products;
        }

        public async Task AddProductAsync(Product product)
        {
            // Yeni ürünü veritabanına ekliyoruz.
            await _productRepository.AddAsync(product);
            // Ürünü cache'e ekliyoruz.
            await _productCache.SetCacheAsync(product.ProductID, product);
        }
    }
}

