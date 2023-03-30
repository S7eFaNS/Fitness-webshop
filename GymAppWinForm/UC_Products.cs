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
    public partial class UC_Products : UserControl
    {
        public UC_Products()
        {
            InitializeComponent();
        }

        private void btn_add_product_Click(object sender, EventArgs e)
        {
            Form_Add_Product form_Add_Product = new Form_Add_Product();
            form_Add_Product.ShowDialog();
        }

        private void btn_edit_product_Click(object sender, EventArgs e)
        {
            Form_Edit_Product form_Edit_Product = new Form_Edit_Product();
            form_Edit_Product.ShowDialog();
        }
    }
}
