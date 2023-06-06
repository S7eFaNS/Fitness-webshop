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
        //private readonly IItemManager itemManager;
        private readonly ItemManager itemManager;

        public Form_Add_Product(/*IItemManager*/ ItemManager itemManager)
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
            try
            {
                string name = tb_item_name.Text.Trim();
                string description = tb_item_description.Text.Trim();

                if (cb_item_type.SelectedIndex == -1)
                {
                    MessageBox.Show("Item type is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(description))
                {
                    MessageBox.Show("Description is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                if (cb_item_type.SelectedIndex == (int)ItemType.Supplement)
                {
                    Supplement supplement = new Supplement();
                    supplement.ItemName = name;

                    double price;
                    if (!double.TryParse(tb_item_price.Text, out price))
                    {
                        MessageBox.Show("Invalid price. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    supplement.ItemPrice = price;

                    supplement.ItemDescription = description;

                    int quantity;
                    if (!int.TryParse(tb_item_quantity.Text, out quantity))
                    {
                        MessageBox.Show("Invalid quantity. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    supplement.ItemQuantity = quantity;

                    supplement.ItemType = ItemType.Supplement;

                    try
                    {
                        if (itemManager.CreateItem(supplement))
                        {
                            DialogResult = DialogResult.OK;
                            Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to create a Supplement \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (cb_item_type.SelectedIndex == (int)ItemType.Program)
                {
                    string programLink = tb_program_link.Text.Trim();

                    // Validate program link
                    if (string.IsNullOrEmpty(programLink))
                    {
                        MessageBox.Show("Program link is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Programs program = new Programs();
                    program.ItemName = name;

                    double price;
                    if (!double.TryParse(tb_item_price.Text, out price))
                    {
                        MessageBox.Show("Invalid price. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    program.ItemPrice = price;

                    program.ItemDescription = description;

                    int quantity;
                    if (!int.TryParse(tb_item_quantity.Text, out quantity))
                    {
                        MessageBox.Show("Invalid quantity. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    program.ItemQuantity = quantity;

                    program.ProgramLink = programLink;
                    program.ItemType = ItemType.Program;

                    try
                    {
                        if (itemManager.CreateItem(program))
                        {
                            DialogResult = DialogResult.OK;
                            Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to create a Program \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to create a Product \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btn_cancel_new_product_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
