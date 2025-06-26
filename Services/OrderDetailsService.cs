using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using Repository;
using Repository.Interface;
using Services.Interface;

namespace Services
{
    public class OrderDetailsService : IOrderDetailsService
    {
        IOrderDetailsRepository _orderDetailsRepository;
        public OrderDetailsService()
        {
            _orderDetailsRepository = new OrderDetailsRepository();
        }
        public List<OrderDetails> GetOrderDetailById(int orderId)
        {
            return _orderDetailsRepository.GetOrderDetailById(orderId);
        }
        public void GenerateSampleDataSet()
        {
            _orderDetailsRepository.GenerateSampleDataSet();
        }
        public bool SaveOrderDetail(OrderDetails orderDetails)
        {
            return _orderDetailsRepository.SaveOrderDetail(orderDetails);
        }
    }
}
