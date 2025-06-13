using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBANCAFE.DTO
{
    public class Category
    {
        private int id;
        private string name;

        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        public Category(int iD, string name)
        {
            this.id = iD;
            this.name = name;
        }
        public Category(DataRow row)
        {
            this.id = (int)row["id"];
            this.name = row["name"].ToString();

        }
    }
}