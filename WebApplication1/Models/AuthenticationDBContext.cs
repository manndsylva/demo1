using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//using WebApplication2.Models.Domain;
using Web1.Models;
//using Microsoft.CodeAnalysis.Options;
namespace Web1.Models

{
    public class AuthenticationDBContext : IdentityDbContext<IdentityUser>
    {
        public AuthenticationDBContext(DbContextOptions<AuthenticationDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);
        }
        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Name = "Admin",
                    ConcurrencyStamp = "1",
                    NormalizedName = "Admin"
                },
                new IdentityRole()
                {
                    Name = "User",
                    ConcurrencyStamp = "2",
                    NormalizedName = "USer"
                },
                new IdentityRole()
                {
                    Name = "HR",
                    ConcurrencyStamp = "3",
                    NormalizedName = "HR"
                });
        }
    }
}
