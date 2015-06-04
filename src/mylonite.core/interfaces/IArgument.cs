using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylonite.core.interfaces
{
    public interface IArgument : IHasName
    {
        /// <summary>
        /// Get a valid value for the argument from a supplied value.
        /// Throws an exception if the argument is not valid.
        /// </summary>
        /// <param name="fromValue"></param>
        /// <returns></returns>
        IValue GetValue(object fromValue);
        /// <summary>
        /// Determine if the supplied value is valid for this argument.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool IsValid(object value);
    }
}
