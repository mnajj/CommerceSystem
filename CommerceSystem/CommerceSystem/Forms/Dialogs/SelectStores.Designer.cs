namespace CommerceSystem.Forms.Dialogs
{
	partial class SelectStores
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
			this.StoresList = new System.Windows.Forms.ListBox();
			this.StoresNamesCombo = new System.Windows.Forms.ComboBox();
			this.AddStoreBtn = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// StoresList
			// 
			this.StoresList.FormattingEnabled = true;
			this.StoresList.Location = new System.Drawing.Point(12, 12);
			this.StoresList.Name = "StoresList";
			this.StoresList.Size = new System.Drawing.Size(120, 134);
			this.StoresList.TabIndex = 0;
			// 
			// StoresNamesCombo
			// 
			this.StoresNamesCombo.FormattingEnabled = true;
			this.StoresNamesCombo.Location = new System.Drawing.Point(12, 152);
			this.StoresNamesCombo.Name = "StoresNamesCombo";
			this.StoresNamesCombo.Size = new System.Drawing.Size(121, 21);
			this.StoresNamesCombo.TabIndex = 35;
			// 
			// AddStoreBtn
			// 
			this.AddStoreBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(180)))), ((int)(((byte)(83)))));
			this.AddStoreBtn.Location = new System.Drawing.Point(12, 179);
			this.AddStoreBtn.Name = "AddStoreBtn";
			this.AddStoreBtn.Size = new System.Drawing.Size(120, 23);
			this.AddStoreBtn.TabIndex = 36;
			this.AddStoreBtn.Text = "Add";
			this.AddStoreBtn.UseVisualStyleBackColor = false;
			this.AddStoreBtn.Click += new System.EventHandler(this.AddStoreBtn_Click);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(146)))), ((int)(((byte)(99)))));
			this.button1.ForeColor = System.Drawing.Color.White;
			this.button1.Location = new System.Drawing.Point(13, 208);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(120, 23);
			this.button1.TabIndex = 37;
			this.button1.Text = "Finish";
			this.button1.UseVisualStyleBackColor = false;
			// 
			// SelectStores
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(150, 243);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.AddStoreBtn);
			this.Controls.Add(this.StoresNamesCombo);
			this.Controls.Add(this.StoresList);
			this.Name = "SelectStores";
			this.Text = "SelectStores";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox StoresList;
		private System.Windows.Forms.ComboBox StoresNamesCombo;
		private System.Windows.Forms.Button AddStoreBtn;
		private System.Windows.Forms.Button button1;
	}
}