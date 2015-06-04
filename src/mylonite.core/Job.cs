using mylonite.core.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylonite.core
{
    public class Job : NamedComponent, IJob
    {
        public Job(string name)
            : base(name)
        {

        }

        public IValue Execute(IActivity activity, Dictionary<IArgument, IValue> arguments)
        {
            throw new NotImplementedException();
        }
    }
}
