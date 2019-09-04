using AutoMapperTutorial.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapperTutorial.Extensions
{
    public static class ConsoleExtensions
    {
        public static void WriteToConsole(this object obj)
        {
            JObject parsed = JObject.Parse(JsonConvert.SerializeObject(obj));
            foreach (var pair in parsed)
            {
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }
        }
    }
}
