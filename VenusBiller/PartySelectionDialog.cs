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
    public partial class PartySelectionDialog : Form
    {
        private List<Party> _allParties;
        private Party _selectedParty;

        public PartySelectionDialog()
        {
            InitializeComponent();
        }

        public Party GetSelectedParty()
        {
            return _selectedParty;
        }

        private void btnSelect_Click(object sender, System.EventArgs e)
        {

        }

        private void PartySelectionDialog_Load(object sender, System.EventArgs e)
        {
        }

        private void PartySelectionDialog_Shown(object sender, System.EventArgs e)
        {
            _allParties = DataService.Party.GetAllParties();
            dgvParties.DataSource = _allParties;
        }

        private void txtPartyName_TextChanged(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPartyName.Text))
            {
                var filterdParties =
                    _allParties.Where(
                        party => party.Name.StartsWith(txtPartyName.Text, StringComparison.OrdinalIgnoreCase)).ToList();
                dgvParties.DataSource = filterdParties;
                lblMatchCount.Text = filterdParties.Count + @" matche(s) found.";
            }
            else
            {
                dgvParties.DataSource = _allParties;
                lblMatchCount.Text = string.Empty;
            }
            btnSelect.Enabled = dgvParties.Rows.Count > 0;
        }

        private void dgvParties_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SetSelectdParty();
            btnSelect.Focus(); // So that user can press enter to dismiss the dialog
        }

        // Set the highlighted item in grid as the currently selected item
        private void SetSelectdParty()
        {
            if (dgvParties.SelectedRows.Count != 0)
            {
                _selectedParty = dgvParties.SelectedRows[0].DataBoundItem as Party;
            }
        }

        private void dgvParties_SelectionChanged(object sender, EventArgs e)
        {
            SetSelectdParty();
        }

        private void dgvParties_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult = DialogResult.OK;
            Hide();
        }
    }
}