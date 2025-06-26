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

namespace DoQuocBaoWPF
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private readonly Employees _currentEmployee;

        public AdminWindow()
        {
            InitializeComponent();
        }
        public AdminWindow(Employees employees)
        {
            InitializeComponent();
            _currentEmployee = employees;
        }

        private void btn_CustomerManagement_Click(object sender, RoutedEventArgs e)
        {
            CustomerManagementWindow customerManagementWindow = new CustomerManagementWindow();
            customerManagementWindow.Show();
        }

        private void btn_ProductManagement_Click(object sender, RoutedEventArgs e)
        {
            ProductManagementWindow productManagementWindow = new ProductManagementWindow();
            productManagementWindow.Show();
        }

        private void btn_OrderManagement_Click(object sender, RoutedEventArgs e)
        {
            OrderManagementWindow orderManagementWindow = new OrderManagementWindow();
            orderManagementWindow.Show();
        }
    }
}
