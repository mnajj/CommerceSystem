using CommerceSystem.Forms.Dialogs;
using CommerceSystem.Model;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Syncfusion.Pdf;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using CommerceSystem.ClassLib;
using System.Data.Entity;

namespace CommerceSystem
{
	public partial class Home : Form
	{
		public CommerceEntities Db { get; set; } = new CommerceEntities();

		public List<int> RepStoresId { get; set; } = new List<int>();
		public List<int> RepProductsId { get; set; } = new List<int>();
		public DateTime RepFromDate { get; set; }	
		public DateTime RepToDate { get; set; }
		public int RepTimePeriod { get; set; }
		public int RepExpiration { get; set; }
		public List<TransProduct> TransProducts { get; set; } = new List<TransProduct>();

		public Home()
		{
			InitializeComponent();
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (tabControl1.SelectedIndex)
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
				case 5:
					DisplayDismissalData();
					break;
				case 6:
					DisplayTransComboBoxData();
					break;
				case 7:
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
				DisplayComboMangerNames();
			}
		}

		private void DisplayComboMangerNames()
		{
			ManagerCombo.Items.Clear();
			var mangers = Db.Stores.Select(s => s.Manager_Id).Distinct().ToList();
			foreach (var manger in mangers)
			{
				ManagerCombo.Items.Add(manger);
			}
		}

		private void AddStoreBtn_Click(object sender, EventArgs e)
		{
			if (
					StorenameFld.Text != String.Empty
					&& StorePhoneFld.Text != String.Empty
					&& StoreMailFld.Text != String.Empty
					&& StoreAddrsFld.Text != String.Empty
					&& ManagerCombo.Text != String.Empty
				)
			{
				try
				{
					Store store = new Store()
					{
						Store_Name = StorenameFld.Text,
						Store_Phone = StorePhoneFld.Text,
						Store_Email = StoreMailFld.Text,
						Store_Address = StoreAddrsFld.Text,
						Manager_Id = int.Parse(ManagerCombo.Text)
					};
					Db.Stores.Add(store);
				}
				catch(Exception ex)
				{
					MessageBox.Show("Manager Field Should be Intger");
				}
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
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			if(StoreIdFld.Text != String.Empty)
			{
				int id = int.Parse(StoreIdFld.Text);
				var store = Db.Stores
					.Where(s => s.Store_Id == id)
					.FirstOrDefault();
				Db.Stores.Remove(store);
				Db.SaveChanges();
				DisplayStoresData();
				ClearStoreFields();
			}
			else
			{
				MessageBox.Show("Please, Select a Store to Delete");
			}
		}

		private void ClearStoreFields()
		{
			StoreIdFld.Text =
			StorenameFld.Text =
			StorePhoneFld.Text =
			StoreMailFld.Text =
			StoreAddrsFld.Text =
			ManagerCombo.Text = String.Empty;
		}

		private void Update_Click(object sender, EventArgs e)
		{
			if (
					StoreIdFld.Text != String.Empty
					&& StorenameFld.Text != String.Empty
					&& StorePhoneFld.Text != String.Empty
					&& StoreMailFld.Text != String.Empty
					&& StoreAddrsFld.Text != String.Empty
					&& ManagerCombo.Text != String.Empty
				)
			{
				int id = int.Parse(StoreIdFld.Text);
				var store = Db.Stores.
					Where(s => s.Store_Id == id)
					.FirstOrDefault();
				store.Store_Name =	 StorenameFld.Text ;
				store.Store_Phone =	 StorePhoneFld.Text;
				store.Store_Email =	 StoreMailFld.Text ;
				store.Store_Address =	 StoreAddrsFld.Text;
				store.Manager_Id =	 int.Parse(ManagerCombo.Text);
				Db.SaveChanges();
				DisplayStoresData();
			}
			else
			{
				MessageBox.Show("Some Fields is empty!");
			}
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
			if (
					ProdNameFld.Text != String.Empty
					&& ProdNameFld.Text != String.Empty
					&& StoresnamesCombo.Text != String.Empty
					&& ProdQtyFld.Text != String.Empty
				)
			{
				try
				{
					Product prod = new Product()
					{
						Prod_Name = ProdNameFld.Text,
						Model_Year = short.Parse(ProdYearFld.Text)
					};
					Db.Products.Add(prod);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Model Year Should be Number");
				}

				var storeId = Db.Stores
					.Where(s => s.Store_Name == StoresnamesCombo.Text)
					.Select(s => s.Store_Id)
					.FirstOrDefault();
				try
				{
					Stock stock = new Stock()
					{
						Store_Id = storeId,
						Prod_Id = Db.Products.Select(p => p.Prod_Id).Max(),
						Qty = int.Parse(ProdQtyFld.Text)
					};
					Db.Stocks.Add(stock);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Quantity Should be Number");
				}
				try
				{
					Db.SaveChanges();
					DisplayProductsData();
					ClearProdFields();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}

			}
			else
			{
				MessageBox.Show("Some Fields is Empty");
			}
		}

		private void ClearProdFields()
		{
			ProdIdFld.Text =
			ProdNameFld.Text =
			ProdNameFld.Text =
			StoresnamesCombo.Text =
			ProdQtyFld.Text = String.Empty;
		}

		private void UpdateProdBtn_Click(object sender, EventArgs e)
		{
			if (
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

				Stock stock = null;
				foreach (var s in Db.Stocks)
				{
					if (s.Prod_Id == id && s.Store_Id == oldStoreId)
					{
						stock = s;
					}
				}

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
			if (ProdIdFld.Text != String.Empty)
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
					sup.Sup_Fax,
					sup.Sup_Telephone,
					sup.Sup_Mail,
					sup.Sup_Site
				};
				ListViewItem item = new ListViewItem(row);
				SuppliersList.Items.Add(item);
			}
		}

