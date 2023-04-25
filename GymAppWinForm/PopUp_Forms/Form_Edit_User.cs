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

namespace GymAppWinForm
{
    public partial class Form_Edit_User : Form
    {
        string Mode { get; set; }
        private int eventId;
        private User user;
        private readonly IUserManager userManager;

        public Form_Edit_User(IUserManager userManager, string mode, int id)
        {
            InitializeComponent();
            this.userManager = userManager;
            Mode = mode;
            FillInData(id);
            eventId = id;
        }

        public void FillInData(int Id)
        {
            user = userManager.GetUserById(Id);

            tb_first_name.Text = user.FirstName;
            tb_last_name.Text = user.LastName;
            tb_email.Text = user.Email;
            tb_password.Text = user.Password;
            comboBox_userType.DataSource = Enum.GetValues(typeof(UserType));
            comboBox_userType.SelectedItem = user.UserType;
        }

        private void Form_Edit_User_Load(object sender, EventArgs e)
        {

        }

        private void btn_save_user_changes_Click(object sender, EventArgs e)
        {
            if (Mode == "Update")
            {
                List<object> eventElements = new List<object>(){
                    eventId,
                    tb_first_name.Text,
                    tb_last_name.Text,
                    tb_email.Text,
                    tb_password.Text,
                    comboBox_userType.Text,
                };

                userManager.UpdateUser(eventElements);
                DialogResult = DialogResult.OK;
            }
            else if (Mode == "Read")
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

        }
    }
}
