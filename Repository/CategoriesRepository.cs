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
    public class CategoriesRepository : ICategoriesRepository
    {
        CategoriesDAO cateDAO = new CategoriesDAO();

        public bool DeleteCategory(Categories categories)
        {
            return cateDAO.DeleteCategory(categories);
        }

        public void GenerateSampleDataSet()
        {
            cateDAO.GenerateSampleDataSet();
        }

        public List<Categories> GetAllCategories()
        {
            return cateDAO.GetAllCategories();
        }

        public Categories GetCategoryById(int categoryId)
        {
            return cateDAO.GetCategoryById(categoryId);
        }

        public bool SaveCategory(Categories categories)
        {
            return cateDAO.SaveCategory(categories);
        }

        public bool UpdateCategory(Categories categories)
        {
            return cateDAO.UpdateCategory(categories);
        }
    }
}
