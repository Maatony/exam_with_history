using Microsoft.EntityFrameworkCore;
using ExamOrientation.Models;

namespace ExamOrientation.Databases
{
    public class OEDb : DbContext
    {
        public DbSet<User> Users { get; set; }

        public OEDb(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // FLUENT API
            // Properties of User table
            modelBuilder.Entity<User>().HasKey(u => u.Username);
            modelBuilder.Entity<User>().Property(p => p.Username).HasColumnType("varchar(30)").IsRequired();
            modelBuilder.Entity<User>().HasMany(m => m.Messages).WithOne(u => u.User);
            
            // Properties of Message table
            modelBuilder.Entity<Message>().HasKey(m => m.Id);
            
            // Properties of Log table
            modelBuilder.Entity<Log>().HasKey(l => l.Id); 
        }
    }
}

