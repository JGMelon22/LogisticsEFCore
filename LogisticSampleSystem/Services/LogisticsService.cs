using LogisticSampleSystem.Data;
using LogisticSampleSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LogisticSampleSystem.Services;

public static class LogisticsService
{
    public static void PostMockInfo()
    {
        using var context = new LogisticsDataContext();

        var customer = new Customer
        {
            Country = "Brazil",
            CustomerName = "Pedro Enrique"
        };

        var productBudget = new ProductBudget
        {
            Country = "Brazil",
            Budget = 250.67f
        };

        var order = new Order
        {
            Quantity = 5,
            Customer = customer,
            Product = productBudget
        };

        // Save at DataBase
        context.Add(order);
        context.SaveChanges();
    }

    public static void GetData()
    {
        using var context = new LogisticsDataContext();
        var orders = context.Orders
                     .Include(x => x.Customer)
                     .Include(y => y.Product)
                     .OrderByDescending(z => z.Id)
                     .ToList();
        // Stopped here
        foreach (var item in orders)
        {
            Console.WriteLine(item);
        }
    }
}
