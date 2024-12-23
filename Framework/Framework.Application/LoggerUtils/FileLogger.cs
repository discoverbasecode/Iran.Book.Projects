using Serilog;
using Serilog.Formatting.Compact;


public static class FileLogger
{
    public static ILogger Logger { get; private set; }

    public static void Configure()
    {
        Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.File(
                new CompactJsonFormatter(),
                "logs/log-.json",
                rollingInterval: Serilog.RollingInterval.Day,
                retainedFileCountLimit: 7
            )
            .CreateLogger();
    }
}