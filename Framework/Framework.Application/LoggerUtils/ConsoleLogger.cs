using Serilog;
using Serilog.Sinks.SystemConsole.Themes;


namespace Framework.Application.LoggerUtils;
public static class ConsoleLogger
{
    public static ILogger Logger { get; private set; }

    public static void Configure()
    {
        var customTheme = new AnsiConsoleTheme(new Dictionary<ConsoleThemeStyle, string>
        {
            [ConsoleThemeStyle.Text] = "\u001b[37m",
            [ConsoleThemeStyle.LevelInformation] = "\u001b[32m",
            [ConsoleThemeStyle.LevelError] = "\u001b[31m"
        });

        Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console(theme: customTheme,
                outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();
    }
}