using Microsoft.EntityFrameworkCore;
using RTC.Models;

namespace RTC.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserResponse> UserResponses { get; set; }
    }
}
