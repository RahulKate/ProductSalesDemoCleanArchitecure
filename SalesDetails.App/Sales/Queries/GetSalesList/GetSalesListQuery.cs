using SalesDetails.App.Interface;
using System.Collections.Generic;
using System.Linq;

namespace SalesDetails.App.Sales.Queries.GetSalesList
{
    public class GetSalesListQuery : IGetSalesListQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetSalesListQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public List<SalesListItemModel> Execute()
        {
            var salesListItem = _databaseService.Sales
                .Select(p => new SalesListItemModel()
                    {
                        Id = p.Id,
                        CusomterName = p.Customer.Name,
                        Date = p.Date,
                        EmployeeName = p.Employee.Name,
                        ProductName = p.Product.Name,
                        Quantity = p.Quantity,
                        TotalPrice = p.TotalPrice,
                        UnitPrice = p.UnitPrice
                    }
                );

            return salesListItem.ToList();
        }
    }
}
