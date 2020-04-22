using Microsoft.EntityFrameworkCore;
using WebAPIOData.Models;

namespace WebAPIOData.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(x => x.UserClaims).WithOne(x => x.User);

            modelBuilder.Entity<User>().HasData(new User { Id = 1, Name = "John Smith" });
            modelBuilder.Entity<UserClaim>().HasData(
                new UserClaim  { Id = 1, Type = "ClaimType1", Value = "ClaimValue1", UserId = 1 },
                new UserClaim  { Id = 2, Type = "ClaimType2", Value = "ClaimValue2", UserId = 1 }
                );
        }
    }
}
