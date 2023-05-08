using ClassLibrary.Classes.User;
using InterfaceLibrary.Interfaces;
using ManagerLibrary.ManagerClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymAppWinForm
{
    public partial class Form_Add_User : Form
    {
        private readonly IUserManager userManager;

        public Form_Add_User(IUserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;
        }

        private void btn_save_user_changes_Click(object sender, EventArgs e)
        {
            // Create a new Admin object with the values entered in the textboxes
            Admin admin = new Admin
            {
                FirstName = tb_first_name.Text,
                LastName = tb_last_name.Text,
                Email = tb_email.Text,
                Password = tb_password.Text
            };

            // Try to create the new admin in the database
            if (userManager.CreateUser(admin))
            {
                // If the admin was created successfully, set the dialog result to OK and close the form
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                // If the admin creation failed, show an error message
                MessageBox.Show("Failed to create admin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cancel_user_changes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
