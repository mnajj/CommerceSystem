using CommerceSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommerceSystem.Forms.Dialogs
{
	public partial class SelectTimePeriod : Form
	{
		public CommerceEntities Db { get; set; } = new CommerceEntities();
		public Home PrevForm { get; set; }
		public bool IsExp { get; set; }

		public SelectTimePeriod(Home prev, bool exp = false)
		{
			InitializeComponent();
			this.PrevForm = prev;
			IsExp = exp;
		}

		private void FinishBtn_Click(object sender, EventArgs e)
		{
			if (IsExp)
			{
				try
				{
					PrevForm.RepExpiration = int.Parse(textBox1.Text);
					this.Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Please, Enter a Number!");
				}
			}
			else
			{
				try
				{
					PrevForm.RepTimePeriod = int.Parse(textBox1.Text);
					this.Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Please, Enter a Number!");
				}
			}
		}
	}
}
