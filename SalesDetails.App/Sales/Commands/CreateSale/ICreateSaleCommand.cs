using System;
using System.Collections.Generic;
using System.Text;

namespace SalesDetails.App.Sales.Commands.CreateSale
{
    public interface ICreateSaleCommand
    {
        void Execute(CreateSaleModel saleModel);
    }
}
