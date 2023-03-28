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
    public partial class UC_Users : UserControl
    {
        public UC_Users()
        {
            InitializeComponent();
        }

        private void btn_edit_user_Click(object sender, EventArgs e)
        {
            Form_Edit_User form_Edit_User = new Form_Edit_User();
            form_Edit_User.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_Purchase_History form_Purchase_History = new Form_Purchase_History();
            form_Purchase_History.Show();
        }
    }
}
