using System;
using System.Collections.Generic;
using System.Text;

namespace SalesDetails.App.Sales.Queries.GetSalesList
{
    public class SalesListItemModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string  CusomterName { get; set; }

        public string ProductName { get; set; }

        public string EmployeeName { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
