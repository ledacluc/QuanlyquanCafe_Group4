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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace QuanlyquanCafe_Group4
{
    public partial class fTableManager : Form
    {
<<<<<<< HEAD
=======
        private FlowLayoutPanel flpTable = new FlowLayoutPanel();
        private ListView lvBill = new ListView();
        private Label lblTotalPrice = new Label();
     
>>>>>>> 2485a0bcac25d01132131b47c1323eb749822893

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
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
            load();


>>>>>>> 98754181e34523585692d4717286dccddda34530
            flpTable.Location = new Point(10, 10);
            flpTable.Size = new Size(500, 450
                );
            this.Controls.Add(flpTable);


            this.Controls.Add(lvBill);

            lblTotalPrice.Location = new Point(520, 320);
            lblTotalPrice.Size = new Size(200, 30);

            this.Controls.Add(lblTotalPrice);

<<<<<<< HEAD
            load();
>>>>>>> 2485a0bcac25d01132131b47c1323eb749822893
=======
            
>>>>>>> 98754181e34523585692d4717286dccddda34530

        }
        void ChangeAccount(int Type)
        {
            adminToolStripMenuItem.Enabled = Type == 1; // Kiểm tra quyền admin

        }
<<<<<<< HEAD
=======
        void load()
        {
            flpTable.AutoScroll = true; // Cho phép cuộn nếu có nhiều bàn
            

            LoadCategoryIntoCombobox(cbCategory);
            LoadFoodIntoCombobox(cbFood);
            LoadTable();
            

        }
        
        void LoadTable()
        {
            List<Table> tablelist = TableDAO.Instance.LoadTableList();
            flpTable.Controls.Clear(); // Xóa bảng cũ nếu có
            foreach (Table item in tablelist)
            {
                Button btn = new Button()
                {
                    Width = 100,
                    Height = 100,
                    Text = string.Format("{0}\n{1}", item.Name, item.Status == "TRONG" ? "Trống" : "Có người"),
                    BackColor = item.Status == "TRONG" ? Color.Aqua : Color.LightPink,          
                };
                btn.Tag = item; // Lưu ID bàn vào Tag của nút
                btn.Click += Btn_Click;
                flpTable.Controls.Add(btn);
            }
        }
        void Btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            lsvBill.Tag = (sender as Button).Tag; // Lưu ID bàn vào ListView để sử dụng sau này
            ShowBill(tableID);
           
        }
        void ShowBill(int idTable)
        {
            lsvBill.Items.Clear();

            string query = "SELECT f.Name, bi.count, f.Price, (f.Price * bi.count) AS total " +
                           "FROM BILL b " +
                           "JOIN Billinfo bi ON b.Id = bi.IdBILL " +
                           "JOIN Food f ON bi.IdFood = f.Id " +
                           "WHERE b.IdTable = " + idTable + " AND b.Status = 0";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            float totalPrice = 0;

            foreach (DataRow row in data.Rows)
            {
                ListViewItem lvi = new ListViewItem(row["Name"].ToString());
                lvi.SubItems.Add(row["count"].ToString());
                lvi.SubItems.Add(row["Price"].ToString());
                lvi.SubItems.Add(row["total"].ToString());

                lsvBill.Items.Add(lvi);
                totalPrice += float.Parse(row["total"].ToString());

            }

            lblTotalPrice.Text = "Tổng: " + totalPrice.ToString("c", new System.Globalization.CultureInfo("vi-VN"));
        }
        void LoadCategoryIntoCombobox(ComboBox cb)
        {

            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";

        }
        void LoadFoodIntoCombobox(ComboBox cb)
        {

            cb.DataSource = FoodDAO.Instance.GetFoodList();
            cb.DisplayMember = "Name";

        }

>>>>>>> 2485a0bcac25d01132131b47c1323eb749822893
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
<<<<<<< HEAD
            f.ShowDialog();
        }

        private void fTableManager_Load(object sender, EventArgs e)
