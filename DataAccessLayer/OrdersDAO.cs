using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccessLayer
{
    public class OrdersDAO
    {
        static List<Orders> orders = new List<Orders>();
        public void GenerateSampleDataSet()
        {
            orders.Add(new Orders
            {
                OrderID = 1,
                CustomerID = 1,
                EmployeeID = 1,
                OrderDate = new DateTime(2024, 6, 1)
            });

            orders.Add(new Orders
            {
                OrderID = 2,
                CustomerID = 2,
                EmployeeID = 2,
                OrderDate = new DateTime(2024, 6, 5)
            });

            orders.Add(new Orders
            {
                OrderID = 3,
                CustomerID = 3,
                EmployeeID = 3,
                OrderDate = new DateTime(2024, 6, 10)
            });
        }
        public List<Orders> GetAllOrders()
        {
            return orders;
        }
        public bool DeleteOrder(Orders order)
        {
            var existingOrder = orders.FirstOrDefault(o => o.OrderID == order.OrderID);
            if (existingOrder != null)
            {
                orders.Remove(existingOrder);
                return true;
            }
            return false;
        }
        public bool UpdateOrder(Orders order)
        {
            var existingOrder = orders.FirstOrDefault(o => o.OrderID == order.OrderID);
            if (existingOrder != null)
            {
                existingOrder.CustomerID = order.CustomerID;
                existingOrder.EmployeeID = order.EmployeeID;
                existingOrder.OrderDate = order.OrderDate;
                return true;
            }
            return false;
        }
        public bool SaveOrder(Orders order)
        {
            var existingOrder = orders.FirstOrDefault(o => o.OrderID == order.OrderID);
            if (existingOrder == null)
            {
                orders.Add(order);
                return true;
            }
            return false;
        }
        public Orders GetOrderById(int orderId)
        {
            return orders.FirstOrDefault(o => o.OrderID == orderId);
        }
    }
}