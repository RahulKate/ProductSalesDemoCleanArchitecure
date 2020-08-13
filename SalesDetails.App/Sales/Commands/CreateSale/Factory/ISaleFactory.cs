
using SalesDetails.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesDetails.App.Sales.Commands.CreateSale.Factory
{
    public interface ISaleFactory
    {
        Sale Create(DateTime Date, Customer customer, Employee employee, Product product, int quantity);
    }
}
