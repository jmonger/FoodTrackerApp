using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FoodTrackerApp.Models;
using Newtonsoft.Json;

namespace FoodTrackerApp.Tests
{
    public class JsonFileHelper
    {
        public JsonFileHelper()
        {
        }

        public List<LogModelResult> GetJson(string filename)
        {
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),filename);
            var res = JsonConvert.DeserializeObject<List<LogModelResult>>(File.ReadAllText(filePath));
            return res;

        }


    }
}
