using mylonite.core.values;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace mylonite.test
{
    public class ValueTests
    {
        /// <summary>
        /// Returns a ok if the input string contains the result find. 
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

        /// <summary>
        /// Executes an HTTP Get request and returns the content content if the return code is 200.
        /// Returns Option.None for all other return codes.
        /// </summary>
        /// <param name="validUrl"></param>
        /// <returns></returns>
        static Option<string> GetContent(string url)
        {
            // Create an http client to make get requests
            var httpClient = new HttpClient();

            try
            {
                // Execute the get request and wait for the result
                var content = httpClient.GetStringAsync(url).Result;
                return Option.Some(content);
            }
            catch (Exception)
            {
                // Return None if there was no result returned
                return Option.None<string>();
            }  
        }

        public void RunTests()
        {

        }

        [TestCase]
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

        [TestCase]
        public void OptionTest()
        {
            var validUrl = "http://google.com";
            var invalidUrl = "htttttp://google.com";
            Option<string> result;

            result = GetContent(validUrl);
            Assert.IsTrue(result.IsSome);
            Assert.IsFalse(result.IsNone);
            Assert.IsTrue(result.Some() != null);
            Assert.Catch(() => result.None());
            
            result = GetContent(invalidUrl);
            Assert.IsFalse(result.IsSome);
            Assert.IsTrue(result.IsNone);
            Assert.IsTrue(result.None() != null);
            Assert.Catch(() => result.Some());
        }
    }
}
