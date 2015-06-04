using mylonite.core.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylonite.core.values
{
    public sealed class Result<T> : IValue
    {
        #region Static Initializers
        /// <summary>
        /// Value containing an error
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static Result<T> Error(Exception error)
        {
            return new Result<T>()
            {
                IsError = true,
                m_error = error
            };
        }
        /// <summary>
        /// A successful value 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Result<T> Ok(T value)
        {
            return new Result<T>()
            {
                IsError = false,
                m_ok = value
            };
        }
        #endregion

        Result() { }

        Exception m_error;
        T m_ok;

        public bool IsError { get; private set; }
        public bool IsOk { get { return !IsError; } }

        #region Methods to extract the underlying value
        public T Ok()
        {   
            if (IsError) throw new NotSupportedException("Cannot access the Ok value for a result that contains an error.");

            return m_ok;
        }
        public Exception Error()
        {
            if (IsOk) throw new NotSupportedException("Cannot access the Error value for a Ok result types.");

            return m_error;
        }
        #endregion

        #region IValue Explicit Interface
        /// <summary>
        /// Results always have a value: An error or an underlying value.
        /// </summary>
        bool IValue.HasValue
        {
            get { return true; }
        }

        /// <summary>
        /// Returns the underlying value which will be an Error or a Value
        /// </summary>
        object IValue.Value
        {
            get
            {
                if (IsError) 
                    return m_error;

                return m_ok;
            }
        }
        #endregion
    }
}
