using ClassLibrary.Classes.User;
using InterfaceLibrary.IManagers;
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
        //private readonly IUserManager userManager;
        private readonly UserManager userManager;


        public Form_Add_User(/*IUserManager*/ UserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;
        }

        private void btn_save_user_changes_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin
            {
                FirstName = tb_first_name.Text,
                LastName = tb_last_name.Text,
                Email = tb_email.Text,
                Password = tb_password.Text
            };

            if (userManager.CreateUser(admin))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
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
