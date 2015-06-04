using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylonite.core.interfaces
{
    public interface IActivity : IHasName
    {
        /// <summary>
        /// The list of arguments required to run this activity
        /// </summary>
        IList<IArgument> Arguments { get; }

        /// <summary>
        /// Run the activity with the specified list of arguments and their some
        /// </summary>
        /// <param name="arguments"></param>
        /// <returns></returns>
        IValue Run(IDictionary<IArgument, IValue> arguments);

        /// <summary>
        /// Handle any errors that occur while running the activity
        /// </summary>
        /// <param name="error"></param>
        /// <param name="arguments"></param>
        void OnError(Exception error, Dictionary<IArgument, IValue> arguments);
    }
}
