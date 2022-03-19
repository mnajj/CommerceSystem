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
	public partial class SelectProductInPeriod : Form
	{
		public Home PrevForm { get; set; }
		public CommerceEntities Db { get; set; } = new CommerceEntities();

		public SelectProductInPeriod(Home prevForm)
		{
			InitializeComponent();
			this.PrevForm = prevForm;
			DisplayProductsData();
		}

		private void DisplayProductsData()
		{
			ProdNamesCombo.Items.Clear();
			var prods = Db.Products
				.Select(p => p.Prod_Name)
				.ToList();
			foreach (var prod in prods)
			{
				ProdNamesCombo.Items.Add(prod);
			}
		}

		private void AddProdBtn_Click(object sender, EventArgs e)
		{
			if (ProdNamesCombo.Text != String.Empty)
			{
				var pId = Db.Products
					.Where(p => p.Prod_Name == ProdNamesCombo.Text)
					.Select(p => p.Prod_Id)
					.FirstOrDefault();
				PrevForm.RepProductsId.Add(pId);
				ProdList.Items.Add(ProdNamesCombo.Text);
				ProdNamesCombo.Text = String.Empty;
			}
			else
			{
				MessageBox.Show("Please, Select a Product to Add");
			}
		}

		private void FinishBtn_Click(object sender, EventArgs e)
		{
			if (
				FromDateFld.Text != String.Empty
				&& ToDateFld.Text != String.Empty
				)
			{
				if (PrevForm.RepProductsId.Count > 0)
				{
					PrevForm.RepFromDate = FromDateFld.Value;
					PrevForm.RepToDate = ToDateFld.Value;
					this.Close();
				}
				else
				{
					MessageBox.Show("You Must Add 1 Product at Least");

				}
			}
			else
			{
				MessageBox.Show("You Must Pick a Date");
			}
		}
	}
}
