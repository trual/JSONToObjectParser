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

        [TestMethod()]
        public void WhentheParserisPassedaStringtoString()
        {

            jsonObject.JsonParser("meow");
            //the object name
            Assert.AreEqual("big", jsonObject.string2string["cups"] );
        }
    }
}
