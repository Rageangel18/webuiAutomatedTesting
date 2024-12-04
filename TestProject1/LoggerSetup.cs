using Serilog;
using System;

public class LoggerSetup
{
    public static void ConfigureLogger()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {Message}{NewLine}{Exception}")
            .WriteTo.File("test_logs.txt", rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}")
            .CreateLogger();

        Console.WriteLine("Logger set up completed");
    }
}