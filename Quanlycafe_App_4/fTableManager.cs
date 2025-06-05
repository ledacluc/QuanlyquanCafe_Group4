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


    public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return FoodDAO.instance;  }

            private set { FoodDAO.instance = value; }
        }
        private FoodDAO() { }

        public List<Food> GetFoodByCategoryID()
        {
            List<Food> List = new List<Food>();
            string query = " Select * from FoodCategory where IdCategory = N{0} ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                List.Add(food);
            }
            return List;
        }
        public List<Food> GetListFood()
        {
            List<Food> List = new List<Food>();
            string query = " Select * from Food ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                List.Add(food);
            }
            return List;
        }
    }
    public class Food
    {
        public Food(int iD, string name, int categoryiD, float price)
        {
            this.ID = iD;
            this.Name = name;
            this.CategoryiD = categoryiD;
            this.Price = price;
        }
        public Food(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.CategoryiD = (int)row["IdCategory"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
        }
        private float price;
        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        private int categoryiD;
        public int CategoryiD
        {
            get { return categoryiD; }
            set { categoryiD = value; }
        }
        private int iD;
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string status;
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

    }
}
 