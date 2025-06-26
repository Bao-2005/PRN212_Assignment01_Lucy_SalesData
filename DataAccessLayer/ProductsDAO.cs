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
                UnitPrice = 150000,
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
                UnitPrice = 9500,
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
                UnitPrice = 220000,
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
                UnitPrice = 300000,
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
        public bool DeleteProduct(Products product)
        {
            var existingProduct = products.FirstOrDefault(p => p.ProductID == product.ProductID);
            if (existingProduct != null)
            {
                products.Remove(existingProduct);
                return true;
            }
            return false;
        }
        public bool UpdateProduct(Products product)
        {
            var existingProduct = products.FirstOrDefault(p => p.ProductID == product.ProductID);
            if (existingProduct != null)
            {
                existingProduct.ProductName = product.ProductName;
                existingProduct.SupplierID = product.SupplierID;
                existingProduct.CategoryID = product.CategoryID;
                existingProduct.QuantityPerUnit = product.QuantityPerUnit;
                existingProduct.UnitPrice = product.UnitPrice;
                existingProduct.UnitsInStock = product.UnitsInStock;
                existingProduct.UnitsOnOrder = product.UnitsOnOrder;
                existingProduct.ReorderLevel = product.ReorderLevel;
                existingProduct.Discontinued = product.Discontinued;
                return true;
            }
            return false;
        }
        public bool SaveProduct(Products product)
        {
            if (product != null)
            {
                if(products.Count <= 0)
                {
                    product.ProductID = 1;
                }
                else
                {
                    product.ProductID = products.Max(p => p.ProductID) + 1;
                }
                products.Add(product);
                return true;
            }
            return false;
        }
        public Products GetProductById(int productId)
        {
            return products.FirstOrDefault(p => p.ProductID == productId);
        }
    }
}
