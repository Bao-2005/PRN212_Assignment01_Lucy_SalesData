using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusinessObject;
using Services;

namespace DoQuocBaoWPF
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        ProductsService _productsService = new ProductsService();
        public ProductWindow()
        {
            InitializeComponent();
        }
        public ProductWindow(int producId)
        {
            InitializeComponent();
            _productsService.GenerateSampleDataSet();
            Products p = _productsService.GetProductById(producId);
            LoadData(p);
        }
        public void LoadData(Products products)
        {
            txtProductID.Text = products.ProductID.ToString();
            txtProductName.Text = products.ProductName;
            txtSupplierID.Text = products.SupplierID.ToString();
            txtCategoryID.Text = products.CategoryID.ToString();
            txtQuantityPerUnit.Text = products.QuantityPerUnit;
            txtUnitPrice.Text = products.UnitPrice.ToString("F2");
            txtUnitsInStock.Text = products.UnitsInStock.ToString();
            txtUnitsOnOrder.Text = products.UnitsOnOrder.ToString();
            txtReorderLevel.Text = products.ReorderLevel.ToString();
            chkDiscontinued.IsChecked = products.Discontinued;
        }
    }
}
