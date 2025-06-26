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
    public class CustomersRepository : ICustomersRepository
    {
        CustomersDAO customersDAO = new CustomersDAO();
        public bool DeleteCustomer(Customers customers)
        {
            return customersDAO.DeleteCustomer(customers);
        }

        public void GenerateSampleDataSet()
        {
            customersDAO.GenerateSampleDataSet();
        }

        public List<Customers> GetAllCustomers()
        {
            return customersDAO.GetAllCustomers();
        }

        public Customers GetCustomerById(int customerId)
        {
            return customersDAO.GetCustomerById(customerId);
        }

        public bool SaveCustomer(Customers customers)
        {
            return customersDAO.SaveCustomer(customers);
        }

        public bool UpdateCustomer(Customers customers)
        {
            return customersDAO.UpdateCustomer(customers);
        }
        public Customers GetCustomerByPhoneNumber(string phoneNumber)
        {
            return customersDAO.GetCustomerByPhoneNumber(phoneNumber);
        }
    }
}
