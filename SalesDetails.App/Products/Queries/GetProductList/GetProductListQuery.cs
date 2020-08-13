using SalesDetails.App.Interface;
using System.Collections.Generic;
using System.Linq;

namespace SalesDetails.App.Products.Queries.GetProductList
{
    public class GetProductListQuery : IGetProductListQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetProductListQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public List<ProductModel> Execute()
        {
            var products = _databaseService.Products
                .Select(p => new ProductModel()
                {
                    Id = p.Id,
                    Name = p.Name
                });

            return products.ToList();
        }
    }
}
