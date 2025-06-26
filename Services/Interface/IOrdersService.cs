using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace Services.Interface
{
    public interface IOrdersService
    {
        public void GenerateSampleDataSet();
        public List<Orders> GetAllOrders();
        public bool SaveOrder(Orders orders);
        public Orders GetOrderById(int orderId);
        public List<Orders> GetOrdersByCustomerId(int customerId);
    }
}
