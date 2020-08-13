using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesDetails.App.Products.Queries.GetProductList;

namespace SalesDetails.WebApi.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGetProductListQuery _getProductListQuery;

        public ProductsController(IGetProductListQuery getProductListQuery)
        {
            _getProductListQuery = getProductListQuery;
        }

        // GET: api/Products
        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            return _getProductListQuery.Execute();
        }
    }
}
