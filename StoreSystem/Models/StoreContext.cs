using Microsoft.EntityFrameworkCore;

namespace StoreSystem.Models
{
    public class StoreContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Sell> Sells { get; set; }
        public DbSet<SellDetail> SellDetails { get; set; }
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}
