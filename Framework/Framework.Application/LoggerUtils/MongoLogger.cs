using Serilog;

namespace Framework.Application.LoggerUtils;

public static class MongoLogger
{
    public static ILogger Logger { get; private set; }

    public static void Configure()
    {
        Logger = new LoggerConfiguration()
            .MinimumLevel.Warning()
            .WriteTo.MongoDB("mongodb://localhost:27017/logs", collectionName: "logEvents")
            .CreateLogger();
    }
}
