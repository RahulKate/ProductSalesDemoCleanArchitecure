using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using SalesDetails.App.Customers.Queries.GetCustomerList;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using System.IO;
using Newtonsoft.Json;

namespace SalesDetails.Function.Customers
{
    public class CustomersController
    {
        private readonly IGetCustomerListQuery _getCustomerListQuery;

        public CustomersController(IGetCustomerListQuery getCustomerListQuery)
        {
            _getCustomerListQuery = getCustomerListQuery;
        }

        [FunctionName(nameof(GetCustomers))]
        public async Task<IActionResult> GetCustomers(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Customers")] 
            HttpRequest req, ILogger log)
        {
            return new OkObjectResult(await _getCustomerListQuery.ExecuteAsync());
        }
    }
}
