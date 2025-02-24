using PowerBsRise.Models;
using PowerBsRise.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerBsRise
{
    public static class ProgramLogic
    {
        public static bool IsValidInteger(string textValue)
        {
            return int.TryParse(textValue, out int parsedChoice);
        }
        public static ApiDataHandler<T> InitializeBroadsignResource<T>(string token, string requestUri) where T : ICommonPropertyResource
        {
            ApiDataHandler<T> handler = new ApiDataHandler<T>();
            var apiContent = FetchApiData(token, requestUri);
            handler.AddResourcesFromJsonString(apiContent);
            return handler;
        }
        private static string FetchApiData(string token, string requestUri)
        {
            var apiServiceInstance = ApiService.Instance;
            var res = apiServiceInstance.get_api_request(token, requestUri);
            return res.Content.ReadAsStringAsync().Result;

        }
    }
}
