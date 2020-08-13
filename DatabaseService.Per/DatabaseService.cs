using Microsoft.EntityFrameworkCore;
using SalesDetails.App.Interface;
using SalesDetails.Domain;

namespace SalesDetails.Data
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }

        public DatabaseService()
        {

        }

        public DatabaseService(DbContextOptions<DatabaseService> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        
        public void Save()
        {
            this.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
