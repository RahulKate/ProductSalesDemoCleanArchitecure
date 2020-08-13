using Microsoft.EntityFrameworkCore;
using SalesDetails.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesDetails.Data
{
    public class DatabaseInitializer
    {
        public static void CreateCustomers(ModelBuilder modelBuilder)
        {
            var customers = new List<Customer>();
            customers.Add(new Customer() { Id =1, Name = "Martin Fowler", Address = "Pune" });
            customers.Add(new Customer() { Id = 2, Name = "Uncle Bob", Address = "Hyderabad" });
            customers.Add(new Customer() { Id = 3, Name = "Kent Beck", Address = "Bangluru" });

            modelBuilder.Entity<Customer>().HasData(customers);
        }

        public static void CreateEmployees(ModelBuilder modelBuilder)
        {
            var employees = new List<Employee>();
            employees.Add(new Employee() { Id = 1, Name = "Eric Evans" });
            employees.Add(new Employee() { Id = 2, Name = "Greg Young" });
            employees.Add(new Employee() { Id = 3, Name = "Udi Dahan" });
            modelBuilder.Entity<Employee>().HasData(employees);
        }

        public static void CreateProducts(ModelBuilder modelBuilder)
        {
            var products = new List<Product>();
            products.Add(new Product() { Id = 1, Name = "Spaghetti", Price = 5m });
            products.Add(new Product() { Id = 2, Name = "Lasagna", Price = 10m });
            products.Add(new Product() { Id = 3, Name = "Ravioli", Price = 15m });
            modelBuilder.Entity<Product>().HasData(products);
        }

        public static void CreateSales(ModelBuilder modelBuilder)
        {
            var sales = new List<Sale>();

            sales.Add(new Sale()
            {
                Date = DateTime.Now.Date.AddDays(-3),
                Customer = new Customer() { Id = 1, Name = "Martin Fowler", Address = "Pune" },
                Employee = new Employee() { Id = 1, Name = "Eric Evans" },
                Product = new Product() { Id = 1, Name = "Spaghetti", Price = 5m },
                UnitPrice = 5m,
                Quantity = 1
            });

            sales.Add(new Sale()
            {
                Date = DateTime.Now.Date.AddDays(-2),
                Customer = new Customer() { Id = 2, Name = "Uncle Bob", Address = "Hyderabad" },
                Employee = new Employee() { Id = 2, Name = "Greg Young" },
                Product = new Product() { Id = 2, Name = "Lasagna", Price = 10m },
                UnitPrice = 10m,
                Quantity = 2
            });

            sales.Add(new Sale()
            {
                Date = DateTime.Now.Date.AddDays(-1),
                Customer = new Customer() { Id = 3, Name = "Kent Beck", Address = "Bangluru" },
                Employee = new Employee() { Id = 3, Name = "Udi Dahan" },
                Product = new Product() { Id = 3, Name = "Ravioli", Price = 15m },
                UnitPrice = 15m,
                Quantity = 3
            });

            modelBuilder.Entity<Product>().HasData(sales);
        }
    }
}
