using NLog;
using NLog.Config;
using NLog.Fluent;
using NLog.Layouts;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIdea.Logger
{
    //public class Logger
    //{
    //    //https://habr.com/ru/articles/450728/
    //    //https://stackoverflow.com/questions/66530857/nlog-in-different-versions-for-multiple-projects
    //    private static NLog.Logger logger = LogManager.GetLogger("");//LogManager.GetCurrentClassLogger();
    //    void t()
    //    {
    //        //logger.Error()
    //    }
    //}
    //https://habr.com/ru/articles/498978/
    //https://csharp.hotexamples.com/ru/examples/NLog.Targets/FileTarget/-/php-filetarget-class-examples.html
    //https://csharp.hotexamples.com/ru/examples/NLog.Targets/FileTarget/-/php-filetarget-class-examples.html
    public class MyIdeaLogger //: NLog.Logger
    {
        ILogger _logger;
        public MyIdeaLogger(ILogger l)
        {
            _logger = l;
        }

        public string Name { get { return _logger.Name; } }

        #region
        public void Debug(object message)
        {
            _logger.Debug(message);
        }


        public void Debug(object message, Exception exception)
        {
            _logger.Debug(message.ToString(), exception);
        }


        public void DebugFormat(string format, params object[] args)
        {
            _logger.Debug(format, args);
        }


        public void DebugFormat(string format, object arg0)
        {
            _logger.Debug(format, arg0);
        }


        public void DebugFormat(string format, object arg0, object arg1)
        {
            _logger.Debug(format, arg0, arg1);
        }

        public void DebugFormat(string format, object arg0, object arg1, object arg2)
        {
            _logger.Debug(format, arg0, arg1, arg2);
        }


        public void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            _logger.Debug(provider, format, args);
        }

        public void Info(object message)
        {
            _logger.Info(message);
        }


        public void Info(object message, Exception exception)
        {
            _logger.Info(message.ToString(), exception);
        }


        public void InfoFormat(string format, params object[] args)
        {
            _logger.Info(format, args);
        }

        public void InfoFormat(string format, object arg0)
        {
            _logger.Info(format, arg0);
        }

        public void InfoFormat(string format, object arg0, object arg1)
        {
            _logger.Info(format, arg0, arg1);
        }

        public void InfoFormat(string format, object arg0, object arg1, object arg2)
        {
            _logger.Info(format, arg0, arg1, arg2);
        }

        public void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            _logger.Info(provider, format, args);
        }

        public void Warn(object message)
        {
            _logger.Warn(message);
        }

        public void Warn(object message, Exception exception)
        {
            _logger.Warn(message.ToString(), exception);
        }


        public void WarnFormat(string format, params object[] args)
        {
            _logger.Warn(format, args);
        }


        public void WarnFormat(string format, object arg0)
        {
            _logger.Warn(format, arg0);
        }
        public void WarnFormat(string format, object arg0, object arg1)
        {
            _logger.Warn(format, arg0, arg1);
        }


        public void WarnFormat(string format, object arg0, object arg1, object arg2)
        {
            _logger.Warn(format, arg0, arg1, arg2);
        }

        //public static void Notice(string message)
        //{
        //    log..Notice(message);
        //}

        //public static void NoticeFormat(string message, params object[] args)
        //{
        //    log.Notice(message, args);
        //}


        public void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            _logger.Warn(provider, format, args);
        }

        public void Error(object message)
        {
            _logger.Error(message);
        }


        public void Error(object message, Exception exception)
        {
            _logger.Error(message.ToString(), exception);
        }


        public void ErrorFormat(string format, params object[] args)
        {
            _logger.Error(format, args);
        }


        public void ErrorFormat(string format, object arg0)
        {
            _logger.Error(format, arg0);
        }

        public void ErrorFormat(string format, object arg0, object arg1)
        {
            _logger.Error(format, arg0, arg1);
        }

        public void ErrorFormat(string format, object arg0, object arg1, object arg2)
        {
            _logger.Error(format, arg0, arg1, arg2);
        }


        public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            _logger.Error(provider, format, args);
        }

        public void Fatal(object message)
        {
            _logger.Fatal(message);
        }

        public void Fatal(object message, Exception exception)
        {
            _logger.Fatal(message.ToString(), exception);
        }

        public void FatalFormat(string format, params object[] args)
        {
            _logger.Fatal(format, args);
        }


        public void FatalFormat(string format, object arg0)
        {
            _logger.Fatal(format, arg0);
        }


        public void FatalFormat(string format, object arg0, object arg1)
        {
            _logger.Fatal(format, arg0, arg1);
        }


        public void FatalFormat(string format, object arg0, object arg1, object arg2)
        {
            _logger.Fatal(format, arg0, arg1, arg2);
        }


        public void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            _logger.Fatal(provider, format, args);
        }


        public bool IsDebugEnabled
        {
            get
            {
                return _logger.IsDebugEnabled;
            }
        }


        public bool IsInfoEnabled
        {
            get
            {
                return _logger.IsInfoEnabled;
            }
        }


        public bool IsWarnEnabled
        {
            get
            {
                return _logger.IsWarnEnabled;
            }
        }


        public bool IsErrorEnabled
        {
            get
            {
                return _logger.IsErrorEnabled;
            }
        }


        public bool IsFatalEnabled
        {
            get
            {
                return _logger.IsFatalEnabled;
            }
        }

        #endregion






        public static string LogFileName
        {
            get { return _logFileName; }
            set
            {
                _logFileName = value;
                InitLogging();
            }
        }
        private static string _logFileName;
        private static LoggingConfiguration _logConfig = null;
        //private static LogFactory MyIdeaLogFactory()
        //{
        //    LoggingConfiguration config = _logConfig ?? new LoggingConfiguration();
        //    Layout header = "Heder";
        //    Layout layout = "${longdate} [${callsite:className=true:includeNamespace=true:fileName=false:includeSourcePath=false:methodName=true:cleanNamesOfAnonymousDelegates=true:cleanNamesOfAsyncContinuations=true}] -> ${level:format=FirstCharacter} : ${message}${onexception:inner=${newline}${exception:format=@}}";

        //    #region FileTarget ----------------------------

        //    //Target fileTarget = NLog.Targets.FileTarget(header, layout).MakeAsyncTarget();
        //    var fileTarget = new FileTarget();
        //    fileTarget.

        //    config.AddTarget(fileTarget);
        //    config.AddRuleForAllLevels(fileTarget);

        //    #endregion


        //    LogFactory logFactory = new LogFactory
        //    {
        //        Configuration = config
        //    };

        //    return logFactory;
        //}

        private static void InitLogging()
        {
            var config = new LoggingConfiguration();

            var consoleTarget = new ColoredConsoleTarget();
            config.AddTarget("console", consoleTarget);

            consoleTarget.Layout = @"[${date:format=HH\:mm\:ss.fff}] ${logger} >> ${message}";

            var consoleRule = new LoggingRule("*", LogLevel.Trace, consoleTarget);
            config.LoggingRules.Add(consoleRule);

            var fileTarget = new FileTarget();
            config.AddTarget("file", fileTarget);

            fileTarget.FileName = "${basedir}/" + _logFileName;
            fileTarget.Layout = @"${date} [${logger}] ${level} - ${message}";
            //@"%date [%logger] [%thread] %-5level - %message%newline";
            //fileTarget.ArchiveFileName = "${basedir}/GrooveCaster.{#}.log";
            fileTarget.ArchiveEvery = FileArchivePeriod.Day;
            fileTarget.ArchiveNumbering = ArchiveNumberingMode.Date;
            //fileTarget.ArchiveDateFormat = "yyyMMdd";

            var fileRule = new LoggingRule("*", LogLevel.Trace, fileTarget);
            config.LoggingRules.Add(fileRule);

            LogManager.Configuration = config;
        }


        private static readonly List<MyIdeaLogger> CurrentLoggers = new List<MyIdeaLogger>();

        private static Object getLoggerLock = new object();
        public static MyIdeaLogger GetLogger(string name)
        {
            MyIdeaLogger logger;
            lock (getLoggerLock)
            {
                foreach (MyIdeaLogger c in CurrentLoggers)
                {
                    if (string.Compare(c.Name, name, false) == 0)
                        return c;
                }

                ILogger l = LogManager.GetLogger(name);

                logger = new MyIdeaLogger(l);
                CurrentLoggers.Add(logger);
            }
            return logger;
        }
    }


   


}
