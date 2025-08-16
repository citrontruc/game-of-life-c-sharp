/* An object to log information from multiple sources. */

using Microsoft.Extensions.Logging;

namespace Logger
{
    public class Logger
    {
        private static ILoggerFactory? _loggerFactory;

        // Initialize once for the whole app
    public static void Initialize(string programName)
    {
        _loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                .AddConsole()
                .SetMinimumLevel(LogLevel.Information);
        });

        Console.WriteLine($"Logger initialized for: {programName}");
    }

    // Create a typed logger for any class/program
    public static ILogger CreateLogger<T>() =>
        _loggerFactory?.CreateLogger<T>() 
        ?? throw new InvalidOperationException("Logger not initialized. Call Logger.Initialize first.");
    }
}