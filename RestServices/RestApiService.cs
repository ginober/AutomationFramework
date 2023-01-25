using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace AutomationFramework.RestServices
{
    public class RestApiService
    {
        public RestClient Client { get; set; }
        public Uri BaseAddress { get; set; }
        public RestRequest Request { get; set; }
        public RestResponse Response { get; set; }
        public RestApiService()
        {
            Client = InitializeClient();
        }
        

        public new RestClient InitializeClient(string baseUrl = "")
        {
            var client = string.IsNullOrEmpty(baseUrl) ? InitializeClient() : new RestClient(baseUrl);
            client.AddHandler("applicatino/json", () => { return NewtonsoftJsonSerializer.Default; });
            client.AddHandler("text/json", () => { return NewtonsoftJsonSerializer.Default; });
            client.AddHandler("text/x-json", () => { return NewtonsoftJsonSerializer.Default; });
            client.AddHandler("text/javascript", () => { return NewtonsoftJsonSerializer.Default; });
            client.AddHandler("*+json", () => { return NewtonsoftJsonSerializer.Default; });

           
            return client;
        }
    }
}
