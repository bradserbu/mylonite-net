using mylonite.core.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylonite.core.values
{
    /// <summary>
    /// Base class for a genric some
    /// </summary>
    public class Val<T> : IValue
    {
        /// <summary>
        /// Create a some class with it's underlying some set.
        /// </summary>
        /// <param name="some"></param>
        public Val(T value)
        {
            m_value = value;
            m_hasValue = true;
        }

        T m_value;
        bool m_hasValue;

        public bool HasValue { get { return m_hasValue; } }
        public T Value
        {
            get { return m_value; }
            protected set
            {
                m_value = value;
                m_hasValue = true;
            }
        }

        #region IValue - Explicit Non-Generic Interface
        object IValue.Value
        {
            get { return m_value; }
        }
        #endregion
    }
}
