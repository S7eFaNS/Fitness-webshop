namespace GymAppWinForm
{
    partial class Form_Edit_User
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Edit_User));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_first_name = new System.Windows.Forms.TextBox();
            this.tb_last_name = new System.Windows.Forms.TextBox();
            this.tb_email = new System.Windows.Forms.TextBox();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.btn_save_user_changes = new System.Windows.Forms.Button();
            this.btn_cancel_user_changes = new System.Windows.Forms.Button();
            this.tb_id = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_age = new System.Windows.Forms.TextBox();
            this.tb_UserType = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(96, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(96, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(96, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Email:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Silver;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(96, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Password:";
            // 
            // tb_first_name
            // 
            this.tb_first_name.BackColor = System.Drawing.Color.Silver;
            this.tb_first_name.Location = new System.Drawing.Point(185, 81);
            this.tb_first_name.Name = "tb_first_name";
            this.tb_first_name.Size = new System.Drawing.Size(482, 27);
            this.tb_first_name.TabIndex = 4;
            // 
            // tb_last_name
            // 
            this.tb_last_name.BackColor = System.Drawing.Color.Silver;
            this.tb_last_name.Location = new System.Drawing.Point(185, 116);
            this.tb_last_name.Name = "tb_last_name";
            this.tb_last_name.Size = new System.Drawing.Size(482, 27);
            this.tb_last_name.TabIndex = 5;
            // 
            // tb_email
            // 
            this.tb_email.BackColor = System.Drawing.Color.Silver;
            this.tb_email.Location = new System.Drawing.Point(185, 154);
            this.tb_email.Name = "tb_email";
            this.tb_email.Size = new System.Drawing.Size(482, 27);
            this.tb_email.TabIndex = 6;
            // 
            // tb_password
            // 
            this.tb_password.BackColor = System.Drawing.Color.Silver;
            this.tb_password.Location = new System.Drawing.Point(185, 195);
            this.tb_password.Name = "tb_password";
            this.tb_password.Size = new System.Drawing.Size(482, 27);
            this.tb_password.TabIndex = 7;
            // 
            // btn_save_user_changes
            // 
            this.btn_save_user_changes.BackColor = System.Drawing.Color.Silver;
            this.btn_save_user_changes.Location = new System.Drawing.Point(110, 271);
            this.btn_save_user_changes.Name = "btn_save_user_changes";
            this.btn_save_user_changes.Size = new System.Drawing.Size(235, 89);
            this.btn_save_user_changes.TabIndex = 8;
            this.btn_save_user_changes.Text = "Save";
            this.btn_save_user_changes.UseVisualStyleBackColor = false;
            this.btn_save_user_changes.Click += new System.EventHandler(this.btn_save_user_changes_Click);
            // 
            // btn_cancel_user_changes
            // 
            this.btn_cancel_user_changes.BackColor = System.Drawing.Color.Silver;
            this.btn_cancel_user_changes.Location = new System.Drawing.Point(432, 271);
            this.btn_cancel_user_changes.Name = "btn_cancel_user_changes";
            this.btn_cancel_user_changes.Size = new System.Drawing.Size(235, 89);
            this.btn_cancel_user_changes.TabIndex = 9;
            this.btn_cancel_user_changes.Text = "Cancel";
            this.btn_cancel_user_changes.UseVisualStyleBackColor = false;
            this.btn_cancel_user_changes.Click += new System.EventHandler(this.btn_cancel_user_changes_Click);
            // 
            // tb_id
            // 
            this.tb_id.BackColor = System.Drawing.Color.Silver;
            this.tb_id.Location = new System.Drawing.Point(185, 43);
            this.tb_id.Name = "tb_id";
            this.tb_id.Size = new System.Drawing.Size(60, 27);
            this.tb_id.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Silver;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(152, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "ID:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Silver;
            this.label6.Location = new System.Drawing.Point(468, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Role:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Silver;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(264, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Age:";
            // 
            // tb_age
            // 
            this.tb_age.BackColor = System.Drawing.Color.Silver;
            this.tb_age.Location = new System.Drawing.Point(309, 43);
            this.tb_age.Name = "tb_age";
            this.tb_age.Size = new System.Drawing.Size(60, 27);
            this.tb_age.TabIndex = 15;
            // 
            // tb_UserType
            // 
            this.tb_UserType.BackColor = System.Drawing.Color.Silver;
            this.tb_UserType.Location = new System.Drawing.Point(516, 38);
            this.tb_UserType.Name = "tb_UserType";
            this.tb_UserType.Size = new System.Drawing.Size(75, 27);
            this.tb_UserType.TabIndex = 16;
            // 
            // Form_Edit_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tb_UserType);
            this.Controls.Add(this.tb_age);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_id);
            this.Controls.Add(this.label5);
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
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "Form_Edit_User";
            this.Text = "Form_Edit_User";
            this.Load += new System.EventHandler(this.Form_Edit_User_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox tb_first_name;
        private TextBox tb_last_name;
        private TextBox tb_email;
        private TextBox tb_password;
        private Button btn_save_user_changes;
        private Button btn_cancel_user_changes;
        private TextBox tb_id;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox tb_age;
        private TextBox tb_UserType;
    }
}