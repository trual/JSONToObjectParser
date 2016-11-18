﻿using System;
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
        public void JsonParser(string jsonString)
        {

            bool isValue = false;
            string keyString = "";
            string valueString = "";


            for (int i = 0; i < jsonString.Length; i++)
            {   

                if (jsonString[i] == '"' && isValue)
                {
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
                    isValue = true;
                }
                if (jsonString[i] == ',')
                {
                    isValue = false;
                }

            }
           

            string2string.Add(keyString, valueString);
           
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
