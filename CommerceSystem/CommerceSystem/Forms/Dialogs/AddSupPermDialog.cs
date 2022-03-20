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
	public partial class AddSupPermDialog : Form
	{
		public List<Supplied_Prod> Products { get; set; } = new List<Supplied_Prod>();
		public CommerceEntities Db { get; set; } = new CommerceEntities();

		public AddSupPermDialog()
		{
			InitializeComponent();
			DisplayComboBoxesData();
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

		private void AddProduct_Click(object sender, EventArgs e)
		{
			if (
				ProdNamesCombo.Text != String.Empty
				&& ProdQtyFld.Text != String.Empty
				&& ProdProddateFld.Text != String.Empty
				&& ProdExpiryFld.Text != String.Empty
				)
			{
				Supplied_Prod prod = new Supplied_Prod()
				{
					Prod_Id = Db.Products
					.Where(p => p.Prod_Name == ProdNamesCombo.Text)
					.Select(p => p.Prod_Id)
					.FirstOrDefault(),
					SupPerm_Id = 0,
					Production_Date = ProdProddateFld.Value,
					Expiry = int.Parse(ProdExpiryFld.Text),
					Qty = int.Parse(ProdQtyFld.Text)
				};
				this.Products.Add(prod);
				MessageBox.Show("Product Added to Permission");
				ClearProdFields();
			}
			else
			{
				MessageBox.Show("Some Fields is empty");
			}
		}

		private void ClearProdFields()
		{
			ProdNamesCombo.Text =
				ProdProddateFld.Text =
				ProdQtyFld.Text =
				ProdExpiryFld.Text = String.Empty;
		}

		private void SubmitSupPermbtn_Click(object sender, EventArgs e)
		{
			if(
					StoresNamesCombo.Text != String.Empty
				&& SupPermDateFld.Text != String.Empty
				&& SuppliersNamesCombo.Text != String.Empty
				)
			{
				if(Products.Count > 0)
				{
					int storeId = Db.Stores
						.Where(s => s.Store_Name == StoresNamesCombo.Text)
						.Select(s => s.Store_Id)
						.FirstOrDefault();
					int supId = Db.Suppliers
						.Where(s => s.Sup_Name == SuppliersNamesCombo.Text)
						.Select(s => s.Sup_Id)
						.FirstOrDefault();
					DateTime permDate = SupPermDateFld.Value;

					SuppliePermission newSupPerm = new SuppliePermission()
					{
						Store_Id = storeId,
						Sup_Id = supId,
						SupPerm_Date = permDate
					};
					Db.SuppliePermissions.Add(newSupPerm);

					// Add Products
					int? supPermId = Db.SuppliePermissions
						.Max(s => (int?)s.SupPerm_Id);
					int PermId = supPermId ?? default(int); ;
					this.Products.ToList().ForEach(p => p.SupPerm_Id = PermId);
					foreach (var prod in Products)
					{
						var sup_prod = Db.Supplied_Prod
							.Where(s => s.Prod_Id == prod.Prod_Id && s.SupPerm_Id == storeId)
							.FirstOrDefault();
						if(sup_prod == null)
						{
							Db.Supplied_Prod.Add(prod);
							Stock stock = null;
							foreach(var s in Db.Stocks)
							{
								if (s.Prod_Id == prod.Prod_Id && s.Store_Id == storeId)
								{
									stock = s;
								}
							}
							if (stock != null)
							{
								stock.Qty += prod.Qty;
							}
							else
							{
								Stock newStock = new Stock();
								newStock.Prod_Id = prod.Prod_Id;
								newStock.Store_Id = (int) storeId;
								newStock.Qty = prod.Qty;
								Db.Stocks.Add(newStock);
							}
						}
					}
					Db.SaveChanges();
					this.Close();
				}
				else
				{
					MessageBox.Show("You Should Add 1 Product at Least!");
				}
			}
			else
			{
				MessageBox.Show("Some Permission Fields is Empty!");
			}
		}
	}
}
