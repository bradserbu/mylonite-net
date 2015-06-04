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
        /// Returns a ok if the input string contains the value find. 
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

            var ok = Contains(input, "Hello");
            Assert.IsFalse(ok.IsError);
            Assert.IsTrue(ok.IsOk);
            Assert.IsTrue(ok.Ok());
            Assert.Catch(() => ok.Error());

            var error = Contains(null, "abscd");
            Assert.IsTrue(error.IsError);
            Assert.IsFalse(error.IsOk);
            Assert.IsTrue(error.Error() is ArgumentNullException);
            Assert.Catch(() => error.Ok());
        }
    }
}
