/* An object to log information from multiple sources. */

using Microsoft.Extensions.Logging;

public class Logger
{
    private static ILoggerFactory _loggerFactory = LoggerFactory.Create(builder =>
    {
        builder
            .AddConsole()
            .SetMinimumLevel(LogLevel.Information);
    });

    // Create a typed logger for any class/program
    public static ILogger CreateLogger<T>()
    {
        return _loggerFactory.CreateLogger<T>();
    }
}