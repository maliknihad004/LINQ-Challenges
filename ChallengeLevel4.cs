using System;
using System.Linq;

class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public DateTime Date { get; set; }
    public decimal Total { get; set; }
}

class LevelFour
{
    public static void Main(string[] args)
    {
        var orders = new List<Order>
        {
            new Order { Id = 1, CustomerId = 101, Date = new DateTime(2026, 9, 1), Total = 250 },
            new Order { Id = 2, CustomerId = 102, Date = new DateTime(2026, 9, 2), Total = 500 },
            new Order { Id = 3, CustomerId = 101, Date = new DateTime(2026, 9, 5), Total = 150 },
            new Order { Id = 4, CustomerId = 103, Date = new DateTime(2026, 9, 7), Total = 800 },
            new Order { Id = 5, CustomerId = 104, Date = new DateTime(2026, 9, 10), Total = 300 }
        };

        var topCustomers = orders.GroupBy(order => order.CustomerId)
                                 .Select(group => new
                                 {
                                     customerId = group.Key,
                                     totalSpent = group.Sum(order => order.Total)
                                 })
                                 .OrderByDescending(customer => customer.totalSpent)
                                 .Take(3);

        Console.WriteLine("Top 3 customers with the highest order totals:");

        foreach (var customer in topCustomers)
        {
            Console.WriteLine($"Customer ID: {customer.customerId}, Total: ${customer.totalSpent}");
        }

        var customerOrders = orders.Where(order => order.Date.Year == DateTime.Now.Year)
                                   .GroupBy(order => order.CustomerId)
                                   .Select(group => new
                                   {
                                       customerId = group.Key,
                                       numberOfOrders = group.Count()
                                   })
                                   .OrderByDescending(customer => customer.numberOfOrders)
                                   .First();

        Console.WriteLine($"Customer with the most orders: Customer ID: {customerOrders.customerId}, Number of Orders: {customerOrders.numberOfOrders}");
    }
}