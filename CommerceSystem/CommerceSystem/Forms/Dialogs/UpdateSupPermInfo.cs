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
	public partial class UpdateSupPermInfo : Form
	{
		public ListViewItem RecordData { get; set; }
		public CommerceEntities Db { get; set; } = new CommerceEntities();

		public UpdateSupPermInfo(ListViewItem recordData)
		{
			InitializeComponent();
			this.RecordData = recordData;
			DisplayComboBoxesData();
			DisplayRecordData();
		}

		private void DisplayRecordData()
		{
			SupPermDateFld.Value = DateTime.Parse(RecordData.SubItems[2].Text);
		}

		private void DisplayComboBoxesData()
		{
			DisplayStoresNames();
			DisplaySuppliers();
			DisplayProducts();
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

		private void DisplaySuppliers()
		{
			SuppliersNamesCombo.Items.Clear();
			var sups = Db.Suppliers
				.Select(s => s.Sup_Name)
				.ToList();
			foreach (var sup in sups)
			{
				SuppliersNamesCombo.Items.Add(sup);
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

		private void ProdNamesCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			int prodId = Db.Products
				.Where(p => p.Prod_Name == ProdNamesCombo.Text)
				.Select(p => p.Prod_Id)
				.FirstOrDefault();
			var sup_prod = Db.Supplied_Prod
				.Where(s => s.Prod_Id == prodId)
				.FirstOrDefault();
			if (sup_prod != null)
			{
				ProdQtyFld.Text = sup_prod.Qty.ToString();
				ProdProddateFld.Value = sup_prod.Production_Date.Value;
				ProdExpiryFld.Text = sup_prod.Expiry.ToString();
			}
			else
			{
				MessageBox.Show("Note That You Selected unavailable Product in Current Permission.\nYou Can Add it to Permessions Product List");
			}
		}

		private void UpdateProductInfo_Click(object sender, EventArgs e)
		{
			int prodId = Db.Products
				.Where(p => p.Prod_Name == ProdNamesCombo.Text)
				.Select(p => p.Prod_Id)
				.FirstOrDefault();
			var sup_prod = Db.Supplied_Prod
				.Where(s => s.Prod_Id == prodId)
				.FirstOrDefault();
			if (sup_prod != null)
			{
				sup_prod.Qty = int.Parse(ProdQtyFld.Text);
				sup_prod.Production_Date = ProdProddateFld.Value;
				sup_prod.Expiry = int.Parse(ProdExpiryFld.Text);
				Db.SaveChanges();
				MessageBox.Show("Product Info Updated Successfully");
				ClearProdFields();
			}
			else
			{
				MessageBox.Show("No Such Product in Permission Products List!");
			}
		}

		private void ClearProdFields()
		{
			ProdQtyFld.Text =
				ProdProddateFld.Text =
				ProdExpiryFld.Text =
				ProdNamesCombo.Text = String.Empty;
		}

		/// Add New Product to Permission
		private void UpdateProduct_Click(object sender, EventArgs e)
		{
			int prodId = Db.Products
			.Where(p => p.Prod_Name == ProdNamesCombo.Text)
			.Select(p => p.Prod_Id)
			.FirstOrDefault();
			var sup_prod = Db.Supplied_Prod
				.Where(s => s.Prod_Id == prodId)
				.FirstOrDefault();
			if (sup_prod == null)
			{
				Supplied_Prod supplied_Prod = new Supplied_Prod()
				{
					Prod_Id = Db.Products
					.Where(p => p.Prod_Name == ProdNamesCombo.Text)
					.Select(p => p.Prod_Id)
					.FirstOrDefault(),
					Qty = int.Parse(ProdQtyFld.Text),
					Production_Date = ProdProddateFld.Value,
					Expiry = int.Parse(ProdExpiryFld.Text)
				};
				Db.Supplied_Prod.Add(supplied_Prod);
				Db.SaveChanges();
				MessageBox.Show("Product Info Added Successfully!");
				ClearProdFields();
			}
			else
			{
				MessageBox.Show("Product Already Exist in Permission Products List!");
			}
		}
	}
}
