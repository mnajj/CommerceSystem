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
	public partial class SelectStores : Form
	{
		public Home PrevForm { get; set; }
		public CommerceEntities Db { get; set; } = new CommerceEntities();

		public SelectStores(Home prevForm)
		{
			InitializeComponent();
			DisplayComboBoxesData();
			this.PrevForm = prevForm;
		}

		private void DisplayComboBoxesData()
		{
			DisplayStoresNames();
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

		private void AddStoreBtn_Click(object sender, EventArgs e)
		{
			if(StoresNamesCombo.Text != String.Empty)
			{
				var sId = Db.Stores
					.Where(s => s.Store_Name == StoresNamesCombo.Text)
					.Select(s => s.Store_Id)
					.FirstOrDefault();
				PrevForm.RepStoresId.Add(sId);
				StoresList.Items.Add(StoresNamesCombo.Text);
			}
			else
			{
				MessageBox.Show("Please, Select a Store to Add");
			}
		}
	}
}
