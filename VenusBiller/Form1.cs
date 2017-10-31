#region

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Grid;
using VenusBiller.Entities;
using VenusBiller.Reports;
using VenusBiller.Services;

#endregion

namespace VenusBiller
{
    public partial class Form1 : Form
    {
        private readonly BindingSource _bindingSource = new BindingSource();
        private Bill _currentBill = new Bill();
        private readonly BindingList<BillItem> _selectedItems = new BindingList<BillItem> {AllowNew = true};
        private Party _selectedParty;

        public Form1()
        {
            InitializeComponent();
            _bindingSource.DataSource = _selectedItems;
            dgvItems.DataSource = _bindingSource;
            dgvItems.CellButtonClicked += dgvItems_CellButtonClicked;
            dgvItems.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            _selectedItems.ListChanged += _selectedItems_ListChanged;
            SetNextBillNumber();
            dgvItems.ActivateCurrentCellBehavior = GridCellActivateAction.SelectAll;
            dgvItems.Model.CellModels.Add("ImagePushButton", new GridPushButtonImageCellModel(dgvItems.Model));
            //Set the button Type as ImagePushButton.
            dgvItems.Binder.InternalColumns["Remove"].StyleInfo.CellType = "ImagePushButton";
            AddSalesTypes();
        }

        private void AddSalesTypes()
        {
            cboSalesType.Items.Add(SalesType.B2C.EnumToString());
            cboSalesType.Items.Add(SalesType.B2B.EnumToString());
            cboSalesType.SelectedIndex = 0;
        }

        private void SetNextBillNumber()
        {
            var nextBillNumber = DataService.Bill.GetNextBillNumber();
            txtBillNumber.Text = nextBillNumber.ToString();
        }

        private void _selectedItems_ListChanged(object sender, ListChangedEventArgs e)
        {
            SetSaveButtonStatus();
            int itemNumber = 1;
            foreach (BillItem item in _selectedItems)
            {
                item.ItemNumber = itemNumber++;
            }
            UpdateAmountsOnScreen();
        }

        private void SetSaveButtonStatus()
        {
            if (_selectedItems.Count > 0 && (!string.IsNullOrEmpty(txtPartyCode.Text)))
            {
                btnSave.Enabled = true;
                btnSaveAndPrint.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
                btnSaveAndPrint.Enabled = false;
            }
        }

        private void dgvItems_CellButtonClicked(object sender,
            GridCellButtonClickedEventArgs e)
        {
            if (_selectedItems.Count != 0)
            {
                var itemNumberValue = dgvItems[e.RowIndex, 1].CellValue;
                int itemNumber;
                if (int.TryParse(itemNumberValue.ToString(), out itemNumber))
                {
                    var item = _selectedItems.FirstOrDefault(si => si.ItemNumber == itemNumber);
                    if (item != null)
                    {
                        _selectedItems.Remove(item);
                        dgvItems.Refresh();
                    }
                }
            }
        }

        private void txtPartyCode_DoubleClick(object sender, EventArgs e)
        {
            using (var psd = new PartySelectionDialog())
            {
                if (psd.ShowDialog(this) == DialogResult.OK)
                {
                    Party party = psd.GetSelectedParty();
                    SetPartyDetails(party);
                    _selectedParty = party;
                    SetSaveButtonStatus();
                }
            }
        }

        private void SetPartyDetails(Party party)
        {
            if (party != null)
            {
                txtPartyCode.Text = party.Code;
                txtPartyName.Text = party.Name;
                txtPartyAddress.Text = party.Address;
                _selectedParty = party;
            }
            else
            {
                txtPartyCode.Text = null;
                txtPartyName.Text = null;
                txtPartyAddress.Text = null;
            }
            dgvItems.Focus();
        }

        // Verify that party code is correct and update party details
        private void txtPartyCode_Leave(object sender, EventArgs e)
        {
            HandleEnterKeyPressEvent();
        }

        private void HandleEnterKeyPressEvent()
        {
            if (!string.IsNullOrEmpty(txtPartyCode.Text))
            {
                Party party = DataService.Party.GetPartyByCode(txtPartyCode.Text);
                SetPartyDetails(party);
            }
            else
            {
                SetPartyDetails(null);
            }
            SetSaveButtonStatus();
        }

