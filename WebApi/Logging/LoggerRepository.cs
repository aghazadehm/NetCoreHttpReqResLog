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

        public void AddErrorLog(ErrorLog errorLog)
        {
            _loggerDbContext.ErrorLogs.Add(errorLog);
        }

        public void AddReqResLog(ReqResLog log)
        {
            _loggerDbContext.ReqResLogs.Add(log);
            _loggerDbContext.SaveChanges();
        }

        public List<ReqResLog> GetAllReqResLogs()
        {
            return _loggerDbContext.ReqResLogs.ToList();
        }

        public List<ErrorLog> GetErrorLogs()
        {
            return _loggerDbContext.ErrorLogs.ToList();
        }
    }
}
