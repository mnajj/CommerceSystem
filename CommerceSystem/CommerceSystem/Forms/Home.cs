using CommerceSystem.Forms.Dialogs;
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

namespace CommerceSystem
{
	public partial class Home : Form
	{
		public CommerceEntities Db { get; set; } = new CommerceEntities();

		public Home()
		{
			InitializeComponent();
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch(tabControl1.SelectedIndex)
			{
				case 0:
					break;
				case 1:
					DisplayStoresData();
					break;
				case 2:
					DisplayProductsData();
					break;
				case 3:
					DisplaySuppliersData();
					break;
				case 4:
					DisplaySupPermsData();
					break;
			}
		}





		#region Stores
		private void DisplayStoresData()
		{
			StoreList.Items.Clear();
			var stores = Db.Stores
				.Select(s => s)
				.ToList();
			foreach (var store in stores)
			{
				string[] row =
				{
					store.Store_Id.ToString(),
					store.Store_Name,
					store.Store_Phone,
					store.Store_Email,
					store.Store_Address,
					store.Staffs
					.Where(s => s.Stf_Id == store.Manager_Id)
					.Select(s => s.Stf_Fname + " " + s.Stf_Lname)
					.FirstOrDefault()
				};
				ListViewItem item = new ListViewItem(row);
				StoreList.Items.Add(item);
			}
		}

		private void DisplayComboMangerNames()
		{
			var mangers = Db.Stores.Select(s => s.Manager_Id).Distinct().ToList();
			foreach (var manger in mangers)
			{
				ManagerCombo.Items.Add(manger);
			}
		}

		private void AddStoreBtn_Click(object sender, EventArgs e)
		{
			if(
					StorenameFld.Text != String.Empty
					&& StorePhoneFld.Text != String.Empty
					&& StoreMailFld.Text != String.Empty
					&& StoreAddrsFld.Text != String.Empty
					&& ManagerCombo.Text != String.Empty
				)
			{
				Store store = new Store()
				{
					Store_Name = StorenameFld.Text,
					Store_Phone = StorenameFld.Text,
					Store_Email = StorenameFld.Text,
					Store_Address = StorenameFld.Text,
					Manager_Id = int.Parse(ManagerCombo.Text)
				};
				Db.Stores.Add(store);
				Db.SaveChanges();
				DisplayStoresData();
			}
			else
			{
				MessageBox.Show("Some Fields is empty!");
			}
		}

		private void StoreList_Click(object sender, EventArgs e)
		{
			if (StoreList.SelectedItems.Count > 0)
			{
				StoreIdFld.Text = StoreList.SelectedItems[0].SubItems[0].Text;
				StorenameFld.Text = StoreList.SelectedItems[0].SubItems[1].Text;
				StorePhoneFld.Text = StoreList.SelectedItems[0].SubItems[2].Text;
				StoreMailFld.Text = StoreList.SelectedItems[0].SubItems[3].Text;
				StoreAddrsFld.Text = StoreList.SelectedItems[0].SubItems[4].Text;
				ManagerCombo.Text = StoreList.SelectedItems[0].SubItems[5].Text;
			}
			ManagerCombo.Enabled = true;
		}
		#endregion

		#region Products
		private void DisplayProductsData()
		{
			ProdList.Items.Clear();
			var prods = Db.Products
				.Select(p => p)
				.ToList();
			foreach (var prod in prods)
			{
				string[] row =
				{
					prod.Prod_Id.ToString(),
					prod.Prod_Name,
					prod.Model_Year.ToString()
				};
				ListViewItem item = new ListViewItem(row);
				ProdList.Items.Add(item);
			}
			DisplayStoresNamseInCombo();
		}

		private void DisplayStoresNamseInCombo()
		{
			var stores = Db.Stores
				.Select(s => s.Store_Name)
				.Distinct()
				.ToList();
			foreach (var store in stores)
			{
				StoresnamesCombo.Items.Add(store);
			}
		}

		private void AddProductBtn_Click(object sender, EventArgs e)
		{
			if(
					ProdNameFld.Text != String.Empty
					&& ProdNameFld.Text != String.Empty
					&& StoresnamesCombo.Text != String.Empty
					&& ProdQtyFld.Text != String.Empty
				)
			{
				Product prod = new Product()
				{
					Prod_Name = ProdNameFld.Text,
					Model_Year = short.Parse(ProdYearFld.Text)
				};
				Db.Products.Add(prod);

				var storeId = Db.Stores
					.Where(s => s.Store_Name == StoresnamesCombo.Text)
					.Select(s => s.Store_Id)
					.FirstOrDefault();
				Stock stock = new Stock()
				{
					Store_Id = storeId,
					Prod_Id = Db.Products.Select(p => p.Prod_Id).Max(),
					Qty = int.Parse(ProdQtyFld.Text)
				};
				Db.Stocks.Add(stock);

				Db.SaveChanges();
				DisplayProductsData();
				ClearProdFields();
			}
			else
			{
				MessageBox.Show("Some Fields is Empty");
			}
		}

