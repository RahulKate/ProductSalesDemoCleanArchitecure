using SalesDetails.App.Interface;
using System.Collections.Generic;
using System.Linq;

namespace SalesDetails.App.Employees.Queries.GetEmployeeList
{
    public class GetEmployeeListQuery : IGetEmployeeListQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetEmployeeListQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public List<EmployeeModel> Execute()
        {
            var employees = _databaseService.Employees
                .Select(p => new EmployeeModel()
                {
                     Id = p.Id,
                     Name = p.Name
                });

            return employees.ToList();
        }
    }
}
