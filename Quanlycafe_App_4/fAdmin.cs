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
        BindingSource foodList = new BindingSource();
        BindingSource foodCategoryList = new BindingSource();

        public Account loginAccount;
        BindingSource accountList = new BindingSource();
        public fAdmin()
        {
            InitializeComponent();

            load();
            
        }
        void load()
        {
            dtgrvFood.DataSource = foodList;
            dtgrvCatagory.DataSource = foodCategoryList;
            dtgrvAccount.DataSource = accountList;

            LoadListFood();
            LoadListFoodCategory();
            LoadCategoryIntoCombobox(cbFoodCategory);
            loadAccountList();
            AddAccountBinding();
            AddFoodBinding();
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
        void AddFoodBinding()
        {
            txbFoodID.DataBindings.Add(new Binding("Text", dtgrvFood.DataSource, "Id"));
            txbFoodName.DataBindings.Add(new Binding("Text", dtgrvFood.DataSource, "name"));
            nmPrice.DataBindings.Add(new Binding("Value", dtgrvFood.DataSource, "Price"));
            txbCategoryID.DataBindings.Add(new Binding("Text", dtgrvCatagory.DataSource, "Id"));
            txbCategoryName.DataBindings.Add(new Binding("Text", dtgrvCatagory.DataSource, "Name"));
        }

        void LoadListFood()
        {
            foodList.DataSource = FoodDAO.Instance.GetFoodList();
        }

        void LoadListFoodCategory()
        {
            foodCategoryList.DataSource = CategoryDAO.Instance.GetListCategory();
        }
        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";

        }


        //Account
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


        //food
        private void txbFoodID_TextChanged(object sender, EventArgs e)
        {
            int id = (int)dtgrvFood.SelectedCells[0].OwningRow.Cells["CategoryiD"].Value;

            Category category = CategoryDAO.Instance.GetCategoryByID(id);
            cbFoodCategory.SelectedItem = category;

            int index = -1;
            int i = 0;
            foreach (Category item in cbFoodCategory.Items)
            {
                if (item.ID == category.ID)
                {
                    index = i;
                    break;
                }
                i++;
            }
            cbFoodCategory.SelectedIndex = index;
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int categoryID = (cbFoodCategory.SelectedItem as Category).ID;
            float price = (float)nmPrice.Value;
            if (FoodDAO.Instance.InsertFood(name, price, categoryID))
            {
                MessageBox.Show("Thêm món ăn thành công");
                LoadListFood();


            }
            else
            {
                MessageBox.Show("Thêm món ăn thất bại");
            }
        }

        private void btnEditFood_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbFoodID.Text);
            string name = txbFoodName.Text;
            int categoryID = (cbFoodCategory.SelectedItem as Category).ID;
            float price = (float)nmPrice.Value;
            if (FoodDAO.Instance.UpdateFood(id, name, price, categoryID))
            {
                MessageBox.Show("cập nhật món ăn thành công");
                LoadListFood();

            }
            else
            {
                MessageBox.Show("cập nhật món ăn thất bại");
            }
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbFoodID.Text);
            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa món ăn thành công");
                LoadListFood();

            }
            else
            {
                MessageBox.Show("Xóa món ăn thất bại");
            }
        }
        private void btnReadFood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }

        //foodCategory
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string name = txbCategoryName.Text;

            if (CategoryDAO.Instance.InsertFoodCategory(name))
            {
                MessageBox.Show("thêm món ăn thành công");
                LoadListFoodCategory();

                LoadCategoryIntoCombobox(cbFoodCategory);
            }
            else
            {
                MessageBox.Show("thêm món ăn thất bại");
            }
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbCategoryID.Text);
            string name = txbCategoryName.Text;

            if (CategoryDAO.Instance.UpdateFoodCategory(id, name))
            {
                MessageBox.Show("cập nhật món ăn thành công");
                LoadListFoodCategory();

                LoadCategoryIntoCombobox(cbFoodCategory);
            }
            else
            {
                MessageBox.Show("cập nhật món ăn thất bại");
            }
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbCategoryID.Text);
            if (CategoryDAO.Instance.DeleteFoodCategory(id))
            {
                MessageBox.Show("Xóa món ăn thành công");
                LoadListFoodCategory();

                LoadCategoryIntoCombobox(cbFoodCategory);

            }
            else
            {
                MessageBox.Show("Xóa món ăn thất bại");
            }
        }

        private void btnReadCategory_Click(object sender, EventArgs e)
        {
            LoadListFoodCategory();
            LoadCategoryIntoCombobox(cbFoodCategory);
        }

        
    }
}