		private void ClearProdFields()
		{
			ProdIdFld.Text   =
			ProdNameFld.Text =
			ProdNameFld.Text =
			StoresnamesCombo.Text =
			ProdQtyFld.Text = String.Empty;
		}

		private void UpdateProdBtn_Click(object sender, EventArgs e)
		{
			if(
				ProdIdFld.Text != String.Empty
				&& ProdNameFld.Text != String.Empty
				&& ProdNameFld.Text != String.Empty
				&& StoresnamesCombo.Text != String.Empty
				&& ProdQtyFld.Text != String.Empty
				)
			{
				int id = int.Parse(ProdIdFld.Text);
				var prod = Db.Products
					.Where(p => p.Prod_Id == id)
					.FirstOrDefault();
				prod.Prod_Name = ProdNameFld.Text;
				prod.Model_Year = short.Parse(ProdYearFld.Text);

				var oldStoreId = Db.Stocks
					.Where(s => s.Prod_Id == id)
					.Select(s => s.Store_Id)
					.FirstOrDefault();

				var newStoreId = Db.Stores
					.Where(s => s.Store_Name == StoresnamesCombo.Text)
					.Select(s => s.Store_Id)
					.FirstOrDefault();

				var stock = Db.Stocks
					.Where(s => s.Prod_Id == id && s.Store_Id == oldStoreId)
					.FirstOrDefault() as Stock;

				stock.Qty = int.Parse(ProdQtyFld.Text);

				Db.SaveChanges();
				DisplayProductsData();
				ClearProdFields();
			}
			else
			{
				MessageBox.Show("Some Fields is Empty");
			}
		}

		private void ProdList_Click(object sender, EventArgs e)
		{
			if (ProdList.SelectedItems.Count > 0)
			{
				int id = int.Parse(ProdList.SelectedItems[0].SubItems[0].Text);
				ProdIdFld.Text = id.ToString();
				ProdNameFld.Text = ProdList.SelectedItems[0].SubItems[1].Text;
				ProdYearFld.Text = ProdList.SelectedItems[0].SubItems[2].Text;

				StoresnamesCombo.Text = Db.Stocks
					.Where(s => s.Prod_Id == id)
					.Select(s => s.Store.Store_Name)
					.FirstOrDefault();
				ProdQtyFld.Text = Db.Stocks
					.Where(s => s.Prod_Id == id)
					.Select(s => s.Qty)
					.FirstOrDefault()
					.ToString();
			}
			ManagerCombo.Enabled = true;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if(ProdIdFld.Text != String.Empty)
			{
				int id = int.Parse(ProdIdFld.Text);
				var product = Db.Products
					.Where(p => p.Prod_Id == id)
					.FirstOrDefault();
				Db.Products.Remove(product);
				Db.SaveChanges();
				DisplayProductsData();
				ClearProdFields();
			}
		}

		#endregion


		#region Suppliers
		private void DisplaySuppliersData()
		{
			SuppliersList.Items.Clear();
			var sups = Db.Suppliers
				.Select(s => s)
				.ToList();
			foreach (var sup in sups)
			{
				string[] row =
				{
					sup.Sup_Id.ToString(),
					sup.Sup_Name,
					sup.Sup_Phone,
					sup.Sup_Telephone,
					sup.Sup_Mail,
					sup.Sup_Mail
				};
				ListViewItem item = new ListViewItem(row);
				SuppliersList.Items.Add(item);
			}
		}

		private void AddSupBtn_Click(object sender, EventArgs e)
		{
			if(
					SupNameFld.Text != String.Empty
					&& SupPhoneFld.Text != String.Empty
					&& SupFaxFld.Text != String.Empty
					&& SupTeleFld.Text != String.Empty
					&& SupMailFld.Text != String.Empty
					&& SupSiteFld.Text != String.Empty
				)
			{
				Supplier sup = new Supplier()
				{
					Sup_Id = int.Parse(SupIdFld.Text),
					Sup_Name = SupNameFld.Text ,
					Sup_Phone = SupPhoneFld.Text,
					Sup_Fax = SupFaxFld.Text,
					Sup_Telephone = SupTeleFld.Text ,
					Sup_Mail = SupMailFld.Text ,
					Sup_Site = SupSiteFld.Text
				};
				Db.Suppliers.Add(sup);
				Db.SaveChanges();
				DisplaySuppliersData();
			}
			else
			{
				MessageBox.Show("Some Fields is Empty");
			}
		}

