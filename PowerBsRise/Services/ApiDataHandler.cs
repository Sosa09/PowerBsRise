using Newtonsoft.Json;
using PowerBsRise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace PowerBsRise.Services
{
    /// <summary>
    /// T can be anything from broadsign resource, Host, Frame, DayPart, DisplayUnit. ..
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiDataHandler<T> where T : ICommonPropertyResource
    {

        List<T> resourceValues = new List<T>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>the first resource object found for the given id</returns>
        /// <exception cref="BroadsignResourceNotFoundException">If the id doesnt any item from that resource</exception>
        public T GetResourceByID(int id)
        {      
            if (!IsResourceFoundByID(id))
            {
                throw new BroadsignResourceNotFoundException();
            }
            return resourceValues.First(x => x.ID == id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<T> GetAllResources()
        { 
            return resourceValues; 
        }
        /// <summary>
        /// bulk or single append of a resource from json data example: directly from an api get request
        /// </summary>
        /// <param name="jsonData"></param>
        public void AddResourcesFromJsonString(string jsonData)
        {
            var baseOutput = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonData);//get the main output with 2 keys that needs to be extracted not_modified_since and the resourceKeyName
            var resourceKey = baseOutput.Keys.LastOrDefault(); //extract the resource key which is always in the second place
            var resourceContent = baseOutput[resourceKey].ToString();
            //convert from json ? char to check for nulls
            List<T>? values = JsonConvert.DeserializeObject<List<T>>(resourceContent);
    
            foreach (T value in values)
            {
                resourceValues.Add(value);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetResourceByIDToJsonString(int id)
        {
            var resource = GetResourceByID(id);
            return JsonConvert.SerializeObject(resource);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetResourcesIDToJsonString()
        {
            return JsonConvert.SerializeObject(resourceValues); //TODO TEST
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resource"></param>
        public void AddResource(T resource)
        {
            resourceValues.Add(resource);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resource"></param>
        public void RemoveResource(T resource)
        {
            resourceValues.Remove(resource);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">unique id of the </param>
        /// <returns>true or false</returns>
        private bool IsResourceFoundByID(int id)
        {
            return resourceValues.Exists(x => x.ID  == id);
        }
    }
}
