using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PowerBsRise.Services
{
    //class will handle the http request to and from broadsign cms
    public class ApiService
    {
        private HttpClient _httpClient;
        private HttpResponseMessage _response;
        private static ApiService _instance;
        private static object _instanceLock = new object();
        public static ApiService Instance 
        { 
            get 
            { 
                lock (_instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new ApiService();
                    }
                }
                return _instance; 
            } 
        }
        private ApiService() 
        {                            
        }
        public HttpResponseMessage get_api_request(string token, string requestUri)
        {
            try
            {
                using (_httpClient = new HttpClient())
                {
                    _response = new HttpResponseMessage();
                    _httpClient.BaseAddress = new Uri(Constants.BS_PRD_API_ENDPOINT);
                    _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                    _httpClient.DefaultRequestHeaders.Add("Authorization", $"Baerer {token}");
                    _response = _httpClient.GetAsync(requestUri).Result;
                }
            }catch (ArgumentException ex)
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
            return _response;
        }
    }
}
