using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SalesDetails.Inventory
{
    public class WebClientWrapper : IWebClientWrapper
    {
        public void Post(string address, string json)
        {
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json"; 
            }
        }
    }
}
