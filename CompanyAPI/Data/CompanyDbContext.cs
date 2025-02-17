using Microsoft.EntityFrameworkCore;
using CompanyAPI.Models;

namespace CompanyAPI.Data
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Property(o => o.ID)
                .HasColumnType("VARCHAR(10)");  // Order ID is treated as string

            modelBuilder.Entity<Customer>()
                .Property(c => c.ID)
                .HasColumnType("VARCHAR(10)"); // Customer ID is treated as string
        }
    }
}
