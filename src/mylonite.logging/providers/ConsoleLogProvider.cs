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
            StatusLength = 10;
        }

        #region Settings
        public int StatusLength { get; private set; }
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
            Console.Write(status.ToUpperInvariant().PadRight(StatusLength));
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
