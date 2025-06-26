using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace Services.Interface
{
    public interface IProductsService
    {
        public void GenerateSampleDataSet();
        public List<Products> GetAllProducts();
        public bool DeleteProduct(Products products);
        public bool UpdateProduct(Products products);
        public bool SaveProduct(Products products);
        public Products GetProductById(int productId);
    }
}
