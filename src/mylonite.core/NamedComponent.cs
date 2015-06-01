using mylonite.core.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylonite.core
{
    public class NamedComponent : Component, IHasName
    {
        protected NamedComponent()
        {

        }

        protected NamedComponent(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
