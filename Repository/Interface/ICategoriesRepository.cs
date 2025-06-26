using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace Repository.Interface
{
    public interface ICategoriesRepository
    {
        public void GenerateSampleDataSet();
        public List<Categories> GetAllCategories();
        public bool DeleteCategory(Categories categories);
        public bool UpdateCategory(Categories categories);
        public bool SaveCategory(Categories categories);
        public Categories GetCategoryById(int categoryId);
    }
}
