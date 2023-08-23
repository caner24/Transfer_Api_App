using Serilog;
namespace Transfer.Core.CrosCuttingConcerns.Logging.Serilog
{
    public class LogManager : ILogManager
    {
        public void LogDebug(string message)
        {
            Log.Debug(message);
        }

        public void LogError(string message)
        {
            Log.Error(message);
        }

        public void LogInfo(string message)
        {
            Log.Information(message);
        }

        public void LogWarning(string message)
        {
            Log.Warning(message);
        }
    }
}
