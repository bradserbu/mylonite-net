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
            RunValueTests();
            // RunStorageTests();
        }

        static void RunValueTests()
        {
            var tests = new ValueTests();
            tests.RunTests();
        }

        static void RunStorageTests()
        {
            var tests = new StorageTests();
            
        }
    }
}
