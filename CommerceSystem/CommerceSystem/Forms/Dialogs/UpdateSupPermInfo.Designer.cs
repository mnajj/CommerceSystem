namespace CommerceSystem.Forms.Dialogs
{
	partial class UpdateSupPermInfo
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
			this.SubmitSupPermbtn = new System.Windows.Forms.Button();
			this.UpdateProduct = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.ProdExpiryFld = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.ProdProddateFld = new System.Windows.Forms.DateTimePicker();
			this.ProdQtyFld = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.ProdNamesCombo = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SupPermDateFld = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.SuppliersNamesCombo = new System.Windows.Forms.ComboBox();
			this.StoresNamesCombo = new System.Windows.Forms.ComboBox();
			this.UpdateProductInfo = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// SubmitSupPermbtn
			// 
			this.SubmitSupPermbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(146)))), ((int)(((byte)(99)))));
			this.SubmitSupPermbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SubmitSupPermbtn.ForeColor = System.Drawing.Color.White;
			this.SubmitSupPermbtn.Location = new System.Drawing.Point(7, 256);
			this.SubmitSupPermbtn.Name = "SubmitSupPermbtn";
			this.SubmitSupPermbtn.Size = new System.Drawing.Size(380, 37);
			this.SubmitSupPermbtn.TabIndex = 32;
			this.SubmitSupPermbtn.Text = "Update Supplie Permission";
			this.SubmitSupPermbtn.UseVisualStyleBackColor = false;
			// 
			// UpdateProduct
			// 
			this.UpdateProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(180)))), ((int)(((byte)(83)))));
			this.UpdateProduct.Location = new System.Drawing.Point(5, 131);
			this.UpdateProduct.Name = "UpdateProduct";
			this.UpdateProduct.Size = new System.Drawing.Size(177, 23);
			this.UpdateProduct.TabIndex = 23;
			this.UpdateProduct.Text = "Add Product To Permisson";
			this.UpdateProduct.UseVisualStyleBackColor = false;
			this.UpdateProduct.Click += new System.EventHandler(this.UpdateProduct_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
			this.groupBox1.Controls.Add(this.UpdateProductInfo);
			this.groupBox1.Controls.Add(this.UpdateProduct);
			this.groupBox1.Controls.Add(this.ProdExpiryFld);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.ProdProddateFld);
			this.groupBox1.Controls.Add(this.ProdQtyFld);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.ProdNamesCombo);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new System.Drawing.Point(7, 90);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(380, 160);
			this.groupBox1.TabIndex = 31;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Products";
			// 
			// ProdExpiryFld
			// 
			this.ProdExpiryFld.Location = new System.Drawing.Point(188, 104);
			this.ProdExpiryFld.Name = "ProdExpiryFld";
			this.ProdExpiryFld.Size = new System.Drawing.Size(121, 20);
			this.ProdExpiryFld.TabIndex = 22;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(74, 103);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(108, 19);
			this.label6.TabIndex = 21;
			this.label6.Text = "Expiry (Months)";
			// 
			// ProdProddateFld
			// 
			this.ProdProddateFld.Location = new System.Drawing.Point(188, 78);
			this.ProdProddateFld.Name = "ProdProddateFld";
			this.ProdProddateFld.Size = new System.Drawing.Size(121, 20);
			this.ProdProddateFld.TabIndex = 18;
			// 
			// ProdQtyFld
			// 
			this.ProdQtyFld.Location = new System.Drawing.Point(188, 52);
			this.ProdQtyFld.Name = "ProdQtyFld";
			this.ProdQtyFld.Size = new System.Drawing.Size(121, 20);
			this.ProdQtyFld.TabIndex = 20;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(74, 78);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(108, 19);
			this.label5.TabIndex = 17;
			this.label5.Text = "Production Date";
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
			this.ProdNamesCombo.SelectedIndexChanged += new System.EventHandler(this.ProdNamesCombo_SelectedIndexChanged);
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
			this.label2.Location = new System.Drawing.Point(100, 62);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 19);
			this.label2.TabIndex = 29;
			this.label2.Text = "Supplier";
			// 
			// SupPermDateFld
			// 
			this.SupPermDateFld.Location = new System.Drawing.Point(165, 37);
			this.SupPermDateFld.Name = "SupPermDateFld";
			this.SupPermDateFld.Size = new System.Drawing.Size(121, 20);
			this.SupPermDateFld.TabIndex = 28;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(107, 37);
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
			this.label24.Location = new System.Drawing.Point(103, 9);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(42, 19);
			this.label24.TabIndex = 25;
			this.label24.Text = "Store";
			// 
			// SuppliersNamesCombo
			// 
			this.SuppliersNamesCombo.FormattingEnabled = true;
			this.SuppliersNamesCombo.Location = new System.Drawing.Point(165, 63);
			this.SuppliersNamesCombo.Name = "SuppliersNamesCombo";
			this.SuppliersNamesCombo.Size = new System.Drawing.Size(121, 21);
			this.SuppliersNamesCombo.TabIndex = 30;
			// 
			// StoresNamesCombo
			// 
			this.StoresNamesCombo.FormattingEnabled = true;
			this.StoresNamesCombo.Location = new System.Drawing.Point(165, 10);
			this.StoresNamesCombo.Name = "StoresNamesCombo";
			this.StoresNamesCombo.Size = new System.Drawing.Size(121, 21);
			this.StoresNamesCombo.TabIndex = 26;
			// 
			// UpdateProductInfo
			// 
			this.UpdateProductInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(180)))), ((int)(((byte)(83)))));
			this.UpdateProductInfo.Location = new System.Drawing.Point(188, 131);
			this.UpdateProductInfo.Name = "UpdateProductInfo";
			this.UpdateProductInfo.Size = new System.Drawing.Size(186, 23);
			this.UpdateProductInfo.TabIndex = 24;
			this.UpdateProductInfo.Text = "Update Product";
			this.UpdateProductInfo.UseVisualStyleBackColor = false;
			this.UpdateProductInfo.Click += new System.EventHandler(this.UpdateProductInfo_Click);
			// 
			// UpdateSupPermInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(396, 294);
			this.Controls.Add(this.SubmitSupPermbtn);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.SupPermDateFld);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label24);
			this.Controls.Add(this.SuppliersNamesCombo);
			this.Controls.Add(this.StoresNamesCombo);
			this.Name = "UpdateSupPermInfo";
			this.Text = "UpdateSupPermInfo";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button SubmitSupPermbtn;
		private System.Windows.Forms.Button UpdateProduct;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox ProdExpiryFld;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.DateTimePicker ProdProddateFld;
		private System.Windows.Forms.TextBox ProdQtyFld;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox ProdNamesCombo;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker SupPermDateFld;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.ComboBox SuppliersNamesCombo;
		private System.Windows.Forms.ComboBox StoresNamesCombo;
		private System.Windows.Forms.Button UpdateProductInfo;
	}
}