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
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        CustomersService _customersService = new CustomersService();
        OrdersService _ordersService = new OrdersService();
        bool isCompleted = false;
        public CustomerWindow(string txtPhoneNum)
        {
            InitializeComponent();
            isCompleted = false;
            _customersService.GenerateSampleDataSet();
            _ordersService.GenerateSampleDataSet();
            LoadCustomerData(txtPhoneNum);
            isCompleted = true;
        }
        public void LoadCustomerData(string txtPhoneNum)
        {
            var customer = _customersService.GetCustomerByPhoneNumber(txtPhoneNum);
            if (customer != null)
            {
                txtCustomerID.Text = customer.CustomerID.ToString();
                txtCompanyName.Text = customer.CompanyName;
                txtContactName.Text = customer.ContactName;
                txtContactTitle.Text = customer.ContactTitle;
                txtAddress.Text = customer.Address;
                txtPhone.Text = customer.Phone;
                lvOldOrder.ItemsSource = null;
                lvOldOrder.ItemsSource = _ordersService.GetOrdersByCustomerId(customer.CustomerID);
            }
            else
            {
                MessageBox.Show("Customer not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnUpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                isCompleted = false;
                int customerId = int.Parse(txtCustomerID.Text);
                Customers c = _customersService.GetCustomerById(customerId);
                if (c == null)
                {
                    return;
                }
                c.CustomerID = int.Parse(txtCustomerID.Text);
                c.CompanyName = txtCompanyName.Text;
                c.ContactName = txtContactName.Text;
                c.ContactTitle = txtContactTitle.Text;
                c.Address = txtAddress.Text;
                c.Phone = txtPhone.Text;
                bool kq = _customersService.UpdateCustomer(c);
                if (!kq)
                {
                    MessageBox.Show("Customer with ID " + customerId + " does not exist.", "Update Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                isCompleted = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the customer: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult ret = MessageBox.Show("Are you sure you want to delete this customer?"
                    , "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (ret == MessageBoxResult.No)
                {
                    return;
                }
                isCompleted = false;
                int id = int.Parse(txtCustomerID.Text);
                Customers c = _customersService.GetCustomerById(id);
                bool kq = _customersService.DeleteCustomer(c);
                if (kq)
                {
                    txtCustomerID.Text = "";
                    txtCompanyName.Text = "";
                    txtContactName.Text = "";
                    txtContactTitle.Text = "";
                    txtAddress.Text = "";
                    txtPhone.Text = "";
                }
                isCompleted = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the customer: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnSaveCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                isCompleted = false;
                Customers c = new Customers
                {
                    CompanyName = txtCompanyName.Text,
                    ContactName = txtContactName.Text,
                    ContactTitle = txtContactTitle.Text,
                    Address = txtAddress.Text,
                    Phone = txtPhone.Text
                };
                bool kq = _customersService.SaveCustomer(c);
                if (kq)
                {
                    isCompleted = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the customer: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                isCompleted = false;
                Customers c = _customersService.GetCustomerByPhoneNumber(txtSearch.Text);
                if (c != null)
                {
                    LoadCustomerData(c.Phone);
                }
                else
                {
                    MessageBox.Show("Customer not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while searching for the customer: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
