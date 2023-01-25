using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.RestServices
{
    public class ReqResServices : RestApiService
    {
        public ReqResServices()
        {
            Client = InitializeClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        }

        private RestRequest InitializeRequest (Method method, string controller, string action)
        {
            var request = new RestRequest
            {
                Method = method,
                RequestFormat = DataFormat.Json,
                Resource = $"api/{controller}/{action}"
            };

            return request;
        }
    }
}
