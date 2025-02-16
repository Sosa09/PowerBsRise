using PowerBsRise.Models;
using PowerBsRise.Services;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace PowerBsRise
{
    public class TestData
    {
        public DataHandler<DisplayUnit> DisplayUnitObjects;
        public DataHandler<Host> HostObjects;
        public DataHandler<DayPart> DayPartObjects;
        public DataHandler<Frame> SkinObjects;
        private FileHandler _fileHandler;
        public TestData()
        {
            _fileHandler = new FileHandler();
            DisplayUnitObjects = GenerateResources<DisplayUnit>(Constants.DISPLAY_UNITS_DATA_FILE);
            HostObjects = GenerateResources<Host>(Constants.HOSTS_DATA_FILE);
            DayPartObjects = GenerateResources<DayPart>(Constants.DAY_PARTS_DATA_FILE);
            SkinObjects = GenerateResources<Frame>(Constants.SKINS_DATA_FILE);                  
        }
        public DataHandler<T> GenerateResources<T>(string resourceFile)
        {
            DataHandler<T> resource = new DataHandler<T>();
            //read the json data
            var content = _fileHandler.GetContent(Constants.PATH_TO_RESOURCES + resourceFile);
            var baseOutput = JsonConvert.DeserializeObject<Dictionary<string, object>>(content);//get the main output with 2 keys that needs to be extracted not_modified_since and the resourceKeyName
            var resourceKey = baseOutput.Keys.LastOrDefault(); //extract the resource key which is always in the second place
            var resourceContent = baseOutput[resourceKey].ToString();
            //convert from json ? char to check for nulls
            List<T>? values = JsonConvert.DeserializeObject<List<T>>(resourceContent) ;
            //iterate through each element to add them into DataHandler's resource specific type
            foreach(T value in values)
            {
                resource.Add(value);
            }
            return resource;
        }
        public void FetchResources<T>(string resource, DataHandler<T> dataHandler)
        {
            Console.WriteLine(resource);
            dataHandler.GetAll().ForEach(x => { Console.WriteLine(x.ToString());});
        }
    }
}
