using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccessLayer
{
    public class OrderDetailsDAO
    {
        static List<OrderDetails> orderDetails = new List<OrderDetails>();
        public void GenerateSampleDataSet()
        {
            orderDetails.Add(new OrderDetails
            {
                OrderID = 1,
                ProductID = 101,
                UnitPrice = 150000m,
                Quantity = 2,
                Discount = 0.05f
            });

            orderDetails.Add(new OrderDetails
            {
                OrderID = 1,
                ProductID = 102,
                UnitPrice = 95000m,
                Quantity = 1,
                Discount = 0.0f
            });

            orderDetails.Add(new OrderDetails
            {
                OrderID = 2,
                ProductID = 103,
                UnitPrice = 220000m,
                Quantity = 3,
                Discount = 0.10f
            });

            orderDetails.Add(new OrderDetails
            {
                OrderID = 3,
                ProductID = 104,
                UnitPrice = 300000m,
                Quantity = 1,
                Discount = 0.15f
            });

        }
        public List<OrderDetails> GetAllOrderDetails()
        {
            return orderDetails;
        }
        public bool DeleteOrderDetail(OrderDetails orderDetail)
        {
            var existingOrderDetail = orderDetails.FirstOrDefault(od => od.OrderID == orderDetail.OrderID 
            && od.ProductID == orderDetail.ProductID);
            if (existingOrderDetail != null)
            {
                orderDetails.Remove(existingOrderDetail);
                return true;
            }
            return false;
        }
        public bool UpdateOrderDetail(OrderDetails orderDetail)
        {
            var existingOrderDetail = orderDetails.FirstOrDefault(od => od.OrderID == orderDetail.OrderID
            && od.ProductID == orderDetail.ProductID);
            if (existingOrderDetail != null)
            {
                existingOrderDetail.UnitPrice = orderDetail.UnitPrice;
                existingOrderDetail.Quantity = orderDetail.Quantity;
                existingOrderDetail.Discount = orderDetail.Discount;
                return true;
            }
            return false;
        }
        public bool SaveOrderDetail(OrderDetails orderDetail)
        {
            var existingOrderDetail = orderDetails.FirstOrDefault(od => od.OrderID == orderDetail.OrderID);
            if (existingOrderDetail == null)
            {
                orderDetails.Add(orderDetail);
                return true;
            }
            return false;
        }
        public List<OrderDetails> GetOrderDetailById(int orderId)
        {
            return orderDetails.Where(od => od.OrderID == orderId).ToList();
        }
    }
}
