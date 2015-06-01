using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mylonite.extensions;
using mylonite.storage;

namespace mylonite.test
{
    public class StorageTests
    {
        public void KeyValueStoreLoadUnloadTest()
        {
            using (var store = new KeyValueStore("test-kvdb"))
            {
                store.Load();
            }
        }
    }
}
