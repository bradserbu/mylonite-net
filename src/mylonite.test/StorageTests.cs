using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mylonite.extensions;
using mylonite.storage;
using System.IO;
using NUnit.Framework;

namespace mylonite.test
{
    public class StorageTests
    {
        KeyValueDatabaseConfiguration Configuration = KeyValueDatabaseConfiguration.Default;
        string DatabaseName = "test-kvdb";

        public void LoadUnloadDeleteTest()
        {
            var databaseDirectory = Path.Combine(Configuration.DataDirectory, DatabaseName);
            var store = new KeyValueDatabase(DatabaseName, Configuration);
            store.Load();

            Assert.IsTrue(store.IsLoaded);
            Assert.IsTrue(Directory.Exists(databaseDirectory));

            store.Unload();
            Assert.IsFalse(store.IsLoaded);

            store.Delete();
            Assert.IsFalse(Directory.Exists(databaseDirectory));
        }
    }
}
