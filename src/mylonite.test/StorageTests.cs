using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mylonite.extensions;
using mylonite.storage;
using System.IO;

namespace mylonite.test
{
    public class StorageTests
    {
        public void KeyValueStoreLoadUnloadTest()
        {
            var databaseName = "test-kvdb";
            var databasePath = Path.Combine("./data", databaseName);

            if (Directory.Exists(databasePath))
                Directory.Delete(databasePath, true);

            using (var store = new KeyValueStore("test-kvdb"))
            {
                store.Load();
            }
        }
    }
}
