using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SalesDetails.App.Sales.Commands.CreateSale;
using SalesDetails.App.Sales.Queries.GetSaleDetail;
using SalesDetails.App.Sales.Queries.GetSalesList;

namespace SalesDetails.WebApi.Sales
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly IGetSaleDetailQuery _getSaleDetailQuery;
        private readonly IGetSalesListQuery _getSalesListQuery;
        private readonly ICreateSaleCommand _createSaleCommand;

        public SalesController(IGetSaleDetailQuery getSaleDetailQuery,
            IGetSalesListQuery getSalesListQuery,
            ICreateSaleCommand createSaleCommand)
        {
            _getSaleDetailQuery = getSaleDetailQuery;
            _getSalesListQuery = getSalesListQuery;
            _createSaleCommand = createSaleCommand;
        }

        // GET: api/Sale/5
        [HttpGet("{id}", Name = "Get")]
        public SaleDetailModel Get(int id)
        {
            return _getSaleDetailQuery.Execute(id);
        }

        // GET: api/Sales
        [HttpGet]
        public IEnumerable<SalesListItemModel> Get()
        {
            return _getSalesListQuery.Execute();
        }

        // GET: api/Sales/5
        [HttpPost]
        public void Post(CreateSaleModel model)
        {
            _createSaleCommand.Execute(model);
        }
    }
}
