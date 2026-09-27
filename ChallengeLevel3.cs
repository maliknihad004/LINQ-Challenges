using System;
using System.Linq;

class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}

class LevelThree
{
    public static void Main(string[] args)
    {
        var products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1200, Stock = 5 },
            new Product { Id = 2, Name = "Mouse", Category = "Electronics", Price = 25, Stock = 20 },
            new Product { Id = 3, Name = "Chair", Category = "Furniture", Price = 150, Stock = 10 },
            new Product { Id = 4, Name = "Desk", Category = "Furniture", Price = 300, Stock = 3 },
            new Product { Id = 5, Name = "Phone", Category = "Electronics", Price = 800, Stock = 0 }
        };

        var expensiveProducts = products.Where(product => product.Stock > 0)
                                        .OrderByDescending(product => product.Price)
                                        .Take(3)
                                        .Select(product => new { product.Name, product.Price });

        Console.WriteLine("Top 3 most expensive products:");

        foreach (var product in expensiveProducts)
        {
            Console.WriteLine($"{product.Name}: ${product.Price}");
        }

        var productInformation = products.GroupBy(product => product.Category)
                                          .Select(group => new
                                          {
                                              categoryName = group.Key,
                                              numberOfProducts = group.Count(),
                                              averagePrice = group.Average(product => product.Price),
                                              mostExpensivePrice = group.Max(product => product.Price)
                                          })
                                          .OrderByDescending(group => group.averagePrice);

        Console.WriteLine("Product information by category:");

        foreach (var group in productInformation)
        {
            Console.WriteLine($"Category: {group.categoryName}, Products: {group.numberOfProducts}, Average Price: ${group.averagePrice}, Most Expensive: ${group.mostExpensivePrice}");
        }
    }
}