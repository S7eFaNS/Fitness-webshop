﻿using ClassLibrary.Classes.User;
using InterfaceLibrary.IRepositories;
using ManagerLibrary.Algorithm;
using ManagerLibrary.ManagerClasses;
using ManagerLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GymAppWinForm.UserControl_Pages
{
    public partial class UC_User : UserControl
    {
        private readonly UserManager userManager;


        public UC_User()
        {
            IUserRepository repository = new UserRepository();
            InitializeComponent();
            this.userManager = new UserManager(repository);
            LoadUsers();
        }

        public void LoadUsers()
        {
            try
            {
                List<User> users = userManager.GetUsers();
                data_grid_view_users.DataSource = users;
                data_grid_view_users.Columns["Id"].Width = 35;
                data_grid_view_users.Columns["FirstName"].Width = 195;
                data_grid_view_users.Columns["LastName"].Width = 195;
                data_grid_view_users.Columns["Email"].Width = 195;
                cb_user_filter.SelectedIndex = 0;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btn_remove_user_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = data_grid_view_users.SelectedRows.Count > 0 ? data_grid_view_users.SelectedRows[0] : null;

            if (selectedRow != null)
            {
                try
                {
                    int id = (int)selectedRow.Cells["id"].Value;
                    userManager.UserDeleted += UserManager_UserDeleted;
                    userManager.DeleteUser(id);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to delete user. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (users.Count == 0)
            {
                MessageBox.Show("No users found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SortUsers sortUsers = new SortUsers();
            List<User> users = userManager.GetUsers();
            if (cb_user_filter.SelectedIndex == 1) //Admins only
            {
                users = sortUsers.SortByUserTypeAdmin(users);
            }
            else if (cb_user_filter.SelectedIndex == 2) //Customers only
            {
                users = sortUsers.SortByUserTypeCustomer(users);
            }
            data_grid_view_users.DataSource = users;
            data_grid_view_users.Columns["Id"].Width = 45;
            data_grid_view_users.Columns["FirstName"].Width = 195;
            data_grid_view_users.Columns["LastName"].Width = 195;
            data_grid_view_users.Columns["Email"].Width = 195;
        }
    }
}
