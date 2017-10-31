using System;
using System.Windows.Forms;

namespace VenusBiller
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnNewBill_Click(object sender, EventArgs e)
        {
            var newBillForm = new Form1();
            newBillForm.ShowDialog(this);
        }

        private void btnBillWiseReport_Click(object sender, EventArgs e)
        {
            var billWiseReport = new BillWiseReport();
            billWiseReport.ShowDialog(this);
        }

        private void btnItemWiseReport_Click(object sender, EventArgs e)
        {
            var itemWise = new ItemWiseReport();
            itemWise.ShowDialog(this);
        }

        private void btnSalesRegister_Click(object sender, EventArgs e)
        {
            var salesRegister = new SalesRegister();
            salesRegister.Show(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var modifyBill = new ModifyBill();
            modifyBill.Show(this);
        }

        private void btnTaxCategoryWiseReport_Click(object sender, EventArgs e)
        {
            var monthlySummary = new MonthlySummary();
            monthlySummary.Show(this);
        }
    }
}