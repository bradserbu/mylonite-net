using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
