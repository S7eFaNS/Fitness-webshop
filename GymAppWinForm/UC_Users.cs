using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary.Classes.User;
using ManagerLibrary;

namespace GymAppWinForm
{
    public partial class UC_Users : UserControl
    {
        UserManager userManager = new UserManager();

        public UC_Users()
        {
            InitializeComponent();
            LoadUsers();
        }

        public void LoadUsers()
        {
            UserManager userManager = new UserManager();
            List<User> users = userManager.GetAllUsers();
            data_grid_view_users.DataSource = users;
            data_grid_view_users.Columns["Id"].Width = 35;
            data_grid_view_users.Columns["GetFirstName"].Width = 195;
            data_grid_view_users.Columns["GetLastName"].Width = 195;
            data_grid_view_users.Columns["GetEmail"].Width = 195;


            data_grid_view_users.Columns["Id"].DisplayIndex = 0;
            data_grid_view_users.Columns["GetFirstName"].DisplayIndex = 1;
            data_grid_view_users.Columns["GetLastName"].DisplayIndex = 2;
            data_grid_view_users.Columns["GetEmail"].DisplayIndex = 3;
        }

        private void btn_edit_user_Click(object sender, EventArgs e)
        {
            Form_Edit_User form_Edit_User = new Form_Edit_User();
            form_Edit_User.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_Purchase_History form_Purchase_History = new Form_Purchase_History();
            form_Purchase_History.ShowDialog();
        }

        private void btn_remove_user_Click(object sender, EventArgs e)
        {
            // Get the selected row
            DataGridViewRow selectedRow = data_grid_view_users.SelectedRows[0];

            // Get the user object from the selected row
            int userId = int.Parse(selectedRow.Cells["Id"].Value.ToString());
            string firstName = selectedRow.Cells["GetFirstName"].Value.ToString();
            string lastName = selectedRow.Cells["GetLastName"].Value.ToString();
            string email = selectedRow.Cells["GetEmail"].Value.ToString();
            User selectedUser = new User { Id = userId, GetFirstName = firstName, GetLastName = lastName, GetEmail = email };

            // Delete the user from the database
            if (userManager.DeleteUser(selectedUser))
            {
                // Remove the row from the DataGridView
                data_grid_view_users.Rows.Remove(selectedRow);
            }
        }
    }
}
