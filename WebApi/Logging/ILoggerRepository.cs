namespace WebApi.Logging
{
    public interface ILoggerRepository
    {
        void Add(Log log);
        List<Log> GetAll();
    }
}
