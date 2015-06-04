using mylonite.core.values;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylonite.test
{
    public class JobTests
    {
        /// <summary>
        /// Returns a result if the input string contains the value find. 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="find"></param>
        /// <returns></returns>
        static Result<bool> Contains(string input, string find)
        {
            if (input == null)
                return Result<bool>.Error(new ArgumentNullException("input", "The input string cannot be null."));

            var contains = input.Contains(find);
            return Result<bool>.Ok(contains);
        }

        public void ResultTest()
        {
            var input = "Hello, World!";

            var result = Contains(input, "Hello");
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.IsOk);

        }
    }
}
