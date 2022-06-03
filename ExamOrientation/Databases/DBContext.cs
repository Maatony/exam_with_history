using Microsoft.EntityFrameworkCore;
using ExamOrientation.Models;

namespace ExamOrientation.Databases
{
    public class OEDb : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Report> Reports { get; set; }

        public OEDb(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // FLUENT API
            // Properties of User table
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().Property(u => u.Name).HasColumnType("varchar(30)").IsRequired();
            modelBuilder.Entity<User>().HasMany(r => r.Reports).WithOne(u => u.Reporter);
            
            // Properties of Report table
            modelBuilder.Entity<Report>().HasKey(r => r.Id);
            modelBuilder.Entity<Report>().Property(r => r.Manufacturer).HasColumnType("varchar(50)").IsRequired();
            modelBuilder.Entity<Report>().Property(r => r.SerialNumber).IsRequired();
            modelBuilder.Entity<Report>().Property(r => r.Handler).IsRequired();
        }
    }
}

