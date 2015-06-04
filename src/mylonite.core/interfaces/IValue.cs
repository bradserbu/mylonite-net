using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylonite.core.interfaces
{
    public interface IValue
    {
        /// <summary>
        /// Returns whether the underlying some is set.
        /// </summary>
        bool HasValue { get; }
        /// <summary>
        /// The underlying some
        /// </summary>
        object Value { get; }
    }
}
