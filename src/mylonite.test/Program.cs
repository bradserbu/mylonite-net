using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mylonite.extensions;

namespace mylonite.test
{
    class Program
    {
        static void Main(string[] args)
        {
            RunStorageTests();
        }

        static void RunStorageTests()
        {
            var tests = new StorageTests();
            tests.LoadUnloadDeleteTest();
            tests.PerformanceTest(
                10000, 
                i => "key-{0}".format(i), 
                i => "Hello, World... for the #{0} time.".format(i));
        }
    }
}
