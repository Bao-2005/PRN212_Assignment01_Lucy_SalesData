using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace Repository.Interface
{
    public interface ICustomersRepository
    {
        public void GenerateSampleDataSet();
        public List<Customers> GetAllCustomers();
        public bool DeleteCustomer(Customers customers);
        public bool UpdateCustomer(Customers customers);
        public bool SaveCustomer(Customers customers);
        public Customers GetCustomerById(string customerId);
    }
}
