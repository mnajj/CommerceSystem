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
	public partial class UpdateDismPerm : Form
	{
		public ListViewItem RecordData { get; set; }
		public CommerceEntities Db { get; set; } = new CommerceEntities();

		public UpdateDismPerm(ListViewItem recordData)
		{
			InitializeComponent();
			this.RecordData = recordData;
			DisplayComboBoxesData();
			DisplayRecordData();
		}

		private void DisplayRecordData()
		{
			StoresNamesCombo.Text = RecordData.SubItems[1].Text;
			DismPermDateFld.Text = RecordData.SubItems[3].Text;
			CustomersNamesCombo.Text = RecordData.SubItems[2].Text;
		}

		private void DisplayComboBoxesData()
		{
			DisplayStoresNames();
			DisplayCustomers();
			DisplayProducts();
		}

		private void DisplayCustomers()
		{
			CustomersNamesCombo.Items.Clear();
			var cus = Db.Customers
				.Select(c => c.Cus_Fname + " " + c.Cus_Lname)
				.ToList();
			foreach (var c in cus)
			{
				CustomersNamesCombo.Items.Add(c);
			}
		}

		private void DisplayProducts()
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

		private void DisplayStoresNames()
		{
			StoresNamesCombo.Items.Clear();
			var stores = Db.Stores
				.Select(s => s.Store_Name)
				.ToList();
			foreach (var store in stores)
			{
				StoresNamesCombo.Items.Add(store);
			}
		}

		private void AddProductToPermission_Click(object sender, EventArgs e)
		{
			if (
					ProdNamesCombo.Text != String.Empty
					&& ProdQtyFld.Text != String.Empty
				)
			{
				int dismId = int.Parse(RecordData.SubItems[0].Text);
				int prodId = Db.Products
					.Where(p => p.Prod_Name == ProdNamesCombo.Text)
					.Select(p => p.Prod_Id)
					.FirstOrDefault();
				int qty = int.Parse(ProdQtyFld.Text);
				Dism_Prod dism_Prod = new Dism_Prod()
				{
					Dism_Id = dismId,
					Prod_Id = prodId,
					Qty = qty
				};
				Db.Dism_Prod.Add(dism_Prod);
				Db.SaveChanges();
				MessageBox.Show("Product Info Added to Dismissal Permission");
				ClearProdFields();
			}
			else
			{
				MessageBox.Show("Some Product Field is Empty");
			}
		}

		private void ClearProdFields()
		{
			ProdNamesCombo.Text =
			ProdQtyFld.Text = String.Empty;
		}

		private void UpdateProductInfo_Click(object sender, EventArgs e)
		{
			int dismId = int.Parse(RecordData.SubItems[0].Text);
			int prodId = Db.Products
				.Where(p => p.Prod_Name == ProdNamesCombo.Text)
				.Select(p => p.Prod_Id)
				.FirstOrDefault();

			var dism_prod_rec = Db.Dism_Prod
				.Where(d => d.Prod_Id == prodId && d.Dism_Id == dismId)
				.FirstOrDefault();

			dism_prod_rec.Qty = int.Parse(ProdQtyFld.Text);
			Db.SaveChanges();
			MessageBox.Show("Product Info Updated");
		}

		private void ProdNamesCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			int dismId = int.Parse(RecordData.SubItems[0].Text);
			int prodId = Db.Products
				.Where(p => p.Prod_Name == ProdNamesCombo.Text)
				.Select(p => p.Prod_Id)
				.FirstOrDefault();
			var dism_prod = Db.Dism_Prod
				.Where(s => s.Prod_Id == prodId && s.Dism_Id == dismId)
				.FirstOrDefault();
			if (dism_prod != null)
			{
				ProdQtyFld.Text = dism_prod.Qty.ToString();
			}
			else
			{
				MessageBox.Show("Note That You Selected unavailable Product in Current Permission.\nYou Can Add it to Permessions Product List");
			}
		}

		private void UpdateDismBtn_Click(object sender, EventArgs e)
		{
			if (
					StoresNamesCombo.Text != String.Empty
					&& DismPermDateFld.Text != String.Empty
					&& CustomersNamesCombo.Text != String.Empty
				)
			{
				int dismId = int.Parse(RecordData.SubItems[0].Text);
				var dism = Db.Dismissals
				.Where(d => d.Dism_Id == dismId)
				.FirstOrDefault();

				int storeId = Db.Stores
					.Where(s => s.Store_Name == StoresNamesCombo.Text)
					.Select(s => s.Store_Id)
					.FirstOrDefault();

				DateTime dismDate = DismPermDateFld.Value;

				int cusId = Db.Customers
					.Where(c => c.Cus_Fname + " " + c.Cus_Lname  == CustomersNamesCombo.Text)
					.Select(c => c.Cus_Id)
					.FirstOrDefault();

				dism.Store_Id = storeId;
				dism.Dism_date = dismDate;
				dism.Cus_id = cusId;
				Db.SaveChanges();
				MessageBox.Show("Dismissal Permission Info Updated Successfully");
			}
			else
			{
				MessageBox.Show("Some Dismissal Permission Fields is Empty!");
			}
		}
	}
}
