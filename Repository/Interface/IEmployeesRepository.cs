using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace Repository.Interface
{
    public interface IEmployeesRepository
    {
        public void GenerateSampleDataSet();
        public List<Employees> GetAllEmployees();
        public bool DeleteEmployee(Employees employees);
        public bool UpdateEmployee(Employees employees);
        public bool SaveEmployee(Employees employees);
        public Employees GetEmployeeById(int employeeId);
    }
}
