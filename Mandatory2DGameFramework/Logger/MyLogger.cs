using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mandatory2DGameFramework.Logger.LogLevel;

namespace Mandatory2DGameFramework.Logger
{
    public class MyLogger
    {
        // Singleton instance 
        private static MyLogger? _instance;
        // Thread safety
        private static readonly object _lock = new object();
        private List<TraceListener> _listeners;

        internal MyLogger()
        {
            _listeners = new List<TraceListener>();
        }

        // Get af Singleton
        public static MyLogger Instance
        {
            get
            {
                // Double check lock, for at sikre thread-safety
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new MyLogger();
                        }
                    }
                }
                return _instance;
            }
        }

        public void AddListener(TraceListener listener)
        {
            if (!_listeners.Contains(listener))
            {
                _listeners.Add(listener);
            }
        }

        public void RemoveListener(TraceListener listener)
        {
            _listeners.Remove(listener);
        }

        public void Log(string message, LogLevel level = LogLevel.Info)
        {
            string formattedMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}";
            foreach (var listener in _listeners)
            {
                listener.WriteLine(formattedMessage);
                listener.Flush();
            }
        }

        internal static MyLogger GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new MyLogger();
                    }
                }
                
            }
            return _instance;
        }

        public void LogInfo(string message) => Log(message, LogLevel.Info);
        public void LogWarning(string message) => Log(message, LogLevel.Warning);
        public void LogError(string message) => Log(message, LogLevel.Error);
        public void LogDebug(string message) => Log(message, LogLevel.Debug);
        
    }
}
