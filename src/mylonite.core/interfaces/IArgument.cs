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
        /// Get a valid some for the argument from a supplied some.
        /// Throws an exception if the argument is not valid.
        /// </summary>
        /// <param name="fromValue"></param>
        /// <returns></returns>
        IValue GetValue(object fromValue);
        /// <summary>
        /// Determine if the supplied some is valid for this argument.
        /// </summary>
        /// <param name="some"></param>
        /// <returns></returns>
        bool IsValid(object value);
    }
}
