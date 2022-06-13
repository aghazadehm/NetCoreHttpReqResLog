using Microsoft.EntityFrameworkCore;

namespace WebApi.Logging
{
    public class LoggerDbContext : DbContext
    {
        public LoggerDbContext(DbContextOptions<LoggerDbContext> options) : base(options)
        {
        }

        public DbSet<ReqResLog> ReqResLogs { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
    }
}
