using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccessLayer
{
    public class CustomersDAO
    {
        static List<Customers> customers = new List<Customers>();
        public void GenerateSampleDataSet()
        {
            customers.Add(new Customers
            {
                CustomerID = 1,
                CompanyName = "Công ty Cổ phần Vingroup",
                ContactName = "Phạm Nhật Vượng",
                ContactTitle = "Chủ tịch",
                Address = "Số 7, Bằng Lăng 1, Khu đô thị Vinhomes Riverside, Hà Nội",
                Phone = "024-39749999"
            });

            customers.Add(new Customers
            {
                CustomerID = 2,
                CompanyName = "Công ty TNHH Thế Giới Di Động",
                ContactName = "Nguyễn Đức Tài",
                ContactTitle = "Tổng Giám đốc",
                Address = "128 Trần Quang Khải, Quận 1, TP.HCM",
                Phone = "028-38125960"
            });

            customers.Add(new Customers
            {
                CustomerID = 3,
                CompanyName = "Công ty Cổ phần FPT",
                ContactName = "Trương Gia Bình",
                ContactTitle = "Chủ tịch HĐQT",
                Address = "17 Duy Tân, Quận Cầu Giấy, Hà Nội",
                Phone = "024-73002222"
            });
        }
        public List<Customers> GetAllCustomers()
        {
            return customers;
        }
        public bool DeleteCustomer(Customers customer)
        {
            var existingCustomer = customers.FirstOrDefault(c => c.CustomerID == customer.CustomerID);
            if(existingCustomer != null)
            {
                customers.Remove(existingCustomer);
                return true;
            }
            return false;
        }
        public bool UpdateCustomer(Customers customer)
        {
            var existingCustomer = customers.FirstOrDefault(c => c.CustomerID == customer.CustomerID);
            if (existingCustomer != null)
            {
                existingCustomer.CompanyName = customer.CompanyName;
                existingCustomer.ContactName = customer.ContactName;
                existingCustomer.ContactTitle = customer.ContactTitle;
                existingCustomer.Address = customer.Address;
                existingCustomer.Phone = customer.Phone;
                return true;
            }
            return false;
        }
        public bool SaveCustomer(Customers customer)
        {
            Customers existingCustomer = customers.FirstOrDefault(c => c.CustomerID == customer.CustomerID);
            if (existingCustomer != null)
            {
                return false;
            }
            return true;
        }
        public Customers GetCustomerById(string customerId)
        {
            return customers.FirstOrDefault(c => c.CustomerID.ToString() == customerId);
        }
    }
}
