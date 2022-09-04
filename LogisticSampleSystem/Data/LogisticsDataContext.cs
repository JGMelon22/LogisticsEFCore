using LogisticSampleSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LogisticSampleSystem.Data;

public class LogisticsDataContext : DbContext
{

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<ProductBudget> ProductBudgets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => base.OnConfiguring(optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Logistics;User Id=sa;Password=Melon@123;"));
}