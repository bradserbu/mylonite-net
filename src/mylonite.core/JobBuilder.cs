using mylonite.core.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylonite.core
{
    public class JobBuilder : Component
    {
        public JobBuilder(string jobName)
        {
            this.JobName = JobName;
            this.m_activities = new List<IActivity>();
        }

        List<IActivity> m_activities;

        public string JobName { get; private set; }

        public void Do(Action action)
        {
            throw new NotImplementedException();
        }

        public void Do(IActivity activity, Func<IArgument, IValue> getArgumentValue)
        {
            throw new NotImplementedException();
        }
    }
}
