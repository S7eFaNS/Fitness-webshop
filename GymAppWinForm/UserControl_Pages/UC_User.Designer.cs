namespace GymAppWinForm.UserControl_Pages
{
    partial class UC_User
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_User));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_add_user = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_edit_user = new System.Windows.Forms.Button();
            this.tb_search_users = new System.Windows.Forms.TextBox();
            this.btn_remove_user = new System.Windows.Forms.Button();
            this.data_grid_view_users = new System.Windows.Forms.DataGridView();
            this.cb_user_filter = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.data_grid_view_users)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_add_user
            // 
            this.btn_add_user.BackColor = System.Drawing.Color.Silver;
            this.btn_add_user.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_add_user.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_add_user.ForeColor = System.Drawing.Color.Black;
            this.btn_add_user.Image = ((System.Drawing.Image)(resources.GetObject("btn_add_user.Image")));
            this.btn_add_user.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_add_user.Location = new System.Drawing.Point(799, 354);
            this.btn_add_user.Name = "btn_add_user";
            this.btn_add_user.Size = new System.Drawing.Size(270, 73);
            this.btn_add_user.TabIndex = 24;
            this.btn_add_user.Text = "Add";
            this.btn_add_user.UseVisualStyleBackColor = false;
            this.btn_add_user.Click += new System.EventHandler(this.btn_add_user_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Silver;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(744, 174);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(378, 73);
            this.button1.TabIndex = 22;
            this.button1.Text = "Purchase History";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(744, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 57);
            this.label1.TabIndex = 21;
            this.label1.Text = "Search:";
            // 
            // btn_edit_user
            // 
            this.btn_edit_user.BackColor = System.Drawing.Color.Silver;
            this.btn_edit_user.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_edit_user.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_edit_user.ForeColor = System.Drawing.Color.Black;
            this.btn_edit_user.Image = ((System.Drawing.Image)(resources.GetObject("btn_edit_user.Image")));
            this.btn_edit_user.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_edit_user.Location = new System.Drawing.Point(799, 433);
            this.btn_edit_user.Name = "btn_edit_user";
            this.btn_edit_user.Size = new System.Drawing.Size(270, 73);
            this.btn_edit_user.TabIndex = 20;
            this.btn_edit_user.Text = "Edit";
            this.btn_edit_user.UseVisualStyleBackColor = false;
            this.btn_edit_user.Click += new System.EventHandler(this.btn_edit_user_Click);
            // 
            // tb_search_users
            // 
            this.tb_search_users.BackColor = System.Drawing.Color.Silver;
            this.tb_search_users.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_search_users.Location = new System.Drawing.Point(744, 99);
            this.tb_search_users.Multiline = true;
            this.tb_search_users.Name = "tb_search_users";
            this.tb_search_users.Size = new System.Drawing.Size(378, 57);
            this.tb_search_users.TabIndex = 19;
            this.tb_search_users.TextChanged += new System.EventHandler(this.tb_search_users_TextChanged);
            // 
            // btn_remove_user
            // 
            this.btn_remove_user.BackColor = System.Drawing.Color.Silver;
            this.btn_remove_user.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_remove_user.ForeColor = System.Drawing.Color.Black;
            this.btn_remove_user.Image = ((System.Drawing.Image)(resources.GetObject("btn_remove_user.Image")));
            this.btn_remove_user.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_remove_user.Location = new System.Drawing.Point(799, 512);
            this.btn_remove_user.Name = "btn_remove_user";
            this.btn_remove_user.Size = new System.Drawing.Size(270, 73);
            this.btn_remove_user.TabIndex = 18;
            this.btn_remove_user.Text = "Remove";
            this.btn_remove_user.UseVisualStyleBackColor = false;
            this.btn_remove_user.Click += new System.EventHandler(this.btn_remove_user_Click);
            // 
            // data_grid_view_users
            // 
            this.data_grid_view_users.AllowUserToAddRows = false;
            this.data_grid_view_users.AllowUserToDeleteRows = false;
            this.data_grid_view_users.AllowUserToOrderColumns = true;
            this.data_grid_view_users.AllowUserToResizeColumns = false;
            this.data_grid_view_users.AllowUserToResizeRows = false;
            this.data_grid_view_users.BackgroundColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.data_grid_view_users.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.data_grid_view_users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_grid_view_users.GridColor = System.Drawing.SystemColors.Control;
            this.data_grid_view_users.Location = new System.Drawing.Point(91, 99);
            this.data_grid_view_users.Margin = new System.Windows.Forms.Padding(2);
            this.data_grid_view_users.Name = "data_grid_view_users";
            this.data_grid_view_users.ReadOnly = true;
            this.data_grid_view_users.RowHeadersVisible = false;
            this.data_grid_view_users.RowHeadersWidth = 200;
            this.data_grid_view_users.RowTemplate.Height = 29;
            this.data_grid_view_users.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.data_grid_view_users.Size = new System.Drawing.Size(624, 474);
            this.data_grid_view_users.TabIndex = 3;
            // 
            // cb_user_filter
            // 
            this.cb_user_filter.BackColor = System.Drawing.Color.Silver;
            this.cb_user_filter.ForeColor = System.Drawing.Color.Black;
            this.cb_user_filter.FormattingEnabled = true;
            this.cb_user_filter.Items.AddRange(new object[] {
            "No Filter",
            "Admins",
            "Customers"});
            this.cb_user_filter.Location = new System.Drawing.Point(564, 58);
            this.cb_user_filter.Name = "cb_user_filter";
            this.cb_user_filter.Size = new System.Drawing.Size(151, 31);
            this.cb_user_filter.TabIndex = 25;
            this.cb_user_filter.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // UC_User
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.cb_user_filter);
            this.Controls.Add(this.data_grid_view_users);
            this.Controls.Add(this.btn_add_user);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_edit_user);
            this.Controls.Add(this.tb_search_users);
            this.Controls.Add(this.btn_remove_user);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UC_User";
            this.Size = new System.Drawing.Size(1182, 616);
            ((System.ComponentModel.ISupportInitialize)(this.data_grid_view_users)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button btn_add_user;
        private Button button1;
        private Label label1;
        private Button btn_edit_user;
        private TextBox tb_search_users;
        private Button btn_remove_user;
        private DataGridView data_grid_view_users;
        private ComboBox cb_user_filter;
    }
}
