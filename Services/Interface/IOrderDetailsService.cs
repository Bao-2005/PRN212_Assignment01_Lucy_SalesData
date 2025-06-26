using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace Services.Interface
{
    public interface IOrderDetailsService
    {
        public List<OrderDetails> GetOrderDetailById(int orderId);
        public void GenerateSampleDataSet();
        public bool SaveOrderDetail(OrderDetails orderDetails);
    }
}
