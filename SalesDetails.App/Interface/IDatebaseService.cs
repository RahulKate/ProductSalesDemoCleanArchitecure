using Microsoft.EntityFrameworkCore;
using SalesDetails.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesDetails.App.Interface
{
    public interface IDatabaseService
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

        void Save();
    }
}
