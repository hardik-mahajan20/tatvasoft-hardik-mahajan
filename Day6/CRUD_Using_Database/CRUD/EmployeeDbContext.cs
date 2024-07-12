using CRUD.Model;
using Microsoft.EntityFrameworkCore;

namespace CRUD
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employee {  get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(x => x.Id);
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {s
                    Id = 1,
                    FirstName = "Entry1",
                    LastName = "Entry1_LastName",
                    isActive = true,
                }
                );
        }

        

    }
}
