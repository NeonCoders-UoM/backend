using Microsoft.EntityFrameworkCore;
using VehiclePassportAPI.Models;
namespace VehiclePassportAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ServiceStation> ServiceStations { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerVehicle> CustomerVehicles { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<ServiceInAppointment> ServicesInAppointment { get; set; }
        public DbSet<ServiceCenterProvidesService> ServiceCenterProvidesServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Prevent multiple cascade paths
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Customer)
                .WithMany(c => c.Appointments)
                .HasForeignKey(a => a.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Vehicle)
                .WithMany(v => v.Appointments)
                .HasForeignKey(a => a.VehicleID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.ServiceStation)
                .WithMany(s => s.Appointments)
                .HasForeignKey(a => a.StationID)
                .OnDelete(DeleteBehavior.Restrict);

            // Optionally: also configure for ServiceInAppointment to avoid similar issues
            modelBuilder.Entity<ServiceInAppointment>()
                .HasOne(sia => sia.Appointment)
                .WithMany(a => a.Services)
                .HasForeignKey(sia => sia.AppointmentID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ServiceInAppointment>()
                .HasOne(sia => sia.Service)
                .WithMany(s => s.ServiceInAppointments)
                .HasForeignKey(sia => sia.ServiceID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
