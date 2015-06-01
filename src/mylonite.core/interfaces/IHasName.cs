using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylonite.core.interfaces
{
    public interface IHasName
    {
        [JsonProperty("$name")]
        string Name { get; }
    }
}
