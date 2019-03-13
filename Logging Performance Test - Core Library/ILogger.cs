using System;

namespace Logging_Performance_Test___Core_Library
{
    public interface ILogger
    {
        void Log(LoggerLevel level, string msg);
        void Log<T>(LoggerLevel level, T obj);
    }
}
