using System;
using System.Collections.Generic;
using System.Text;

namespace SalesDetails.App.Products.Queries.GetProductList
{
    public interface IGetProductListQuery
    {
        List<ProductModel> Execute();
    }
}
