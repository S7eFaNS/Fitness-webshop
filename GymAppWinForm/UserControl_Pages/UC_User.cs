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
        private readonly IUserManager userManager;

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

            data_grid_view_users.Columns["Id"].DisplayIndex = 0;
            data_grid_view_users.Columns["FirstName"].DisplayIndex = 1;
            data_grid_view_users.Columns["LastName"].DisplayIndex = 2;
            data_grid_view_users.Columns["Email"].DisplayIndex = 3;
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

            LoadUsers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_Purchase_History form_Purchase_History = new Form_Purchase_History();
            form_Purchase_History.ShowDialog();
        }

        private void btn_remove_user_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = data_grid_view_users.SelectedRows.Count > 0 ? data_grid_view_users.SelectedRows[0] : null;

            if (selectedRow != null)
            {
                int id = (int)selectedRow.Cells["id"].Value;
                userManager.DeleteUser(id);
            }
            LoadUsers();
        }

        private void btn_add_user_Click(object sender, EventArgs e)
        {
            Form_Add_User form_Add_User = new Form_Add_User(userManager);
            form_Add_User.ShowDialog();

            LoadUsers();
        }
    }
}
