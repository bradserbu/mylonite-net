using mylonite.core.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylonite.core.values
{
    /// <summary>
    /// Used to represent a value that is either None (having no value)
    /// or Some<typeparamref name=">The Type of the underlying value"/>
    /// 
    /// NOTE: This is similar to a Nullable<> built into the .NET framework
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Option<T> : IValue
    {
        /// <summary>
        /// Static Internal object used for all None references.  This is to support == on the IValue.Value 
        /// </summary>
        static object _none = new object();

        #region Static Initializers
        /// <summary>
        /// Return an option representing an empty or no underlying value.
        /// </summary>
        public static Option<T> None
        {
            get
            {
                return new Option<T>()
                {
                    IsSome = false
                };
            }
        }

        /// <summary>
        /// Return an option value that has an underlying value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Option<T> Some(T value)
        {
            if (value == null)
                throw new ArgumentNullException("value", "Some values cannot be null.  Consider using Option.None to represent empty values.");

            var option = new Option<T>()
            {
                IsSome = true,
                m_someValue = value
            };

            return option;
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Used for Static initializers Option.None and Option.Some(value)
        /// </summary>
        Option() { }
        #endregion

        T m_someValue;

        /// <summary>
        /// Indicates whether this Option has an underlying value.
        /// </summary>
        public bool IsSome { get; private set; }
        /// <summary>
        /// Helper method to check if the option has no underlying value (i.e. None).
        /// </summary>
        public bool IsNone { get { return !IsSome; } }

        #region IValue Explicit Interface
        /// <summary>
        /// Option values always have a value: either Some | None
        /// </summary>
        bool IValue.HasValue { get { return true; } }
        /// <summary>
        /// Returns the underlying value for the option with will be _none or Some
        /// </summary>
        object IValue.Value
        {
            get
            {
                if (!IsSome)
                    return _none;

                return m_someValue;
            }
        }
        #endregion
    }
}

