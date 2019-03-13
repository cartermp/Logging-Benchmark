using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Logging_Performance_Test___Core_Library;
using Logging_Performance_Test___Core_Library___FS;

namespace Logging_Performance_Test___Core
{
    [MemoryDiagnoser]
    public class BaseLoggerBenchmark
    {
        private const int COUNT = 10000;

        [Benchmark]
        public void LogDirect()
        {
            var logger = new BaseLogger();
            DoWork(logger);
        }

        private static void DoWork(BaseLogger logger)
        {
            for (var i = 0; i < COUNT; i++)
                logger.Log(LoggerLevel.Information, "Test");
        }
        
        [Benchmark]
        public void LogDirectFs()
        {
            var logger = new Logger();
            DoWork(logger);
        }

        private static void DoWork(Logger logger)
        {
            for (var i = 0; i < COUNT; i++)
                logger.Log(LoggerLevel.Information, "Test");
        }

        [Benchmark(Baseline = true)]
        public void LogViaInjection()
        {
            ILogger logger = new BaseLogger();
            DoWork(logger);
        }

        [Benchmark]
        public void LogViaInjectionFs()
        {
            ILogger logger = new Logger();
            DoWork(logger);
        }

        private static void DoWork(ILogger logger)
        {
            for (var i = 0; i < COUNT; i++)
                logger.Log(LoggerLevel.Information, "Test");
        }

        [Benchmark]
        public void LogViaCallback()
        {
            Action<LoggerLevel, string> logger = new BaseLogger().Log;
            DoWork(logger);
        }

        [Benchmark]
        public void LogViaCallbackFs()
        {
            Action<LoggerLevel, string> logger = new Logger().Log;
            DoWork(logger);
        }

        private static void DoWork(Action<LoggerLevel, string> logger)
        {
            for (var i = 0; i < COUNT; i++)
                logger(LoggerLevel.Information, "Test");
        }

        [Benchmark]
        public void LogObjDirect()
        {
            var logger = new BaseLogger();
            var o = new Guid();
            DoWork(logger, o);
        }

        private static void DoWork(BaseLogger logger, Guid o)
        {
            for (var i = 0; i < COUNT; i++)
                logger.Log(LoggerLevel.Information, o);
        }

        [Benchmark]
        public void LogObjDirectFs()
        {
            var logger = new Logger();
            var o = new Guid();
            DoWork(logger, o);
        }

        private static void DoWork(Logger logger, Guid o)
        {
            for (var i = 0; i < COUNT; i++)
                logger.Log(LoggerLevel.Information, o);
        }

        [Benchmark]
        public void LogObjViaInjection()
        {
            ILogger logger = new BaseLogger();
            var o = new Guid();
            DoWork(logger, o);
        }

        [Benchmark]
        public void LogObjViaInjectionFs()
        {
            ILogger logger = new Logger();
            var o = new Guid();
            DoWork(logger, o);
        }

        private static void DoWork(ILogger logger, Guid o)
        {
            for (var i = 0; i < COUNT; i++)
                logger.Log(LoggerLevel.Information, o);
        }
        
        [Benchmark]
        public void LogObjViaCallback()
        {
            Action<LoggerLevel, Guid> logger = new BaseLogger().Log;
            var o = new Guid();
            DoWork(logger, o);
        }

        [Benchmark]
        public void LogObjViaCallbackFs()
        {
            Action<LoggerLevel, Guid> logger = new Logger().Log;
            var o = new Guid();
            DoWork(logger, o);
        }

        private static void DoWork(Action<LoggerLevel, Guid> logger, Guid o)
        {
            for (var i = 0; i < COUNT; i++)
                logger(LoggerLevel.Information, o);
        }

        [Benchmark]
        public void LogInlineDirect()
        {
            var logger = new BaseLogger();
            for (var i = 0; i < COUNT; i++)
                logger.Log(LoggerLevel.Information, "Test");
        }

        [Benchmark]
        public void LogInlineDirectFs()
        {
            var logger = new Logger();
            for (var i = 0; i < COUNT; i++)
                logger.Log(LoggerLevel.Information, "Test");
        }

        [Benchmark]
        public void LogInlineViaInjection()
        {
            ILogger logger = new BaseLogger();
            for (var i = 0; i < COUNT; i++)
                logger.Log(LoggerLevel.Information, "Test");
        }

        [Benchmark]
        public void LogInlineViaInjectionFs()
        {
            ILogger logger = new Logger();
            for (var i = 0; i < COUNT; i++)
                logger.Log(LoggerLevel.Information, "Test");
        }

        [Benchmark]
        public void LogInlineViaCallback()
        {
            Action<LoggerLevel, string> logger = new BaseLogger().Log;
            for (var i = 0; i < COUNT; i++)
                logger(LoggerLevel.Information, "Test");
        }

        [Benchmark]
        public void LogInlineViaCallbackFs()
        {
            Action<LoggerLevel, string> logger = new Logger().Log;
            for (var i = 0; i < COUNT; i++)
                logger(LoggerLevel.Information, "Test");
        }

        [Benchmark]
        public void LogInlineDynamicDirect()
        {
            dynamic logger = new BaseLogger();
            for (var i = 0; i < COUNT; i++)
                logger.Log(LoggerLevel.Information, "Test");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var benchmark = BenchmarkRunner.Run<BaseLoggerBenchmark>();
            Console.ReadLine();
        }
    }
}
