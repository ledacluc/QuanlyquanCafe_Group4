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
        public fAdmin(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;
            loadAccountList();
            AddAccountBinding();
        }
        void changeAccount(Account acc)
        {
            if (LoginAccount == null) return;
            txbUserName.Text = LoginAccount.UserName;
            txbDisplayName.Text = LoginAccount.DisplayName;
        }
        void loadAccountList()
        {
            string query = "select UserName, DisplayName, Type from dbo.Account";

            dtgrvAccount.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
        void AddAccountBinding()
        {
            txbUserName.DataBindings.Add(new Binding("Text", dtgrvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txbDisplayName.DataBindings.Add(new Binding("Text", dtgrvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            numericUpDown1.DataBindings.Add(new Binding("Value", dtgrvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }

        //private void btnDeleteAccount_Click(object sender, EventArgs e)
        //{
        //    string userName = txbUserName.Text;
        //    deleteAccount(userName);
        //}
        //void deleteAccount(string userName)
        //{
        //    if (AccountDAO.Instance.DeleteAccount(userName))
        //    {
        //        MessageBox.Show("cập nhật thành công");
        //    }
        //    else
        //    {
        //        MessageBox.Show("cập nhật không  thành công");
        //    }

        //}

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

        }
    }
}
