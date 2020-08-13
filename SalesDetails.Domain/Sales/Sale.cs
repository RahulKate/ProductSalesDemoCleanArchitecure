using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesDetails.Domain
{
    public class Sale
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal TotalPrice { get; set; }

        public DateTime Date { get; set; }

        public Customer Customer { get; set; }

        public Employee Employee { get; set; }

        public Product Product { get; set; }

        private void UpdateTotalPrice()
        {
            TotalPrice = UnitPrice * Quantity;
        }
    }
}
