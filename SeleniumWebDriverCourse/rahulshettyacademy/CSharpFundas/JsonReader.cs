using System;
using System.IO;
using Newtonsoft.Json.Linq;


          String myJsonString = File.ReadAllText("testData.json");

           var jsonObject = JToken.Parse(myJsonString);
            Console.WriteLine(jsonObject.SelectToken("products").Value<string>());


