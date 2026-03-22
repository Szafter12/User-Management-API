using Microsoft.EntityFrameworkCore;
using User_Management_API.Models;

namespace User_Management_API.Data.Seeding
{
    public static class SeedData
    {
        public static void seed(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Department>()
                .HasData(
                    new Department { DepartmentID = 1, Name = "HR" },
                    new Department { DepartmentID = 2, Name = "Engineering" }
                );

            modelBuilder
                .Entity<Employee>()
                .HasData(
                    new Employee
                    {
                        EmployeeID = 1,
                        FirstName = "Aiko",
                        LastName = "Tanaka",
                        DepartmentID = 1,
                    },
                    new Employee
                    {
                        EmployeeID = 2,
                        FirstName = "Zainab",
                        LastName = "Al-Farsi",
                        DepartmentID = 2,
                    }
                );
        }
    }
}
