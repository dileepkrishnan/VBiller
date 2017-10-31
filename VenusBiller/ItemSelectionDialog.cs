#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using VenusBiller.Entities;
using VenusBiller.Services;

#endregion

namespace VenusBiller
{
    public partial class ItemSelectionDialog : Form
    {
        private List<Item> _allItems;
        private Item _selectedItem;

        public ItemSelectionDialog()
        {
            InitializeComponent();
        }

        public Item GetSelectedItem()
        {
            return _selectedItem;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
        }

        private void ItemSelectionDialog_Load(object sender, EventArgs e)
        {
        }

        private void ItemSelectionDialog_Shown(object sender, EventArgs e)
        {
            _allItems = DataService.Item.GetAllItems();
            dgvItems.DataSource = _allItems;
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtItemName.Text))
            {
                var filteredItems =
                    _allItems.Where(
                        item => item.Name.StartsWith(txtItemName.Text, StringComparison.OrdinalIgnoreCase)).ToList();
                dgvItems.DataSource = filteredItems;
                lblMatchCount.Text = filteredItems.Count + @" matche(s) found.";
            }
            else
            {
                dgvItems.DataSource = _allItems;
                lblMatchCount.Text = string.Empty;
            }
            btnSelect.Enabled = dgvItems.Rows.Count > 0;
        }

        private void dgvParties_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SetSelectdItem();
            btnSelect.Focus(); // So that user can press enter to dismiss the dialog
        }

        // Set the highlighted item in grid as the currently selected item
        private void SetSelectdItem()
        {
            if (dgvItems.SelectedRows.Count != 0)
            {
                _selectedItem = dgvItems.SelectedRows[0].DataBoundItem as Item;
            }
        }

        private void dgvParties_SelectionChanged(object sender, EventArgs e)
        {
            SetSelectdItem();
        }

        private void dgvParties_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult = DialogResult.OK;
            Hide();
        }
    }
}