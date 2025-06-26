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
using Services.Interface;

namespace DoQuocBaoWPF
{
    /// <summary>
    /// Interaction logic for ProductManagementWindow.xaml
    /// </summary>
    public partial class ProductManagementWindow : Window
    {
        ProductsService _productsService = new ProductsService();
        bool isCompleted = false;
        public ProductManagementWindow()
        {
            InitializeComponent();
            isCompleted = false;
            _productsService.GenerateSampleDataSet();
            lvProduct.ItemsSource = _productsService.GetAllProducts();
            isCompleted = true;
        }

        private void btnSaveProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                isCompleted = false;
                Products p = new Products
                {
                    ProductName = txtProductName.Text,
                    SupplierID = int.Parse(txtSupplierID.Text),
                    CategoryID = int.Parse(txtCategoryID.Text),
                    QuantityPerUnit = txtQuantityPerUnit.Text,
                    UnitPrice = decimal.Parse(txtUnitPrice.Text),
                    UnitsInStock = int.Parse(txtUnitsInStock.Text),
                    UnitsOnOrder = int.Parse(txtUnitsOnOrder.Text),
                    ReorderLevel = int.Parse(txtReorderLevel.Text),
                    Discontinued = chkDiscontinued.IsChecked ?? false
                };
                bool kq = _productsService.SaveProduct(p);
                if (kq)
                {
                    lvProduct.ItemsSource = null;
                    lvProduct.ItemsSource = _productsService.GetAllProducts();
                    isCompleted = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the customer: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnUpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                isCompleted = false;
                int productId = int.Parse(txtProductID.Text);
                Products p = _productsService.GetProductById(productId);
                if (p == null)
                {
                    return;
                }
                p.ProductName = txtProductName.Text;
                p.SupplierID = int.Parse(txtSupplierID.Text);
                p.CategoryID = int.Parse(txtCategoryID.Text);
                p.QuantityPerUnit = txtQuantityPerUnit.Text;
                p.UnitPrice = decimal.Parse(txtUnitPrice.Text);
                p.UnitsInStock = int.Parse(txtUnitsInStock.Text);
                p.UnitsOnOrder = int.Parse(txtUnitsOnOrder.Text);
                p.ReorderLevel = int.Parse(txtReorderLevel.Text);
                p.Discontinued = chkDiscontinued.IsChecked ?? false;

                bool kq = _productsService.UpdateProduct(p);
                if (kq)
                {
                    lvProduct.ItemsSource = null;
                    lvProduct.ItemsSource = _productsService.GetAllProducts();
                }
                else
                {
                    MessageBox.Show("Customer with ID " + productId + " does not exist.", "Update Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                isCompleted = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the product: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult ret = MessageBox.Show("Are you sure you want to delete this product?"
                    , "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (ret == MessageBoxResult.No)
                {
                    return;
                }
                isCompleted = false;
                int id = int.Parse(txtProductID.Text);
                Products c = _productsService.GetProductById(id);
                bool kq = _productsService.DeleteProduct(c);
                if (kq)
                {
                    lvProduct.ItemsSource = null;
                    lvProduct.ItemsSource = _productsService.GetAllProducts();
                    txtProductID.Text = "";
                    txtProductName.Text = "";
                    txtSupplierID.Text = "";
                    txtCategoryID.Text = "";
                    txtQuantityPerUnit.Text = "";
                    txtUnitPrice.Text = "";
                    txtUnitsInStock.Text = "";
                    txtUnitsOnOrder.Text = "";
                    txtReorderLevel.Text = "";
                    chkDiscontinued.IsChecked = false;
                }
                isCompleted = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the product: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isCompleted == false)
            {
                return;
            }
            if (e.AddedItems.Count < 0)
            {
                return;
            }
            Products c = e.AddedItems[0] as Products;
            if (c == null)
            {
                return;
            }
            txtProductID.Text = c.ProductID.ToString();
            txtProductName.Text = c.ProductName;
            txtSupplierID.Text = c.SupplierID.ToString();
            txtCategoryID.Text = c.CategoryID.ToString();
            txtQuantityPerUnit.Text = c.QuantityPerUnit;
            txtUnitPrice.Text = c.UnitPrice.ToString("F2");
            txtUnitsInStock.Text = c.UnitsInStock.ToString();
            txtUnitsOnOrder.Text = c.UnitsOnOrder.ToString();
            txtReorderLevel.Text = c.ReorderLevel.ToString();
            chkDiscontinued.IsChecked = c.Discontinued;
        }
    }
}
