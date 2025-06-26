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
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        OrderDetailsDAO orderDetailsDAO = new OrderDetailsDAO();
        public bool DeleteOrderDetail(OrderDetails orderDetails)
        {
            return orderDetailsDAO.DeleteOrderDetail(orderDetails);
        }

        public void GenerateSampleDataSet()
        {
            orderDetailsDAO.GenerateSampleDataSet();
        }

        public List<OrderDetails> GetAllOrderDetails()
        {
            return orderDetailsDAO.GetAllOrderDetails();
        }

        public List<OrderDetails> GetOrderDetailById(int orderId)
        {
            return orderDetailsDAO.GetOrderDetailById(orderId);
        }

        public bool SaveOrderDetail(OrderDetails orderDetails)
        {
            return orderDetailsDAO.SaveOrderDetail(orderDetails);
        }

        public bool UpdateOrderDetail(OrderDetails orderDetails)
        {
            return orderDetailsDAO.UpdateOrderDetail(orderDetails);
        }
    }
}
