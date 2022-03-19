namespace CommerceSystem.Forms.Dialogs
{
	partial class UpdateOrDeleteDialog
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
			this.label1 = new System.Windows.Forms.Label();
			this.DeleteSupBtn = new System.Windows.Forms.Button();
			this.UpdateSupBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(301, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "Do You Want to Update or Delete This Record?";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// DeleteSupBtn
			// 
			this.DeleteSupBtn.BackColor = System.Drawing.Color.Crimson;
			this.DeleteSupBtn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DeleteSupBtn.ForeColor = System.Drawing.Color.White;
			this.DeleteSupBtn.Location = new System.Drawing.Point(171, 57);
			this.DeleteSupBtn.Name = "DeleteSupBtn";
			this.DeleteSupBtn.Size = new System.Drawing.Size(88, 35);
			this.DeleteSupBtn.TabIndex = 28;
			this.DeleteSupBtn.Text = "Delete";
			this.DeleteSupBtn.UseVisualStyleBackColor = false;
			this.DeleteSupBtn.Click += new System.EventHandler(this.DeleteSupBtn_Click);
			// 
			// UpdateSupBtn
			// 
			this.UpdateSupBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(181)))), ((int)(((byte)(80)))));
			this.UpdateSupBtn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.UpdateSupBtn.ForeColor = System.Drawing.Color.White;
			this.UpdateSupBtn.Location = new System.Drawing.Point(77, 57);
			this.UpdateSupBtn.Name = "UpdateSupBtn";
			this.UpdateSupBtn.Size = new System.Drawing.Size(88, 35);
			this.UpdateSupBtn.TabIndex = 27;
			this.UpdateSupBtn.Text = "Update";
			this.UpdateSupBtn.UseVisualStyleBackColor = false;
			this.UpdateSupBtn.Click += new System.EventHandler(this.UpdateSupBtn_Click);
			// 
			// UpdateOrDeleteDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(337, 104);
			this.Controls.Add(this.DeleteSupBtn);
			this.Controls.Add(this.UpdateSupBtn);
			this.Controls.Add(this.label1);
			this.Name = "UpdateOrDeleteDialog";
			this.Text = "UpdateOrDeleteDialog";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button DeleteSupBtn;
		private System.Windows.Forms.Button UpdateSupBtn;
	}
}