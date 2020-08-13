using System;
using System.Collections.Generic;
using System.Text;

namespace SalesDetails.App.Sales.Queries.GetSaleDetail
{
    public interface IGetSaleDetailQuery
    {
        SaleDetailModel Execute(int SaleId);
    }
}
