using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanlyquanCafe_Group4;
namespace QuanlyquanCafe_Group4
{


    public partial class fAccountProfile: Form
    {
        private Account loginAccount;
        public Account LoginAccount
        {
            get { return loginAccount; }
            set
            {
                loginAccount = value;
                changeAccount(loginAccount);
            }
        }

        public fAccountProfile(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;

        }

        void changeAccount(Account acc)
        {
            if (LoginAccount == null) return;
            txbUserName.Text = LoginAccount.UserName;
            txtDisplayName.Text = LoginAccount.DisplayName;
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string displayName = txtDisplayName.Text;
            string userName = txbUserName.Text;
            string oldPassword = txtPassWord.Text;
            string newPass = txtNewPassWord.Text;
            string reNewPass = txtReEnterPassWord.Text;
            
            if (newPass == null || reNewPass == null || newPass != reNewPass)
            {
                MessageBox.Show("Mật khẩu không khớp");
                return;
            }
            else
            {
                EditAccount(userName, displayName, oldPassword, newPass);
            }
                

        }
        void EditAccount(string userName, string displayName, string oldPassword, string newPassword)
        {
            if (AccountDAO.Instance.UpdateAccount1(userName, displayName) && AccountDAO.Instance.ResetPassword(oldPassword, newPassword))
            {
                MessageBox.Show("Cập nhật thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
        }
 
    }
}
