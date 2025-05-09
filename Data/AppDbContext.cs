
using Microsoft.EntityFrameworkCore;
using VPassport.Models;

namespace VPassport.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerVehicle> CustomerVehicles { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<ServiceRecord> ServiceRecords { get; set; }

        public DbSet<FuelEntry> FuelEntries { get; set; }
        public DbSet<ServiceReminder> ServiceReminders { get; set; }
        public DbSet<PartWarranty> PartWarranties { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerVehicle>()
                .HasOne(cv => cv.Customer)
                .WithMany(c => c.Vehicles)
                .HasForeignKey(cv => cv.Customer_ID);
        }
    }
}
