using PostSharp.Aspects;
using PostSharp.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Transfer.Core.CrosCuttingConcerns.Logging;

namespace Transfer.Core.CrosCuttingConcerns.Aspects.PostSharp.LogAspects
{
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Method, TargetMemberAttributes = MulticastAttributes.Instance)]
    public class LogAspect : MethodInterceptionAspect
    {
        private Type _loggerType;
        private readonly ILogManager _logManager;
        public LogAspect(Type loggerType)
        {
            _loggerType = loggerType;
            _logManager = (ILogManager)Activator.CreateInstance(_loggerType);
        }
        public override void RuntimeInitialize(MethodBase method)
        {
            _logManager.LogInfo($"Initializing  Method  : {method.Name}");
            base.RuntimeInitialize(method);
        }
        public override Task OnInvokeAsync(MethodInterceptionArgs args)
        {
            _logManager.LogInfo($"Method Parameters ");
            foreach (var item in args.Arguments)
            {
                _logManager.LogInfo($"Method parameters : type | {item.GetType()} | value : {item}");
            }
            return base.OnInvokeAsync(args);
        }

    }
}
