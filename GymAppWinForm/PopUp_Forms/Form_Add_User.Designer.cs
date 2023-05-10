namespace GymAppWinForm
{
    partial class Form_Add_User
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Add_User));
            this.btn_cancel_user_changes = new System.Windows.Forms.Button();
            this.btn_save_user_changes = new System.Windows.Forms.Button();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.tb_email = new System.Windows.Forms.TextBox();
            this.tb_last_name = new System.Windows.Forms.TextBox();
            this.tb_first_name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_cancel_user_changes
            // 
            this.btn_cancel_user_changes.BackColor = System.Drawing.Color.Silver;
            this.btn_cancel_user_changes.Location = new System.Drawing.Point(451, 328);
            this.btn_cancel_user_changes.Name = "btn_cancel_user_changes";
            this.btn_cancel_user_changes.Size = new System.Drawing.Size(235, 89);
            this.btn_cancel_user_changes.TabIndex = 21;
            this.btn_cancel_user_changes.Text = "Cancel";
            this.btn_cancel_user_changes.UseVisualStyleBackColor = false;
            this.btn_cancel_user_changes.Click += new System.EventHandler(this.btn_cancel_user_changes_Click);
            // 
            // btn_save_user_changes
            // 
            this.btn_save_user_changes.BackColor = System.Drawing.Color.Silver;
            this.btn_save_user_changes.Location = new System.Drawing.Point(132, 328);
            this.btn_save_user_changes.Name = "btn_save_user_changes";
            this.btn_save_user_changes.Size = new System.Drawing.Size(235, 89);
            this.btn_save_user_changes.TabIndex = 20;
            this.btn_save_user_changes.Text = "Save";
            this.btn_save_user_changes.UseVisualStyleBackColor = false;
            this.btn_save_user_changes.Click += new System.EventHandler(this.btn_save_user_changes_Click);
            // 
            // tb_password
            // 
            this.tb_password.BackColor = System.Drawing.Color.Silver;
            this.tb_password.Location = new System.Drawing.Point(204, 219);
            this.tb_password.Name = "tb_password";
            this.tb_password.Size = new System.Drawing.Size(482, 27);
            this.tb_password.TabIndex = 19;
            // 
            // tb_email
            // 
            this.tb_email.BackColor = System.Drawing.Color.Silver;
            this.tb_email.Location = new System.Drawing.Point(204, 178);
            this.tb_email.Name = "tb_email";
            this.tb_email.Size = new System.Drawing.Size(482, 27);
            this.tb_email.TabIndex = 18;
            // 
            // tb_last_name
            // 
            this.tb_last_name.BackColor = System.Drawing.Color.Silver;
            this.tb_last_name.Location = new System.Drawing.Point(204, 140);
            this.tb_last_name.Name = "tb_last_name";
            this.tb_last_name.Size = new System.Drawing.Size(482, 27);
            this.tb_last_name.TabIndex = 17;
            // 
            // tb_first_name
            // 
            this.tb_first_name.BackColor = System.Drawing.Color.Silver;
            this.tb_first_name.Location = new System.Drawing.Point(204, 105);
            this.tb_first_name.Name = "tb_first_name";
            this.tb_first_name.Size = new System.Drawing.Size(482, 27);
            this.tb_first_name.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Silver;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(115, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(115, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(115, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Last Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(115, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "First Name:";
            // 
            // Form_Add_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_cancel_user_changes);
            this.Controls.Add(this.btn_save_user_changes);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.tb_email);
            this.Controls.Add(this.tb_last_name);
            this.Controls.Add(this.tb_first_name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form_Add_User";
            this.Text = "Form_Add_User";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button btn_cancel_user_changes;
        private Button btn_save_user_changes;
        private TextBox tb_password;
        private TextBox tb_email;
        private TextBox tb_last_name;
        private TextBox tb_first_name;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}