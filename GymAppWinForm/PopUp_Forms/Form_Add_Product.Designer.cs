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
            this.tb_item_name = new System.Windows.Forms.TextBox();
            this.tb_item_price = new System.Windows.Forms.TextBox();
            this.tb_item_description = new System.Windows.Forms.TextBox();
            this.btn_save_new_product = new System.Windows.Forms.Button();
            this.btn_cancel_new_product = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_item_quantity = new System.Windows.Forms.TextBox();
            this.cb_item_type = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_program_link = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tb_item_name
            // 
            this.tb_item_name.BackColor = System.Drawing.Color.Silver;
            this.tb_item_name.Location = new System.Drawing.Point(164, 69);
            this.tb_item_name.Name = "tb_item_name";
            this.tb_item_name.Size = new System.Drawing.Size(445, 27);
            this.tb_item_name.TabIndex = 0;
            // 
            // tb_item_price
            // 
            this.tb_item_price.BackColor = System.Drawing.Color.Silver;
            this.tb_item_price.Location = new System.Drawing.Point(164, 102);
            this.tb_item_price.Name = "tb_item_price";
            this.tb_item_price.Size = new System.Drawing.Size(66, 27);
            this.tb_item_price.TabIndex = 1;
            // 
            // tb_item_description
            // 
            this.tb_item_description.BackColor = System.Drawing.Color.Silver;
            this.tb_item_description.Location = new System.Drawing.Point(106, 170);
            this.tb_item_description.Multiline = true;
            this.tb_item_description.Name = "tb_item_description";
            this.tb_item_description.Size = new System.Drawing.Size(538, 124);
            this.tb_item_description.TabIndex = 2;
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
            this.btn_save_new_product.Click += new System.EventHandler(this.btn_save_new_product_Click);
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
            this.btn_cancel_new_product.Click += new System.EventHandler(this.btn_cancel_new_product_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(106, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(106, 105);
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
            this.label4.Location = new System.Drawing.Point(249, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Quantity:";
            // 
            // tb_item_quantity
            // 
            this.tb_item_quantity.BackColor = System.Drawing.Color.Silver;
            this.tb_item_quantity.Location = new System.Drawing.Point(323, 102);
            this.tb_item_quantity.Name = "tb_item_quantity";
            this.tb_item_quantity.Size = new System.Drawing.Size(70, 27);
            this.tb_item_quantity.TabIndex = 8;
            // 
            // cb_item_type
            // 
            this.cb_item_type.BackColor = System.Drawing.Color.Silver;
            this.cb_item_type.FormattingEnabled = true;
            this.cb_item_type.Location = new System.Drawing.Point(458, 102);
            this.cb_item_type.Name = "cb_item_type";
            this.cb_item_type.Size = new System.Drawing.Size(151, 28);
            this.cb_item_type.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(409, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Type:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Silver;
            this.label6.Location = new System.Drawing.Point(106, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Link:";
            // 
            // tb_program_link
            // 
            this.tb_program_link.BackColor = System.Drawing.Color.Silver;
            this.tb_program_link.Location = new System.Drawing.Point(164, 137);
            this.tb_program_link.Name = "tb_program_link";
            this.tb_program_link.Size = new System.Drawing.Size(445, 27);
            this.tb_program_link.TabIndex = 12;
            // 
            // Form_Add_Product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_program_link);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cb_item_type);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_item_quantity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_cancel_new_product);
            this.Controls.Add(this.btn_save_new_product);
            this.Controls.Add(this.tb_item_description);
            this.Controls.Add(this.tb_item_price);
            this.Controls.Add(this.tb_item_name);
            this.Name = "Form_Add_Product";
            this.Text = "Form_Add_Product";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tb_item_name;
        private TextBox tb_item_price;
        private TextBox tb_item_description;
        private Button btn_save_new_product;
        private Button btn_cancel_new_product;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox tb_item_quantity;
        private ComboBox cb_item_type;
        private Label label5;
        private Label label6;
        private TextBox tb_program_link;
    }
}