// Exercism practica 12 Isandel Abreu

//Logs, Logs, Logs!

public enum LogLevel
{
    Unknown = 0,
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42
}

static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine)
    {
        var level = logLine[1..4];
        return level switch
        {
            "TRC" => LogLevel.Trace,
            "DBG" => LogLevel.Debug,
            "INF" => LogLevel.Info,
            "WRN" => LogLevel.Warning,
            "ERR" => LogLevel.Error,
            "FTL" => LogLevel.Fatal,
            _ => LogLevel.Unknown
        };
    }

    public static string OutputForShortLog(LogLevel logLevel, string message) => $"{(int)logLevel}:{message}";
}

class Program
{
    static void Main()
    {
        string log1 = "[INF] System started";
        string log2 = "[ERR] Connection failed";
        string log3 = "[FTL] Critical error";

        LogLevel level1 = LogLine.ParseLogLevel(log1);
        LogLevel level2 = LogLine.ParseLogLevel(log2);
        LogLevel level3 = LogLine.ParseLogLevel(log3);

        Console.WriteLine("Log 1: " + level1);
        Console.WriteLine("Log 2: " + level2);
        Console.WriteLine("Log 3: " + level3);

        Console.WriteLine(
            LogLine.OutputForShortLog(
                LogLevel.Error,
                "Something went wrong"));
    }
}