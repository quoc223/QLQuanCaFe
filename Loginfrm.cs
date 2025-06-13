using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBANCAFE.DAO;
namespace QLBANCAFE
{
    public partial class Loginfrm : Form
    {
        public Loginfrm()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtUserN.Text;
            string password = txtPassW.Text;
            if (Login(username,password)) 
            {
                mainFrm mfrm = new mainFrm();
                this.Hide();
                mfrm.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Nhập Sai Tên TK Hoặc MK");
            }
            
            
      
        }
        bool Login(string username, string password)
        {
           
            return AccountDAO.Instance.Login(username, password);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Loginfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát ?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
