using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylonite.core.interfaces
{
    public interface IJob : IHasName
    {
        /// <summary>
        /// Execute an activity in the context of this job.
        /// </summary>
        /// <param name="activity">The activity to execute.</param>
        /// <param name="arguments">Arguments to pass to the activity and their associated values.</param>
        /// <returns></returns>
        IValue Execute(IActivity activity, Dictionary<IArgument, IValue> arguments);
    }
}
