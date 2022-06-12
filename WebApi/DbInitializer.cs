using WebApi.Logging;

public static class DbInitializer
    {
        public static void Initialize(LoggerDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
