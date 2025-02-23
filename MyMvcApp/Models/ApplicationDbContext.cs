using Microsoft.EntityFrameworkCore;

namespace MyMvcApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; } // students 
        public DbSet<Employee> Employees { get; set; } // employees
        public DbSet<Leave> Leaves { get; set; } // leave requests
        public DbSet<Admin> Admins { get; set; } // admin
        public DbSet<Payslip> Payslips { get; set; } // payslip
        public DbSet<User> Users { get; set; } // employees
    }
}
