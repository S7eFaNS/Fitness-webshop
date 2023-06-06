using ClassLibrary.Classes.Item;
using InterfaceLibrary.IManagers;
using InterfaceLibrary.IRepositories;
using ManagerLibrary.Algorithm;
using ManagerLibrary.ManagerClasses;
using ManagerLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymAppWinForm
{
    public partial class UC_Products : UserControl
    {
        private readonly ItemManager itemManager;

        public UC_Products()
        {
            IItemRepository itemRepository = new ItemRepository();
            InitializeComponent();
            this.itemManager = new ItemManager(itemRepository);
            LoadItems();
        }

        public void LoadItems()
        {
            try
            {
                List<Item> items = itemManager.GetItems();
                data_grid_view_items.DataSource = items;
                data_grid_view_items.Columns["ItemId"].Width = 80;
                data_grid_view_items.Columns["ItemName"].Width = 195;
                data_grid_view_items.Columns["ItemPrice"].Width = 125;
                data_grid_view_items.Columns["ItemDescription"].Width = 250;
                data_grid_view_items.Columns["ItemQuantity"].Width = 150;
                cb_item_filter.SelectedIndex = 0;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_add_product_Click(object sender, EventArgs e)
        {
            Form_Add_Product form_Add_Product = new Form_Add_Product(itemManager);
            form_Add_Product.ShowDialog();

            tb_search_items.Clear();
            cb_item_filter.SelectedIndex = 0;
            LoadItems();
        }

        private void btn_edit_product_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = data_grid_view_items.SelectedRows.Count > 0 ? data_grid_view_items.SelectedRows[0] : null;

            if (selectedRow != null)
            {
                int id = (int)selectedRow.Cells["ItemId"].Value;

                Form_Edit_Product frm = new Form_Edit_Product(itemManager, id);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show($"There were no rows selected.");
            }
            tb_search_items.Clear();
            cb_item_filter.SelectedIndex = 0;
            LoadItems();
        }

        private void btn_remove_product_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = data_grid_view_items.SelectedRows.Count > 0 ? data_grid_view_items.SelectedRows[0] : null;

            if (selectedRow != null)
            {
                try
                {
                    int id = (int)selectedRow.Cells["ItemId"].Value;
                    itemManager.DeleteItem(id);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to delete user. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            tb_search_items.Clear();
            cb_item_filter.SelectedIndex = 0;
            LoadItems();
        }

        private void tb_search_users_TextChanged(object sender, EventArgs e)
        {
            List<Item> items;
            if (string.IsNullOrWhiteSpace(tb_search_items.Text))
            {
                items = itemManager.GetItems();
            }
            else
            {
                items = itemManager.SearchItems(tb_search_items.Text);
            }
            data_grid_view_items.DataSource = items;
            data_grid_view_items.Columns["ItemId"].Width = 80;
            data_grid_view_items.Columns["ItemName"].Width = 195;
            data_grid_view_items.Columns["ItemPrice"].Width = 125;
            data_grid_view_items.Columns["ItemDescription"].Width = 250;
            data_grid_view_items.Columns["ItemQuantity"].Width = 150;
            cb_item_filter.SelectedIndex = 0;
            if (items.Count == 0)
            {
                MessageBox.Show("No items found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cb_item_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Item> items = itemManager.GetItems();
            if (cb_item_filter.SelectedIndex == 1) // Price ASC
            {
                SortItems.SortByPriceAsc(items);
            }
            else if (cb_item_filter.SelectedIndex == 2) // Price DESC
            {
                SortItems.SortByPriceDesc(items);
            }
            else if (cb_item_filter.SelectedIndex == 3) // Quantity ASC
            {
                SortItems.SortByQuantityAsc(items);
            }
            else if (cb_item_filter.SelectedIndex == 4) // Quantity DESC
            {
                SortItems.SortByQuantityDesc(items);
            }
            else if (cb_item_filter.SelectedIndex == 5) // Supplements only
            {
                items = SortItems.SortByItemTypeSupplement(items);
            }
            else if (cb_item_filter.SelectedIndex == 6) // Programs only
            {
                items = SortItems.SortByItemTypeProgram(items);
            }
            data_grid_view_items.DataSource = items;
            data_grid_view_items.Columns["ItemId"].Width = 80;
            data_grid_view_items.Columns["ItemName"].Width = 195;
            data_grid_view_items.Columns["ItemPrice"].Width = 125;
            data_grid_view_items.Columns["ItemDescription"].Width = 250;
            data_grid_view_items.Columns["ItemQuantity"].Width = 150;
        }
    }
}
