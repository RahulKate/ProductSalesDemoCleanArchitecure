using System;

namespace SalesDetails.App.Interface
{
    public interface IInventoryService
    {
        public void NotifySaleOccured(int productId, int quantity);
    }
}
