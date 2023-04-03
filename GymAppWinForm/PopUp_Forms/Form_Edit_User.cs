using ClassLibrary.Classes.User;
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
        User user;
        UserManager userManager = new UserManager();

        public Form_Edit_User(string mode, int id)
        {
            InitializeComponent();
            Mode = mode;
            FillInData(id);
            eventId = id;
        }

        public void FillInData(int Id)
        {
            user = userManager.GetUserById(Id);

            tb_first_name.Text = user.GetFirstName;
            tb_last_name.Text = user.GetLastName;
            tb_email.Text = user.GetEmail;
            tb_password.Text = user.GetPassword;
            comboBox_userType.DataSource = Enum.GetValues(typeof(UserType));
            comboBox_userType.SelectedItem = user.GetUserType;
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

                userManager.UpdateEvent(eventElements);
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
