using System.Collections.Generic;

namespace VenusBiller.Reports.Entities
{
    public class PrintableBill
    {
        public string BillNumber { get; set; }
        public string Date { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerGstn { get; set; }
        public double Roundoff { get; set; }
        public double GrandTotal { get; set; }
        public string GrandTotalAmountInWords { get; set; }
        public double SumOfAmounts { get; set; }
        public double SumOfDiscounts { get; set; }
        public double SumOfTaxableAmounts { get; set; }
        public double SumOfCgstAmounts { get; set; }
        public double SumOfSgstAmounts { get; set; }
        public double SumOfCessAmounts { get; set; }
        public double SumOfTotalAmounts { get; set; }
        public List<PrintableBillItem> Items { get; set; }
        public List<TaxCategory> TaxCatogories { get; set; }
    }

    public class PrintableBillItem
    {
        public int ItemNumber { get; set; }
        public string ItemName { get; set; }
        public string HsnOrSac { get; set; }
        public int Quantity { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public double Discount { get; set; }
        public double TaxableAmount { get; set; }
        public double CgstRate { get; set; }
        public double CgstAmount { get; set; }
        public double SgstRate { get; set; }
        public double SgstAmount { get; set; }
        public double CessRate { get; set; }
        public double CessAmount { get; set; }
        public double TotalAmount { get; set; }
    }

    public class TaxCategory
    {
        public double GstRate { get; set; }
        public double CessRate { get; set; }
        public double SaleAmount { get; set; }
        public double TaxAmount { get; set; }

    }
}