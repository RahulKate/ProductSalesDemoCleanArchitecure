using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SalesDetails.App.Interface;
using SalesDetails.App.Sales.Commands.CreateSale;
using SalesDetails.App.Sales.Commands.CreateSale.Factory;
using SalesDetails.App.Sales.Queries.GetSalesList;
using SalesDetails.CommonFeatures.Dates;
using SalesDetails.Data;
using SalesDetails.Domain;
using SalesDetails.Inventory;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesDetails.App.Sales.Commands.CreateSale.Tests
{
    [TestClass()]
    public class CreateSaleCommandTests
    {
        [TestMethod()]
        public void CanInsertSalesIntoDatabase()
        {
            Mock<IDatabaseService> mockDatabaseService = new Mock<IDatabaseService>();
            Mock<IDateService> mockDateService = new Mock<IDateService>();
            Mock<IInventoryService> mockInvServ = new Mock<IInventoryService>();
            Mock<ISaleFactory> mockSaleFactory = new Mock<ISaleFactory>();

            CreateSaleCommand createSaleCommand = 
                new CreateSaleCommand(
                    mockDatabaseService.Object,
                    mockDateService.Object,
                    mockInvServ.Object,
                    mockSaleFactory.Object
                    );

            createSaleCommand.Execute(new CreateSaleModel()
            {
                CustomerId = 1,
                EmployeeId = 1,
                ProductId = 1,
                Quantity = 3
            });
        }
    } 
}