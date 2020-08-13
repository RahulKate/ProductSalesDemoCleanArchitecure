using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesDetails.App.Employees.Queries;

namespace SalesDetails.WebApi.Employees
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IGetEmployeeListQuery _getEmployeeListQuery;

        public EmployeesController(IGetEmployeeListQuery getEmployeeListQuery)
        {
            _getEmployeeListQuery = getEmployeeListQuery;
        }

        // GET: api/Employee
        [HttpGet]
        public IEnumerable<EmployeeModel> Get()
        {
            return _getEmployeeListQuery.Execute();
        }
    }
}
