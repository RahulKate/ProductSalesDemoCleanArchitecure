using System;
using System.Collections.Generic;
using System.Text;

namespace SalesDetails.App.Employees.Queries
{
    public interface IGetEmployeeListQuery
    {
        public List<EmployeeModel> Execute();
    }
}
