using RedisExample.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisExample.DataAccessLayer.Abstract
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int productId);
        Task<IEnumerable<Product>> GetAllAsync();
        Task AddAsync(Product product);
    }
}
