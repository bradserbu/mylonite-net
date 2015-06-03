using mylonite.core.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylonite.core
{
    public class Job : NamedComponent
    {
        public Job(string name)
            : base(name)
        {

        }

        public void Execute(IActivity activity) { throw new NotImplementedException(); }
        public Task ExecuteAsync(IActivity activity) { throw new NotImplementedException(); }
    }
}
