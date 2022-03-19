namespace CommerceSystem.Forms.Dialogs
{
	partial class SelectTimePeriod
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
			this.FinishBtn = new System.Windows.Forms.Button();
			this.From = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// FinishBtn
			// 
			this.FinishBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(146)))), ((int)(((byte)(99)))));
			this.FinishBtn.ForeColor = System.Drawing.Color.White;
			this.FinishBtn.Location = new System.Drawing.Point(12, 38);
			this.FinishBtn.Name = "FinishBtn";
			this.FinishBtn.Size = new System.Drawing.Size(249, 23);
			this.FinishBtn.TabIndex = 42;
			this.FinishBtn.Text = "Show Report";
			this.FinishBtn.UseVisualStyleBackColor = false;
			this.FinishBtn.Click += new System.EventHandler(this.FinishBtn_Click);
			// 
			// From
			// 
			this.From.AutoSize = true;
			this.From.Location = new System.Drawing.Point(9, 15);
			this.From.Name = "From";
			this.From.Size = new System.Drawing.Size(105, 13);
			this.From.TabIndex = 45;
			this.From.Text = "Time Period (Month):";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(120, 12);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(141, 20);
			this.textBox1.TabIndex = 46;
			// 
			// SelectTimePeriod
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(279, 71);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.From);
			this.Controls.Add(this.FinishBtn);
			this.Name = "SelectTimePeriod";
			this.Text = "SelectTimePeriod";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button FinishBtn;
		private System.Windows.Forms.Label From;
		private System.Windows.Forms.TextBox textBox1;
	}
}