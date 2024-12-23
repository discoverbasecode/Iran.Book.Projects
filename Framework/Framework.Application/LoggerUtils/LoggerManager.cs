using Serilog.Events;

namespace Framework.Application.LoggerUtils;

public static class LoggerManager
{
    public static void ConfigureAllLoggers()
    {
        ConsoleLogger.Configure();
        FileLogger.Configure();
        MongoLogger.Configure();
    }

    /// <summary>
    /// Create Log to Console By Theme Custom
    /// </summary>
    /// <param name="level"></param>
    /// <param name="message"></param>
    /// <param name="ex"></param>
    public static void LogToConsole(LogEventLevel level, string message, Exception? ex = null) =>
        ConsoleLogger.Logger?.Write(level, ex, message);

    /// <summary>
    /// Create Log and Save Log to File -> JSON
    /// </summary>
    /// <param name="level"></param>
    /// <param name="message"></param>
    /// <param name="ex"></param>
    public static void LogToFile(LogEventLevel level, string message, Exception? ex = null) =>
        FileLogger.Logger?.Write(level, ex, message);

    /// <summary>
    /// Create Log and Save To Mongo DB
    /// </summary>
    /// <param name="level"></param>
    /// <param name="message"></param>
    /// <param name="ex"></param>
    public static void LogToMongo(LogEventLevel level, string message, Exception? ex = null) =>
        MongoLogger.Logger?.Write(level, ex, message);

}


//LoggerManager.ConfigureAllLoggers();

// ارسال لاگ به Console
//LoggerManager.LogToConsole(LogEventLevel.Information, "پیام اطلاعاتی به Console");

// ارسال لاگ به فایل
//LoggerManager.LogToFile(LogEventLevel.Warning, "هشدار به فایل");

// ارسال لاگ به MongoDB
//LoggerManager.LogToMongo(LogEventLevel.Error, "خطا در MongoDB", new Exception("جزئیات خطا"));
