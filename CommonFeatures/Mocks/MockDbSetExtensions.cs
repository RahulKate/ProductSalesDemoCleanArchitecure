using Moq;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SalesDetails.CommonFeatures.Mocks
{
    public static class MockDbSetExtensions
    {
        public static void SetUpDbSet<TEntity>(Mock<DbSet<TEntity>> mock, IList<TEntity> list)
            where TEntity : class
        {
            var querable = list.AsQueryable();

            //mock.Setup(p => p as IEnumerator)
            //        .Returns(querable.GetEnumerator());
        }
    }
}
