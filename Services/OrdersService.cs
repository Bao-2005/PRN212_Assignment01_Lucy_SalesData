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
    public class OrdersService : IOrdersService
    {
        IOrdersRepository _ordersRepository;
        public OrdersService()
        {
            _ordersRepository = new OrdersRepository();
        }
        public void GenerateSampleDataSet()
        {
            _ordersRepository.GenerateSampleDataSet();
        }

        public List<Orders> GetAllOrders()
        {
            return _ordersRepository.GetAllOrders();
        }

        public Orders GetOrderById(int orderId)
        {
            return _ordersRepository.GetOrderById(orderId);
        }

        public bool SaveOrder(Orders orders)
        {
            return _ordersRepository.SaveOrder(orders);
        }
        public List<Orders> GetOrdersByCustomerId(int customerId)
        {
            return _ordersRepository.GetOrdersByCustomerId(customerId);
        }
    }
}
