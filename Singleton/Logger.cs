using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton;

//thread Safe version
public class TSLogger {
    private static readonly Lazy<TSLogger> _lazyLogger = new(() => new TSLogger());

    private TSLogger() {
    }

    public static TSLogger? Instance {
        get {
            return _lazyLogger.Value;
        }
    }
    //singleton operation
    public void Log(string message) {
        Console.WriteLine($"Loging --- {message}");
    }
}
//
public class Logger {
    private static Logger? _instance { get; set; }

    private Logger() {
    }

    public static Logger? Instance {
        get {
            if (_instance == null) {
                _instance = new();
                return _instance;
            }
            return _instance;
        }
    }
    //singleton operation
    public void Log(string message) {
        Console.WriteLine($"Loging --- {message}");
    }
}
