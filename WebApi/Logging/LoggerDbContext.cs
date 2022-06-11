using Microsoft.EntityFrameworkCore;

namespace WebApi.Logging
{
    public class LoggerDbContext : DbContext
    {
        public LoggerDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Log> Logs { get; set; }
    }
}
