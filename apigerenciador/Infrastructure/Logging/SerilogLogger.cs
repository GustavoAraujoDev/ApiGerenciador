using Serilog;
using Serilog.Settings.Configuration;
using System;
using apigerenciador.Infrastructure.Logging;
using System.Configuration;

namespace apigerenciador.Infrastructure.Logging
{
    public class SerilogLogger : ILogger
    {
        private readonly Serilog.ILogger _logger;

        public SerilogLogger()
        {
            // Configuração do Serilog
            _logger = new LoggerConfiguration()
                        .MinimumLevel.Information()  // Define o nível de log mínimo
                        .WriteTo.Console()           // Sinks de log para Console
                        .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day) // Arquivo de log com rotação diária
                        .CreateLogger();
        }

        public void LogInfo(string message)
        {
            _logger.Information(message);
        }

        public void LogError(string message, Exception exception)
        {
            _logger.Error(exception, message);
        }
    }
}
