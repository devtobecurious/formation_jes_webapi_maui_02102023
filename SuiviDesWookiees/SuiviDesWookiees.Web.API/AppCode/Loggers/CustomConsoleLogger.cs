namespace SuiviDesWookiees.Web.API.AppCode.Loggers
{
    public record CustomConsoleCOnfig(ConsoleColor Color);

    public class CustomConsoleLogger : ILogger
    {
        private readonly Func<CustomConsoleCOnfig> config;

        public CustomConsoleLogger(Func<CustomConsoleCOnfig> config)
        {
            this.config = config;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            var configResult = config();
            Console.ForegroundColor = configResult.Color;
            Console.WriteLine($"{eventId}");

        }
    }

    [ProviderAlias("CustomConsole")]
    public class CustomConsoleLoggerProvider : ILoggerProvider
    {
        public CustomConsoleLoggerProvider(Func<CustomConsoleCOnfig> config)
        {
            Config = config;
        }

        public Func<CustomConsoleCOnfig> Config { get; }

        public ILogger CreateLogger(string categoryName)
        {
            return new CustomConsoleLogger(Config);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
