namespace CommerceSystem.Forms.Dialogs
{
	partial class AddDismPerm
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
			this.SubmitDismBtn = new System.Windows.Forms.Button();
			this.AddProduct = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.ProdQtyFld = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.ProdNamesCombo = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.DismPermDateFld = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.CustomersNamesCombo = new System.Windows.Forms.ComboBox();
			this.StoresNamesCombo = new System.Windows.Forms.ComboBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// SubmitDismBtn
			// 
			this.SubmitDismBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(146)))), ((int)(((byte)(99)))));
			this.SubmitDismBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SubmitDismBtn.ForeColor = System.Drawing.Color.White;
			this.SubmitDismBtn.Location = new System.Drawing.Point(4, 209);
			this.SubmitDismBtn.Name = "SubmitDismBtn";
			this.SubmitDismBtn.Size = new System.Drawing.Size(380, 32);
			this.SubmitDismBtn.TabIndex = 32;
			this.SubmitDismBtn.Text = "Submit";
			this.SubmitDismBtn.UseVisualStyleBackColor = false;
			this.SubmitDismBtn.Click += new System.EventHandler(this.SubmitDismBtn_Click);
			// 
			// AddProduct
			// 
			this.AddProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(180)))), ((int)(((byte)(83)))));
			this.AddProduct.Location = new System.Drawing.Point(77, 78);
			this.AddProduct.Name = "AddProduct";
			this.AddProduct.Size = new System.Drawing.Size(232, 23);
			this.AddProduct.TabIndex = 23;
			this.AddProduct.Text = "Add Product";
			this.AddProduct.UseVisualStyleBackColor = false;
			this.AddProduct.Click += new System.EventHandler(this.AddProduct_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
			this.groupBox1.Controls.Add(this.AddProduct);
			this.groupBox1.Controls.Add(this.ProdQtyFld);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.ProdNamesCombo);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new System.Drawing.Point(4, 90);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(380, 113);
			this.groupBox1.TabIndex = 31;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Products";
			// 
			// ProdQtyFld
			// 
			this.ProdQtyFld.Location = new System.Drawing.Point(188, 52);
			this.ProdQtyFld.Name = "ProdQtyFld";
			this.ProdQtyFld.Size = new System.Drawing.Size(121, 20);
			this.ProdQtyFld.TabIndex = 20;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(100, 51);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(60, 19);
			this.label4.TabIndex = 19;
			this.label4.Text = "Quantity";
			// 
			// ProdNamesCombo
			// 
			this.ProdNamesCombo.FormattingEnabled = true;
			this.ProdNamesCombo.Location = new System.Drawing.Point(188, 25);
			this.ProdNamesCombo.Name = "ProdNamesCombo";
			this.ProdNamesCombo.Size = new System.Drawing.Size(121, 21);
			this.ProdNamesCombo.TabIndex = 18;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(84, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(98, 19);
			this.label3.TabIndex = 17;
			this.label3.Text = "Product Name";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(82, 62);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(74, 19);
			this.label2.TabIndex = 29;
			this.label2.Text = "Customers";
			// 
			// DismPermDateFld
			// 
			this.DismPermDateFld.Location = new System.Drawing.Point(162, 37);
			this.DismPermDateFld.Name = "DismPermDateFld";
			this.DismPermDateFld.Size = new System.Drawing.Size(121, 20);
			this.DismPermDateFld.TabIndex = 28;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(104, 37);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 19);
			this.label1.TabIndex = 27;
			this.label1.Text = "Date";
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label24.ForeColor = System.Drawing.Color.Black;
			this.label24.Location = new System.Drawing.Point(100, 9);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(42, 19);
			this.label24.TabIndex = 25;
			this.label24.Text = "Store";
			// 
			// CustomersNamesCombo
			// 
			this.CustomersNamesCombo.FormattingEnabled = true;
			this.CustomersNamesCombo.Location = new System.Drawing.Point(162, 63);
			this.CustomersNamesCombo.Name = "CustomersNamesCombo";
			this.CustomersNamesCombo.Size = new System.Drawing.Size(121, 21);
			this.CustomersNamesCombo.TabIndex = 30;
			// 
			// StoresNamesCombo
			// 
			this.StoresNamesCombo.FormattingEnabled = true;
			this.StoresNamesCombo.Location = new System.Drawing.Point(162, 10);
			this.StoresNamesCombo.Name = "StoresNamesCombo";
			this.StoresNamesCombo.Size = new System.Drawing.Size(121, 21);
			this.StoresNamesCombo.TabIndex = 26;
			// 
			// AddDismPerm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(393, 248);
			this.Controls.Add(this.SubmitDismBtn);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.DismPermDateFld);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label24);
			this.Controls.Add(this.CustomersNamesCombo);
			this.Controls.Add(this.StoresNamesCombo);
			this.Name = "AddDismPerm";
			this.Text = "AddDismPerm";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button SubmitDismBtn;
		private System.Windows.Forms.Button AddProduct;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox ProdQtyFld;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox ProdNamesCombo;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker DismPermDateFld;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.ComboBox CustomersNamesCombo;
		private System.Windows.Forms.ComboBox StoresNamesCombo;
	}
}