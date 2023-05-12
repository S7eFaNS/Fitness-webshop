using ClassLibrary.Classes.User;
using InterfaceLibrary.IManagers;
using InterfaceLibrary.IRepositories;
using ManagerLibrary.ManagerClasses;
using ManagerLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GymAppWinForm.UserControl_Pages
{
    public partial class UC_User : UserControl
    {
        //private readonly IUserManager userManager;
        private readonly UserManager userManager;

        //public UC_User(User currentUser)
        //{
        //    InitializeComponent();
        //    LoadUsers();
        //    user = currentUser;
        //}

        public UC_User()
        {
            IUserRepository repository = new UserRepository();
            InitializeComponent();
            this.userManager = new UserManager(repository);
            LoadUsers();
        }

        public void LoadUsers()
        {
            List<User> users = userManager.GetUsers();
            data_grid_view_users.DataSource = users;
            data_grid_view_users.Columns["Id"].Width = 35;
            data_grid_view_users.Columns["FirstName"].Width = 195;
            data_grid_view_users.Columns["LastName"].Width = 195;
            data_grid_view_users.Columns["Email"].Width = 195;
            cb_user_filter.SelectedIndex = 0;

            //data_grid_view_users.Columns["Id"].DisplayIndex = 0;
            //data_grid_view_users.Columns["FirstName"].DisplayIndex = 1;
            //data_grid_view_users.Columns["LastName"].DisplayIndex = 2;
            //data_grid_view_users.Columns["Email"].DisplayIndex = 3;
        }

        private void btn_edit_user_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = data_grid_view_users.SelectedRows.Count > 0 ? data_grid_view_users.SelectedRows[0] : null;

            if (selectedRow != null)
            {
                int id = (int)selectedRow.Cells["Id"].Value;

                Form_Edit_User frm = new Form_Edit_User(userManager, id);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show($"There were no rows selected.");
            }
            tb_search_users.Clear();
            cb_user_filter.SelectedIndex = 0;
            LoadUsers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_Purchase_History form_Purchase_History = new Form_Purchase_History();
            form_Purchase_History.ShowDialog();
            tb_search_users.Clear();
            cb_user_filter.SelectedIndex = 0;
        }

        private void btn_remove_user_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = data_grid_view_users.SelectedRows.Count > 0 ? data_grid_view_users.SelectedRows[0] : null;

            if (selectedRow != null)
            {
                {
                    int id = (int)selectedRow.Cells["id"].Value;
                    userManager.UserDeleted += UserManager_UserDeleted;
                    userManager.DeleteUser(id);
                }
            }
            tb_search_users.Clear();
            cb_user_filter.SelectedIndex = 0;
            LoadUsers();
        }

        private void UserManager_UserDeleted(object sender, EventArgs e)
        {
            MessageBox.Show("User was successfully removed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            userManager.UserDeleted -= UserManager_UserDeleted;
        }

        private void btn_add_user_Click(object sender, EventArgs e)
        {
            Form_Add_User form_Add_User = new Form_Add_User(userManager);
            form_Add_User.ShowDialog();
            tb_search_users.Clear();
            cb_user_filter.SelectedIndex = 0;
            LoadUsers();
        }

        private void tb_search_users_TextChanged(object sender, EventArgs e)
        {
            List<User> users;
            if (string.IsNullOrWhiteSpace(tb_search_users.Text))
            {
                users = userManager.GetUsers();
            }
            else
            {
                users = userManager.SearchUsers(tb_search_users.Text);
            }
            data_grid_view_users.DataSource = users;
            data_grid_view_users.Columns["Id"].Width = 35;
            data_grid_view_users.Columns["FirstName"].Width = 195;
            data_grid_view_users.Columns["LastName"].Width = 195;
            data_grid_view_users.Columns["Email"].Width = 195;
            cb_user_filter.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<User> users = userManager.GetUsers();
            if (cb_user_filter.SelectedIndex == 1) //Admins only
            {
                users = users.Where(user => user.UserType == UserType.Admin).ToList();
            }
            else if (cb_user_filter.SelectedIndex == 2) //Customers only
            {
                users = users.Where(user => user.UserType == UserType.Customer).ToList();
            }
            data_grid_view_users.DataSource = users;
            data_grid_view_users.Columns["Id"].Width = 35;
            data_grid_view_users.Columns["FirstName"].Width = 195;
            data_grid_view_users.Columns["LastName"].Width = 195;
            data_grid_view_users.Columns["Email"].Width = 195;
        }
    }
}
