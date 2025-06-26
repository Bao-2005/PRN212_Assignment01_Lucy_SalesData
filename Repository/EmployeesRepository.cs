using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccessLayer;
using Repository.Interface;

namespace Repository
{
    public class EmployeesRepository : IEmployeesRepository
    {
        EmployeesDAO employeesDAO = new EmployeesDAO();
        public bool DeleteEmployee(Employees employees)
        {
            return employeesDAO.DeleteEmployee(employees);
        }

        public void GenerateSampleDataSet()
        {
            employeesDAO.GenerateSampleDataSet();
        }

        public List<Employees> GetAllEmployees()
        {
            return employeesDAO.GetAllEmployees();
        }

        public Employees GetEmployeeById(int employeeId)
        {
            return employeesDAO.GetEmployeeById(employeeId);
        }

        public bool SaveEmployee(Employees employees)
        {
            return employeesDAO.SaveEmployee(employees);
        }

        public bool UpdateEmployee(Employees employees)
        {
            return employeesDAO.UpdateEmployee(employees);
        }
    }
}
