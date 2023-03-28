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
            this.lb_products = new System.Windows.Forms.ListBox();
            this.btn_add_product = new System.Windows.Forms.Button();
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
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(781, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 61);
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
            // 
            // tb_search_users
            // 
            this.tb_search_users.BackColor = System.Drawing.Color.Silver;
            this.tb_search_users.Location = new System.Drawing.Point(781, 99);
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
            // 
            // lb_products
            // 
            this.lb_products.BackColor = System.Drawing.Color.Silver;
            this.lb_products.FormattingEnabled = true;
            this.lb_products.ItemHeight = 61;
            this.lb_products.Location = new System.Drawing.Point(23, 32);
            this.lb_products.Name = "lb_products";
            this.lb_products.Size = new System.Drawing.Size(752, 553);
            this.lb_products.TabIndex = 7;
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
            // 
            // UC_Products
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Indigo;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btn_add_product);
            this.Controls.Add(this.search_product_delete);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_edit_product);
            this.Controls.Add(this.tb_search_users);
            this.Controls.Add(this.btn_remove_product);
            this.Controls.Add(this.lb_products);
            this.Font = new System.Drawing.Font("Century Gothic", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UC_Products";
            this.Size = new System.Drawing.Size(1182, 616);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button search_product_delete;
        private Label label1;
        private Button btn_edit_product;
        private TextBox tb_search_users;
        private Button btn_remove_product;
        private ListBox lb_products;
        private Button btn_add_product;
    }
}
