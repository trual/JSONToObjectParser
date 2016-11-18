using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONToObjectParser
{
    public class JsonObject
    {
        public Dictionary<string, string> string2string = new Dictionary<string, string>();


        public void JsonParser(string jsonString)
        {
            

            string2string.Add("cups", "big");
           
        }
    }

  
}
