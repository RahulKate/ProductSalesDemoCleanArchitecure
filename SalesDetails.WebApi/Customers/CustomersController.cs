using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesDetails.App.Customers.Queries.GetCustomerList;

namespace SalesDetails.WebApi.Customers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IGetCustomerListQuery _getCustomerListQuery;

        public CustomersController(IGetCustomerListQuery getCustomerListQuery)
        {
            _getCustomerListQuery = getCustomerListQuery;
        }

        // GET: api/Customers
        [HttpGet]
        public IEnumerable<CustomerModel> Get()
        {
            return _getCustomerListQuery.Execute();
        }
    }
}
