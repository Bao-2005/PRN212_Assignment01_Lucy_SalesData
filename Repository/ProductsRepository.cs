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
    public class ProductsRepository : IProductsRepository
    {
        ProductsDAO productsDAO = new ProductsDAO();
        public bool DeleteProduct(Products products)
        {
            return productsDAO.DeleteProduct(products);
        }

        public void GenerateSampleDataSet()
        {
            productsDAO.GenerateSampleDataSet();
        }

        public List<Products> GetAllProducts()
        {
            return productsDAO.GetAllProducts();
        }

        public Products GetProductById(int productId)
        {
            return productsDAO.GetProductById(productId);
        }

        public bool SaveProduct(Products products)
        {
            return productsDAO.SaveProduct(products);
        }

        public bool UpdateProduct(Products products)
        {
            return productsDAO.UpdateProduct(products);
        }
    }
}
