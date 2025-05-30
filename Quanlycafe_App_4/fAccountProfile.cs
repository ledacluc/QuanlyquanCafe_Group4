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

        public fAccountProfile(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;

        }





        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
