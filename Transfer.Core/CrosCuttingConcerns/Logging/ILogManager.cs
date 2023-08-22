using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfer.Core.CrosCuttingConcerns.Logging
{
    public interface ILogManager
    {
        public void LogDebug(string message);

        public void LogError(string message);

        public void LogInfo(string message) ;

        public void LogWarning(string message);
    }
}
