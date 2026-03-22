using Microsoft.EntityFrameworkCore;
using User_Management_API.Data.Seeding;
using User_Management_API.Models;

namespace User_Management_API.Data
{
    public class HRDbContext : DbContext
    {
        public HRDbContext(DbContextOptions<HRDbContext> options)
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HRDbContext).Assembly);
            modelBuilder.seed();
        }
    }
}
