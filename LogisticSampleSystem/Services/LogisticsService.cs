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

        foreach (var item in orders)
        {
            Console.WriteLine($"Customer: {item.Customer.CustomerName}");
            Console.WriteLine($"Customer Country: {item.Customer.Country}");
            Console.WriteLine($"Product Id: {item.Product.Id}");
            Console.WriteLine($"Product Quantity: {item.Quantity}");
        }

        Console.WriteLine();
    }

    // By Id
    public static void GetDataById(int id)
    {
        using var context = new LogisticsDataContext();
        var orders = context.Orders
                     .Include(x => x.Customer)
                     .Include(y => y.Product)
                     .Where(a => a.Product.Id == id)
                     .OrderByDescending(z => z.Id)
                     .ToList();
        Console.ForegroundColor = ConsoleColor.Blue;
        foreach (var item in orders)
        {
            Console.WriteLine($"Customer: {item.Customer.CustomerName}");
            Console.WriteLine($"Customer Country: {item.Customer.Country}");
            Console.WriteLine($"Product Id: {item.Product.Id}");
            Console.WriteLine($"Product Quantity: {item.Quantity}");
        }
        Console.ResetColor();
        Console.WriteLine();
    }


    public static void UpdateMethod(int id)
    {
        using var context = new LogisticsDataContext();
        var order = context.Orders
            .Include(x => x.Customer)
            .Include(y => y.Product)
            .OrderByDescending(z => z.Id)
            .FirstOrDefault(a => a.Product.Id == id);

        order.Customer.CustomerName = "Customer recently updated";
        context.Orders.Update(order);
        context.SaveChanges();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Customer with product id {id} updated!\n");
        Console.ResetColor();
    }

    public static void DeleteMethod(int id)
    {
        using var context = new LogisticsDataContext();
        var customerToRemove = context.Customers.FirstOrDefault(x => x.Id == id);

        context.Remove(customerToRemove);
        context.SaveChanges();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Customer {id} deleted!\n");
        Console.ResetColor();
    }
}
