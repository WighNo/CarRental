using System.Data.Entity;
using CarRental.Model;

namespace CarRental
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection")
        {
            
        }

        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Client> Clients { get; set; }
        
        public DbSet<Car> Cars { get; set; }
        
        public DbSet<Rental> Rentals { get; set; }
    }
}