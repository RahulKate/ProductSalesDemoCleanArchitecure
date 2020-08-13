using SalesDetails.App.Interface;
using System.Linq;

namespace SalesDetails.App.Sales.Queries.GetSaleDetail
{
    public class GetSaleDetailQuery : IGetSaleDetailQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetSaleDetailQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public SaleDetailModel Execute(int SaleId)
        {
            var saleDetail = _databaseService.Sales
                .Where(p => p.Id == SaleId)
                .Select(p => new SaleDetailModel()
                    {
                        Id = p.Id,
                        CustomerName = p.Customer.Name,
                        Date = p.Date,
                        EmployeeName = p.Employee.Name,
                        ProductName = p.Product.Name,
                        UnitPrice = p.UnitPrice,
                        Quantity = p.Quantity,
                        TotalPrice = p.TotalPrice
                    }
                ).Single();

            return saleDetail;
        }
    }
}
