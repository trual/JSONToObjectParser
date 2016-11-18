using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONToObjectParser
{
    [TestClass()]
    public class ParserTester
    {

        JsonObject jsonObject = new JsonObject();


        /// <summary>
        ///  test case:
        /// { "cups" : "big" }
        /// </summary>
        [TestMethod()]
        public void WhentheParserisPassedaStringtoString()
        {


            
            string testString = "{ \"cups\" : \"big\" }";
            jsonObject.JsonParser(testString);
            //the object name
            Console.WriteLine(testString);

           Console.WriteLine(jsonObject.string2string.Count);

            foreach (string key in jsonObject.string2string.Keys)
            {
                Console.WriteLine(key);
            }

            Assert.AreEqual("big", jsonObject.string2string["cups"] );
        }
    }
}
