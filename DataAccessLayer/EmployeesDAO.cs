using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccessLayer
{
    public class EmployeesDAO
    {
        static List<Employees> employees = new List<Employees>();
        public void GenerateSampleDataSet()
        {
            employees.Add(new Employees
            {
                EmployeeID = 1,
                Name = "Nguyễn Văn A",
                UserName = "nguyenvana",
                Password = "123456",
                JobTitle = "Nhân viên bán hàng",
                BirthDate = new DateTime(1990, 5, 12),
                HireDate = new DateTime(2020, 1, 15),
                Address = "123 Lê Lợi, Quận 1, TP.HCM"
            });

            employees.Add(new Employees
            {
                EmployeeID = 2,
                Name = "Trần Thị B",
                UserName = "tranthib",
                Password = "abcdef",
                JobTitle = "Quản lý kho",
                BirthDate = new DateTime(1985, 9, 22),
                HireDate = new DateTime(2018, 3, 10),
                Address = "456 Hai Bà Trưng, Quận 3, TP.HCM"
            });

            employees.Add(new Employees
            {
                EmployeeID = 3,
                Name = "Lê Quốc C",
                UserName = "lequocc",
                Password = "letmein",
                JobTitle = "Kế toán",
                BirthDate = new DateTime(1992, 11, 30),
                HireDate = new DateTime(2021, 7, 1),
                Address = "789 Trần Phú, Quận Hải Châu, Đà Nẵng"
            });
        }
        public List<Employees> GetAllEmployees()
        {
            return employees;
        }
        public bool DeleteEmployee(Employees employee)
        {
            var existingEmployee = employees.FirstOrDefault(e => e.EmployeeID == employee.EmployeeID);
            if (existingEmployee != null)
            {
                employees.Remove(existingEmployee);
                return true;
            }
            return false;
        }
        public bool UpdateEmployee(Employees employee)
        {
            var existingEmployee = employees.FirstOrDefault(e => e.EmployeeID == employee.EmployeeID);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.UserName = employee.UserName;
                existingEmployee.Password = employee.Password;
                existingEmployee.JobTitle = employee.JobTitle;
                existingEmployee.BirthDate = employee.BirthDate;
                existingEmployee.HireDate = employee.HireDate;
                existingEmployee.Address = employee.Address;
                return true;
            }
            return false;
        }
        public bool SaveEmployee(Employees employee)
        {
            var existingEmployee = employees.FirstOrDefault(e => e.EmployeeID == employee.EmployeeID);
            if (existingEmployee == null)
            {
                employees.Add(employee);
                return true;
            }
            return false;
        }
        public Employees GetEmployeeById(int employeeId)
        {
            return employees.FirstOrDefault(e => e.EmployeeID == employeeId);
        }
    }
}
