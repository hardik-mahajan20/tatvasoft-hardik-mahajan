using CRUD.Model;
using Microsoft.EntityFrameworkCore;

namespace CRUD
{
    public class OurCustomerDbContext : DbContext
    {
        public OurCustomerDbContext(DbContextOptions<OurCustomerDbContext> options) : base(options)
        {

        }

        public DbSet<OurCustomer> OurCustomers { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OurCustomer>().HasKey(x => x.Id);

            modelBuilder.Entity<OurCustomer>().HasData(
                new OurCustomer
                {
                    Id = 1,
                    FirstName = "Customer1",
                    LastName = "",
                    IsActive = true,
                }
            );
            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = 1,
                    FirstName = "Admin1",
                    LastName = "",
                    Adminname = "Admin1",
                    Password = "Admin1",
                });
        }

    }
}
