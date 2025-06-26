using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccessLayer
{
    public class ProductsDAO
    {
        static List<Products> products = new List<Products>();
        public void GenerateSampleDataSet()
        {
            products.Add(new Products
            {
                ProductID = 101,
                ProductName = "Bánh trung thu Kinh Đô",
                SupplierID = 1,
                CategoryID = 1,
                QuantityPerUnit = "Hộp 4 bánh",
                UnitPrice = 150000m,
                UnitsInStock = 100,
                UnitsOnOrder = 20,
                ReorderLevel = 10,
                Discontinued = false
            });

            products.Add(new Products
            {
                ProductID = 102,
                ProductName = "Nước khoáng La Vie 500ml",
                SupplierID = 2,
                CategoryID = 2,
                QuantityPerUnit = "Thùng 24 chai",
                UnitPrice = 9500m,
                UnitsInStock = 500,
                UnitsOnOrder = 50,
                ReorderLevel = 30,
                Discontinued = false
            });

            products.Add(new Products
            {
                ProductID = 103,
                ProductName = "Cà phê Trung Nguyên 1kg",
                SupplierID = 3,
                CategoryID = 3,
                QuantityPerUnit = "Túi 1kg",
                UnitPrice = 220000m,
                UnitsInStock = 200,
                UnitsOnOrder = 40,
                ReorderLevel = 25,
                Discontinued = false
            });

            products.Add(new Products
            {
                ProductID = 104,
                ProductName = "Sữa đặc Ông Thọ",
                SupplierID = 4,
                CategoryID = 4,
                QuantityPerUnit = "Thùng 48 lon",
                UnitPrice = 300000m,
                UnitsInStock = 150,
                UnitsOnOrder = 30,
                ReorderLevel = 15,
                Discontinued = false
            });

        }
        public List<Products> GetAllProducts()
        {
            return products;
        }
    }
}
