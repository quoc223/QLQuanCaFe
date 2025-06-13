using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBANCAFE.DTO;
using QLBANCAFE.DAO;
using System.Data;

namespace QLBANCAFE.DAO
{
    class TableDAO
    {
        private static TableDAO instance;
        public static  TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }
        private TableDAO() { }
        public static int TableWidth = 90;
        public static int TableHeight = 90;

        public List<Table> LoadTableList()
        {
            List<Table> tables = new List<Table>();

            DataTable data = DataProvide.Instance.ExcuteQuery("select*from dbo.TABLEFOOD");
            foreach(DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tables.Add(table);
            }
            return tables;
        }
    }
}
