using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace CMCapital.API
{
    public class Log4NetProvider : ILoggerProvider
    {
        private ConcurrentDictionary<string, ILogger> _loggers = new ConcurrentDictionary<string, ILogger>();

        public ILogger CreateLogger(string name)
        {
            return _loggers.GetOrAdd(name, n => new Log4NetAdapter(n));
        }

        public void Dispose()
        {
            _loggers.Clear();
            _loggers = null;
        }
    }
}