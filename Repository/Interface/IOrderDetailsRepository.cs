using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace Repository.Interface
{
    public interface IOrderDetailsRepository
    {
        public void GenerateSampleDataSet();
        public List<OrderDetails> GetAllOrderDetails();
        public bool DeleteOrderDetail(OrderDetails orderDetails);
        public bool UpdateOrderDetail(OrderDetails orderDetails);
        public bool SaveOrderDetail(OrderDetails orderDetails);
        public List<OrderDetails> GetOrderDetailById(int orderId);
    }
}
