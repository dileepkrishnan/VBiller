using System;
using System.Windows.Forms;
using VenusBiller.Reports;
using VenusBiller.Services;

namespace VenusBiller
{
    public partial class BillWiseReport : Form
    {
        public BillWiseReport()
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
            Dispose();
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
            return sortType;
        }

        private void btnGenerateAndView_Click(object sender, EventArgs e)
        {
            GenerateReportWithOption(false);
        }

        private void GenerateReportWithOption(bool print)
        {
            var bwBillWiseReport = new BillWiseReportCriteria
            {
                StartDate = dtpStartDate.Value,
                EndDate = dtpEndDate.Value
            };
            if (!string.IsNullOrEmpty(txtFirstBill.Text))
                bwBillWiseReport.StartingBillNumber = int.Parse(txtFirstBill.Text);
            if (!string.IsNullOrEmpty(txtLastBill.Text))
                bwBillWiseReport.EndingBillNumber = int.Parse(txtLastBill.Text);
            bwBillWiseReport.CustomerCode = txtCustomerCode.Text;
            bwBillWiseReport.PrintAfterGeneration = print;
            bwBillWiseReport.SortType = GetSelectedSortType();
            DataService.Report.GenerateReportBillWise(bwBillWiseReport);
        }

        private void btnGenerateAndPrint_Click(object sender, EventArgs e)
        {
            GenerateReportWithOption(true);
        }
    }
}