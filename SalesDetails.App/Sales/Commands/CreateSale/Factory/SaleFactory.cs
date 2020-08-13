using SalesDetails.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesDetails.App.Sales.Commands.CreateSale.Factory
{
    public class SaleFactory : ISaleFactory
    {
        public Sale Create(DateTime Date, Customer customer, Employee employee, Product product, int quantity)
        {
            var sale = new Sale()
            {
                Date = Date,
                Customer = customer,
                Employee = employee,
                Product = product,
                Quantity = quantity,
                TotalPrice = product.Price
            };

            return sale;
        }
    }
}
