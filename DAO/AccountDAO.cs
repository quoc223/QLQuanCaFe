using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBANCAFE.DAO
{
    class AccountDAO
    {
        private static AccountDAO instance;
        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return AccountDAO.instance; }
            private set { AccountDAO.instance = value; }

        }
        private AccountDAO() { }
        public bool Login(string username, string passw)
        {


            string query = "AccessLogin @userName , @passWord";
            DataTable result = DataProvide.Instance.ExcuteQuery(query, new object[] { username, passw });
            return result.Rows.Count > 0;
        }
    }
}
