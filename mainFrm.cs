using QLBANCAFE.DAO;
using QLBANCAFE.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBANCAFE
{
    public partial class mainFrm : Form
    {
        public mainFrm()
        {
            InitializeComponent();
            LoadTable();
            LoadCategory();
        }
        private void Logout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TsInformation_Click(object sender, EventArgs e)
        {
            ProfileFrm p = new ProfileFrm();
            p.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AdminFrm a = new AdminFrm();
            a.ShowDialog();
            
        }
        /// <summary>
        /// Tải danh sách loại đồ uống
        /// </summary>
        void LoadCategory()
        {
            List<Category> listcategories = CategoryDAO.Instance.GetCategories();
            cbCategory.DataSource = listcategories;
            cbCategory.DisplayMember = "Name";
        }
        /// <summary>
        /// Tải đồ uống theo id
        /// </summary>
        /// <param name="id"></param>
        void LoadFoodListByCateID(int id)
        {
            List<Food> listfood = FoodDAO.Instance.GetFoodsByCategoryID(id);
            cbFood.DataSource = listfood;
            cbFood.DisplayMember = "Name";
        }
        //Phương thức tải bàn hiện có. Với bàn trống màu trăng và bàn có nguoiwff màu đỏ
        void LoadTable()
        {
            List<Table> tables = TableDAO.Instance.LoadTableList();
            foreach (Table item in tables)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += btn_Click;
                btn.Tag = item;

                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.White;
                        break;
                    default:
                        btn.BackColor = Color.Red;
                        break;

                }
                 flTable.Controls.Add(btn);
            }
        }
        /// <summary>
        /// Hiển thị Bill
        /// </summary>
        /// <param name="id"></param>
        void ShowBill(int id)
        {
            lvXuathd.Items.Clear();
            List<QLBANCAFE.DTO.Menu> listbillInfors = MenuDAO.Instance.GetListMenuByTable(id);
            float totalPrice = 0;
            foreach(QLBANCAFE.DTO.Menu item in listbillInfors)
            {
                ListViewItem listViewItem = new ListViewItem(item.FoodName.ToString());
                listViewItem.SubItems.Add(item.Count.ToString());
                listViewItem.SubItems.Add(item.Price.ToString());
                listViewItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                lvXuathd.Items.Add(listViewItem);
                
            }

           
            CultureInfo cultureInfo = new CultureInfo("vi-VN");
          
            txtToltalPrice.Text = totalPrice.ToString("c",cultureInfo);
        }
        void btn_Click(object sender, EventArgs e)
        {
            int tableID=((sender as Button).Tag as Table).ID;
            lvXuathd.Tag = (sender as Button).Tag;
            ShowBill(tableID);
        }
      
        private void nmFoodCount_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
           
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null) 
              
                return;
            
            Category selected = cb.SelectedItem as Category;
            id = selected.ID;

            LoadFoodListByCateID(id);
        }

        private void btnAddfood_Click(object sender, EventArgs e)
        {
            Table table = lvXuathd.Tag as Table;

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            int foodID = (cbFood.SelectedItem as Food).ID;
            int count = (int)nmFoodCount.Value;
            if (idBill == -1) 
            {
                BillDAO.Instance.InsertBill(table.ID);
                BillInforDAO.Instance.InsertBillInfor(BillDAO.Instance.GetMaxIDBill(), foodID, count);
            }
            else
            {
                BillInforDAO.Instance.InsertBillInfor(idBill, foodID, count);
               
            }

            ShowBill(table.ID);
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Table table = lvXuathd.Tag as Table;
            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);

            if (idBill !=-1)
            {
                if (MessageBox.Show("Bạn có chăc thanh toán hóa đơn bàn " + table.Name, "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill);
                   
                    ShowBill(table.ID);
                }
               
            }
        } 
    }
}
