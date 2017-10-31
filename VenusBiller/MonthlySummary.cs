using System;
using System.Windows.Forms;
using VenusBiller.Services;

namespace VenusBiller
{
    public partial class MonthlySummary : Form
    {
        public MonthlySummary()
        {
            InitializeComponent();
            DateTime now = DateTime.Now;
            dtpStartDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEndDate.Value = now;
        }

        private void btnGenerateAndView_Click(object sender, EventArgs e)
        {
            DataService.Report.GenerateMonthlySummary(dtpStartDate.Value, dtpEndDate.Value, false);
        }

        private void btnGenerateAndPrint_Click(object sender, EventArgs e)
        {
            DataService.Report.GenerateMonthlySummary(dtpStartDate.Value, dtpEndDate.Value, true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}