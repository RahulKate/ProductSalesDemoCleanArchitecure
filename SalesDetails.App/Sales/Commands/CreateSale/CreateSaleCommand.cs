using SalesDetails.CommonFeatures.Dates;
using SalesDetails.App.Interface;
using SalesDetails.App.Sales.Commands.CreateSale.Factory;
using System.Linq;

namespace SalesDetails.App.Sales.Commands.CreateSale
{
    public class CreateSaleCommand : ICreateSaleCommand
    {
        private readonly IDatabaseService _databaseService;
        private readonly IDateService _dateService;
        private readonly IInventoryService _inventoryService;
        private readonly ISaleFactory _saleFactory;

        public CreateSaleCommand(
            IDatabaseService databaseService,
            IDateService dateService,
            IInventoryService inventoryService,
            ISaleFactory saleFactory
            )
        {
            _databaseService = databaseService;
            _dateService = dateService;
            _inventoryService = inventoryService;
            _saleFactory = saleFactory;
        }

        public void Execute(CreateSaleModel saleModel)
        {
            var date = _dateService.GetDate();

            var customer = _databaseService.Customers
                .Single(p => p.Id == saleModel.CustomerId);

            var employee = _databaseService.Employees
                .Single(p => p.Id == saleModel.EmployeeId);

            var product = _databaseService.Products
                .Single(p => p.Id == saleModel.ProductId);

            var sale = _saleFactory.Create(date, customer, employee, product, saleModel.Quantity);

            _databaseService.Sales.Add(sale);

            _databaseService.Save();

            _inventoryService.NotifySaleOccured(product.Id, saleModel.Quantity);
        }
    }
}
