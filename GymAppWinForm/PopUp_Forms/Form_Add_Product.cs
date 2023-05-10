using ClassLibrary.Classes.Item;
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
    public partial class Form_Add_Product : Form
    {
        private readonly IItemManager itemManager;

        public Form_Add_Product(IItemManager itemManager)
        {
            InitializeComponent();
            this.itemManager = itemManager;
            foreach (string itemTypeName in Enum.GetNames(typeof(ItemType)))
            {
                cb_item_type.Items.Add(itemTypeName);
            }
        }

        private void btn_save_new_product_Click(object sender, EventArgs e)
        {
            if (cb_item_type.SelectedIndex == (int)ItemType.Supplement)
            {
                Supplement supplement = new Supplement();
                supplement.ItemName = tb_item_name.Text;
                supplement.ItemPrice = Convert.ToDouble(tb_item_price.Text);
                supplement.ItemDescription = tb_item_description.Text;
                supplement.ItemQuantity = Convert.ToInt32(tb_item_quantity.Text);
                supplement.ItemType = ItemType.Supplement;
                //supplement.ItemType = (ItemType)cb_item_type.SelectedItem;
                if (itemManager.CreateItem(supplement))
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Failed to create a supplement.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (cb_item_type.SelectedIndex == (int)ItemType.Program)
            {
                Programs program = new Programs();
                program.ItemName = tb_item_name.Text;
                program.ItemPrice = Convert.ToDouble(tb_item_price.Text);
                program.ItemDescription = tb_item_description.Text;
                program.ItemQuantity = Convert.ToInt32(tb_item_quantity.Text);
                program.ProgramLink = tb_program_link.Text;
                program.ItemType = ItemType.Program;    
                //program.ItemType = (ItemType)cb_item_type.SelectedItem;
                if (itemManager.CreateItem(program))
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Failed to create a program.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Failed to create an item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cancel_new_product_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
