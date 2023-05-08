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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GymAppWinForm
{
    public partial class Form_Edit_User : Form
    {
        string Mode { get; set; }
        private int userId;
        private User user;
        private readonly IUserManager userManager;

        public Form_Edit_User(IUserManager userManager, string mode, int id)
        {
            InitializeComponent();
            this.userManager = userManager;
            Mode = mode;
            FillInData(id);
            userId = id;
        }

        public void FillInData(int Id)
        {
            user = userManager.GetUserById(Id);

            tb_id.Text = user.Id.ToString();
            tb_id.ReadOnly= true;
            tb_first_name.Text = user.FirstName;
            tb_last_name.Text = user.LastName;
            tb_email.Text = user.Email;
            tb_password.Text = user.Password;
            tb_UserType.Text = user.UserType.ToString();
            tb_UserType.ReadOnly = true;

            if (user is Customer)
            {
                tb_age.Visible = true;
                tb_age.Text = ((Customer)user).Age.ToString();
            }
            else
            {
                tb_age.Visible = false;
            }
        }

        private void Form_Edit_User_Load(object sender, EventArgs e)
        {

        }

        private void btn_save_user_changes_Click(object sender, EventArgs e)
        {
            if (user == null)
            {
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            bool success = false;

            if (user.UserType == UserType.Admin)
            {
                // Update the Admin object with the new information
                Admin admin = new Admin();
                admin.Id= Convert.ToInt32(tb_id.Text);
                admin.FirstName = tb_first_name.Text;
                admin.LastName = tb_last_name.Text;
                admin.Email = tb_email.Text;
                admin.Password = tb_password.Text;

                // Call the UpdateAdmin method to update the Admin object in the database
                success = userManager.UpdateUser(admin);
            }
            else if (user.UserType == UserType.Customer)
            {
                // Update the Customer object with the new information
                Customer customer = (Customer)user;
                customer.Id= Convert.ToInt32(tb_id.Text) ;
                customer.FirstName = tb_first_name.Text;
                customer.LastName = tb_last_name.Text;
                customer.Age = Convert.ToInt32(tb_age.Text);
                customer.Email = tb_email.Text;
                customer.Password = tb_password.Text;

                // Call the UpdateCustomer method to update the Customer object in the database
                success = userManager.UpdateUser(customer);
            }

            if (success)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }

            Close();
        }

        private void btn_cancel_user_changes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
