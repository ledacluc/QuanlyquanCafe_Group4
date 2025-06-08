using QuanlyquanCafe_Group4.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuanlyquanCafe_Group4
{
    public partial class fAdmin : Form
    {
        public Account loginAccount;
        BindingSource accountList = new BindingSource();
        public fAdmin()
        {
            InitializeComponent();

            load();
            
        }
        void load()
        {
            dtgrvAccount.DataSource = accountList;

            loadAccountList();
            AddAccountBinding();
        }
      
        void loadAccountList()
        {
            accountList.DataSource = AccountDAO.Instance.GetAccountList();

        }
        void AddAccountBinding()
        {
            txbUserName.DataBindings.Clear();
            txbDisplayName.DataBindings.Clear();
            numericUpDown1.DataBindings.Clear();

            txbUserName.DataBindings.Add(new Binding("Text", dtgrvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txbDisplayName.DataBindings.Add(new Binding("Text", dtgrvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            numericUpDown1.DataBindings.Add(new Binding("Value", dtgrvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }

        
      

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int type = (int)numericUpDown1.Value;
            editAccount(userName, displayName, type);
        }
        void editAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.UpdateAccount2(userName, displayName, type))
            {
                MessageBox.Show("cập nhật thành công");
            }
            else
            {
                MessageBox.Show("cập nhật không  thành công");
            }
            loadAccountList();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int type = (int)numericUpDown1.Value; 
            addAccount(userName, displayName, type);
        }
        void addAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.InsertAccount(userName, displayName, type))
            {
                MessageBox.Show("thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("thêm tài khoản không thành công");
            }
            loadAccountList();
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string userNamee = txbUserName.Text;
            deleteAccount(userNamee);
        }
        void deleteAccount(string userName)
        {
            if(loginAccount.UserName.Equals(userName))
            {
                MessageBox.Show("không thể xóa tài khoản đang đăng nhập");
                return;
            }
            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("xóa tài khoản không  thành công");
            }
            loadAccountList();
        }
    }
}
