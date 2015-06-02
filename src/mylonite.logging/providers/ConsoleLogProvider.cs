using mylonite.logging.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylonite.logging.providers
{
    public class ConsoleLogProvider : ILog
    {
        public ConsoleLogProvider()
        {
            StatusLength = 15;
        }

        #region Settings
        public int StatusLength { get; private set; }
        #endregion

        #region Info/Debug/Trace
        public void Info(string message)
        {
            Write((int)LogLevel.Info, message);
        }
        public void Info(string message, params object[] args)
        {
            Info(string.Format(message, args));
        }
        public void Debug(string message)
        {
            Write((int)LogLevel.Debug, message);
        }
        public void Debug(string message, params object[] args)
        {
            Debug(string.Format(message, args));
        }
        public void Trace(string message)
        {
            Write((int)LogLevel.Trace, message);
        }
        public void Trace(string message, params object[] args)
        {
            Trace(string.Format(message, args));
        }
        #endregion

        #region Write
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
        public void Write(string message, params object[] args)
        {
            Write(string.Format(message, args));
        }
        public void Write(int level, string message)
        {
            Console.WriteLine("({0:D2}): {1}", level, message);
        }
        public void Write(int level, string message, params object[] args)
        {
            Write(string.Format(message, args));
        }
        #endregion

        #region Status
        public void Status(string status, string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(status.ToUpperInvariant().PadLeft(StatusLength));
            Console.ResetColor();
            Console.WriteLine("| {0}", message);
        }
        public void Status(string status, string message, params object[] args)
        {
            Status(status, string.Format(message, args));
        }
        #endregion

        #region Alert
        public void Alert(string name, string message)
        {
            throw new NotImplementedException();
        }
        public void Alert(string name, string message, params object[] args)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Run
        public void Run(string title, Action action)
        {
            throw new NotImplementedException();
        }
        public TResult Run<TResult>(string title, Func<TResult> func)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
