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

namespace GymAppWinForm
{
    public partial class UC_Home : UserControl
    {
        private User loggedInUser;

        public UC_Home(User user)
        {
            this.loggedInUser = user;
            InitializeComponent();
            UserData();
        }

        public void UserData()
        {
            tb_id.Text = "Id: " + loggedInUser.Id.ToString();
            tb_name.Text = "Name: " + loggedInUser.FirstName;
            tb_email.Text = "Email: " + loggedInUser.Email; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loggedInUser = null;
            Form1 form1 = this.ParentForm as Form1;
            form1.Logout(); 
        }


    }
}
