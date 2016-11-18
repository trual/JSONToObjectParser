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
            jsonObject = jsonObject.JsonParser(testString, 0);
            //the object name
            Console.WriteLine(testString);

           Console.WriteLine(jsonObject.string2string.Count);

            foreach (string key in jsonObject.string2string.Keys)
            {
                Console.WriteLine(key);
            }

            Assert.AreEqual("big", jsonObject.string2string["cups"] );
        }


        [TestMethod()]
        public void WhentheParserisPassedaMultipleStringtoString()
        {



            string testString = "{ \"key1\" : \"val1\" , \"key2\" : \"val2\" }";
            jsonObject = jsonObject.JsonParser(testString, 0);
            //the object name
            Console.WriteLine(testString);

            Console.WriteLine(jsonObject.string2string.Count);

            Assert.AreEqual("val1", jsonObject.string2string["key1"]);
            Assert.AreEqual("val2", jsonObject.string2string["key2"]);
        }


        /// <summary>
        /// { "obj1" : { "key1" : "val1" } }
        /// </summary>
        [TestMethod()]
        public void WhentheParserisPassedaMultipleObjectWithStringtoString()
        {



            string testString = "{ \"obj1\" : { \"key1\" : \"val1\" } }";
            jsonObject = jsonObject.JsonParser(testString, 0);
            //the object name
            Console.WriteLine(testString);

            Console.WriteLine(jsonObject.string2string.Count);

            Assert.AreEqual("val1", jsonObject.string2Object["obj1"].string2string["key1"]);
        }


        /// <summary>
        /// testing multiple strings and obbjects
        /// { "obj1" : { "ob1key1" : "ob1val1" }, "key1" : "val1", "obj2" : { "ob2key1" : "ob2val1" } }
        /// </summary>
        [TestMethod()]
        public void WhentheParserisPassedaMultipleObjectsAndMultipleStringsWithStringtoString()
        {



            string testString = "{ \"obj1\" : { \"ob1key1\" : \"ob1val1\" }, \"key1\" : \"val1\", \"obj2\" : { \"ob2key1\" : \"ob2val1\" } }";
            jsonObject = jsonObject.JsonParser(testString, 0);
            //the object name
            Console.WriteLine(testString);

            Console.WriteLine(jsonObject.string2string.Count);

            Assert.AreEqual("ob1val1", jsonObject.string2Object["obj1"].string2string["ob1key1"]);
            Assert.AreEqual("ob2val1", jsonObject.string2Object["obj2"].string2string["ob2key1"]);
            Assert.AreEqual("val1", jsonObject.string2string["key1"]);
        }
    }
}
