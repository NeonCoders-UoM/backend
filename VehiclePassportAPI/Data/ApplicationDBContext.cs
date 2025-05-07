using Microsoft.EntityFrameworkCore;
using VehiclePassportAPI.Models;

namespace VehiclePassportAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
    }
}
