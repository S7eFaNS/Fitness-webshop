using ClassLibrary.Classes.Item;
using ClassLibrary.Classes.User;
using InterfaceLibrary.IManagers;
using ManagerLibrary.ManagerClasses;
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class Form_Edit_Product : Form
    {
        private Item item;
        private readonly IItemManager itemManager;

        public Form_Edit_Product(IItemManager itemManager, int id)
        {
            InitializeComponent();
            this.itemManager = itemManager;
            FillInData(id);

        }

        public void FillInData(int Id)
        {
            item = itemManager.GetItemsById(Id);

            tb_item_id.Text = item.ItemId.ToString();
            tb_item_id.ReadOnly = true;
            tb_item_name.Text = item.ItemName;
            tb_item_price.Text = item.ItemPrice.ToString();
            tb_item_quantity.Text = item.ItemQuantity.ToString();
            tb_item_description.Text = item.ItemDescription;
            tb_item_type.Text = item.ItemType.ToString();
            tb_item_type.ReadOnly = true;

            if (item is Programs)
            {
                tb_program_link.Visible = true;
                var program = (Programs)item;
                tb_program_link.Text = program.ProgramLink.ToString();
            }
            else
            {
                tb_program_link.Visible = false;
            }
        }

        private void btn_save_editted_product_Click(object sender, EventArgs e)
        {
            if (item == null)
            {
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }
            bool success = false;

            if (item.ItemType == ItemType.Supplement)
            {
                Supplement supplement = new Supplement();
                supplement.ItemId = Convert.ToInt32(tb_item_id.Text);
                supplement.ItemName = tb_item_name.Text;
                supplement.ItemPrice = Convert.ToDouble(tb_item_price.Text);
                supplement.ItemDescription = tb_item_description.Text;
                supplement.ItemQuantity = Convert.ToInt32(tb_item_quantity.Text);

                success = itemManager.UpdateItem(supplement);
            }
            else if (item.ItemType == ItemType.Program)
            {
                Programs program = new Programs();
                program.ItemId = Convert.ToInt32(tb_item_id.Text);
                program.ItemName = tb_item_name.Text;
                program.ItemPrice = Convert.ToDouble(tb_item_price.Text);
                program.ItemDescription = tb_item_description.Text;
                program.ItemQuantity = Convert.ToInt32(tb_item_quantity.Text);

                success = itemManager.UpdateItem(program);
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

        private void btn_cancel_editing_product_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
