namespace WebApi.Logging
{
    public interface ILoggerRepository
    {
        void AddReqResLog(ReqResLog log);
        void AddErrorLog(ErrorLog errorLog);
        List<ReqResLog> GetAllReqResLogs();
    }
}
