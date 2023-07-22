using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class POSDbContext:IdentityDbContext
    {
        public POSDbContext(DbContextOptions options): base(options) 
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProducType> ProducTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreTransfer> StoreTransfers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }

    }
}
