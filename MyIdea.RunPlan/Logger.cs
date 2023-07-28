using MyIdea.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIdea.RunPlan
{
    internal static class Logger
    {
        public static MyIdeaLogger log = MyIdeaLogger.GetLogger("SERV"); 

        public static MyIdeaLogger GetLogger()
        {
            return log;
        }


        public static void Debug(object message)
        {
            log.Debug(message);
        }


        public static void Debug(object message, Exception exception)
        {
            log.Debug(message.ToString(), exception);
        }


        public static void DebugFormat(string format, params object[] args)
        {
            log.DebugFormat(format, args);
        }


        public static void DebugFormat(string format, object arg0)
        {
            log.DebugFormat(format, arg0);
        }


        public static void DebugFormat(string format, object arg0, object arg1)
        {
            log.DebugFormat(format, arg0, arg1);
        }

        public static void DebugFormat(string format, object arg0, object arg1, object arg2)
        {
            log.DebugFormat(format, arg0, arg1, arg2);
        }


        public static void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            log.DebugFormat(provider, format, args);
        }

        public static void Info(object message)
        {
            log.Info(message);
        }


        public static void Info(object message, Exception exception)
        {
            log.Info(message.ToString(), exception);
        }


        public static void InfoFormat(string format, params object[] args)
        {
            log.InfoFormat(format, args);
        }

        public static void InfoFormat(string format, object arg0)
        {
            log.InfoFormat(format, arg0);
        }

        public static void InfoFormat(string format, object arg0, object arg1)
        {
            log.InfoFormat(format, arg0, arg1);
        }

        public static void InfoFormat(string format, object arg0, object arg1, object arg2)
        {
            log.InfoFormat(format, arg0, arg1, arg2);
        }

        public static void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            log.InfoFormat(provider, format, args);
        }

        public static void Warn(object message)
        {
            log.Warn(message);
        }

        public static void Warn(object message, Exception exception)
        {
            log.Warn(message.ToString(), exception);
        }


        public static void WarnFormat(string format, params object[] args)
        {
            log.WarnFormat(format, args);
        }


        public static void WarnFormat(string format, object arg0)
        {
            log.WarnFormat(format, arg0);
        }
        public static void WarnFormat(string format, object arg0, object arg1)
        {
            log.WarnFormat(format, arg0, arg1);
        }


        public static void WarnFormat(string format, object arg0, object arg1, object arg2)
        {
            log.WarnFormat(format, arg0, arg1, arg2);
        }

        //public static void Notice(string message)
        //{
        //    log..Notice(message);
        //}

        //public static void NoticeFormat(string message, params object[] args)
        //{
        //    log.Notice(message, args);
        //}


        public static void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            log.WarnFormat(provider, format, args);
        }

        public static void Error(object message)
        {
            log.Error(message);
        }


        public static void Error(object message, Exception exception)
        {
            log.Error(message.ToString(), exception);
        }


        public static void ErrorFormat(string format, params object[] args)
        {
            log.ErrorFormat(format, args);
        }


        public static void ErrorFormat(string format, object arg0)
        {
            log.ErrorFormat(format, arg0);
        }

        public static void ErrorFormat(string format, object arg0, object arg1)
        {
            log.ErrorFormat(format, arg0, arg1);
        }

        public static void ErrorFormat(string format, object arg0, object arg1, object arg2)
        {
            log.ErrorFormat(format, arg0, arg1, arg2);
        }


        public static void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            log.ErrorFormat(provider, format, args);
        }

        public static void Fatal(object message)
        {
            log.Fatal(message);
        }

        public static void Fatal(object message, Exception exception)
        {
            log.Fatal(message.ToString(), exception);
        }

        public static void FatalFormat(string format, params object[] args)
        {
            log.FatalFormat(format, args);
        }


        public static void FatalFormat(string format, object arg0)
        {
            log.FatalFormat(format, arg0);
        }


        public static void FatalFormat(string format, object arg0, object arg1)
        {
            log.FatalFormat(format, arg0, arg1);
        }


        public static void FatalFormat(string format, object arg0, object arg1, object arg2)
        {
            log.FatalFormat(format, arg0, arg1, arg2);
        }


        public static void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            log.FatalFormat(provider, format, args);
        }


        public static bool IsDebugEnabled
        {
            get
            {
                return log.IsDebugEnabled;
            }
        }


        public static bool IsInfoEnabled
        {
            get
            {
                return log.IsInfoEnabled;
            }
        }


        public static bool IsWarnEnabled
        {
            get
            {
                return log.IsWarnEnabled;
            }
        }


        public static bool IsErrorEnabled
        {
            get
            {
                return log.IsErrorEnabled;
            }
        }


        public static bool IsFatalEnabled
        {
            get
            {
                return log.IsFatalEnabled;
            }
        }
    }
}
