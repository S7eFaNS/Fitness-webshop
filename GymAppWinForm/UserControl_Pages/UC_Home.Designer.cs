namespace GymAppWinForm
{
    partial class UC_Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Home));
            this.Welcome = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tb_id = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.Label();
            this.tb_email = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Welcome
            // 
            this.Welcome.AutoSize = true;
            this.Welcome.Font = new System.Drawing.Font("Cooper Black", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Welcome.ForeColor = System.Drawing.Color.Silver;
            this.Welcome.Location = new System.Drawing.Point(458, 141);
            this.Welcome.Name = "Welcome";
            this.Welcome.Size = new System.Drawing.Size(304, 69);
            this.Welcome.TabIndex = 0;
            this.Welcome.Text = "Welcome";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Chiller", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(521, 404);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 68);
            this.button1.TabIndex = 1;
            this.button1.Text = "Log out";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tb_id
            // 
            this.tb_id.AutoSize = true;
            this.tb_id.Font = new System.Drawing.Font("Elephant", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tb_id.ForeColor = System.Drawing.Color.Silver;
            this.tb_id.Location = new System.Drawing.Point(467, 210);
            this.tb_id.Name = "tb_id";
            this.tb_id.Size = new System.Drawing.Size(180, 64);
            this.tb_id.TabIndex = 2;
            this.tb_id.Text = "label1";
            // 
            // tb_name
            // 
            this.tb_name.AutoSize = true;
            this.tb_name.Font = new System.Drawing.Font("Elephant", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tb_name.ForeColor = System.Drawing.Color.Silver;
            this.tb_name.Location = new System.Drawing.Point(467, 274);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(191, 64);
            this.tb_name.TabIndex = 3;
            this.tb_name.Text = "label2";
            // 
            // tb_email
            // 
            this.tb_email.AutoSize = true;
            this.tb_email.Font = new System.Drawing.Font("Elephant", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tb_email.ForeColor = System.Drawing.Color.Silver;
            this.tb_email.Location = new System.Drawing.Point(468, 337);
            this.tb_email.Name = "tb_email";
            this.tb_email.Size = new System.Drawing.Size(190, 64);
            this.tb_email.TabIndex = 4;
            this.tb_email.Text = "label3";
            // 
            // UC_Home
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.tb_email);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.tb_id);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Welcome);
            this.Font = new System.Drawing.Font("Century Gothic", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UC_Home";
            this.Size = new System.Drawing.Size(900, 500);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label Welcome;
        private Button button1;
        private Label tb_id;
        private Label tb_name;
        private Label tb_email;
    }
}
