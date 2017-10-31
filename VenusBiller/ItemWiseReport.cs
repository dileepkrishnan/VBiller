using System;
using System.Windows.Forms;
using VenusBiller.Reports;
using VenusBiller.Services;

namespace VenusBiller
{
    public partial class ItemWiseReport : Form
    {
        public ItemWiseReport()
        {
            InitializeComponent();
            var now = DateTime.Now;
            dtpStartDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEndDate.Value = now;
        }

        private void txtFirstBill_KeyPress(object sender, KeyPressEventArgs e)
        {
            HandleKeyPressInBillNumberTextBox(e);
        }

        private static void HandleKeyPressInBillNumberTextBox(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtLastBill_KeyPress(object sender, KeyPressEventArgs e)
        {
            HandleKeyPressInBillNumberTextBox(e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private SortType GetSelectedSortType()
        {
            var sortType = SortType.BillNumber;
            if (rdbDate.Checked)
                sortType = SortType.BillDate;
            else if (rdbAmount.Checked)
                sortType = SortType.BillAmount;
            else if (rdbTax.Checked)
                sortType = SortType.TaxAmount;
            else if (rdbItemCode.Checked)
                sortType = SortType.ItemCode;
            return sortType;
        }

        private void btnGenerateAndView_Click(object sender, EventArgs e)
        {
            GenerateReportWithOption(false);
        }

        private void GenerateReportWithOption(bool print)
        {
            var itemWiseReportCriteria = new ItemWiseReportCriteria
            {
                StartDate = dtpStartDate.Value,
                EndDate = dtpEndDate.Value
            };
            if (!string.IsNullOrEmpty(txtFirstBill.Text))
                itemWiseReportCriteria.StartingBillNumber = int.Parse(txtFirstBill.Text);
            if (!string.IsNullOrEmpty(txtLastBill.Text))
                itemWiseReportCriteria.EndingBillNumber = int.Parse(txtLastBill.Text);
            itemWiseReportCriteria.CustomerCode = txtCustomerCode.Text;
            itemWiseReportCriteria.ItemCode = txtItemCode.Text;
            itemWiseReportCriteria.PrintAfterGeneration = print;
            itemWiseReportCriteria.SortType = GetSelectedSortType();
            DataService.Report.GenerateReportItemWise(itemWiseReportCriteria);
        }

        private void btnGenerateAndPrint_Click(object sender, EventArgs e)
        {
            GenerateReportWithOption(true);
        }
    }
}