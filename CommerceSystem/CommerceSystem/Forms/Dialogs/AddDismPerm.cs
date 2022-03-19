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
	public partial class AddDismPerm : Form
	{
		public List<Dism_Prod> Products { get; set; } = new List<Dism_Prod>();
		public CommerceEntities Db { get; set; } = new CommerceEntities();

		public AddDismPerm()
		{
			InitializeComponent();
			DisplayComboBoxesData();
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

		private void AddProduct_Click(object sender, EventArgs e)
		{
			if(
				ProdNamesCombo.Text != String.Empty
				&& ProdQtyFld.Text != String.Empty
				)
			{
				Dism_Prod dism_Prod = new Dism_Prod()
				{
					Dism_Id = 0,
					Prod_Id = Db.Products
					.Where(p => p.Prod_Name == ProdNamesCombo.Text)
					.Select(p => p.Prod_Id)
					.FirstOrDefault(),
					Qty = int.Parse(ProdQtyFld.Text)
				};
				this.Products.Add(dism_Prod);
				MessageBox.Show("Product Added Succeffuly to Dismissal");
				ClearProdFields();
			}
			else
			{
				MessageBox.Show("Some Product Fields is empty");
			}
		}

		private void ClearProdFields()
		{
			ProdNamesCombo.Text =
				ProdQtyFld.Text = String.Empty;
		}

		private void SubmitDismBtn_Click(object sender, EventArgs e)
		{
			if (
					StoresNamesCombo.Text != String.Empty
				&& DismPermDateFld.Text != String.Empty
				&& CustomersNamesCombo.Text != String.Empty
				)
			{
				if (Products.Count > 0)
				{
					int storeId = Db.Stores
						.Where(s => s.Store_Name == StoresNamesCombo.Text)
						.Select(s => s.Store_Id)
						.FirstOrDefault();
					DateTime dismDate = DismPermDateFld.Value;
					int cusId = Db.Customers
						.Where(c => c.Cus_Fname + " " + c.Cus_Lname == CustomersNamesCombo.Text)
						.Select(c => c.Cus_Id)
						.FirstOrDefault();
					Dismissal newDism = new Dismissal()
					{
						Store_Id = storeId,
						Dism_date = dismDate,
						Cus_id = cusId
					};
					Db.Dismissals.Add(newDism);

					// Add Products
					int dismId = Db.Dismissals
						.Select(s => s.Dism_Id)
						.Max();
					this.Products.ToList().ForEach(p => p.Dism_Id = dismId);
					foreach (var product in Products)
					{
						var dism_prod = Db.Dism_Prod
							.Where(d => d.Prod_Id == product.Prod_Id && d.Dism_Id == product.Dism_Id)
							.FirstOrDefault();
						if (dism_prod == null)
						{
							Db.Dism_Prod.Add(product);
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
				MessageBox.Show("Some Dismissal Fields is Empty!");
			}
		}
	}
}