=======
            f.loginAccount = LoginAccount;
            f.ShowDialog();
        }

        private void btnAddFood_Click(object sender, EventArgs e)
>>>>>>> 2485a0bcac25d01132131b47c1323eb749822893
        {
            Table table = lsvBill.Tag as Table;

            int idBill = BillDAO.Instance.GetUnCheckBillIDByTableID(table.ID);
            int foodID = (cbFood.SelectedItem as Food).ID;
            int count = (int)nmFoodCount.Value;

                if (idBill == -1)
                {
                    BillDAO.Instance.InsertBill(table.ID);
                    BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIdBill(), foodID, count);
                }
                else
                {
                    BillInfoDAO.Instance.InsertBillInfo(idBill, foodID, count);
                }
            ShowBill(table.ID);
            LoadTable();



        }

        
        //lọc food theo danh sách món ăn
        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCategory.SelectedItem is Category selectedCategory)
            {
                var foods = FoodDAO.Instance.GetFoodListByCategoryID(selectedCategory.ID);
                cbFood.DataSource = foods;
                cbFood.DisplayMember = "Name";

                if (foods.Count > 0)
                {
                    cbFood.SelectedIndex = 0;
                }
                else
                {
                    cbFood.SelectedIndex = -1;
                }
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;

            int idBill = BillDAO.Instance.GetUnCheckBillIDByTableID(table.ID);
            if (idBill != -1)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn thanh toán hóa đơn này không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.Payment(idBill);
                    ShowBill(table.ID);
                    LoadTable(); // Cập nhật lại trạng thái bàn
                }
               
            }
           
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
                return AccountDAO.instance;
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
        //them, xoa, sua Account, reset pass
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
<<<<<<< HEAD

<<<<<<< HEAD
    
=======
    public class MenuDAO
=======
    public class TableDAO
