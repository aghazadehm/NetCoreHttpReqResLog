using Microsoft.EntityFrameworkCore;

namespace WebApi.Logging
{
    public class LoggerRepository : ILoggerRepository
    {
        private readonly LoggerDbContext _loggerDbContext;

        public LoggerRepository(IDbContextFactory<LoggerDbContext> dbContextFactory)
        {
            _loggerDbContext = dbContextFactory.CreateDbContext();
        }
        public void Add(Log log)
        {
            _loggerDbContext.Add(log);
            _loggerDbContext.SaveChanges();
        }

        public List<Log> GetAll()
        {
            return _loggerDbContext.Logs.ToList();
        }
    }
}
