using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TravelListApp.ViewModel
{
    class Client
    {                        
        public static HttpClient HttpClient;
        public static Client ClientInstance;
        public static Client Instantiate(HttpClient httpClient)
        {
            if(ClientInstance == null)
            {
                ClientInstance = new Client();                                
                HttpClient = httpClient;
            }
            return Client.ClientInstance;
        }
    }
}
