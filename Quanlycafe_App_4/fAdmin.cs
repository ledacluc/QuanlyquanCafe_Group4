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
    public partial class fAdmin: Form
    {
        public fAdmin()
        {
            InitializeComponent();

            loadAccountList();
        }

        void loadAccountList() 

        {
            string query = "select * from dbo.Account";



            dtgrvAccount.DataSource = DataProvider.Instance.ExecuteQuery(query); 
        }

    }
}
