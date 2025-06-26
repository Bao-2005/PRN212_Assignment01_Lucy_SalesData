using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using Repository;
using Repository.Interface;
using Services.Interface;

namespace Services
{
    public class CustomersService : ICustomersService
    {
        ICustomersRepository _customersRepository;
        public CustomersService()
        {
            _customersRepository = new CustomersRepository();
        }
        public bool DeleteCustomer(Customers customers)
        {
            return _customersRepository.DeleteCustomer(customers);
        }

        public void GenerateSampleDataSet()
        {
            _customersRepository.GenerateSampleDataSet();
        }

        public List<Customers> GetAllCustomers()
        {
            return _customersRepository.GetAllCustomers();
        }

        public Customers GetCustomerById(int customerId)
        {
            return _customersRepository.GetCustomerById(customerId);
        }

        public bool SaveCustomer(Customers customers)
        {
            return _customersRepository.SaveCustomer(customers);
        }

        public bool UpdateCustomer(Customers customers)
        {
            return _customersRepository.UpdateCustomer(customers);
        }
        public Customers GetCustomerByPhoneNumber(string phoneNumber)
        {
            return _customersRepository.GetCustomerByPhoneNumber(phoneNumber);
        }
    }
}
