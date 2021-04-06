using Microsoft.EntityFrameworkCore;

namespace api.Entities
{
    public class LostDbContext: DbContext
    {
        private string _connectionString = @"Server=localhost\SQLEXPRESS;Database=LostApi;Trusted_Connection=true;";
        public DbSet<Lost> Lost { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<Role>()
                .Property(r => r.Name)
                .IsRequired();

            modelBuilder.Entity<Lost>()
                .Property(l => l.FirstName)
                .IsRequired();
            
            
            modelBuilder.Entity<Lost>()
                .Property(l => l.SecondName)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}