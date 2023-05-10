namespace GymAppWinForm
{
    partial class UC_Products
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Products));
            this.search_product_delete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_edit_product = new System.Windows.Forms.Button();
            this.tb_search_users = new System.Windows.Forms.TextBox();
            this.btn_remove_product = new System.Windows.Forms.Button();
            this.btn_add_product = new System.Windows.Forms.Button();
            this.data_grid_view_items = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.data_grid_view_items)).BeginInit();
            this.SuspendLayout();
            // 
            // search_product_delete
            // 
            this.search_product_delete.Image = ((System.Drawing.Image)(resources.GetObject("search_product_delete.Image")));
            this.search_product_delete.Location = new System.Drawing.Point(1091, 99);
            this.search_product_delete.Name = "search_product_delete";
            this.search_product_delete.Size = new System.Drawing.Size(68, 69);
            this.search_product_delete.TabIndex = 13;
            this.search_product_delete.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(781, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 57);
            this.label1.TabIndex = 11;
            this.label1.Text = "Search:";
            // 
            // btn_edit_product
            // 
            this.btn_edit_product.BackColor = System.Drawing.Color.Silver;
            this.btn_edit_product.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_edit_product.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_edit_product.ForeColor = System.Drawing.Color.Black;
            this.btn_edit_product.Image = ((System.Drawing.Image)(resources.GetObject("btn_edit_product.Image")));
            this.btn_edit_product.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_edit_product.Location = new System.Drawing.Point(836, 433);
            this.btn_edit_product.Name = "btn_edit_product";
            this.btn_edit_product.Size = new System.Drawing.Size(270, 73);
            this.btn_edit_product.TabIndex = 10;
            this.btn_edit_product.Text = "Edit";
            this.btn_edit_product.UseVisualStyleBackColor = false;
            this.btn_edit_product.Click += new System.EventHandler(this.btn_edit_product_Click);
            // 
            // tb_search_users
            // 
            this.tb_search_users.BackColor = System.Drawing.Color.Silver;
            this.tb_search_users.Location = new System.Drawing.Point(781, 99);
            this.tb_search_users.Multiline = true;
            this.tb_search_users.Name = "tb_search_users";
            this.tb_search_users.Size = new System.Drawing.Size(378, 69);
            this.tb_search_users.TabIndex = 9;
            // 
            // btn_remove_product
            // 
            this.btn_remove_product.BackColor = System.Drawing.Color.Silver;
            this.btn_remove_product.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_remove_product.ForeColor = System.Drawing.Color.Black;
            this.btn_remove_product.Image = ((System.Drawing.Image)(resources.GetObject("btn_remove_product.Image")));
            this.btn_remove_product.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_remove_product.Location = new System.Drawing.Point(836, 512);
            this.btn_remove_product.Name = "btn_remove_product";
            this.btn_remove_product.Size = new System.Drawing.Size(270, 73);
            this.btn_remove_product.TabIndex = 8;
            this.btn_remove_product.Text = "Remove";
            this.btn_remove_product.UseVisualStyleBackColor = false;
            this.btn_remove_product.Click += new System.EventHandler(this.btn_remove_product_Click);
            // 
            // btn_add_product
            // 
            this.btn_add_product.BackColor = System.Drawing.Color.Silver;
            this.btn_add_product.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_add_product.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_add_product.ForeColor = System.Drawing.Color.Black;
            this.btn_add_product.Image = ((System.Drawing.Image)(resources.GetObject("btn_add_product.Image")));
            this.btn_add_product.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_add_product.Location = new System.Drawing.Point(836, 354);
            this.btn_add_product.Name = "btn_add_product";
            this.btn_add_product.Size = new System.Drawing.Size(270, 73);
            this.btn_add_product.TabIndex = 14;
            this.btn_add_product.Text = "Add";
            this.btn_add_product.UseVisualStyleBackColor = false;
            this.btn_add_product.Click += new System.EventHandler(this.btn_add_product_Click);
            // 
            // data_grid_view_items
            // 
            this.data_grid_view_items.AllowUserToAddRows = false;
            this.data_grid_view_items.AllowUserToDeleteRows = false;
            this.data_grid_view_items.AllowUserToOrderColumns = true;
            this.data_grid_view_items.AllowUserToResizeColumns = false;
            this.data_grid_view_items.AllowUserToResizeRows = false;
            this.data_grid_view_items.BackgroundColor = System.Drawing.Color.Silver;
            this.data_grid_view_items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_grid_view_items.GridColor = System.Drawing.SystemColors.Control;
            this.data_grid_view_items.Location = new System.Drawing.Point(60, 84);
            this.data_grid_view_items.Margin = new System.Windows.Forms.Padding(2);
            this.data_grid_view_items.Name = "data_grid_view_items";
            this.data_grid_view_items.ReadOnly = true;
            this.data_grid_view_items.RowHeadersVisible = false;
            this.data_grid_view_items.RowHeadersWidth = 200;
            this.data_grid_view_items.RowTemplate.Height = 29;
            this.data_grid_view_items.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.data_grid_view_items.Size = new System.Drawing.Size(675, 501);
            this.data_grid_view_items.TabIndex = 3;
            // 
            // UC_Products
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.data_grid_view_items);
            this.Controls.Add(this.btn_add_product);
            this.Controls.Add(this.search_product_delete);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_edit_product);
            this.Controls.Add(this.tb_search_users);
            this.Controls.Add(this.btn_remove_product);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UC_Products";
            this.Size = new System.Drawing.Size(1182, 616);
            ((System.ComponentModel.ISupportInitialize)(this.data_grid_view_items)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button search_product_delete;
        private Label label1;
        private Button btn_edit_product;
        private TextBox tb_search_users;
        private Button btn_remove_product;
        private Button btn_add_product;
        private DataGridView data_grid_view_items;
    }
}
