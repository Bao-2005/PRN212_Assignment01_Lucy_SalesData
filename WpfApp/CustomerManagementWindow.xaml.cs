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
    /// Interaction logic for CustomerManagementWindow.xaml
    /// </summary>
    public partial class CustomerManagementWindow : Window
    {
        CustomersService _customersService = new CustomersService();
        bool isCompleted = false;
        public CustomerManagementWindow()
        {
            InitializeComponent();
            isCompleted = false;
            _customersService.GenerateSampleDataSet();
            lvCustomer.ItemsSource = _customersService.GetAllCustomers();
            isCompleted = true;
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
                if(kq)
                {
                    lvCustomer.ItemsSource = null;
                    lvCustomer.ItemsSource = _customersService.GetAllCustomers();
                    isCompleted = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the customer: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnUpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                isCompleted = false;
                int customerId = int.Parse(txtCustomerID.Text);
                Customers c = _customersService.GetCustomerById(customerId);
                if(c == null)
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
                if (kq)
                {
                    lvCustomer.ItemsSource = null;
                    lvCustomer.ItemsSource = _customersService.GetAllCustomers();
                } 
                else
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
                if(ret == MessageBoxResult.No)
                {
                    return;
                }
                isCompleted = false;
                int id = int.Parse(txtCustomerID.Text);
                Customers c = _customersService.GetCustomerById(id);
                bool kq = _customersService.DeleteCustomer(c);
                if(kq)
                {
                    lvCustomer.ItemsSource = null;
                    lvCustomer.ItemsSource = _customersService.GetAllCustomers();
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

        private void lvCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(isCompleted == false)
            {
                return;
            }
            if(e.AddedItems.Count < 0)
            {
                return;
            }
            Customers c = e.AddedItems[0] as Customers;
            if(c == null)
            {
                return;
            }
            txtCustomerID.Text = c.CustomerID.ToString();
            txtCompanyName.Text = c.CompanyName;
            txtContactName.Text = c.ContactName;
            txtContactTitle.Text = c.ContactTitle;
            txtAddress.Text = c.Address;
            txtPhone.Text = c.Phone;
        }
    }
}