        private void ShowItemSelectionDialog(GridCellButton button = null)
        {
            using (var isd = new ItemSelectionDialog())
            {
                if (isd.ShowDialog(this) == DialogResult.OK)
                {
                    var billItem = new BillItem(isd.GetSelectedItem());
                    _bindingSource.Add(billItem);
                    if (button != null)
                    {
                        button.Text = billItem.Code;
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PrepareBillToSave();
            try
            {
                DataService.Bill.SaveBill(_currentBill);
                ClearCurrentBill();
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Error while saving bill !" + Environment.NewLine + exception.Message +
                    exception.StackTrace, @"Save Bill",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrepareBillToSave()
        {
            _currentBill.Items.AddRange(_selectedItems.ToList());
            _currentBill.BillDate = dateTimePicker1.Value;
            _currentBill.BillNumnber = txtBillNumber.Text;
            _currentBill.PartyCode = txtPartyCode.Text;
            _currentBill.SalesType = SalesTypeExtension.StringToEnum(cboSalesType.Text);
            _currentBill.SpecialDiscountPercent = double.Parse(txtSpecialDiscountPercentage.Text);
            _currentBill.SpecialDiscountAmount = double.Parse(txtSpecialDiscountAmount.Text);
            _currentBill.PartyAddress = txtPartyAddress.Text;
            _currentBill.PartyName = txtPartyName.Text;
            _currentBill.PartyGstIn = _selectedParty.GstIn;
        }

        private void ClearCurrentBill()
        {
            _currentBill = new Bill();
            _selectedItems.Clear();
            txtBillNumber.Text = DataService.Bill.GetNextBillNumber().ToString();
            dgvItems.Refresh();
            _selectedParty = null;

            txtPartyCode.Text = string.Empty;
            txtPartyName.Text = string.Empty;
            txtPartyAddress.Text = string.Empty;

            txtTotal.Text = @"0.0";
            txtRoundedTotal.Text = @"0";
            txtDiscount.Text = @"0.0";
            txtSpecialDiscountPercentage.Text = @"0.0";
            txtSpecialDiscountAmount.Text = @"0.0";
            txtSubTotal.Text = @"0.0";
            txtGrandTotal.Text = @"0.0";
            txtGstAmount.Text = @"0.0";
            txtCessAmount.Text = @"0.0";
            txtRoundOff.Text = @"0.0";
            txtPresentBalance.Text = @"0.0";
        }

        private void dgvItems_CurrentCellControlDoubleClick(object sender, ControlEventArgs e)
        {
            int itemCodeColumnIndex = dgvItems.NameToColIndex("Code");
            if (dgvItems.CurrentCell.ColIndex == itemCodeColumnIndex)
                // User double-clicked on a cell in ItemCode column.
            {
                using (var isd = new ItemSelectionDialog())
                {
                    if (isd.ShowDialog(this) == DialogResult.OK)
                    {
                        var billItem = new BillItem(isd.GetSelectedItem());
                        _selectedItems.Add(billItem);
                        // ResetDataBinding(); // Hack to make the item code appear properly after a new item is added
                        dgvItems.Refresh();
                        UpdateAmountsOnScreen();
                    }
                }
            }
        }

        private void UpdateAmountsOnScreen()
        {
            double total = _selectedItems.Sum(item => item.Rate*item.Quantity);
            double disCount = _selectedItems.Sum(item => item.Quantity*item.Rate*item.DiscountPercent/100);
            double specialDiscountPercentage =
                double.Parse(string.IsNullOrEmpty(txtSpecialDiscountPercentage.Text)
                    ? "0.0"
                    : txtSpecialDiscountPercentage.Text);
            double specialDiscountAmount = (total - disCount)*specialDiscountPercentage/100;
            double subTotal = total - disCount - specialDiscountAmount;
            double gstAmount = 0, cessAmount = 0;
            foreach (BillItem item in _selectedItems)
            {
                double priceAfterDiscount = item.Rate - item.Rate*item.DiscountPercent/100;
                double priceAfterSpecialDiscount = priceAfterDiscount - priceAfterDiscount*specialDiscountPercentage/100;
                double gst = priceAfterSpecialDiscount*item.GstPercent/100;
                double cess = priceAfterSpecialDiscount*item.CessPercent/100;
                gstAmount += gst*item.Quantity;
                cessAmount += cess*item.Quantity;
                item.SpecialDiscountAmount = item.Quantity*priceAfterDiscount*specialDiscountPercentage/100;
                item.NetAmount = priceAfterSpecialDiscount + gst*item.Quantity + cess*item.Quantity;
            }
            double grandTotal = subTotal + gstAmount + cessAmount;
            double roundoff = Math.Round(grandTotal, 0) - grandTotal;
            double finalRoundedAmount = grandTotal + roundoff;
            txtTotal.Text = Math.Round(total, 2).ToString();
            txtDiscount.Text = Math.Round(disCount, 2).ToString();
            txtSpecialDiscountAmount.Text = Math.Round(specialDiscountAmount, 2).ToString();
            txtSubTotal.Text = Math.Round(subTotal, 2).ToString();
            txtGstAmount.Text = Math.Round(gstAmount, 2).ToString();
            txtCessAmount.Text = Math.Round(cessAmount, 2).ToString();
            txtGrandTotal.Text = Math.Round(grandTotal, 2).ToString();
            txtRoundOff.Text = Math.Round(roundoff, 2).ToString();
            txtRoundedTotal.Text = Math.Round(finalRoundedAmount, 2).ToString();
            txtPresentBalance.Text = Math.Round(finalRoundedAmount, 2).ToString();
            _currentBill.TaxAmount = Math.Round(gstAmount, 2);
            _currentBill.NetAmount = Math.Round(grandTotal, 2);
            _currentBill.TotalAmount1 = Math.Round(total, 2);
            _currentBill.TotalAmount2 = Math.Round(total - disCount, 2);
            _currentBill.TotalAmount3 = Math.Round(subTotal, 2);
            _currentBill.TotalAmount4 = Math.Round(grandTotal, 2);
            _currentBill.DsicountAmount = Math.Round(disCount, 2);
            _currentBill.FinalBillAmount = Math.Round(finalRoundedAmount, 2);
            _currentBill.RoundOffAmount = Math.Round(roundoff, 2);
            _currentBill.Profit =
                Math.Round(finalRoundedAmount - _selectedItems.Sum(item => item.LandingCost*item.Quantity), 2);
        }

        private void ResetDataBinding()
        {
            dgvItems.DataSource = null;
            dgvItems.Model.ClearCells(GridRangeInfo.Table(), true); // Clear the contents of the entire grid.
            int itemNumber = 1;
            foreach (BillItem item in _selectedItems)
            {
                item.ItemNumber = itemNumber++;
            }
            dgvItems.DataSource = _bindingSource;
        }

        private void dgvItems_PrepareViewStyleInfo(object sender, GridPrepareViewStyleInfoEventArgs e)
        {
            if (e.ColIndex == 0 && e.RowIndex > 0)
            {
                e.Style.Text = e.RowIndex.ToString();

                e.Style.Font.Bold = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvItems.BaseStylesMap["Row Header"].StyleInfo.CellType = "Header";
        }

        private void btnSaveAndPrint_Click(object sender, EventArgs e)
        {
            PrepareBillToSave();
            try
            {
                DataService.Bill.SaveAndPrintBill(_currentBill);
                ClearCurrentBill();
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Error while saving bill !" + Environment.NewLine + exception.Message, @"Save Bill",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtSpecialDiscountPercentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtPartyCode_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txtPartyCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                HandleEnterKeyPressEvent();
            }
        }

        private void dgvItems_CurrentCellChanged(object sender, EventArgs e)
        {
            int itemCodeColumnIndex = dgvItems.NameToColIndex("Quantity");
            if (dgvItems.CurrentCell.ColIndex == itemCodeColumnIndex)
            {
                UpdateAmountsOnScreen();
            }

        }

        private void dgvItems_CurrentCellEditingComplete(object sender, EventArgs e)
        {
            int itemCodeColumnIndex = dgvItems.NameToColIndex("Quantity");
            if (dgvItems.CurrentCell.ColIndex == itemCodeColumnIndex)
            {
                UpdateAmountsOnScreen();
            }
        }

        private void dgvItems_CurrentCellKeyPress(object sender, KeyPressEventArgs e)
        {
            int itemCodeColumnIndex = dgvItems.NameToColIndex("Quantity");
            if (dgvItems.CurrentCell.ColIndex == itemCodeColumnIndex)
            {
                itemCodeColumnIndex = dgvItems.NameToColIndex("Code");
                if (dgvItems[dgvItems.CurrentCell.RowIndex, itemCodeColumnIndex].CellValue == null)
                {
                    e.Handled = true;
                }
            }

        }

        private void dgvItems_CurrentCellKeyDown(object sender, KeyEventArgs e)
        {
            int itemCodeColumnIndex = dgvItems.NameToColIndex("Quantity");
            if (dgvItems.CurrentCell.ColIndex == itemCodeColumnIndex)
            {
                itemCodeColumnIndex = dgvItems.NameToColIndex("Code");
                if (dgvItems[dgvItems.CurrentCell.RowIndex, itemCodeColumnIndex].CellValue == null)
                {
                    e.Handled = true;
                }
            }
        }

        private void dgvItems_CurrentCellStartEditing(object sender, CancelEventArgs e)
        {
            var itemCodeColumnIndex = dgvItems.NameToColIndex("Code");
            var quamtityColumnIndex = dgvItems.NameToColIndex("Quantity");
            var discountPercentColumnIndex = dgvItems.NameToColIndex("DiscountPercent");

            if (dgvItems.CurrentCell.ColIndex == discountPercentColumnIndex ||
                dgvItems.CurrentCell.ColIndex == quamtityColumnIndex)
            {
                if (dgvItems[dgvItems.CurrentCell.RowIndex, itemCodeColumnIndex].CellValue == null ||
                    string.IsNullOrEmpty(
                        dgvItems[dgvItems.CurrentCell.RowIndex, itemCodeColumnIndex].CellValue.ToString()))
                {
                    e.Cancel = true;
                }
            }
        }

        private void txtSpecialDiscountPercentage_TextChanged(object sender, EventArgs e)
        {
            if (_selectedItems.Count > 0)
            {

                var specialDiscountPercentage = GetSpecialDiscountPercentage();
                var finalPriceAfterDiscount = 0.0;
                foreach (BillItem item in _selectedItems)
                {
                    double priceAfterDiscount = (item.Rate - item.Rate*item.DiscountPercent/100)*item.Quantity;
                    finalPriceAfterDiscount += priceAfterDiscount;
                }
                txtSpecialDiscountAmount.Text =
                    Math.Round(finalPriceAfterDiscount*specialDiscountPercentage/100, 2).ToString();
                UpdateAmountsOnScreen();
            }
        }

        private double GetSpecialDiscountPercentage()
        {
            double specialDiscountPercentage;
            if (double.TryParse(txtSpecialDiscountPercentage.Text, out specialDiscountPercentage))
            {
                return specialDiscountPercentage;
            }
            return 0.0;
        }
    }

    public class GridPrintToFitDocument : GridPrintDocument
    {
        private GridControlBase _grid;

        public GridPrintToFitDocument(GridControlBase grid, bool printPreview)
            : base(grid, printPreview)
        {
            _grid = grid;
        }

        //protected override void OnPrintPage(System.Drawing.Printing.PrintPageEventArgs ev)
        //{

        //    ev.HasMorePages = false;

        //    //draw a fullsize bitmap of the grid...
        //    int gridHeight = _grid.Model.RowHeights.GetTotal(0, _grid.Model.RowCount);
        //    int gridWidth = _grid.Model.ColWidths.GetTotal(0, _grid.Model.ColCount);

        //    Bitmap gridBM = new Bitmap(gridWidth, gridHeight);

        //    Graphics g = Graphics.FromImage(gridBM);

        //    Rectangle saveGridRect = this._grid.GridBounds;
        //    this._grid.GridBounds = new Rectangle(0, 0, gridWidth, gridHeight);
        //    this._grid.DrawGrid(g);
        //    this._grid.GridBounds = saveGridRect;

        //    g.Dispose();

        //    Rectangle destRect = ev.MarginBounds;


        //    //use the printer graphics
        //    g = ev.Graphics;

        //    //draw grid bitmap into the rect on the print page
        //    System.Drawing.GraphicsUnit gu = System.Drawing.GraphicsUnit.Point;
        //    RectangleF srcRect = gridBM.GetBounds(ref gu);


        //    //adjust destRect to make sizing proportional
        //    // you can comment this out this block if you don't want proportional fit
        //    float srcRatio = srcRect.Width / srcRect.Height;
        //    float tarRatio = (float)destRect.Width / destRect.Height;
        //    if (tarRatio < srcRatio)
        //    {
        //        destRect.Height = (int)(destRect.Width / srcRatio);
        //    }
        //    else
        //    {
        //        destRect.Width = (int)(destRect.Height * srcRatio);
        //    }
        //    //////////////endof proportional fit//////////////////////////

        //    g.DrawImage(gridBM, destRect, srcRect, gu);

        //}
    }
}