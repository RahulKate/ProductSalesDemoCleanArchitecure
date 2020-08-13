using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesDetails.App.Interface;

namespace SalesDetails.App.Customers.Queries.GetCustomerList
{
    public class GetCustomerListQuery : IGetCustomerListQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetCustomerListQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public List<CustomerModel> Execute()
        {
            var customers = _databaseService.Customers
                .Select(p => new CustomerModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Address = p.Address
                });

            return customers.ToList();
        }

        public async Task<List<CustomerModel>> ExecuteAsync()
        {
            var customers = await Task.Run(() => _databaseService.Customers
                .Select(p => new CustomerModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Address = p.Address
                }));

            return customers.ToList();
        }
    }
}
