using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccessLayer;
using Repository.Interface;

namespace Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        OrdersDAO ordersDAO = new OrdersDAO();

        public bool DeleteOrder(Orders orders)
        {
            return ordersDAO.DeleteOrder(orders);
        }

        public void GenerateSampleDataSet()
        {
            ordersDAO.GenerateSampleDataSet();
        }

        public List<Orders> GetAllOrders()
        {
            return ordersDAO.GetAllOrders();
        }

        public Orders GetOrderById(int orderId)
        {
            return ordersDAO.GetOrderById(orderId);
        }

        public bool SaveOrder(Orders orders)
        {
            return ordersDAO.SaveOrder(orders);
        }

        public bool UpdateOrder(Orders orders)
        {
            return ordersDAO.UpdateOrder(orders);
        }
    }
}
