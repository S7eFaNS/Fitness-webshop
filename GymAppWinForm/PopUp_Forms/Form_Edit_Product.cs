using ClassLibrary.Classes.Item;
using ClassLibrary.Classes.User;
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
        //private readonly IItemManager itemManager;
        private readonly ItemManager itemManager;

        public Form_Edit_Product(/*IItemManager*/ ItemManager itemManager, int id)
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
            tb_item_price.Text = Convert.ToDouble(item.ItemPrice).ToString();
            tb_item_quantity.Text = item.ItemQuantity.ToString();
            tb_item_description.Text = item.ItemDescription;
            tb_item_type.Text = item.ItemType.ToString();
            tb_item_type.ReadOnly = true;

            if (item.ItemType == ItemType.Program)
            {
                Programs program = item as Programs;
                if (program != null)
                {
                    tb_program_link.Text = program.ProgramLink.ToString();
                }
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

            try
            {
                bool success = false;

                if (item.ItemType == ItemType.Supplement)
                {
                    Supplement supplement = new Supplement();
                    supplement.ItemId = Convert.ToInt32(tb_item_id.Text);

                    string name = tb_item_name.Text.Trim();
                    if (string.IsNullOrEmpty(name))
                    {
                        MessageBox.Show("Name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    supplement.ItemName = name;

                    double price;
                    if (!double.TryParse(tb_item_price.Text, out price))
                    {
                        MessageBox.Show("Invalid price. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    supplement.ItemPrice = price;

                    string description = tb_item_description.Text.Trim();
                    if (string.IsNullOrEmpty(description))
                    {
                        MessageBox.Show("Description is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    supplement.ItemDescription = description;

                    int quantity;
                    if (!int.TryParse(tb_item_quantity.Text, out quantity))
                    {
                        MessageBox.Show("Invalid quantity. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    supplement.ItemQuantity = quantity;

                    try
                    {
                        success = itemManager.UpdateItem(supplement);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to update the selected Supplement \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (item.ItemType == ItemType.Program)
                {
                    Programs program = new Programs();
                    program.ItemId = Convert.ToInt32(tb_item_id.Text);

                    string name = tb_item_name.Text.Trim();
                    if (string.IsNullOrEmpty(name))
                    {
                        MessageBox.Show("Name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    program.ItemName = name;

                    double price;
                    if (!double.TryParse(tb_item_price.Text, out price))
                    {
                        MessageBox.Show("Invalid price. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    program.ItemPrice = price;

                    string description = tb_item_description.Text.Trim();
                    if (string.IsNullOrEmpty(description))
                    {
                        MessageBox.Show("Description is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    program.ItemDescription = description;

                    int quantity;
                    if (!int.TryParse(tb_item_quantity.Text, out quantity))
                    {
                        MessageBox.Show("Invalid quantity. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    program.ItemQuantity = quantity;

                    if (!string.IsNullOrEmpty(tb_program_link.Text))
                    {
                        program.ProgramLink = tb_program_link.Text.Trim();
                    }
                    else
                    {
                        MessageBox.Show("Program link is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    try
                    {
                        success = itemManager.UpdateItem(program);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to update the selected Program \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update the selected Product \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btn_cancel_editing_product_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
