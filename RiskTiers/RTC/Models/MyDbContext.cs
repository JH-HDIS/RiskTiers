using Microsoft.EntityFrameworkCore;
using RTC.Models;

namespace RTC.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<UserResponse> UserResponses { get; set; }
        // Add DbSets for other entities as needed
    }
}
