using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylonite.logging.interfaces
{
    public interface ILog
    {
        void Info(string message);
        void Info(string message, params object[] args);
        void Debug(string message);
        void Debug(string message, params object[] args);
        void Trace(string message);
        void Trace(string message, params object[] args);

        /// <summary>
        /// Writes a message to the log using the specified log level
        /// </summary>
        /// <param name="level"></param>
        /// <param name="message"></param>
        void Write(int level, string message);
        /// <summary>
        /// Writes a formatted message to the log using the specified log level.
        /// </summary>
        /// <param name="level"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void Write(int level, string message, params object[] args);
        
        /// <summary>
        /// Writes a status message to the log
        /// </summary>
        /// <param name="status"></param>
        /// <param name="message"></param>
        void Status(string status, string message);
        /// <summary>
        /// Writes a formatted status message to the log 
        /// </summary>
        /// <param name="status"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void Status(string status, string message, params object[] args);

        /// <summary>
        /// Issues an alert notification with a message
        /// </summary>
        /// <param name="name"></param>
        /// <param name="message"></param>
        void Alert(string name, string message);
        /// <summary>
        /// Issues an alert notification with a formatted message
        /// </summary>
        /// <param name="name"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void Alert(string name, string message, params object[] args);

        /// <summary>
        /// Trace the execution of an action
        /// </summary>
        /// <param name="title"></param>
        /// <param name="action"></param>
        void Run(string title, Action action);
        /// <summary>
        /// Trace the execution of a function and return the result
        /// </summary>
        /// <param name="title"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        TResult Run<TResult>(string title, Func<TResult> func);
    }
}
