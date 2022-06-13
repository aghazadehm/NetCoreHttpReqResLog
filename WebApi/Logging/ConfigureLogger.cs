using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace WebApi.Logging
{
    public static class ConfigureLogger
    {
        public static void Config(this IApplicationBuilder app, string connectionString)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.MSSqlServer(
                connectionString: connectionString,
                sinkOptions: new MSSqlServerSinkOptions { TableName = "LogEvents" })
                .CreateLogger();
        }
    }
}
