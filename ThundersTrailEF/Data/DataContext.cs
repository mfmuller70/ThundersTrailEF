using Microsoft.EntityFrameworkCore;
using ThundersTrailEF.Models;

namespace ThundersTrailEF.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; } = default!;

        public DbSet<Office> Offices { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Office>().HasData(
                new Office {  OfficeId= 1,  OfficeName = "IT"},
                new Office { OfficeId = 2, OfficeName = "HR" },
                new Office { OfficeId = 3, OfficeName = "Cloud" },
                new Office { OfficeId = 4, OfficeName = "Compliance" }
            );
            modelBuilder.Entity<Employee>()
                .Property(b => b.CreateDate)
                .HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<Employee>()
                .Property(b => b.CreatedBy)
                .HasDefaultValue(1);
            modelBuilder.Entity<Employee>()
                .Property(b => b.UpdatedBy)
                .HasDefaultValue(null);
            modelBuilder.Entity<Employee>()
             .Property(b => b.UpdatedDate)
             .HasDefaultValue(null);
        }
    }
}
