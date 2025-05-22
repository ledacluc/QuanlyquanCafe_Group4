using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanlyquanCafe_Group4
{
    public partial class fLogin: Form
    {
        public fLogin()
        {
            InitializeComponent();
        }
        // cac xu ly khi đăng nhập hoặc thoát chương trình 
        private void btnLogin_Click(object sender, EventArgs e)
        {
            fTableManager fmain = new fTableManager();
            this.Hide();
            fmain.ShowDialog();
            this.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát chương trình ? ", " Thông báo!", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
