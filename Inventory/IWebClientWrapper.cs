using System;
using System.Collections.Generic;
using System.Text;

namespace SalesDetails.Inventory
{
    public interface IWebClientWrapper
    {
        void Post(string address, string json);
    }
}
