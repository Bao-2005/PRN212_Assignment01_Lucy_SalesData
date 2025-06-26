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
    /// Interaction logic for EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        EmployeesService _employeesService = new EmployeesService();
        public EmployeeWindow()
        {
            InitializeComponent();
        }
        public EmployeeWindow(int employeeId)
        {
            InitializeComponent();
            _employeesService.GenerateSampleDataSet();
            var employee = _employeesService.GetEmployeeById(employeeId);
            LoadData(employee);
        }
        public void LoadData(Employees employees)
        {
            txtEmployeeID.Text = employees.EmployeeID.ToString();
            txtName.Text = employees.Name;
            txtUserName.Text = employees.UserName;
            txtPassword.Text = employees.Password;
            txtJobTitle.Text = employees.JobTitle;
            txtBirthDate.Text = employees.BirthDate.ToString("yyyy-MM-dd");
            txtHireDate.Text = employees.HireDate.ToString("yyyy-MM-dd");
            txtAddress.Text = employees.Address;
        }
    }
}
