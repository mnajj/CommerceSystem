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
	public partial class UpdateOrDeleteDialog : Form
	{
		public UpdateOrDeleteDialog()
		{
			InitializeComponent();
		}

		private void UpdateSupBtn_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			this.Close();
		}

		private void DeleteSupBtn_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}
	}
}
