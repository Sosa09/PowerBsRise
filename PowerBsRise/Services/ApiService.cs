using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerBsRise.Services
{
    //class will handle the http request to and from broadsign cms
    public class ApiService
    {
        private ApiService _instance;
        private object _instanceLock = new object();
        public ApiService Instance 
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
        private ApiService() { }
    }
}
