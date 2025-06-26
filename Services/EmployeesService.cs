using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using Services.Interface;
using Repository;
using Repository.Interface;

namespace Services
{
    public class EmployeesService : IEmployeesService
    {
        IEmployeesRepository employeesRepository;
        public EmployeesService()
        {
            employeesRepository = new EmployeesRepository();
        }
        public bool DeleteEmployee(Employees employees)
        {
            return employeesRepository.DeleteEmployee(employees);
        }

        public void GenerateSampleDataSet()
        {
            employeesRepository.GenerateSampleDataSet();
        }

        public List<Employees> GetAllEmployees()
        {
            return employeesRepository.GetAllEmployees();
        }

        public Employees GetEmployeeById(int employeeId)
        {
            return employeesRepository.GetEmployeeById(employeeId);
        }

        public bool SaveEmployee(Employees employees)
        {
            return employeesRepository.SaveEmployee(employees);
        }

        public bool UpdateEmployee(Employees employees)
        {
            return employeesRepository.UpdateEmployee(employees);
        }

        public Employees Login(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return null;
            }
            return employeesRepository.Login(userName, password);
        }
    }
}
