using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mylonite.extensions;
using mylonite.storage;
using System.IO;
using NUnit.Framework;
using System.Diagnostics;

namespace mylonite.test
{
    public class StorageTests
    {
        KeyValueDatabaseConfiguration Configuration = KeyValueDatabaseConfiguration.Default;
        string DatabaseName = "test-kvdb";

        public void LoadUnloadDeleteTest()
        {
            var databaseDirectory = Path.Combine(Configuration.DataDirectory, DatabaseName);
            var database = new KeyValueDatabase(DatabaseName, Configuration);
            database.Load();

            Assert.IsTrue(database.IsLoaded);
            Assert.IsTrue(Directory.Exists(databaseDirectory));

            database.Unload();
            Assert.IsFalse(database.IsLoaded);

            database.Delete();
            Assert.IsFalse(Directory.Exists(databaseDirectory));
        }

        public void PerformanceTest(long numRecords, Func<long, string> keyGenerator, Func<long, string> valueGenerator)
        {
            TimeSpan setElapsed,
                     getElapsed,
                     saveElapsed,
                     removeElapsed,
                     totalElapsed;

            var timer = Stopwatch.StartNew();
            using (var database = new KeyValueDatabase(DatabaseName, Configuration))
            {
                database.Load();
                using (var connection = database.OpenConnection())
                {
                    // Store the values
                    for (long lcv = 0; lcv < numRecords; lcv++)
                    {
                        var key = keyGenerator(lcv);
                        var value = valueGenerator(lcv);

                        connection.Set(key, value);
                    }
                    setElapsed = timer.Elapsed;

                    // Get the values
                    for (long lcv = 0; lcv < numRecords; lcv++)
                    {
                        var key = keyGenerator(lcv);
                        string value;

                        connection.Get(key, out value);
                    }
                    getElapsed = timer.Elapsed - setElapsed;

                    // Save all the data
                    connection.Save();
                    saveElapsed = timer.Elapsed - getElapsed;

                    // Remove the values
                    for (long lcv = 0; lcv < numRecords; lcv++)
                    {
                        var key = keyGenerator(lcv);
                        connection.Remove(key);
                    }
                    removeElapsed = timer.Elapsed - saveElapsed;

                    // Close the connection
                    connection.Close();

                    // Unload the database
                    database.Unload();
                    database.Delete();
                }
            }
            timer.Stop();
            totalElapsed = timer.Elapsed;

            Console.WriteLine("- Set......... {0:N4} at {1:N2} rec/sec.", setElapsed.TotalSeconds, numRecords / setElapsed.TotalSeconds);
            Console.WriteLine("- Get......... {0:N4} at {1:N2} rec/sec.", getElapsed.TotalSeconds, numRecords / getElapsed.TotalSeconds);
            Console.WriteLine("- Remove...... {0:N4} at {1:N2} rec/sec.", removeElapsed.TotalSeconds, numRecords / removeElapsed.TotalSeconds);
            Console.WriteLine("- Save........ {0:N4} at {1:N2} rec/sec.", saveElapsed.TotalSeconds, numRecords / saveElapsed.TotalSeconds);
            Console.WriteLine("- Total....... {0:N4} at {1:N2} rec/sec.", totalElapsed.TotalSeconds, numRecords / totalElapsed.TotalSeconds);
        }
    }
}
