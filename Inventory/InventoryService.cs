using SalesDetails.App.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesDetails.Inventory
{
    public class InventoryService : IInventoryService
    {
        // Note: these are hard coded to keep the demo simple
        private const string AddressTemplate = "http://abc123.com/inventory/products/{0}/notifysaleoccured/";
        private const string JsonTemplate = "{{\"quantity\": {0}}}";

        private readonly IWebClientWrapper _webClientWrapper = null;

        public InventoryService(IWebClientWrapper webClientWrapper)
        {
            _webClientWrapper = webClientWrapper;
        }

        public void NotifySaleOccured(int productId, int quantity)
        {
            var address = string.Format(AddressTemplate, productId);

            var json = string.Format(JsonTemplate, quantity);

            _webClientWrapper.Post(address, json);
        }
    }
}
