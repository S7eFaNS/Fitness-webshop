﻿namespace GymAppWinForm
{
    partial class UC_Users
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Users));
            this.lb_users = new System.Windows.Forms.ListBox();
            this.btn_remove_user = new System.Windows.Forms.Button();
            this.tb_search_users = new System.Windows.Forms.TextBox();
            this.btn_edit_user = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.search_users_delete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_users
            // 
            this.lb_users.BackColor = System.Drawing.Color.Silver;
            this.lb_users.FormattingEnabled = true;
            this.lb_users.ItemHeight = 61;
            this.lb_users.Location = new System.Drawing.Point(43, 28);
            this.lb_users.Name = "lb_users";
            this.lb_users.Size = new System.Drawing.Size(752, 553);
            this.lb_users.TabIndex = 0;
            // 
            // btn_remove_user
            // 
            this.btn_remove_user.BackColor = System.Drawing.Color.Silver;
            this.btn_remove_user.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_remove_user.ForeColor = System.Drawing.Color.Black;
            this.btn_remove_user.Image = ((System.Drawing.Image)(resources.GetObject("btn_remove_user.Image")));
            this.btn_remove_user.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_remove_user.Location = new System.Drawing.Point(856, 508);
            this.btn_remove_user.Name = "btn_remove_user";
            this.btn_remove_user.Size = new System.Drawing.Size(270, 73);
            this.btn_remove_user.TabIndex = 1;
            this.btn_remove_user.Text = "Remove";
            this.btn_remove_user.UseVisualStyleBackColor = false;
            // 
            // tb_search_users
            // 
            this.tb_search_users.BackColor = System.Drawing.Color.Silver;
            this.tb_search_users.Location = new System.Drawing.Point(801, 95);
            this.tb_search_users.Name = "tb_search_users";
            this.tb_search_users.Size = new System.Drawing.Size(378, 69);
            this.tb_search_users.TabIndex = 2;
            // 
            // btn_edit_user
            // 
            this.btn_edit_user.BackColor = System.Drawing.Color.Silver;
            this.btn_edit_user.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_edit_user.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_edit_user.ForeColor = System.Drawing.Color.Black;
            this.btn_edit_user.Image = ((System.Drawing.Image)(resources.GetObject("btn_edit_user.Image")));
            this.btn_edit_user.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_edit_user.Location = new System.Drawing.Point(856, 429);
            this.btn_edit_user.Name = "btn_edit_user";
            this.btn_edit_user.Size = new System.Drawing.Size(270, 73);
            this.btn_edit_user.TabIndex = 3;
            this.btn_edit_user.Text = "Edit";
            this.btn_edit_user.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(801, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 61);
            this.label1.TabIndex = 4;
            this.label1.Text = "Search:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Silver;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(801, 170);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(378, 73);
            this.button1.TabIndex = 5;
            this.button1.Text = "Purchase History";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // search_users_delete
            // 
            this.search_users_delete.Image = ((System.Drawing.Image)(resources.GetObject("search_users_delete.Image")));
            this.search_users_delete.Location = new System.Drawing.Point(1111, 95);
            this.search_users_delete.Name = "search_users_delete";
            this.search_users_delete.Size = new System.Drawing.Size(68, 69);
            this.search_users_delete.TabIndex = 6;
            this.search_users_delete.UseVisualStyleBackColor = true;
            // 
            // UC_Users
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Indigo;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.search_users_delete);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_edit_user);
            this.Controls.Add(this.tb_search_users);
            this.Controls.Add(this.btn_remove_user);
            this.Controls.Add(this.lb_users);
            this.Font = new System.Drawing.Font("Century Gothic", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UC_Users";
            this.Size = new System.Drawing.Size(1182, 616);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox lb_users;
        private Button btn_remove_user;
        private TextBox tb_search_users;
        private Button btn_edit_user;
        private Label label1;
        private Button button1;
        private Button search_users_delete;
    }
}
