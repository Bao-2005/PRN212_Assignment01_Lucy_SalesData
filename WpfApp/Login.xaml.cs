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
using Services;
using Services.Interface;

namespace DoQuocBaoWPF
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        EmployeesService employeesService = new EmployeesService();
        CustomersService customersService = new CustomersService();
        public Login()
        {
            
            InitializeComponent();
            employeesService.GenerateSampleDataSet();
            customersService.GenerateSampleDataSet();
        }

        private void btnAdminLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Password))
                {
                    MessageBox.Show("Please enter both username and password.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                var user = employeesService.Login(txtUserName.Text, txtPassword.Password);
                if (user == null)
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during login: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCustomerLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtPhone.Text))
                {
                    MessageBox.Show("Please enter your phone number.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                var customer = customersService.GetCustomerByPhoneNumber(txtPhone.Text);
                if (customer == null)
                {
                    MessageBox.Show("No customer found with this phone number.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    CustomerWindow customerWindow = new CustomerWindow(txtPhone.Text);
                    customerWindow.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during login: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