		private void AddSupBtn_Click(object sender, EventArgs e)
		{
			if (
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
					Sup_Name = SupNameFld.Text,
					Sup_Phone = SupPhoneFld.Text,
					Sup_Fax = SupFaxFld.Text,
					Sup_Telephone = SupTeleFld.Text,
					Sup_Mail = SupMailFld.Text,
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
					SupIdFld.Text != String.Empty
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
				sup.Sup_Name = SupNameFld.Text;
				sup.Sup_Phone = SupPhoneFld.Text;
				sup.Sup_Fax = SupFaxFld.Text;
				sup.Sup_Telephone = SupTeleFld.Text;
				sup.Sup_Mail = SupMailFld.Text;
				sup.Sup_Site = SupSiteFld.Text;
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
			if (SupIdFld.Text != String.Empty)
			{
				int id = int.Parse(SupIdFld.Text);
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


		private void SuppliersList_Click(object sender, EventArgs e)
		{
			if (SuppliersList.SelectedItems.Count > 0)
			{
				SupIdFld.Text = SuppliersList.SelectedItems[0].SubItems[0].Text;
				SupNameFld.Text = SuppliersList.SelectedItems[0].SubItems[1].Text;
				SupPhoneFld.Text = SuppliersList.SelectedItems[0].SubItems[2].Text;
				SupFaxFld.Text = SuppliersList.SelectedItems[0].SubItems[3].Text;
				SupTeleFld.Text = SuppliersList.SelectedItems[0].SubItems[4].Text;
				SupMailFld.Text = SuppliersList.SelectedItems[0].SubItems[5].Text;
				SupSiteFld.Text = SuppliersList.SelectedItems[0].SubItems[6].Text;
			}
		}

		private void ClearSupFields()
		{
			SupIdFld.Text =
			SupNameFld.Text =
			SupPhoneFld.Text =
			SupFaxFld.Text =
			SupTeleFld.Text =
			SupMailFld.Text =
			SupSiteFld.Text = String.Empty;
		}
		#endregion

		#region Supplie Permissions
		private void DisplaySupPermsData()
		{
			SupPermList.Items.Clear();
			var sups = Db.SuppliePermissions
				.Select(s => s)
				.ToList();
			foreach (var sup in sups)
			{
				string prodInfo = String.Empty;
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
					sup.SupPerm_Id.ToString(),
					sup.Store.Store_Name,
					sup.SupPerm_Date.Value.Date.ToString("dd/MM/yyyy"),
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
			DisplaySupPermsData();
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

		#region Dismissals
		private void DisplayDismissalData()
		{
			DismList.Items.Clear();
			var disms = Db.Dismissals
				.Select(s => s)
				.ToList();
			foreach (var dism in disms)
			{
				string prodInfo = String.Empty;
				var prod_perm = dism.Dism_Prod.Where(d => d.Dism_Id == dism.Dism_Id).ToList();
				if (prod_perm != null)
				{
					foreach (var prod in prod_perm)
					{
						prodInfo += $"{Db.Products.Where(p => p.Prod_Id == prod.Prod_Id).Select(p => p.Prod_Name).FirstOrDefault()}, {prod.Qty}, {Environment.NewLine}";
					}
					string[] row =
					{
						dism.Dism_Id.ToString(),
						dism.Store.Store_Name,
						$"{dism.Customer.Cus_Fname} {dism.Customer.Cus_Lname}",
						dism.Dism_date.ToString(),
						prodInfo
					};
					ListViewItem listViewItem = new ListViewItem(row);
					DismList.Items.Add(listViewItem);
				}
			}
		}

		private void AddDismBtn_Click(object sender, EventArgs e)
		{
			AddDismPerm addDismPerm = new AddDismPerm();
			addDismPerm.ShowDialog();
			DisplayDismissalData();
		}


		private void DismList_Click(object sender, EventArgs e)
		{
			if (DismList.SelectedItems.Count > 0)
			{
				UpdateOrDeleteDialog updateOrDeleteDialog = new UpdateOrDeleteDialog();
				DialogResult dlgRes = updateOrDeleteDialog.ShowDialog();
				if (dlgRes == DialogResult.OK)
				{
					UpdateDismPerm updateDismPerm = new UpdateDismPerm(DismList.SelectedItems[0]);
					updateDismPerm.ShowDialog();
					DisplayDismissalData();
				}
				else
				{
					int dismId = int.Parse(DismList.SelectedItems[0].SubItems[0].Text);
					var dism = Db.Dismissals
						.Where(s => s.Dism_Id == dismId)
						.FirstOrDefault();
					Db.Dismissals.Remove(dism);
					Db.SaveChanges();
					DisplayDismissalData();
				}
			}
		}
		#endregion

		#region Reports
		private void button3_Click(object sender, EventArgs e)
		{
			SelectStores selectStores = new SelectStores(this);
			selectStores.ShowDialog();
			string repData = string.Empty;
			RepStoresId = RepStoresId.Distinct().ToList();
			foreach (var id in RepStoresId)
			{
				string storeName = Db.Stores
					.Where(s => s.Store_Id == id)
					.Select(s => s.Store_Name)
					.FirstOrDefault();
				repData += $"Store: {storeName}\nStocks:\n";
				var stocks = Db.Stocks
					.Where(s => s.Store_Id == id)
					.ToList();
				foreach (var stock in stocks)
				{
					repData += $"{stock.Product.Prod_Name}           {stock.Qty}\n";
				}
				repData += "******************************\n";
				ConvertDataToPdfFile(repData);
				RepStoresId.Clear();
			}
		}

		private void ConvertDataToPdfFile(string data)
		{
			PdfDocument pdfDoc = new PdfDocument();
			PdfPage page = pdfDoc.Pages.Add();
			PdfGraphics graphics = page.Graphics;
			PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
			PdfStringFormat format = new PdfStringFormat();
			format.Alignment = PdfTextAlignment.Justify;
			format.LineAlignment = PdfVerticalAlignment.Top;
			format.ParagraphIndent = 10f;
			graphics.DrawString(data, font, PdfBrushes.Black, new RectangleF(new PointF(0, 0), page.GetClientSize()), format);
			try
			{
				File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "Report.pdf"));
				pdfDoc.Save("Report.pdf");
				pdfDoc.Close(true);
				Process.Start("Report.pdf");
			}
			catch (Exception ex) { }
		}

		private void GenerateStoresReportBtn_Click(object sender, EventArgs e)
		{
			var storesId = Db.Stores
				.Select(s => s.Store_Id)
				.ToList();
			string repData = String.Empty;
			foreach (var id in storesId)
			{
				string storeName = Db.Stores
					.Where(s => s.Store_Id == id)
					.Select(s => s.Store_Name)
					.FirstOrDefault();
				repData += $"Store: {storeName}\nStocks:\n";
				var stocks = Db.Stocks
					.Where(s => s.Store_Id == id)
					.ToList();
				foreach (var stock in stocks)
				{
					repData += $"{stock.Product.Prod_Name}           {stock.Qty}\n";
				}
				repData += "******************************\n";
			}
			ConvertDataToPdfFile(repData);
		}

		private void ProdPeriodBtn_Click(object sender, EventArgs e)
		{
			SelectProductInPeriod selectProductInPeriod = new SelectProductInPeriod(this);
			selectProductInPeriod.ShowDialog();
			String repData = String.Empty;
			RepProductsId = RepProductsId.Distinct().ToList();
			foreach(var id in RepProductsId)
			{
				var prod = Db.Products
					.Where(p => p.Prod_Id == id)
					.FirstOrDefault();
				repData += $"Product: {prod.Prod_Name}\n";

				var sups = Db.Supplied_Prod
					.Where(s => s.Prod_Id == id)
					.ToList();
				var disms = Db.Dism_Prod
					.Where(s => s.Prod_Id == id)
					.ToList();
				if(sups.Count > 0)
				{
					repData += $"  1- Supplies Permissions:\n    Permisson Id    Store    Supplier    Date\n";
					foreach (var sup in sups)
					{
						if (sup.SuppliePermission.SupPerm_Date > RepFromDate
							&& sup.SuppliePermission.SupPerm_Date < RepToDate
							)
						{
							repData += $"{sup.SupPerm_Id}   {sup.SuppliePermission.Store.Store_Name}   {sup.SuppliePermission.Supplier.Sup_Name}    {sup.SuppliePermission.SupPerm_Date.Value.ToString("dd/MM/yyyy")}";
						}
					}
				}
				if (disms.Count > 0)
				{
					repData += $"  2- Dismissals:\n    Dismissal Id    Store    Customer    Date\n";
					foreach (var dis in disms)
					{
						if (dis.Dismissal.Dism_date > RepFromDate
							&& dis.Dismissal.Dism_date < RepToDate
							)
						{
							repData += $"{dis.Dismissal.Dism_Id}   {dis.Dismissal.Store.Store_Name}   {dis.Dismissal.Customer.Cus_Fname}    {dis.Dismissal.Dism_date.Value.ToString("dd/MM/yyyy")}";
						}
					}
				}
				repData += "******************************\n";
			}
			ConvertDataToPdfFile(repData);
			RepProductsId.Clear();
		}


		private void PassedProdBtn_Click(object sender, EventArgs e)
		{
			SelectTimePeriod selectTimePeriod = new SelectTimePeriod(this);
			selectTimePeriod.ShowDialog();
			string repData = "Products That Have Passed a Period of Time in Stores\n";
			repData += "Product    Store    Entry Date\n";

			foreach(var p in Db.Supplied_Prod)
			{
				int period = ((DateTime.Now.Year - p.SuppliePermission.SupPerm_Date.Value.Year) * 12)
					+ DateTime.Now.Month - p.SuppliePermission.SupPerm_Date.Value.Month;
				if (period > RepTimePeriod)
				{
					repData += $"- {p.Product.Prod_Name}    {p.SuppliePermission.Store.Store_Name}    {p.SuppliePermission.SupPerm_Date.Value.ToString("dd/MM/yyyy")}\n";
				}
			}
			ConvertDataToPdfFile(repData);
		}


		private void ExpirationBtn_Click(object sender, EventArgs e)
		{
			SelectTimePeriod selectTimePeriod = new SelectTimePeriod(this, true);
			selectTimePeriod.ShowDialog();
			string repData = "Items That Are Close to Expiration\n";
			repData += "Product    Store    Producation Date   Expiry(Mth)\n";
			foreach (var p in Db.Supplied_Prod)
			{
				DateTime expDate = p.Production_Date.Value.AddMonths(p.Expiry.Value);
				int restMth = ((expDate.Year - p.Production_Date.Value.Year) * 12)
					+ expDate.Month - p.Production_Date.Value.Month;
				if (restMth == RepExpiration)
				{
					repData += $"- {p.Product.Prod_Name}    {p.SuppliePermission.Store.Store_Name}    {p.Production_Date.Value.ToString("dd/MM/yyyy")}   {p.Expiry}\n";
				}
			}
			ConvertDataToPdfFile(repData);
		}

		#endregion

		#region Trsnfer Items

		private void DisplayComboProducts()
		{
			var prods = Db.Products
				.Select(p => p.Prod_Name)
				.ToList();
			foreach(var p in prods)
			{
				ProdNamesCombo.Items.Add(p);
			}
		}

		private void TransAddProductBtn_Click(object sender, EventArgs e)
		{
			if (
					ProdNamesCombo.Text != String.Empty
				&& ProdQtyF.Text != String.Empty
				&& ProdProddateFld.Text != String.Empty
				&& ProdExpiryFld.Text != String.Empty
				&& TransSupCombo.Text != String.Empty
				)
			{
				try
				{
					TransProduct prod = new TransProduct()
					{
						ProdId = Db.Supplied_Prod
						.Where(p => p.Product.Prod_Name == ProdNamesCombo.Text)
						.Select(p => p.Product.Prod_Id)
						.FirstOrDefault(),
						ProdDate = ProdProddateFld.Value,
						Qty = int.Parse(ProdQtyF.Text),
						Exp = int.Parse(ProdExpiryFld.Text),
						Supplier = Db.Suppliers
						.Where(s => s.Sup_Name == TransSupCombo.Text)
						.FirstOrDefault()
					};
					TransProducts.Add(prod);
					TransProductsList.Items.Add(ProdNamesCombo.Text);
					ClearTransProdFields();
				}
				catch(Exception ex)
				{
					MessageBox.Show("Quantity and Expiry must be Numbers");
					return;
				}
			}
			else
			{
				MessageBox.Show("Some Product Field is Empty");
			}
		}

		private void ClearTransProdFields()
		{
			ProdNamesCombo.Text =
			ProdQtyF.Text =
			ProdProddateFld.Text =
			ProdExpiryFld.Text = String.Empty;
		}

		private void TransBtn_Click(object sender, EventArgs e)
		{
			if (FromStoresCombo.Text != String.Empty
				&& ToStoresCombo.Text != String.Empty)
			{
				if(FromStoresCombo.Text != ToStoresCombo.Text)
				{
					TransProdsToStore();
					ClearAllFields();
					MessageBox.Show($"Products Transferred Successfully");
				}
				else
				{
					MessageBox.Show("You Choose The Same Store!");
				}
			}
			else
			{
				MessageBox.Show("Please, Choose From and To Store");
			}
		}

		private void ClearAllFields()
		{
			TransProductsList.Items.Clear();
			FromStoresCombo.Text = 
				ToStoresCombo.Text =
				ProdQtyF.Text =
				ProdExpiryFld.Text =
				TransSupCombo.Text = String.Empty;
		}

		private void DisplayTransComboBoxData()
		{
			DisplayComboProducts();
			DisplayComboSuppliers();
			DisplayFromAndToStoresCombo();
		}

		private void DisplayFromAndToStoresCombo()
		{
			var stores = Db.Stores
				.Select(s => s.Store_Name)
				.ToList();
			foreach(var store in stores)
			{
				FromStoresCombo.Items.Add(store);
				ToStoresCombo.Items.Add(store);
			}
		}

		private void DisplayComboSuppliers()
		{
			var sups = Db.Suppliers
				.Select(s => s.Sup_Name)
				.ToList();
			foreach(var sup in sups)
			{
				TransSupCombo.Items.Add(sup);
			}
		}

		private void TransProdsToStore()
		{
			var fromStore = Db.Stores
				.Where(s => s.Store_Name == FromStoresCombo.Text)
				.FirstOrDefault();
			var toStore = Db.Stores
				.Where(s => s.Store_Name == ToStoresCombo.Text)
				.FirstOrDefault();
			foreach ( var prod in TransProducts)
			{
				var fromProd = Db.Supplied_Prod
					.Where(
								p => p.Prod_Id == prod.ProdId
							&& p.Expiry == prod.Exp
							&& DbFunctions.TruncateTime(p.Production_Date) == prod.ProdDate.Date
							&& p.SuppliePermission.Store_Id == fromStore.Store_Id
							&& p.SuppliePermission.Sup_Id == prod.Supplier.Sup_Id
							)
					.FirstOrDefault();
				if (fromProd != null)
				{
					var toStock = Db.Stocks
						.Where(s => s.Store_Id == toStore.Store_Id
									&& s.Prod_Id == prod.ProdId)
						.FirstOrDefault();
					var fromStock = Db.Stocks
						.Where(s => s.Store_Id == fromStore.Store_Id
									&& s.Prod_Id == prod.ProdId)
						.FirstOrDefault();
					if (toStock != null)
					{
						toStock.Qty += prod.Qty;
						fromStock.Qty -= prod.Qty;
						Db.SaveChanges();
						CreateSupPermForTrans(prod, toStore, fromStore);
					}
					else
					{
						fromStock.Qty -= prod.Qty;
						Stock newStock = new Stock()
						{
							Store_Id = toStore.Store_Id,
							Prod_Id = prod.ProdId,
							Qty = prod.Qty
						};
						Db.Stocks.Add(newStock);
						Db.SaveChanges();
						CreateSupPermForTrans(prod, toStore, fromStore);
					}
				}
			}
		}

		private void CreateSupPermForTrans(TransProduct prod, Store toStore, Store fromStore)
		{
			var fromSupPermProd = Db.Supplied_Prod
				.Where(s => s.SuppliePermission.Store_Id == fromStore.Store_Id
				&& s.Prod_Id == prod.ProdId
				&& s.Expiry == prod.Exp
				&& DbFunctions.TruncateTime(s.Production_Date) == prod.ProdDate.Date)
				.FirstOrDefault();
			fromSupPermProd.Qty -= prod.Qty;
			SuppliePermission newSupPerm = new SuppliePermission()
			{
				Store_Id = toStore.Store_Id,
				Sup_Id = prod.Supplier.Sup_Id,
				SupPerm_Date = DateTime.Now
			};
			Db.SuppliePermissions.Add(newSupPerm);
			Db.SaveChanges();
			AddProductToSupllied_Prod(prod);
		}

		private void AddProductToSupllied_Prod(TransProduct prod)
		{
			Supplied_Prod newSupplied_Prod = new Supplied_Prod()
			{
				Prod_Id = prod.ProdId,
				SupPerm_Id = Db.SuppliePermissions
				.Select(x => x.SupPerm_Id)
				.Max(),
				Production_Date = prod.ProdDate,
				Expiry = prod.Exp,
				Qty = prod.Qty
			};
			Db.Supplied_Prod.Add(newSupplied_Prod);
			Db.SaveChanges();
		}

		#endregion
	}
}
