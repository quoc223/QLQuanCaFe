using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBANCAFE.DTO
{
    public class Food
    {
        public Food(int iD, string name, int idCategory, double price)
        {
            this.id = iD;
            this.name = name;
            this.IdCategory = idCategory;
            this.Price = price;
        }
        public  Food(DataRow row)
        {
            this.id = (int)row["id"];
            this.name = row["Name"].ToString();
            this.IdCategory = (int)row["idCategory"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
        }
        private int id          ;
        private string name     ;
        private int idCategory  ;
        private double price    ;

        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int IdCategory { get => idCategory; set => idCategory = value; }
        public double Price { get => price; set => price = value; }
    }
}
