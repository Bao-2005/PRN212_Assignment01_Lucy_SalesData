using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace Repository.Interface
{
    public interface IOrdersRepository
    {
        public void GenerateSampleDataSet();
        public List<Orders> GetAllOrders();
        public bool DeleteOrder(Orders orders);
        public bool UpdateOrder(Orders orders);
        public bool SaveOrder(Orders orders);
        public Orders GetOrderById(int orderId);
    }
}
