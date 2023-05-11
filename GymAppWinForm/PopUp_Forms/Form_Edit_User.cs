﻿using ClassLibrary.Classes.User;
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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GymAppWinForm
{
    public partial class Form_Edit_User : Form
    {
        private User user;
        //private readonly IUserManager userManager;
        private readonly UserManager userManager;


        public Form_Edit_User(/*IUserManager*/ UserManager userManager,  int id)
        {
            InitializeComponent();
            this.userManager = userManager;
            FillInData(id);
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
            tb_password.ReadOnly= true;
            tb_UserType.Text = user.UserType.ToString();
            tb_UserType.ReadOnly = true;

            if (user.UserType == UserType.Customer)
            {
                Customer customer = user as Customer;
                if (customer != null)
                {
                    tb_age.Text = customer.Age.ToString();
                }
            }
            else
            {
                tb_age.Visible= false;
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
                Admin admin = new Admin();
                admin.Id= Convert.ToInt32(tb_id.Text);
                admin.FirstName = tb_first_name.Text;
                admin.LastName = tb_last_name.Text;
                admin.Email = tb_email.Text;

                success = userManager.UpdateUser(admin);
            }
            else if (user.UserType == UserType.Customer)
            {
                Customer customer = new Customer();
                customer.Id= Convert.ToInt32(tb_id.Text) ;
                customer.FirstName = tb_first_name.Text;
                customer.LastName = tb_last_name.Text;
                customer.Age = Convert.ToInt32(tb_age.Text);
                customer.Email = tb_email.Text;

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
