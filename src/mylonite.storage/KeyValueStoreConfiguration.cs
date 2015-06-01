using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mylonite.extensions;

namespace mylonite.storage
{
    public class KeyValueStoreConfiguration
    {
        public static KeyValueStoreConfiguration Default
        {
            get
            {
                return new KeyValueStoreConfiguration()
                {
                    DataDirectory = "./data/",
                    SparseFileSupportEnabled = true,
                    DatabaseFileSize = 2.Gigabytes(),
                    MaxCollections = 10
                };
            }
        }

        KeyValueStoreConfiguration() { }

        [JsonProperty("data_directory")]
        public string DataDirectory { get; private set; }

        [JsonProperty("sparse_file_support_enabled")]
        public bool SparseFileSupportEnabled { get; private set; }

        [JsonProperty("database_file_size")]
        public long DatabaseFileSize { get; private set; }

        [JsonProperty("max_collections")]
        public int MaxCollections { get; private set; }
    }
}
