using System;
using System.Windows.Forms;
using VenusBiller.Reports;
using VenusBiller.Services;

namespace VenusBiller
{
    public partial class SalesRegister : Form
    {
        public SalesRegister()
        {
            InitializeComponent();
            var now = DateTime.Now;
            dtpStartDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEndDate.Value = now;
        }

        private static void HandleKeyPressInBillNumberTextBox(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGenerateAndView_Click(object sender, EventArgs e)
        {
            GenerateReportWithOption(false);
        }

        private void GenerateReportWithOption(bool print)
        {
            var salesRegisterReportCriteria = new SalesRegisterReportCriteria
            {
                StartDate = dtpStartDate.Value,
                EndDate = dtpEndDate.Value,
                PrintAfterGeneration = print,
                SalesType = rdbB2B.Checked ? SalesType.B2B : rdbB2C.Checked ? SalesType.B2C : SalesType.Both
            };
            DataService.Report.GenerateSalesRegisterReport(salesRegisterReportCriteria);
        }

        private void btnGenerateAndPrint_Click(object sender, EventArgs e)
        {
            GenerateReportWithOption(true);
        }
    }
}