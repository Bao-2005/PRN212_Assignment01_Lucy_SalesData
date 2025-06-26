using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusinessObject;
using Services;

namespace DoQuocBaoWPF
{
    /// <summary>
    /// Interaction logic for OrderManagementWindow.xaml
    /// </summary>
    public partial class OrderManagementWindow : Window
    {
        OrdersService _ordersService = new OrdersService();
        OrderDetailsService _orderDetailsService = new OrderDetailsService();
        ProductsService _productsService = new ProductsService();
        bool isCompleted = false;
        public OrderManagementWindow()
        {
            InitializeComponent();
            isCompleted = false;
            _ordersService.GenerateSampleDataSet();
            _orderDetailsService.GenerateSampleDataSet();
            _productsService.GenerateSampleDataSet();
            lvOrder.ItemsSource = _ordersService.GetAllOrders();
            isCompleted = true;
        }

        private void lvOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedOrder = lvOrder.SelectedItem as Orders;
            if (selectedOrder != null)
            {
                int selectedOrderId = selectedOrder.OrderID;
                var orderDetails = _orderDetailsService.GetOrderDetailById(selectedOrderId).ToList();
                lvOrderDetails.ItemsSource = null;
                lvOrderDetails.ItemsSource = orderDetails;
                txtEmployeeID.Text = selectedOrder.EmployeeID.ToString();
            }
        }

        private void btnSaveOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                isCompleted = false;
                Orders c = new Orders()
                {
                    CustomerID = int.Parse(txtCustomerID.Text),
                    EmployeeID = int.Parse(txtEmployeeID.Text),
                    OrderDate = DateTime.Parse(txtOrderDate.Text)
                };
                OrderDetails od = new OrderDetails()
                {
                    OrderID = c.OrderID,
                    ProductID = int.Parse(txtProductID.Text),
                    Quantity = int.Parse(txtQuantity.Text),
                    UnitPrice = _productsService.GetProductById(int.Parse(txtProductID.Text)).UnitPrice
                };
                bool kq = _ordersService.SaveOrder(c);
                bool kq2 = _orderDetailsService.SaveOrderDetail(od);
                if (kq && kq2)
                {
                    lvOrder.ItemsSource = null;
                    lvOrder.ItemsSource = _ordersService.GetAllOrders();
                    isCompleted = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the order: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnViewEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow employeeWindow = new EmployeeWindow(int.Parse(txtEmployeeID.Text));
            employeeWindow.Show();
        }

        private void btnViewProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductWindow productWindow = new ProductWindow(int.Parse(txtProductID.Text));
            productWindow.Show();
        }

        private void lvOrderDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedOrderDetail = lvOrderDetails.SelectedItem as OrderDetails;
            txtProductID.Text = selectedOrderDetail.ProductID.ToString();
        }
    }
}
