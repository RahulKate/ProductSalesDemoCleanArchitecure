using System;
using System.Collections.Generic;
using System.Text;

namespace SalesDetails.App.Sales.Queries.GetSalesList
{
    public interface IGetSalesListQuery
    {
        List<SalesListItemModel> Execute();
    }
}
