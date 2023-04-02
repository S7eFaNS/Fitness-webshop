namespace GymAppWinForm
{
    partial class Form_Add_Product
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Add_Product));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.btn_save_new_product = new System.Windows.Forms.Button();
            this.btn_cancel_new_product = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.cb_supplement = new System.Windows.Forms.CheckBox();
            this.cb_program = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Silver;
            this.textBox1.Location = new System.Drawing.Point(164, 92);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(229, 27);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Silver;
            this.textBox2.Location = new System.Drawing.Point(164, 125);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(66, 27);
            this.textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.Silver;
            this.textBox3.Location = new System.Drawing.Point(106, 170);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(538, 124);
            this.textBox3.TabIndex = 2;
            // 
            // btn_save_new_product
            // 
            this.btn_save_new_product.BackColor = System.Drawing.Color.Silver;
            this.btn_save_new_product.Location = new System.Drawing.Point(106, 329);
            this.btn_save_new_product.Name = "btn_save_new_product";
            this.btn_save_new_product.Size = new System.Drawing.Size(220, 74);
            this.btn_save_new_product.TabIndex = 3;
            this.btn_save_new_product.Text = "Save";
            this.btn_save_new_product.UseVisualStyleBackColor = false;
            // 
            // btn_cancel_new_product
            // 
            this.btn_cancel_new_product.BackColor = System.Drawing.Color.Silver;
            this.btn_cancel_new_product.Location = new System.Drawing.Point(424, 329);
            this.btn_cancel_new_product.Name = "btn_cancel_new_product";
            this.btn_cancel_new_product.Size = new System.Drawing.Size(220, 74);
            this.btn_cancel_new_product.TabIndex = 4;
            this.btn_cancel_new_product.Text = "Cancel";
            this.btn_cancel_new_product.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(106, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(106, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Price:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(12, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Description:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(249, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Quantity:";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.Silver;
            this.textBox4.Location = new System.Drawing.Point(323, 125);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(70, 27);
            this.textBox4.TabIndex = 8;
            // 
            // cb_supplement
            // 
            this.cb_supplement.AutoSize = true;
            this.cb_supplement.BackColor = System.Drawing.Color.Transparent;
            this.cb_supplement.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cb_supplement.ForeColor = System.Drawing.Color.Silver;
            this.cb_supplement.Location = new System.Drawing.Point(424, 95);
            this.cb_supplement.Name = "cb_supplement";
            this.cb_supplement.Size = new System.Drawing.Size(148, 27);
            this.cb_supplement.TabIndex = 10;
            this.cb_supplement.Text = "Supplement";
            this.cb_supplement.UseVisualStyleBackColor = false;
            // 
            // cb_program
            // 
            this.cb_program.AutoSize = true;
            this.cb_program.BackColor = System.Drawing.Color.Transparent;
            this.cb_program.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cb_program.ForeColor = System.Drawing.Color.Silver;
            this.cb_program.Location = new System.Drawing.Point(424, 125);
            this.cb_program.Name = "cb_program";
            this.cb_program.Size = new System.Drawing.Size(113, 27);
            this.cb_program.TabIndex = 11;
            this.cb_program.Text = "Program";
            this.cb_program.UseVisualStyleBackColor = false;
            // 
            // Form_Add_Product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cb_program);
            this.Controls.Add(this.cb_supplement);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_cancel_new_product);
            this.Controls.Add(this.btn_save_new_product);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form_Add_Product";
            this.Text = "Form_Add_Product";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button btn_save_new_product;
        private Button btn_cancel_new_product;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox4;
        private CheckBox cb_supplement;
        private CheckBox cb_program;
    }
}