using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanlyquanCafe_Group4.DAO;

namespace QuanlyquanCafe_Group4
{
    public partial class fTableManager : Form
    {

        private Account loginAccount;
        public Account LoginAccount
        {
            get { return loginAccount; }
            set
            {
                loginAccount = value;
                ChangeAccount(loginAccount.Type);
            }
        }
        public fTableManager(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;

        }
        void ChangeAccount(int Type)
        {
            adminToolStripMenuItem.Enabled = Type == 1; // Kiểm tra quyền admin

        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {

            fAccountProfile f = new fAccountProfile(LoginAccount);
            f.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.loginAccount = LoginAccount;
            f.ShowDialog();
        }
    }
    public class AccountDAO
    {

        private static AccountDAO instance;
        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new AccountDAO();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }
        private AccountDAO() { }
        
        public bool Login(string userName, string passWord)
        {
            string query = "USP_Login @userName , @passWord";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] {userName, passWord});
            return result.Rows.Count > 0;
        }
        public Account GetAccountbyUserName(string userName)
        {
            string query = "SELECT * FROM dbo.Account WHERE UserName = @userName";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { userName });
            if (data.Rows.Count > 0)
            {
                return new Account(data.Rows[0]);
            }
            return null;
        }
        public bool InsertAccount(string name, string displayName, int type)
        {
            string query = string.Format("insert dbo.Account ( UserName, DisplayName, Type) values (N'{0}', N'{1}', {2})", name, displayName, type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateAccount1(string name, string displayName)
        {
            string query = string.Format("update dbo.Account set DisplayName = N'{1}' where UserName = N'{0}'", name, displayName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateAccount2(string name, string displayName, int type)
        {
            string query = string.Format("update dbo.Account set DisplayName = N'{1}', Type = {2} where UserName = N'{0}'", name, displayName, type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteAccount(string name)
        {
            string query = string.Format("delete from dbo.Account where UserName = N'{0}'", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool ResetPassword(string oldPassword, string newPassword)
        {
            string query = string.Format("update dbo.Account set PassWord = N'{0}' where Password = N'{1}'", newPassword, oldPassword);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public DataTable GetAccountList()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT UserName, DisplayName, Type FROM dbo.Account");
        }
    }
    public class Account
    {

        public Account(string userName, string displayName, int type)
        {
            this.UserName = userName;
            this.DisplayName = displayName;
            this.Type = type;
        }
        public Account (DataRow row)
        {
            this.UserName = row["UserName"].ToString();
            this.DisplayName = row["DisplayName"].ToString();
            this.Type = (int)row["Type"];
        }
        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string displayName;
        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }
        private int type;
        public int Type
        {
            get { return type; }
            set { type = value; }
        }
    }

   
}
 