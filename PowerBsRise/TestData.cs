﻿using PowerBsRise.Models;
using PowerBsRise.Services;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
namespace PowerBsRise
{
    public class TestData
    {
        public ApiDataHandler<DisplayUnit> DisplayUnitObjects;
        public ApiDataHandler<Host> HostObjects;
        public ApiDataHandler<DayPart> DayPartObjects;
        public ApiDataHandler<Frame> SkinObjects;
        private FileHandler _fileHandler;
        public string Token { get; set; }
        public TestData(string Token)
        {
            _fileHandler = new FileHandler();
            DisplayUnitObjects = ProgramLogic.InitializeBroadsignResource<DisplayUnit>(Token, Constants.DISPLAY_UNITS_API_PATH);
            HostObjects = ProgramLogic.InitializeBroadsignResource<Host>(Token, Constants.HOSTS_API_PATH);
            DayPartObjects = ProgramLogic.InitializeBroadsignResource<DayPart>(Token, Constants.DAY_PARTS_API_PATH);
            SkinObjects = ProgramLogic.InitializeBroadsignResource<Frame>(Token, Constants.SKINS_API_PATH);                  
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

        //Testing api service
        public string TestApiGetRequest(string token, string requestUri)
        {
            try
            {
                ApiService apiService = ApiService.Instance;
                var raw_content = apiService.get_api_request(token, requestUri);
                return raw_content.Content.ReadAsStringAsync().Result;
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }
            catch (UriFormatException ex)
            {
                throw new UriFormatException(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            catch (FormatException ex)
            {
                throw new FormatException(ex.Message);
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException(ex.Message);
            }
            catch (TaskCanceledException ex)
            {
                throw new TaskCanceledException(ex.Message);
            }
            catch (AggregateException ex)
            {
                throw new AggregateException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
