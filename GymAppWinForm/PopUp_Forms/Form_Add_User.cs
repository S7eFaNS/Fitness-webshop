﻿using ClassLibrary.Classes.User;
using ManagerLibrary.ManagerClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymAppWinForm
{
    public partial class Form_Add_User : Form
    {
        private readonly UserManager userManager;


        public Form_Add_User(UserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;
        }

        private void btn_save_user_changes_Click(object sender, EventArgs e)
        {
            string emailPattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";
            string namePattern = @"^[A-Za-z]+([-']?[A-Za-z]+)*$";

            if (!Regex.IsMatch(tb_email.Text, emailPattern))
            {
                MessageBox.Show("Invalid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Regex.IsMatch(tb_first_name.Text, namePattern))
            {
                MessageBox.Show("Invalid first name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Regex.IsMatch(tb_last_name.Text, namePattern))
            {
                MessageBox.Show("Invalid last name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(tb_password.Text))
            {
                MessageBox.Show("Password is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create admin object with validated input
            Admin admin = new Admin
            {
                FirstName = char.ToUpper(tb_first_name.Text[0]) + tb_first_name.Text.Substring(1),
                LastName = char.ToUpper(tb_last_name.Text[0]) + tb_last_name.Text.Substring(1),
                Email = tb_email.Text.ToLower(),
                Password = tb_password.Text
            };

            try
            {
                if (userManager.CreateUser(admin))
                {
                    DialogResult = DialogResult.OK;
                    userManager.AdminCreated += UserManager_AdminCreated;
                    Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to create admin. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserManager_AdminCreated(object sender, EventArgs e)
        {
            MessageBox.Show("Admin created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            userManager.AdminCreated -= UserManager_AdminCreated;
        }

        private void btn_cancel_user_changes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
