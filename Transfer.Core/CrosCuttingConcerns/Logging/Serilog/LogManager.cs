using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfer.Core.CrosCuttingConcerns.Logging.NLog
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
