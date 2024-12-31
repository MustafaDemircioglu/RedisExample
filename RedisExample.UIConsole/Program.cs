using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedisExample.BusinessLogicLayer.Abstract;
using RedisExample.BusinessLogicLayer.Concrate;
using RedisExample.CacheLayer.Abstract;
using RedisExample.CacheLayer.Concrete;
using RedisExample.DataAccessLayer.Abstract;
using RedisExample.DataAccessLayer.Conctrete;
using RedisExample.Entity;
using StackExchange.Redis;
using System;


var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var serviceProvider = new ServiceCollection()
  
                 .AddSingleton<IConfiguration>(configuration)
                 .AddSingleton<IProductRepository, ProductRepository>(provider =>
        new ProductRepository(configuration.GetConnectionString("DefaultConnection")))
                 .AddSingleton<IProductCache, ProductCache>()
                 .AddSingleton<IProductService, ProductService>()
                 .AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("localhost:6379"))  // Redis bağlantısı
                 .BuildServiceProvider();

var productService = serviceProvider.GetService<IProductService>();

// Product işlemleri
var product = productService.GetProductByIdAsync(1).Result;
Console.WriteLine($"Product: {product?.ProductName}, {product?.UnitPrice}");

var allProducts = productService.GetAllProductsAsync().Result;
foreach (var p in allProducts)
{
    Console.WriteLine($"Product: {p.ProductName}, {p.UnitPrice}");
}

//// Yeni ürün ekliyoruz
//var newProduct = new Product { ProductName = "Mustafa Yeni Ürün", UnitPrice = 100m };
//productService.AddProductAsync(newProduct).Wait();

//Console.WriteLine("Yeni ürün başarıyla eklendi.");