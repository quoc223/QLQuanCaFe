using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QLBANCAFE.DAO;

namespace QLBANCAFE
{
    public partial class AdminFrm : Form
    {

       
        public AdminFrm()
        {
            
            InitializeComponent();
            LoadAccountList();
            LoadFoodList();
            LoadFoodCategoryList();
            LoadTableList();
            LoadBillList();
        }
        void LoadAccountList()
        {
            //EXEC dbo.GetAccountByUName @usern='staff3'
            string query = "select*from dbo.ACCOUNT";
            
            dgvTk.DataSource = DataProvide.Instance.ExcuteQuery(query);
        }

        void LoadFoodList()
        {
            //EXEC dbo.GetAccountByUName @usern='staff3'
            string query = "select*from dbo.FOOD";

            dgvFood.DataSource = DataProvide.Instance.ExcuteQuery(query);
        }
        void LoadFoodCategoryList()
        {
            //EXEC dbo.GetAccountByUName @usern='staff3'
            string query = "select*from dbo.FOODCATEGORY";

            dgvDanhmuc.DataSource = DataProvide.Instance.ExcuteQuery(query);
        }
        void LoadTableList()
        {
            //EXEC dbo.GetAccountByUName @usern='staff3'
            string query = "select*from dbo.TABLEFOOD";

            dgvTable.DataSource = DataProvide.Instance.ExcuteQuery(query);
        }
        void LoadBillList()
        {
            //EXEC dbo.GetAccountByUName @usern='staff3'
            string query = "select*from dbo.BILL";

            dgvDoanhthu.DataSource = DataProvide.Instance.ExcuteQuery(query);
        }

        private void dgvDoanhthu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
