using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccessLayer
{
    public class CategoriesDAO
    {
        static List<Categories> categories = new List<Categories>();
        public void GenerateSampleDataSet()
        {
            categories.Add(new Categories { CategoryID = 1, CategoryName = "Beverages", Description = "Soft drinks, coffees, teas, beers, and ales" });
            categories.Add(new Categories { CategoryID = 2, CategoryName = "Condiments", Description = "Sweet and savory sauces, relishes, spreads, and seasonings" });
            categories.Add(new Categories { CategoryID = 3, CategoryName = "Confections", Description = "Desserts, candies, and sweet breads" });
            categories.Add(new Categories { CategoryID = 4, CategoryName = "Dairy Products", Description = "Cheeses" });
            categories.Add(new Categories { CategoryID = 5, CategoryName = "Grains/Cereals", Description = "Breads, crackers, pasta, and cereal" });
        }
        public List<Categories> GetAllCategories()
        {
            return categories;
        }
        public bool DeleteCategory(Categories category)
        {
            var existingCategory = categories.FirstOrDefault(c => c.CategoryID == category.CategoryID);
            if (existingCategory != null)
            {
                categories.Remove(existingCategory);
                return true;
            }
            return false;
        }
        public Categories GetCategoryById(int categoryId)
        {
            return categories.FirstOrDefault(c => c.CategoryID == categoryId);
        }
        public bool SaveCategory(Categories category)
        {
            Categories existingCategory = categories.FirstOrDefault(c => c.CategoryID == category.CategoryID);
            if (existingCategory != null)
            {
                return false;
            }
            categories.Add(category);
            return true;
        }
        public bool UpdateCategory(Categories category)
        {
            Categories old = categories.FirstOrDefault(p => p.CategoryID == category.CategoryID);
            if (old == null)
            {
                return false;
            }
            old.CategoryName = category.CategoryName;
            old.Description = category.Description;
            old.Picture = category.Picture;
            return true;
        }
    }
}
