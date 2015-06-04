using mylonite.core.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylonite.core.values
{
    public static class Option
    {
        #region Static Initializers
        /// <summary>
        /// Return an option representing an empty or no underlying some.
        /// </summary>
        public static Option<T> None<T>()
        {
            return new Option<T>();
        }

        /// <summary>
        /// Return an option some that has an underlying some.
        /// </summary>
        /// <param name="some"></param>
        /// <returns></returns>
        public static Option<T> Some<T>(T value)
        {
            var option = new Option<T>(value);

            return option;
        }
        #endregion
    }

    /// <summary>
    /// Used to represent a some that is either None (having no some)
    /// or Some<typeparamref name=">The Type of the underlying some"/>
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

        #region Constructors
        internal Option()
        {
            IsSome = false;
        }
        /// <summary>
        /// Used for Static initializers Option.None and Option.Some(some)
        /// </summary>
        internal Option(T some)
        {
            if (some == null)
                throw new ArgumentNullException("value", "Some values cannot be null.  Consider using Option.None to represent empty values.");

            IsSome = true;
            m_someValue = some;
        }
        #endregion

        T m_someValue;

        /// <summary>
        /// Indicates whether this Option has an underlying some.
        /// </summary>
        public bool IsSome { get; private set; }
        /// <summary>
        /// Helper method to check if the option has no underlying some (i.e. None).
        /// </summary>
        public bool IsNone { get { return !IsSome; } }

        #region Extract the underlying Some/None values
        public object None()
        {
            if (IsSome) throw new NotSupportedException("Cannot extract a None value from an Option that has a Some value.");

            return _none;
        }
        public T Some()
        {
            if (IsNone) throw new NotSupportedException("Cannot extract a Some value from an Option that has a None value.");

            return m_someValue;
        }
        #endregion

        #region IValue Explicit Interface
        /// <summary>
        /// Option values always have a some: either Some | None
        /// </summary>
        bool IValue.HasValue { get { return true; } }
        /// <summary>
        /// Returns the underlying some for the option with will be _none or Some
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

