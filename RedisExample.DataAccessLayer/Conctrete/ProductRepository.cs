using RedisExample.Entity;
using Dapper;

using System.Collections.Generic;
using System.Threading.Tasks;
using RedisExample.DataAccessLayer.Abstract;
using Microsoft.Data.SqlClient;


namespace RedisExample.DataAccessLayer.Conctrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        // DI container tarafından constructor injection ile bağlantı string'ini alıyoruz.
        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Product> GetByIdAsync(int productId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT ProductID, ProductName, UnitPrice FROM Products WHERE ProductID = @Id";
                return await connection.QueryFirstOrDefaultAsync<Product>(query, new { Id = productId });
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT ProductID, ProductName, UnitPrice FROM Products";
                return await connection.QueryAsync<Product>(query);
            }
        }

        public async Task AddAsync(Product product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO Products (ProductName, UnitPrice) VALUES (@ProductName, @UnitPrice)";
                await connection.ExecuteAsync(query, product);
            }
        }
    }
}