>>>>>>> 98754181e34523585692d4717286dccddda34530
    {
        private static TableDAO instance;
        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }
        private TableDAO() { }
        public List<Table> LoadTableList()
        {
            List<Table> list = new List<Table>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_TableList");
            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                list.Add(table);
            }
            return list;
        }
    }
     public class Table
    {
        public Table(int id, string name, string status)
        {
            this.ID = id;
            this.Name = name;
            this.Status = status;
        }
        public Table(DataRow row)
        {
            this.ID = (int)row["Id"];
            this.Name = row["Name"].ToString();
            this.Status = row["Status"].ToString();
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
    public class BillDAO
    {
        private static BillDAO instance;
        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }
        private BillDAO() { }

        public int GetUnCheckBillIDByTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.BILL WHERE IdTable = " + id + " AND Status = 0");
            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }
            return -1; // Trả về -1 nếu không tìm thấy hóa đơn chưa thanh toán
        }
        public void InsertBill(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_InsertBILL @IdTable", new object[] { id });
        }

        public int GetMaxIdBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(Id) FROM dbo.BILL");
            }
            catch
            {
                return 1; // Trả về 1 nếu không có bản ghi nào
            }
        }
        public void Payment(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("UPDATE dbo.BILL SET Status = 1 WHERE Id = " + id);
        }
    }
    public class Bill
    {
        public Bill(int id, DateTime dateCheckIn, int idTable, int status)
        {
            this.ID = id;
            this.DateCheckIn = dateCheckIn;
            this.IdTable = idTable;
            this.Status = status;
        }
        public Bill(DataRow row)
        {
            this.ID = (int)row["Id"];
            this.DateCheckIn = (DateTime?)row["DateCheckIn"];
            this.IdTable = (int)row["IdTable"];
            this.Status = (int)row["Status"];
        }
        private int iD;
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        private DateTime? dateCheckIn;
        public DateTime? DateCheckIn
        {
            get { return dateCheckIn; }
            set { dateCheckIn = value; }
        }
        private int idTable;
        public int IdTable
        {
            get { return idTable; }
            set { idTable = value; }
        }
        private int status;
        public int Status
        {
            get { return status; }
            set { status = value; }
        }
    }
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;
        public static BillInfoDAO Instance
        {
            get { if (instance == null) instance = new BillInfoDAO(); return BillInfoDAO.instance; }
            private set { BillInfoDAO.instance = value; }
        }
        private BillInfoDAO() { }

        // Lấy danh sách thông tin hóa đơn theo ID hóa đơn
        public List<BillInfo> GetListBillInfoByBillID(int id)
        {
            List<BillInfo> list = new List<BillInfo>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Billinfo WHERE IdBILL = " + id);
            foreach (DataRow item in data.Rows)
            {
                BillInfo billInfo = new BillInfo(item);
                list.Add(billInfo);
            }
            return list;
        }

        public void InsertBillInfo(int idBill, int idFood, int Count)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_InsertBillInfo @IdBILL , @IdFood , @count", new object[] { idBill, idFood, Count });
        }
       

    }
    public class BillInfo
    {
        public BillInfo(int id, int idBILL, int idFood, int count)
        {
            this.ID = id;
            this.IdBILL = idBILL;
            this.IdFood = idFood;
            this.Count = count;
        }
        public BillInfo(DataRow row)
        {
            this.ID = (int)row["Id"];
            this.IdBILL = (int)row["IdBILL"];
            this.IdFood = (int)row["IdFood"];
            this.Count = (int)row["count"];
        }
        private int iD;
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        private int idBILL;
        public int IdBILL
        {
            get { return idBILL; }
            set { idBILL = value; }
        }
        private int idFood;
        public int IdFood
        {
            get { return idFood; }
            set { idFood = value; }
        }
        private int count;
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
    }
    public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return FoodDAO.instance; }

            private set { FoodDAO.instance = value; }
        }
        private FoodDAO() { }


        // Thêm, sửa, xóa món ăn
        public bool InsertFood(string Name, float price, int categoryID)
        {
            string query = string.Format("insert dbo.Food ( Name, Price, IdCategory) values (N'{0}', {1}, {2})", Name, price, categoryID);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateFood(int id, string Name, float price, int categoryID)
        {
            string query = string.Format("update dbo.Food set Name = N'{1}', Price = {2}, IdCategory = {3} where Id = {0}", id, Name, price, categoryID);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteFood(int id)
        {
            string query = string.Format("delete from dbo.Food where Id = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public List<Food> GetFoodListByCategoryID(int id)
        {
            List<Food> list = new List<Food>();
            string query = "select * from dbo.Food where IdCategory = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }
            return list;
        }
        public List<Food> GetFoodList()
        {
            List<Food> list = new List<Food>();
            string query = "select * from dbo.Food";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }
            return list;
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
            this.ID = (int)row["Id"];
            this.Name = row["Name"].ToString();
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
    }

    public class CategoryDAO
    {
        private static CategoryDAO instance;
        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return CategoryDAO.instance; }
            private set { CategoryDAO.instance = value; }
        }
        private CategoryDAO() { }
        public List<Category> GetListCategory()
        {
            List<Category> list = new List<Category>();
            string query = "select * from dbo.FoodCategory";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                list.Add(category);
            }
            return list;

        }
        public Category GetCategoryByID(int id)
        {

            string query = "select * from dbo.FoodCategory where Id = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                return new Category(item);
            }
            return null;
        }
        // Thêm, sửa, xóa danh mục món ăn
        public bool InsertFoodCategory(string Name)
        {
            string query = string.Format("insert dbo.FoodCategory (Name) values (N'{0}')", Name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateFoodCategory(int id, string Name)
        {
            string query = string.Format("update dbo.FoodCategory set Name = N'{1}' where Id = {0}", id, Name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteFoodCategory(int id)
        {
            string query = string.Format("delete from dbo.FoodCategory where Id = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }

    public class Category
    {
        public Category(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
        public Category(DataRow row)
        {
            this.ID = (int)row["Id"];
            this.Name = row["Name"].ToString();
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
    }

>>>>>>> 2485a0bcac25d01132131b47c1323eb749822893
}
 