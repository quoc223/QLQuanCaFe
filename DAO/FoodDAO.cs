using QLBANCAFE.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBANCAFE.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;
        public static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return FoodDAO.instance; }
            private set { FoodDAO.instance = value; }

        }
        private FoodDAO() { }
        public List<Food> GetFoodsByCategoryID(int id)
        {
            List<Food> listfood = new List<Food>();
            DataTable data = DataProvide.Instance.ExcuteQuery("GetFoodByCateId @idCategory="+ id);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                listfood.Add(food);
            }
            return listfood;

        }
    }
}
