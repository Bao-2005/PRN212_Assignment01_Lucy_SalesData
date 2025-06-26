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
    public class ProductsService : IProductsService
    {
        IProductsRepository _productsRepository;
        public ProductsService()
        {
            _productsRepository = new ProductsRepository();
        }
        public bool DeleteProduct(Products products)
        {
            return _productsRepository.DeleteProduct(products);
        }

        public void GenerateSampleDataSet()
        {
            _productsRepository.GenerateSampleDataSet();
        }

        public List<Products> GetAllProducts()
        {
            return _productsRepository.GetAllProducts();
        }

        public Products GetProductById(int productId)
        {
            return _productsRepository.GetProductById(productId);
        }

        public bool SaveProduct(Products products)
        {
            return _productsRepository.SaveProduct(products);
        }

        public bool UpdateProduct(Products products)
        {
            return _productsRepository.UpdateProduct(products);
        }
    }
}
