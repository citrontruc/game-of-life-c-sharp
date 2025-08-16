// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Logging;
using Logger;

Console.WriteLine("Hello, World!");
Logger.Logger.Initialize("TestApp");
ProgramA.Run();

class ProgramA
{
    private static readonly ILogger _logger = Logger.Logger.CreateLogger<ProgramA>();

    public static void Run()
    {
        _logger.LogInformation("Program A started.");
    }
}


