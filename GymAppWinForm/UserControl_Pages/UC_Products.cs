using ClassLibrary.Classes.Item;
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
    public partial class UC_Products : UserControl
    {
        private readonly IItemManager itemManager;

        public UC_Products()
        {
            IItemRepository itemRepository = new ItemRepository();
            InitializeComponent();
            this.itemManager = new ItemManager(itemRepository);
            LoadItems();
        }

        public void LoadItems()
        {
            List<Item> items = itemManager.GetItems();
            data_grid_view_items.DataSource = items;
            data_grid_view_items.Columns["ItemId"].Width = 80;
            data_grid_view_items.Columns["ItemName"].Width = 195;
            data_grid_view_items.Columns["ItemPrice"].Width = 125;
            data_grid_view_items.Columns["ItemDescription"].Width = 250;
            data_grid_view_items.Columns["ItemQuantity"].Width = 150;

            //data_grid_view_items.Columns["Id"].DisplayIndex = 0;
            //data_grid_view_items.Columns["FirstName"].DisplayIndex = 1;
            //data_grid_view_items.Columns["LastName"].DisplayIndex = 2;
            //data_grid_view_items.Columns["Email"].DisplayIndex = 3;
        }

        private void btn_add_product_Click(object sender, EventArgs e)
        {
            Form_Add_Product form_Add_Product = new Form_Add_Product(itemManager);
            form_Add_Product.ShowDialog();

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

            LoadItems();
        }

        private void btn_remove_product_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = data_grid_view_items.SelectedRows.Count > 0 ? data_grid_view_items.SelectedRows[0] : null;

            if (selectedRow != null)
            {
                int id = (int)selectedRow.Cells["ItemId"].Value;
                itemManager.DeleteItem(id);
            }
            LoadItems();
        }
    }
}
