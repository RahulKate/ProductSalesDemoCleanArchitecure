using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SalesDetails.App.Customers.Queries.GetCustomerList
{
    public interface IGetCustomerListQuery
    {
        List<CustomerModel> Execute();

        Task<List<CustomerModel>> ExecuteAsync();
    }
}
