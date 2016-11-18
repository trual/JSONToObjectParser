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



        /// { "cups" : "big" }
        public JsonObject JsonParser(string jsonString, int currentChar)
        {
            JsonObject jsonObject = new JsonObject();

            bool isValue = false;
            string keyString = "";
            string valueString = "";


            for (int i = currentChar + 1; i < jsonString.Length; i++)
            {   
                if (jsonString[i] == '{')
                {
                    jsonObject = jsonObject.JsonParser(jsonString, i);
                    for (int j = i; j < jsonString.Length; j++)
                    {
                        if (jsonString[j]== '}') {
                            i = j;
                            break; 

                        }

                    }
                }

                if (jsonString[i] == '"' && isValue)
                {   
                   // we are in a value string
                    valueString = returnString(jsonString, i);
                    i += valueString.Length + 1;

                }
                else if (jsonString[i] == '"')
                {
                    //we are in a string
                    keyString = returnString(jsonString, i);
                    i += keyString.Length + 1;
                }
                if (jsonString[i] == ':')
                {   
                    //this marks the begining of a value
                    isValue = true;
                }
                if (jsonString[i] == ',')
                {
                    //this marks the end of a value pair
                    isValue = false;
                    jsonObject.string2string.Add(keyString, valueString);
                    keyString = "";
                    valueString = "";
                }
                if (jsonString[i] == '}')
                {
                    if (keyString.Length != 0)
                    {
                        jsonObject.string2string.Add(keyString, valueString);
                    }

                    return jsonObject;
                }

            }

           

            return jsonObject;
            
           
        }


        public string returnString(string jsonString, int currentChar)
        {
            string stringToReturn = "" ;
            for (int i = currentChar+1; i < jsonString.Length; i++)
            {
                if (jsonString[i] != '"')
                {
                    stringToReturn = stringToReturn + jsonString[i];
                }
                else
                {
                    return stringToReturn;
                }

            }

            return stringToReturn;

        }
    }

  
}
