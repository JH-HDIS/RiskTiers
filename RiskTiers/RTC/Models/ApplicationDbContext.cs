using Microsoft.EntityFrameworkCore;

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
