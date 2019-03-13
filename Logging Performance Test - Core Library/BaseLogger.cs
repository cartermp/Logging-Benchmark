using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Logging_Performance_Test___Core_Library
{
    public class BaseLogger : ILogger
    {
        private List<string> messages = new List<string>(10000);
        
        public void Log(LoggerLevel level, string msg)
        {
            messages.Add(msg);
        }
        
        public void Log<T>(LoggerLevel level, T obj)
        {
            messages.Add(obj.ToString());
        }
    }
}