		private void UpdateSupBtn_Click(object sender, EventArgs e)
		{
			if (
					SupIdFld.Text == String.Empty
					&& SupNameFld.Text != String.Empty
					&& SupPhoneFld.Text != String.Empty
					&& SupFaxFld.Text != String.Empty
					&& SupTeleFld.Text != String.Empty
					&& SupMailFld.Text != String.Empty
					&& SupSiteFld.Text != String.Empty
				)
			{
				int id = int.Parse(SupIdFld.Text);
				var sup = Db.Suppliers
					.Where(s => s.Sup_Id == id)
					.FirstOrDefault();
				sup.Sup_Name = SupNameFld.Text ;
				sup.Sup_Phone = SupPhoneFld.Text;
				sup.Sup_Fax = SupFaxFld.Text	 ;
				sup.Sup_Telephone = SupTeleFld.Text ;
				sup.Sup_Mail = SupMailFld.Text ;
				sup.Sup_Mail = SupSiteFld.Text;
				Db.SaveChanges();
				DisplaySuppliersData();
				ClearSupFields();
			}
			else
			{
				MessageBox.Show("Some Fields is Empty");
			}
		}

		private void DeleteSupBtn_Click(object sender, EventArgs e)
		{
			if(SupIdFld.Text != String.Empty)
			{
				int id = int.Parse (SupIdFld.Text);
				var sup = Db.Suppliers
					.Where(s => s.Sup_Id == id)
					.FirstOrDefault();
				Db.Suppliers.Remove(sup);
				Db.SaveChanges();
				ClearSupFields();
			}
			else
			{
				MessageBox.Show("Please, choose a Supplier");
			}
		}

		private void ClearSupFields()
		{
			SupIdFld.Text    =
			SupNameFld.Text  =
			SupPhoneFld.Text =
			SupFaxFld.Text 	 =
			SupTeleFld.Text	 =
			SupMailFld.Text	 =
			SupSiteFld.Text	 = String.Empty;
		}
		#endregion

		#region Supplie Permissions
		private void DisplaySupPermsData()
		{
			var sups = Db.SuppliePermissions
				.Select(s => s)
				.ToList();
			foreach (var sup in sups)
			{
				string prodInfo = String.Empty;
				//var prod_perm = sup.Supplied_Prod.Where(s => s.SupPerm_Id == sup.SupPerm_Id).FirstOrDefault();
				var prod_perm = sup.Supplied_Prod.Where(s => s.SupPerm_Id == sup.SupPerm_Id).ToList();
				if (prod_perm != null)
				{
					foreach (var prod in prod_perm)
					{
						prodInfo += $"{Db.Products.Where(p => p.Prod_Id == prod.Prod_Id).Select(p => p.Prod_Name).FirstOrDefault()}, {prod.Qty}, {prod.Production_Date}, {prod.Expiry}{Environment.NewLine}";
					}
				}

				string[] row =
				{
					sup.Store_Id.ToString(),
					sup.Store.Store_Name,
					sup.SupPerm_Date.Value.Date.ToString(),
					sup.Supplier.Sup_Name,
					prodInfo
				};
				ListViewItem listViewItem = new ListViewItem(row);
				SupPermList.Items.Add(listViewItem);
			}
		}

		private void AddSupPerm_Click(object sender, EventArgs e)
		{
			AddSupPermDialog addSupPermDialog = new AddSupPermDialog();
			addSupPermDialog.ShowDialog();
		}


		private void SupPermList_Click(object sender, EventArgs e)
		{
			if (SupPermList.SelectedItems.Count > 0)
			{
				UpdateOrDeleteDialog updateOrDeleteDialog = new UpdateOrDeleteDialog();
				DialogResult dlgRes = updateOrDeleteDialog.ShowDialog();
				if (dlgRes == DialogResult.OK)
				{
					UpdateSupPermInfo updateSupPermInfo = new UpdateSupPermInfo(SupPermList.SelectedItems[0]);
					updateSupPermInfo.ShowDialog();
				}
				else
				{
					int supPermId = int.Parse(SupPermList.SelectedItems[0].SubItems[0].Text);
					var sup = Db.SuppliePermissions
						.Where(s => s.SupPerm_Id == supPermId)
						.FirstOrDefault();
					Db.SuppliePermissions.Remove(sup);
					Db.SaveChanges();
					DisplaySupPermsData();
				}
			}
		}

		#endregion
	}

}
