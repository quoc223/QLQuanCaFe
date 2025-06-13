using QLBANCAFE.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBANCAFE.DAO
{
    class CategoryDAO
    {
        private static CategoryDAO instance;
        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return CategoryDAO.instance; }
            private set { CategoryDAO.instance = value; }

        }
        private CategoryDAO() { }
        /// <summary>
        /// lấy danh sách loại sản phẩm.
        /// </summary>
        /// <returns></returns>
        public List<Category> GetCategories()
        {
            List<Category> listcategory = new List<Category>();
            DataTable data = DataProvide.Instance.ExcuteQuery("GetCategory");
            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                listcategory.Add(category);
            }
            return listcategory;
        }
    }
}
